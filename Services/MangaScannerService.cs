using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LemonLab.Models;

namespace LemonLab.Services
{
    /// <summary>
    /// Serviço para escanear e indexar mangás
    /// </summary>
    public class MangaScannerService
    {
        private readonly DatabaseService _database;
        private readonly string[] _supportedFormats = { ".cbz", ".cbr", ".zip", ".pdf", ".rar", ".7z" };

        public event EventHandler<ScanProgressEventArgs>? ScanProgress;

        public MangaScannerService(DatabaseService database)
        {
            _database = database;
        }

        public async Task<List<Manga>> ScanDirectoryAsync(string directory)
        {
            var newMangas = new List<Manga>();

            if (!Directory.Exists(directory))
                return newMangas;

            var files = Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories)
                .Where(f => _supportedFormats.Contains(Path.GetExtension(f).ToLower()))
                .ToList();

            var totalFiles = files.Count;
            var processedFiles = 0;

            foreach (var file in files)
            {
                processedFiles++;
                OnScanProgress(new ScanProgressEventArgs
                {
                    CurrentFile = Path.GetFileName(file),
                    ProcessedFiles = processedFiles,
                    TotalFiles = totalFiles
                });

                if (!_database.MangaExists(file))
                {
                    var manga = await Task.Run(() => CreateMangaFromFile(file));
                    if (manga != null)
                    {
                        _database.AddManga(manga);
                        newMangas.Add(manga);
                    }
                }

                await Task.Delay(10); // Pequeno delay para não travar a UI
            }

            return newMangas;
        }

        private Manga? CreateMangaFromFile(string filePath)
        {
            try
            {
                var fileInfo = new FileInfo(filePath);
                var fileName = Path.GetFileNameWithoutExtension(filePath);

                // Tentar extrair informações do nome do arquivo
                var (title, author) = ParseFileName(fileName);

                var manga = new Manga
                {
                    Title = title,
                    Author = author,
                    FilePath = filePath,
                    FileFormat = fileInfo.Extension.TrimStart('.').ToUpper(),
                    FileSize = fileInfo.Length,
                    DateAdded = DateTime.Now,
                    Status = ReadingStatus.PlanToRead,
                    Genre = "Desconhecido"
                };

                return manga;
            }
            catch
            {
                return null;
            }
        }

        private (string title, string author) ParseFileName(string fileName)
        {
            // Tenta extrair título e autor do nome do arquivo
            // Formatos comuns: "Title - Author", "Title by Author", "Title (Author)"
            
            var title = fileName;
            var author = "Desconhecido";

            if (fileName.Contains(" - "))
            {
                var parts = fileName.Split(new[] { " - " }, 2, StringSplitOptions.None);
                title = parts[0].Trim();
                if (parts.Length > 1)
                    author = parts[1].Trim();
            }
            else if (fileName.Contains(" by "))
            {
                var parts = fileName.Split(new[] { " by " }, 2, StringSplitOptions.RemoveEmptyEntries);
                title = parts[0].Trim();
                if (parts.Length > 1)
                    author = parts[1].Trim();
            }
            else if (fileName.Contains("(") && fileName.Contains(")"))
            {
                var startIndex = fileName.IndexOf('(');
                var endIndex = fileName.IndexOf(')');
                if (startIndex < endIndex)
                {
                    title = fileName.Substring(0, startIndex).Trim();
                    author = fileName.Substring(startIndex + 1, endIndex - startIndex - 1).Trim();
                }
            }

            return (title, author);
        }

        public async Task<bool> RunPythonScannerAsync(string directory)
        {
            try
            {
                var scriptPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Scripts", "manga_scanner.py");
                
                if (!File.Exists(scriptPath))
                    return false;

                var startInfo = new ProcessStartInfo
                {
                    FileName = "python",
                    Arguments = $"\"{scriptPath}\" \"{directory}\"",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using var process = Process.Start(startInfo);
                if (process != null)
                {
                    await process.WaitForExitAsync();
                    return process.ExitCode == 0;
                }
            }
            catch
            {
                // Python não está instalado ou script não existe
            }

            return false;
        }

        protected virtual void OnScanProgress(ScanProgressEventArgs e)
        {
            ScanProgress?.Invoke(this, e);
        }
    }

    public class ScanProgressEventArgs : EventArgs
    {
        public string CurrentFile { get; set; } = "";
        public int ProcessedFiles { get; set; }
        public int TotalFiles { get; set; }
        public double ProgressPercentage => TotalFiles > 0 ? (double)ProcessedFiles / TotalFiles * 100 : 0;
    }
}
