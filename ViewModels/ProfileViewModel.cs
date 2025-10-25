using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using LemonLab.Models;
using LemonLab.Services;

namespace LemonLab.ViewModels
{
    /// <summary>
    /// ViewModel para a tela de Perfil
    /// </summary>
    public class ProfileViewModel : ViewModelBase
    {
        private readonly DatabaseService _database;
        private UserProfile _profile;
        private bool _isEditingUsername;
        private string _tempUsername = "";

        public UserProfile Profile
        {
            get => _profile;
            set => SetProperty(ref _profile, value);
        }

        public bool IsEditingUsername
        {
            get => _isEditingUsername;
            set => SetProperty(ref _isEditingUsername, value);
        }

        public string TempUsername
        {
            get => _tempUsername;
            set => SetProperty(ref _tempUsername, value);
        }

        public ObservableCollection<Manga> TopMangas { get; }

        public ICommand EditUsernameCommand { get; }
        public ICommand SaveUsernameCommand { get; }
        public ICommand CancelEditCommand { get; }
        public ICommand RefreshStatsCommand { get; }

        public ProfileViewModel(DatabaseService database)
        {
            _database = database;
            _profile = new UserProfile();
            TopMangas = new ObservableCollection<Manga>();

            EditUsernameCommand = new RelayCommand(StartEditUsername);
            SaveUsernameCommand = new RelayCommand(SaveUsername);
            CancelEditCommand = new RelayCommand(CancelEdit);
            RefreshStatsCommand = new RelayCommand(LoadProfile);

            LoadProfile();
        }

        private void LoadProfile()
        {
            Profile = _database.GetUserProfile();
            UpdateStatistics();
            LoadTopMangas();
        }

        private void UpdateStatistics()
        {
            var stats = _database.GetMangaCountByStatus();
            
            Profile.TotalMangas = stats.Values.Sum();
            Profile.MangasRead = stats.ContainsKey(ReadingStatus.Completed) ? stats[ReadingStatus.Completed] : 0;
            Profile.MangasReading = stats.ContainsKey(ReadingStatus.Reading) ? stats[ReadingStatus.Reading] : 0;
            Profile.MangasOnHold = stats.ContainsKey(ReadingStatus.OnHold) ? stats[ReadingStatus.OnHold] : 0;
            Profile.MangasDropped = stats.ContainsKey(ReadingStatus.Dropped) ? stats[ReadingStatus.Dropped] : 0;
            Profile.MangasPlanToRead = stats.ContainsKey(ReadingStatus.PlanToRead) ? stats[ReadingStatus.PlanToRead] : 0;
            Profile.AverageRating = _database.GetAverageRating();
        }

        private void LoadTopMangas()
        {
            TopMangas.Clear();
            var topMangas = _database.GetTopRatedMangas(5);
            foreach (var manga in topMangas)
            {
                TopMangas.Add(manga);
            }
        }

        private void StartEditUsername()
        {
            TempUsername = Profile.Username;
            IsEditingUsername = true;
        }

        private void SaveUsername()
        {
            if (!string.IsNullOrWhiteSpace(TempUsername))
            {
                Profile.Username = TempUsername;
                _database.UpdateUserProfile(Profile);
                IsEditingUsername = false;
            }
        }

        private void CancelEdit()
        {
            TempUsername = "";
            IsEditingUsername = false;
        }
    }
}
