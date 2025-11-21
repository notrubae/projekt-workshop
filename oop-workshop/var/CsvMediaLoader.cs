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

            Console.WriteLine($"Loading CSV from: {path}");
            string[] lines = File.ReadAllLines(path);
            Console.WriteLine($"Total lines in CSV: {lines.Length}");

            // First line = header
            int loadedCount = 0;
            for (int i = 1; i < lines.Length; i++)
            {
                try
                {
                    string[] row = lines[i].Split(',');

                    string type = row[0];
                    string title = row[1];
                    string language = row[7];  // Fixed index: Language is at index 7, not 8

                    Console.WriteLine($"Processing line {i}: Type={type}, Title={title}");

                    switch (type)
                    {
                        case "EBook":
                            collection.AddMedia(new EBook(
                                title,
                                language,
                                row[2],                               // Author
                                ParseInt(row[8]),                     // Pages (index 8, not 9)
                                ParseInt(row[5]),                     // Year
                                row[6]                                // ISBN
                            ));
                            loadedCount++;
                            break;

                        case "Movie":
                            collection.AddMedia(new Movie(
                                title,
                                language,
                                row[3],                               // Director
                                row[4].Split(';').ToList(),           // Genres
                                ParseInt(row[5]),                     // Year
                                ParseInt(row[9])                      // Duration (index 9, not 10)
                            ));
                            loadedCount++;
                            break;

                        case "Song":
                            collection.AddMedia(new Song(
                                title,
                                language,
                                row[11],                              // Composer
                                row[10],                              // Singer
                                row[4],                               // Genre
                                row[12],                              // FileType
                                ParseInt(row[9])                      // Duration
                            ));
                            loadedCount++;
                            break;

                        case "VideoGame":
                            collection.AddMedia(new VideoGame(
                                title,
                                language,
                                row[4],                               // Genre
                                row[13],                              // Publisher
                                ParseInt(row[5]),                     // ReleaseYear
                                row[14].Split(';').ToList()           // Platforms
                            ));
                            loadedCount++;
                            break;

                        case "App":
                            collection.AddMedia(new App(
                                title,
                                language,
                                row[15],                              // Version
                                row[13],                              // Publisher
                                row[14].Split(';').ToList(),          // Platforms
                                ParseInt(row[16])                     // FileSize
                            ));
                            loadedCount++;
                            break;

                        case "Podcast":
                            collection.AddMedia(new Podcast(
                                title,
                                language,
                                ParseInt(row[5]),                     // ReleaseYear
                                row[20].Split(';').ToList(),          // Hosts
                                row[21].Split(';').ToList(),          // Guests
                                ParseInt(row[22])                     // Episode
                            ));
                            loadedCount++;
                            break;

                        case "Image":
                            DateTime dt = DateTime.TryParse(row[19], out var d) ? d : DateTime.Now;
                            collection.AddMedia(new Image(
                                title,
                                language,
                                row[17],                              // Resolution
                                row[18],                              // FileFormat
                                ParseInt(row[16]),                    // FileSize
                                dt
                            ));
                            loadedCount++;
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading line {i}: {ex.Message}");
                }
            }

            Console.WriteLine($"Successfully loaded {loadedCount} media items.");
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
