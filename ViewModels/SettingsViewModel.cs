using System;
using System.Windows.Input;
using LemonLab.Models;
using LemonLab.Services;

namespace LemonLab.ViewModels
{
    /// <summary>
    /// ViewModel para a tela de Configurações
    /// </summary>
    public class SettingsViewModel : ViewModelBase
    {
        private readonly ConfigService _configService;
        private readonly DatabaseService _database;
        private AppSettings _settings;
        private string _statusMessage = "";

        public AppSettings Settings
        {
            get => _settings;
            set => SetProperty(ref _settings, value);
        }

        public string StatusMessage
        {
            get => _statusMessage;
            set => SetProperty(ref _statusMessage, value);
        }

        public ICommand SaveSettingsCommand { get; }
        public ICommand ResetSettingsCommand { get; }
        public ICommand ResetDatabaseCommand { get; }
        public ICommand ExportDataCommand { get; }
        public ICommand ImportDataCommand { get; }
        public ICommand SelectDirectoryCommand { get; }
        public ICommand ToggleThemeCommand { get; }

        public event EventHandler<bool>? ThemeChanged;

        public SettingsViewModel(ConfigService configService, DatabaseService database)
        {
            _configService = configService;
            _database = database;
            _settings = _configService.LoadSettings();

            SaveSettingsCommand = new RelayCommand(SaveSettings);
            ResetSettingsCommand = new RelayCommand(ResetSettings);
            ResetDatabaseCommand = new RelayCommand(ResetDatabase);
            ExportDataCommand = new RelayCommand(ExportData);
            ImportDataCommand = new RelayCommand<string>(ImportData);
            SelectDirectoryCommand = new RelayCommand(SelectDirectory);
            ToggleThemeCommand = new RelayCommand(ToggleTheme);
        }

        private void SaveSettings()
        {
            try
            {
                _configService.SaveSettings(Settings);
                StatusMessage = "Configurações salvas com sucesso!";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Erro ao salvar: {ex.Message}";
            }
        }

        private void ResetSettings()
        {
            _configService.ResetSettings();
            Settings = _configService.LoadSettings();
            StatusMessage = "Configurações resetadas!";
        }

        private void ResetDatabase()
        {
            try
            {
                _database.ResetDatabase();
                StatusMessage = "Banco de dados resetado! Todos os mangás foram removidos.";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Erro ao resetar: {ex.Message}";
            }
        }

        private void ExportData()
        {
            try
            {
                var exportPath = _configService.ExportData();
                StatusMessage = $"Dados exportados para: {exportPath}";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Erro ao exportar: {ex.Message}";
            }
        }

        private void ImportData(string? filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                return;

            try
            {
                var success = _configService.ImportData(filePath);
                StatusMessage = success ? "Dados importados com sucesso!" : "Erro ao importar dados.";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Erro ao importar: {ex.Message}";
            }
        }

        private void SelectDirectory()
        {
            // Será implementado na View com dialog nativo
            StatusMessage = "Use o botão 'Procurar' para selecionar o diretório.";
        }

        private void ToggleTheme()
        {
            Settings.IsDarkMode = !Settings.IsDarkMode;
            _configService.SaveSettings(Settings);
            ThemeChanged?.Invoke(this, Settings.IsDarkMode);
            StatusMessage = Settings.IsDarkMode ? "Tema escuro ativado" : "Tema claro ativado";
        }
    }
}
