using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LemonLab.Models
{
    /// <summary>
    /// Representa um mangá na biblioteca do usuário
    /// </summary>
    public class Manga : INotifyPropertyChanged
    {
        private int _id;
        private string _title = "";
        private string _author = "";
        private string _filePath = "";
        private string _coverPath = "";
        private ReadingStatus _status = ReadingStatus.PlanToRead;
        private double _rating;
        private string _review = "";
        private int _currentChapter;
        private int _totalChapters;
        private DateTime _dateAdded;
        private DateTime? _lastRead;
        private string _genre = "";
        private string _fileFormat = "";
        private long _fileSize;

        public int Id
        {
            get => _id;
            set { _id = value; OnPropertyChanged(); }
        }

        public string Title
        {
            get => _title;
            set { _title = value; OnPropertyChanged(); }
        }

        public string Author
        {
            get => _author;
            set { _author = value; OnPropertyChanged(); }
        }

        public string FilePath
        {
            get => _filePath;
            set { _filePath = value; OnPropertyChanged(); }
        }

        public string CoverPath
        {
            get => _coverPath;
            set { _coverPath = value; OnPropertyChanged(); }
        }

        public ReadingStatus Status
        {
            get => _status;
            set { _status = value; OnPropertyChanged(); OnPropertyChanged(nameof(StatusText)); OnPropertyChanged(nameof(StatusColor)); }
        }

        public double Rating
        {
            get => _rating;
            set { _rating = Math.Max(0, Math.Min(10, value)); OnPropertyChanged(); OnPropertyChanged(nameof(RatingText)); }
        }

        public string Review
        {
            get => _review;
            set { _review = value; OnPropertyChanged(); }
        }

        public int CurrentChapter
        {
            get => _currentChapter;
            set { _currentChapter = value; OnPropertyChanged(); OnPropertyChanged(nameof(Progress)); }
        }

        public int TotalChapters
        {
            get => _totalChapters;
            set { _totalChapters = value; OnPropertyChanged(); OnPropertyChanged(nameof(Progress)); }
        }

        public DateTime DateAdded
        {
            get => _dateAdded;
            set { _dateAdded = value; OnPropertyChanged(); }
        }

        public DateTime? LastRead
        {
            get => _lastRead;
            set { _lastRead = value; OnPropertyChanged(); }
        }

        public string Genre
        {
            get => _genre;
            set { _genre = value; OnPropertyChanged(); }
        }

        public string FileFormat
        {
            get => _fileFormat;
            set { _fileFormat = value; OnPropertyChanged(); }
        }

        public long FileSize
        {
            get => _fileSize;
            set { _fileSize = value; OnPropertyChanged(); OnPropertyChanged(nameof(FileSizeText)); }
        }

        // Computed Properties
        public string StatusText => Status switch
        {
            ReadingStatus.Reading => "Lendo",
            ReadingStatus.Completed => "Completo",
            ReadingStatus.OnHold => "Pausado",
            ReadingStatus.Dropped => "Abandonado",
            ReadingStatus.PlanToRead => "Planejar Ler",
            _ => "Desconhecido"
        };

        public string StatusColor => Status switch
        {
            ReadingStatus.Reading => "#10B981",
            ReadingStatus.Completed => "#3B82F6",
            ReadingStatus.OnHold => "#F59E0B",
            ReadingStatus.Dropped => "#EF4444",
            ReadingStatus.PlanToRead => "#6B7280",
            _ => "#9CA3AF"
        };

        public string RatingText => Rating > 0 ? $"{Rating:F1}/10" : "Sem nota";

        public double Progress => TotalChapters > 0 ? (double)CurrentChapter / TotalChapters * 100 : 0;

        public string FileSizeText
        {
            get
            {
                if (FileSize < 1024) return $"{FileSize} B";
                if (FileSize < 1024 * 1024) return $"{FileSize / 1024.0:F1} KB";
                if (FileSize < 1024 * 1024 * 1024) return $"{FileSize / (1024.0 * 1024):F1} MB";
                return $"{FileSize / (1024.0 * 1024 * 1024):F1} GB";
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    /// <summary>
    /// Status de leitura do mangá
    /// </summary>
    public enum ReadingStatus
    {
        PlanToRead = 0,
        Reading = 1,
        Completed = 2,
        OnHold = 3,
        Dropped = 4
    }
}
