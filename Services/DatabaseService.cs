using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Microsoft.Data.Sqlite;
using LemonLab.Models;

namespace LemonLab.Services
{
    /// <summary>
    /// Serviço para gerenciar o banco de dados SQLite
    /// </summary>
    public class DatabaseService
    {
        private readonly string _connectionString;
        private readonly string _dbPath;

        public DatabaseService()
        {
            var dataFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            Directory.CreateDirectory(dataFolder);
            _dbPath = Path.Combine(dataFolder, "lemonlab.db");
            _connectionString = $"Data Source={_dbPath}";
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Mangas (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Title TEXT NOT NULL,
                    Author TEXT,
                    FilePath TEXT NOT NULL UNIQUE,
                    CoverPath TEXT,
                    Status INTEGER DEFAULT 0,
                    Rating REAL DEFAULT 0,
                    Review TEXT,
                    CurrentChapter INTEGER DEFAULT 0,
                    TotalChapters INTEGER DEFAULT 0,
                    DateAdded TEXT NOT NULL,
                    LastRead TEXT,
                    Genre TEXT,
                    FileFormat TEXT,
                    FileSize INTEGER DEFAULT 0
                );

                CREATE TABLE IF NOT EXISTS UserProfile (
                    Id INTEGER PRIMARY KEY CHECK (Id = 1),
                    Username TEXT NOT NULL,
                    MemberSince TEXT NOT NULL
                );

                INSERT OR IGNORE INTO UserProfile (Id, Username, MemberSince) 
                VALUES (1, 'Otaku', datetime('now'));
            ";
            command.ExecuteNonQuery();
        }

        // Manga Operations
        public List<Manga> GetAllMangas()
        {
            var mangas = new List<Manga>();
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Mangas ORDER BY Title";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                mangas.Add(ReadMangaFromReader(reader));
            }

            return mangas;
        }

        public Manga? GetMangaById(int id)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Mangas WHERE Id = @id";
            command.Parameters.AddWithValue("@id", id);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return ReadMangaFromReader(reader);
            }

            return null;
        }

        public void AddManga(Manga manga)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"
                INSERT INTO Mangas (Title, Author, FilePath, CoverPath, Status, Rating, Review, 
                                   CurrentChapter, TotalChapters, DateAdded, LastRead, Genre, FileFormat, FileSize)
                VALUES (@title, @author, @filePath, @coverPath, @status, @rating, @review,
                       @currentChapter, @totalChapters, @dateAdded, @lastRead, @genre, @fileFormat, @fileSize)
            ";

            AddMangaParameters(command, manga);
            command.ExecuteNonQuery();
        }

        public void UpdateManga(Manga manga)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"
                UPDATE Mangas SET 
                    Title = @title, Author = @author, FilePath = @filePath, CoverPath = @coverPath,
                    Status = @status, Rating = @rating, Review = @review,
                    CurrentChapter = @currentChapter, TotalChapters = @totalChapters,
                    DateAdded = @dateAdded, LastRead = @lastRead, Genre = @genre,
                    FileFormat = @fileFormat, FileSize = @fileSize
                WHERE Id = @id
            ";

            command.Parameters.AddWithValue("@id", manga.Id);
            AddMangaParameters(command, manga);
            command.ExecuteNonQuery();
        }

        public void DeleteManga(int id)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Mangas WHERE Id = @id";
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }

        public bool MangaExists(string filePath)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT COUNT(*) FROM Mangas WHERE FilePath = @filePath";
            command.Parameters.AddWithValue("@filePath", filePath);

            var count = Convert.ToInt32(command.ExecuteScalar());
            return count > 0;
        }

        // User Profile Operations
        public UserProfile GetUserProfile()
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM UserProfile WHERE Id = 1";

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new UserProfile
                {
                    Username = reader.GetString(reader.GetOrdinal("Username")),
                    MemberSince = DateTime.Parse(reader.GetString(reader.GetOrdinal("MemberSince")))
                };
            }

            return new UserProfile { MemberSince = DateTime.Now };
        }

        public void UpdateUserProfile(UserProfile profile)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"
                UPDATE UserProfile SET Username = @username WHERE Id = 1
            ";
            command.Parameters.AddWithValue("@username", profile.Username);
            command.ExecuteNonQuery();
        }

        // Statistics
        public Dictionary<ReadingStatus, int> GetMangaCountByStatus()
        {
            var stats = new Dictionary<ReadingStatus, int>();
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT Status, COUNT(*) as Count FROM Mangas GROUP BY Status";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var status = (ReadingStatus)reader.GetInt32(0);
                var count = reader.GetInt32(1);
                stats[status] = count;
            }

            return stats;
        }

        public double GetAverageRating()
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT AVG(Rating) FROM Mangas WHERE Rating > 0";

            var result = command.ExecuteScalar();
            return result != DBNull.Value ? Convert.ToDouble(result) : 0;
        }

        public List<Manga> GetTopRatedMangas(int count = 5)
        {
            var mangas = new List<Manga>();
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM Mangas WHERE Rating > 0 ORDER BY Rating DESC LIMIT {count}";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                mangas.Add(ReadMangaFromReader(reader));
            }

            return mangas;
        }

        public void ResetDatabase()
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"
                DELETE FROM Mangas;
                DELETE FROM UserProfile;
                INSERT INTO UserProfile (Id, Username, MemberSince) VALUES (1, 'Otaku', datetime('now'));
            ";
            command.ExecuteNonQuery();
        }

        // Helper Methods
        private Manga ReadMangaFromReader(SqliteDataReader reader)
        {
            return new Manga
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                Title = reader.GetString(reader.GetOrdinal("Title")),
                Author = reader.IsDBNull(reader.GetOrdinal("Author")) ? "" : reader.GetString(reader.GetOrdinal("Author")),
                FilePath = reader.GetString(reader.GetOrdinal("FilePath")),
                CoverPath = reader.IsDBNull(reader.GetOrdinal("CoverPath")) ? "" : reader.GetString(reader.GetOrdinal("CoverPath")),
                Status = (ReadingStatus)reader.GetInt32(reader.GetOrdinal("Status")),
                Rating = reader.GetDouble(reader.GetOrdinal("Rating")),
                Review = reader.IsDBNull(reader.GetOrdinal("Review")) ? "" : reader.GetString(reader.GetOrdinal("Review")),
                CurrentChapter = reader.GetInt32(reader.GetOrdinal("CurrentChapter")),
                TotalChapters = reader.GetInt32(reader.GetOrdinal("TotalChapters")),
                DateAdded = DateTime.Parse(reader.GetString(reader.GetOrdinal("DateAdded"))),
                LastRead = reader.IsDBNull(reader.GetOrdinal("LastRead")) ? null : DateTime.Parse(reader.GetString(reader.GetOrdinal("LastRead"))),
                Genre = reader.IsDBNull(reader.GetOrdinal("Genre")) ? "" : reader.GetString(reader.GetOrdinal("Genre")),
                FileFormat = reader.IsDBNull(reader.GetOrdinal("FileFormat")) ? "" : reader.GetString(reader.GetOrdinal("FileFormat")),
                FileSize = reader.GetInt64(reader.GetOrdinal("FileSize"))
            };
        }

        private void AddMangaParameters(SqliteCommand command, Manga manga)
        {
            command.Parameters.AddWithValue("@title", manga.Title);
            command.Parameters.AddWithValue("@author", manga.Author);
            command.Parameters.AddWithValue("@filePath", manga.FilePath);
            command.Parameters.AddWithValue("@coverPath", manga.CoverPath);
            command.Parameters.AddWithValue("@status", (int)manga.Status);
            command.Parameters.AddWithValue("@rating", manga.Rating);
            command.Parameters.AddWithValue("@review", manga.Review);
            command.Parameters.AddWithValue("@currentChapter", manga.CurrentChapter);
            command.Parameters.AddWithValue("@totalChapters", manga.TotalChapters);
            command.Parameters.AddWithValue("@dateAdded", manga.DateAdded.ToString("yyyy-MM-dd HH:mm:ss"));
            command.Parameters.AddWithValue("@lastRead", manga.LastRead?.ToString("yyyy-MM-dd HH:mm:ss") ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@genre", manga.Genre);
            command.Parameters.AddWithValue("@fileFormat", manga.FileFormat);
            command.Parameters.AddWithValue("@fileSize", manga.FileSize);
        }
    }
}
