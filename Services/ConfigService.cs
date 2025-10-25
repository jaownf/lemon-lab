using System;
using System.IO;
using System.Text.Json;
using LemonLab.Models;

namespace LemonLab.Services
{
    /// <summary>
    /// Serviço para gerenciar configurações em JSON
    /// </summary>
    public class ConfigService
    {
        private readonly string _configPath;
        private AppSettings? _settings;

        public ConfigService()
        {
            var dataFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            Directory.CreateDirectory(dataFolder);
            _configPath = Path.Combine(dataFolder, "config.json");
        }

        public AppSettings LoadSettings()
        {
            if (_settings != null)
                return _settings;

            if (File.Exists(_configPath))
            {
                try
                {
                    var json = File.ReadAllText(_configPath);
                    _settings = JsonSerializer.Deserialize<AppSettings>(json) ?? new AppSettings();
                }
                catch
                {
                    _settings = new AppSettings();
                }
            }
            else
            {
                _settings = new AppSettings();
                SaveSettings(_settings);
            }

            return _settings;
        }

        public void SaveSettings(AppSettings settings)
        {
            _settings = settings;
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            var json = JsonSerializer.Serialize(settings, options);
            File.WriteAllText(_configPath, json);
        }

        public void ResetSettings()
        {
            _settings = new AppSettings();
            SaveSettings(_settings);
        }

        public string ExportData()
        {
            var exportFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "LemonLab_Export");
            Directory.CreateDirectory(exportFolder);

            var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            var exportPath = Path.Combine(exportFolder, $"lemonlab_backup_{timestamp}.json");

            // Copy database
            var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "lemonlab.db");
            if (File.Exists(dbPath))
            {
                var dbExportPath = Path.Combine(exportFolder, $"lemonlab_backup_{timestamp}.db");
                File.Copy(dbPath, dbExportPath, true);
            }

            // Export settings
            var settings = LoadSettings();
            var json = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(exportPath, json);

            return exportFolder;
        }

        public bool ImportData(string filePath)
        {
            try
            {
                if (filePath.EndsWith(".json"))
                {
                    var json = File.ReadAllText(filePath);
                    var settings = JsonSerializer.Deserialize<AppSettings>(json);
                    if (settings != null)
                    {
                        SaveSettings(settings);
                        return true;
                    }
                }
                else if (filePath.EndsWith(".db"))
                {
                    var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "lemonlab.db");
                    File.Copy(filePath, dbPath, true);
                    return true;
                }
            }
            catch
            {
                return false;
            }

            return false;
        }
    }
}
