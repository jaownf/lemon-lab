using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LemonLab
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _searchText = "";
        private MangaItem? _selectedManga;

        public ObservableCollection<MangaItem> Mangas { get; set; }
        
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();
            }
        }

        public MangaItem? SelectedManga
        {
            get => _selectedManga;
            set
            {
                _selectedManga = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            // Sample data - replace with actual manga indexing logic
            Mangas = new ObservableCollection<MangaItem>
            {
                new MangaItem 
                { 
                    Title = "One Piece", 
                    Author = "Eiichiro Oda",
                    Chapters = 1100,
                    Status = "Ongoing",
                    Genre = "Action, Adventure",
                    Rating = 9.2,
                    CoverColor = "#FF6B35"
                },
                new MangaItem 
                { 
                    Title = "Berserk", 
                    Author = "Kentaro Miura",
                    Chapters = 374,
                    Status = "Hiatus",
                    Genre = "Dark Fantasy, Action",
                    Rating = 9.5,
                    CoverColor = "#2C3E50"
                },
                new MangaItem 
                { 
                    Title = "Vinland Saga", 
                    Author = "Makoto Yukimura",
                    Chapters = 200,
                    Status = "Ongoing",
                    Genre = "Historical, Action",
                    Rating = 9.0,
                    CoverColor = "#8B4513"
                },
                new MangaItem 
                { 
                    Title = "Chainsaw Man", 
                    Author = "Tatsuki Fujimoto",
                    Chapters = 97,
                    Status = "Completed",
                    Genre = "Action, Horror",
                    Rating = 8.8,
                    CoverColor = "#E74C3C"
                },
                new MangaItem 
                { 
                    Title = "Spy x Family", 
                    Author = "Tatsuya Endo",
                    Chapters = 90,
                    Status = "Ongoing",
                    Genre = "Comedy, Action",
                    Rating = 8.7,
                    CoverColor = "#E91E63"
                },
                new MangaItem 
                { 
                    Title = "Jujutsu Kaisen", 
                    Author = "Gege Akutami",
                    Chapters = 245,
                    Status = "Ongoing",
                    Genre = "Action, Supernatural",
                    Rating = 8.9,
                    CoverColor = "#9C27B0"
                }
            };
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class MangaItem
    {
        public string Title { get; set; } = "";
        public string Author { get; set; } = "";
        public int Chapters { get; set; }
        public string Status { get; set; } = "";
        public string Genre { get; set; } = "";
        public double Rating { get; set; }
        public string CoverColor { get; set; } = "#3498DB";
    }
}
