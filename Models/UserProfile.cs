using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LemonLab.Models
{
    /// <summary>
    /// Perfil do usuário com estatísticas
    /// </summary>
    public class UserProfile : INotifyPropertyChanged
    {
        private string _username = "Otaku";
        private int _totalMangas;
        private int _mangasRead;
        private int _mangasReading;
        private int _mangasOnHold;
        private int _mangasDropped;
        private int _mangasPlanToRead;
        private double _averageRating;
        private DateTime _memberSince;

        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(); }
        }

        public int TotalMangas
        {
            get => _totalMangas;
            set { _totalMangas = value; OnPropertyChanged(); }
        }

        public int MangasRead
        {
            get => _mangasRead;
            set { _mangasRead = value; OnPropertyChanged(); }
        }

        public int MangasReading
        {
            get => _mangasReading;
            set { _mangasReading = value; OnPropertyChanged(); }
        }

        public int MangasOnHold
        {
            get => _mangasOnHold;
            set { _mangasOnHold = value; OnPropertyChanged(); }
        }

        public int MangasDropped
        {
            get => _mangasDropped;
            set { _mangasDropped = value; OnPropertyChanged(); }
        }

        public int MangasPlanToRead
        {
            get => _mangasPlanToRead;
            set { _mangasPlanToRead = value; OnPropertyChanged(); }
        }

        public double AverageRating
        {
            get => _averageRating;
            set { _averageRating = value; OnPropertyChanged(); OnPropertyChanged(nameof(AverageRatingText)); }
        }

        public DateTime MemberSince
        {
            get => _memberSince;
            set { _memberSince = value; OnPropertyChanged(); OnPropertyChanged(nameof(MemberSinceText)); }
        }

        public string AverageRatingText => AverageRating > 0 ? $"{AverageRating:F1}/10" : "N/A";

        public string MemberSinceText => MemberSince.ToString("dd/MM/yyyy");

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
