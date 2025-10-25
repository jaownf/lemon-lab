using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using LemonLab.Services;
using LemonLab.ViewModels;

namespace LemonLab
{
    /// <summary>
    /// ViewModel principal da aplicação
    /// </summary>
    public class MainViewModel : INotifyPropertyChanged
    {
        private ViewModelBase? _currentView;
        private string _currentViewName = "Biblioteca";

        public DatabaseService Database { get; }
        public ConfigService Config { get; }
        public MangaScannerService Scanner { get; }

        public LibraryViewModel LibraryViewModel { get; }
        public ProfileViewModel ProfileViewModel { get; }
        public SettingsViewModel SettingsViewModel { get; }

        public ICommand NavigateToLibraryCommand { get; }
        public ICommand NavigateToProfileCommand { get; }
        public ICommand NavigateToSettingsCommand { get; }

        public ViewModelBase? CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public string CurrentViewName
        {
            get => _currentViewName;
            set
            {
                _currentViewName = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            // Inicializar serviços
            Database = new DatabaseService();
            Config = new ConfigService();
            Scanner = new MangaScannerService(Database);

            // Inicializar ViewModels
            LibraryViewModel = new LibraryViewModel(Database, Scanner);
            ProfileViewModel = new ProfileViewModel(Database);
            SettingsViewModel = new SettingsViewModel(Config, Database);

            // Inicializar comandos
            NavigateToLibraryCommand = new RelayCommand(() => NavigateTo("Biblioteca"));
            NavigateToProfileCommand = new RelayCommand(() => NavigateTo("Perfil"));
            NavigateToSettingsCommand = new RelayCommand(() => NavigateTo("Configurações"));

            // Definir view inicial
            CurrentView = LibraryViewModel;
            CurrentViewName = "Biblioteca";
        }

        public void NavigateTo(string viewName)
        {
            CurrentViewName = viewName;
            CurrentView = viewName switch
            {
                "Biblioteca" => LibraryViewModel,
                "Perfil" => ProfileViewModel,
                "Configurações" => SettingsViewModel,
                _ => LibraryViewModel
            };
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
