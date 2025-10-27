# LemonLab - Library Manager

Um gerenciador moderno e completo de biblioteca local, desenvolvido com .NET 9, Avalonia UI, SQLite, Python e outras tecnologias. Inspirado em Tachiyomi, AniList e MyAnimeList.

## Features

 **Modern UI Design**
- Clean, intuitive interface with card-based layout
- Two-panel design: Library list + Detailed view
- Responsive and smooth animations
- Beautiful color scheme with Indigo accent

 **Manga Management**
- Browse your collection
- View detailed information (title, author, chapters, status, rating, genres)
- Search functionality (by title, author, or genre)
- Visual manga cards with color-coded covers

 **UI Highlights**
- Professional header with logo and search bar
- Manga cards with cover placeholders
- Status badges (Ongoing, Completed, Hiatus)
- Rating display with stars
- Chapter count and genre tags
- Empty state when no manga is selected

## Getting Started

### Prerequisites
- .NET 9.0 SDK or later
- Windows, macOS, or Linux

### Running the Application

```bash
dotnet run
```

The application window will open automatically showing the manga library interface.

### Building the Application

```bash
dotnet build
```

## Project Structure

```
LemonLab/
├── App.axaml              # Application configuration
├── App.axaml.cs           # Application code-behind
├── MainWindow.axaml       # Main window UI (XAML)
├── MainWindow.axaml.cs    # Main window code-behind
├── MainViewModel.cs       # ViewModel with manga data
├── Program.cs             # Application entry point
└── LemonLab.csproj        # Project file
```

## Technology Stack

- **.NET 9.0** - Modern cross-platform framework
- **Avalonia UI 11.3.6** - Cross-platform XAML-based UI framework
- **MVVM Pattern** - Clean separation of concerns
- **Fluent Design** - Modern UI components

## UI Design Details

### Color Palette
- **Primary**: Indigo (#6366F1)
- **Accent**: Amber (#FBBF24)
- **Background**: Light Gray (#F5F5F5)
- **Cards**: White with subtle shadows
- **Text**: Gray scale for hierarchy

### Typography
- **Headers**: Bold, 22-32px
- **Body**: Regular, 14-18px
- **Labels**: Medium, 12px
- **Font**: Inter (included with Avalonia)

### Layout
- **Header**: 80px fixed height with logo, search, and actions
- **Left Panel**: 350px manga list with scrolling
- **Right Panel**: Flexible detail view with scrolling
- **Spacing**: Consistent 12-24px margins

## Future Enhancements

- [ ] Real manga indexing from file system
- [ ] Database integration (SQLite)
- [ ] Cover image support
- [ ] Chapter reading functionality
- [ ] Download manager
- [ ] Filters and sorting options
- [ ] Dark theme support
- [ ] Settings panel
- [ ] Import/Export library

## License

Personal use project.


---

Made with 🍋 and .NET
