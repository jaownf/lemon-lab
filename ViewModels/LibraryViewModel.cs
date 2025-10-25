using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using LemonLab.Models;
using LemonLab.Services;

namespace LemonLab.ViewModels
{
    /// <summary>
    /// ViewModel para a tela de Biblioteca
    /// </summary>
    public class LibraryViewModel : ViewModelBase
    {
        private readonly DatabaseService _database;
        private readonly MangaScannerService _scanner;
        private string _searchText = "";
        private Manga? _selectedManga;
        private ReadingStatus? _filterStatus;
        private bool _isScanning;
        private string _scanProgress = "";

        public ObservableCollection<Manga> Mangas { get; }
        public ObservableCollection<Manga> FilteredMangas { get; }

        public string SearchText
        {
            get => _searchText;
            set
            {
                if (SetProperty(ref _searchText, value))
                    ApplyFilters();
            }
        }

        public Manga? SelectedManga
        {
            get => _selectedManga;
            set => SetProperty(ref _selectedManga, value);
        }

        public ReadingStatus? FilterStatus
        {
            get => _filterStatus;
            set
            {
                if (SetProperty(ref _filterStatus, value))
                    ApplyFilters();
            }
        }

        public bool IsScanning
        {
            get => _isScanning;
            set => SetProperty(ref _isScanning, value);
        }

        public string ScanProgress
        {
            get => _scanProgress;
            set => SetProperty(ref _scanProgress, value);
        }

        public ICommand RefreshCommand { get; }
        public ICommand ScanDirectoryCommand { get; }
        public ICommand UpdateMangaCommand { get; }
        public ICommand DeleteMangaCommand { get; }
        public ICommand ClearFiltersCommand { get; }

        public LibraryViewModel(DatabaseService database, MangaScannerService scanner)
        {
            _database = database;
            _scanner = scanner;
            
            Mangas = new ObservableCollection<Manga>();
            FilteredMangas = new ObservableCollection<Manga>();

            RefreshCommand = new RelayCommand(LoadMangas);
            ScanDirectoryCommand = new RelayCommand<string>(async (dir) => await ScanDirectoryAsync(dir));
            UpdateMangaCommand = new RelayCommand<Manga>(UpdateManga);
            DeleteMangaCommand = new RelayCommand<Manga>(DeleteManga);
            ClearFiltersCommand = new RelayCommand(ClearFilters);

            _scanner.ScanProgress += OnScanProgress;

            LoadMangas();
        }

        private void LoadMangas()
        {
            Mangas.Clear();
            var mangas = _database.GetAllMangas();
            foreach (var manga in mangas)
            {
                Mangas.Add(manga);
            }
            ApplyFilters();
        }

        private async Task ScanDirectoryAsync(string? directory)
        {
            if (string.IsNullOrEmpty(directory))
                return;

            IsScanning = true;
            ScanProgress = "Iniciando scan...";

            try
            {
                var newMangas = await _scanner.ScanDirectoryAsync(directory);
                LoadMangas();
                ScanProgress = $"Scan completo! {newMangas.Count} novos mangás adicionados.";
            }
            catch (Exception ex)
            {
                ScanProgress = $"Erro ao escanear: {ex.Message}";
            }
            finally
            {
                IsScanning = false;
            }
        }

        private void OnScanProgress(object? sender, ScanProgressEventArgs e)
        {
            ScanProgress = $"Processando: {e.CurrentFile} ({e.ProcessedFiles}/{e.TotalFiles})";
        }

        private void UpdateManga(Manga? manga)
        {
            if (manga != null)
            {
                _database.UpdateManga(manga);
                LoadMangas();
            }
        }

        private void DeleteManga(Manga? manga)
        {
            if (manga != null)
            {
                _database.DeleteManga(manga.Id);
                Mangas.Remove(manga);
                ApplyFilters();
            }
        }

        private void ApplyFilters()
        {
            FilteredMangas.Clear();

            var filtered = Mangas.AsEnumerable();

            // Filtro de busca
            if (!string.IsNullOrWhiteSpace(SearchText))
            {
                filtered = filtered.Where(m =>
                    m.Title.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                    m.Author.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                    m.Genre.Contains(SearchText, StringComparison.OrdinalIgnoreCase));
            }

            // Filtro de status
            if (FilterStatus.HasValue)
            {
                filtered = filtered.Where(m => m.Status == FilterStatus.Value);
            }

            foreach (var manga in filtered)
            {
                FilteredMangas.Add(manga);
            }
        }

        private void ClearFilters()
        {
            SearchText = "";
            FilterStatus = null;
        }
    }
}
