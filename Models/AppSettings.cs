using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LemonLab.Models
{
    /// <summary>
    /// Configurações do aplicativo
    /// </summary>
    public class AppSettings : INotifyPropertyChanged
    {
        private string _mangaDirectory = "";
        private bool _isDarkMode = false;
        private string _language = "pt-BR";
        private bool _autoScanOnStartup = true;
        private bool _showSplashScreen = true;
        private int _itemsPerPage = 20;

        public string MangaDirectory
        {
            get => _mangaDirectory;
            set { _mangaDirectory = value; OnPropertyChanged(); }
        }

        public bool IsDarkMode
        {
            get => _isDarkMode;
            set { _isDarkMode = value; OnPropertyChanged(); }
        }

        public string Language
        {
            get => _language;
            set { _language = value; OnPropertyChanged(); }
        }

        public bool AutoScanOnStartup
        {
            get => _autoScanOnStartup;
            set { _autoScanOnStartup = value; OnPropertyChanged(); }
        }

        public bool ShowSplashScreen
        {
            get => _showSplashScreen;
            set { _showSplashScreen = value; OnPropertyChanged(); }
        }

        public int ItemsPerPage
        {
            get => _itemsPerPage;
            set { _itemsPerPage = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
