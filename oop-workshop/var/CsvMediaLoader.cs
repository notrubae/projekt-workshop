using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace projekt_workshop.oop_workshop.Domain.Media
{
    public static class CsvMediaLoader
    {
        public static void LoadMedia(string path, MediaCollection collection)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine($"CSV not found at {path}");
                return;
            }

            string[] lines = File.ReadAllLines(path);

            // First line = header
            for (int i = 1; i < lines.Length; i++)
            {
                string[] row = lines[i].Split(',');

                string type = row[0];
                string title = row[1];
                string language = row[8];

                switch (type)
            {
                case "EBook":
                    collection.AddMedia(new EBook(
                        title,
                        language,
                        row[2],                               // Author
                        ParseInt(row[9]),                     // Pages
                        ParseInt(row[5]),                     // Year
                        row[6]                                // ISBN
                    ));
                    break;

                case "Movie":
                    collection.AddMedia(new Movie(
                        title,
                        language,
                        row[3],                               // Director
                        row[4].Split(';').ToList(),           // Genres
                        ParseInt(row[5]),                     // Year
                        ParseInt(row[10])                     // Duration
                    ));
                    break;

                case "Song":
                    collection.AddMedia(new Song(
                        title,
                        language,
                        row[11],                              // Composer
                        row[12],                              // Singer
                        row[4],                               // Genre
                        row[13],                              // FileType
                        ParseInt(row[10])                     // Duration
                    ));
                    break;

                case "VideoGame":
                    collection.AddMedia(new VideoGame(
                        title,
                        language,
                        row[4],                               // Genre
                        row[14],                              // Publisher
                        ParseInt(row[5]),                     // ReleaseYear
                        row[15].Split(';').ToList()           // Platforms
                    ));
                    break;

                case "App":
                    collection.AddMedia(new App(
                        title,
                        language,
                        row[16],                              // Version
                        row[14],                              // Publisher
                        row[15].Split(';').ToList(),          // Platforms
                        ParseInt(row[17])                     // FileSize
                    ));
                    break;

                case "Podcast":
                    collection.AddMedia(new Podcast(
                        title,
                        language,
                        ParseInt(row[5]),                     // ReleaseYear
                        row[21].Split(';').ToList(),          // Hosts
                        row[22].Split(';').ToList(),          // Guests
                        ParseInt(row[23])                     // Episode
                    ));
                    break;

                case "Image":
                    DateTime dt = DateTime.TryParse(row[20], out var d) ? d : DateTime.Now;
                    collection.AddMedia(new Image(
                        title,
                        language,
                        row[18],                              // Resolution
                        row[19],                              // FileFormat
                        ParseInt(row[17]),                     // FileSize
                        dt
                    ));
                    break;
            }
        }
    }

        private static int ParseInt(string s)
        {
            int result;
            if (int.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
            {
                return result;
            }
            return 0;
        }
    }
}
