using Movie_Admin_App.Models;

namespace Movie_Admin_App.Data
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationContext>();

                context.Database.EnsureCreated();


                if (!context.Countries.Any())
                {
                    Country c1 = new() { Name = "us" };
                    Country c2 = new() { Name = "ca" };
                    Country c3 = new() { Name = "it" };
                    Country c4 = new() { Name = "au" };
                    Country c5 = new() { Name = "uk" };
                    Country c6 = new() { Name = "ge" };
                    Country c7 = new() { Name = "me" };

                    context.AddRange(c1, c2, c3, c4, c5, c6, c7);

                    context.SaveChanges();
                }

                if (!context.Genres.Any())
                {
                    Genre g1 = new() { Name = "Drama" };
                    Genre g2 = new() { Name = "Action" };
                    Genre g3 = new() { Name = "Comedy" };
                    Genre g4 = new() { Name = "Thriller" };
                    Genre g5 = new() { Name = "Historical" };
                    Genre g6 = new() { Name = "Adventure" };
                    Genre g7 = new() { Name = "Crime" };
                    Genre g8 = new() { Name = "Western" };
                    Genre g9 = new() { Name = "Sports" };
                    Genre g10 = new() { Name = "Mystery" };
                    Genre g11 = new() { Name = "Fantasy" };

                    context.AddRange(g1, g2, g3, g4, g5, g6, g7, g8, g9, g10, g11);

                    context.SaveChanges();
                }

                if (!context.Actors.Any())
                {
                    // ACTORS
                    Actor a1 = new()
                    {
                        FirstName = "Michael",
                        LastName = "Keaton",
                        Height = 1.78,
                        Birthday = new DateTime(1951, 09, 05),
                        Image = "3sl5cw7cg8.jfif",
                        Bio = "Michael Keaton is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                        CountryId = 1
                    };

                    Actor a2 = new()
                    {
                        FirstName = "Edward",
                        LastName = "Norton",
                        Height = 1.83,
                        Birthday = new DateTime(1969, 08, 18),
                        Image = "456dj45ert.jfif",
                        Bio = "Edward Norton is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                        CountryId = 1
                    };

                    Actor a3 = new()
                    {
                        FirstName = "Emma",
                        LastName = "Stone",
                        Height = 1.68,
                        Birthday = new DateTime(1988, 11, 06),
                        Image = "abgytr5ert.jfif",
                        Bio = "Edward Norton is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                        CountryId = 1
                    };

                    Actor a4 = new()
                    {
                        FirstName = "Zach",
                        LastName = "Galifianakis",
                        Height = 1.73,
                        Birthday = new DateTime(1974, 04, 17),
                        Image = "33gytr5ert.jfif",
                        Bio = "Zach Galifianakis is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                        CountryId = 1
                    };

                    Actor a5 = new()
                    {
                        FirstName = "Sam",
                        LastName = "Worthington",
                        Height = 1.78,
                        Birthday = new DateTime(1976, 08, 18),
                        Image = "asrytr5ert.jfif",
                        Bio = "Sam Worthington is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                        CountryId = 4
                    };

                    Actor a6 = new()
                    {
                        FirstName = "Sigourney",
                        LastName = "Weaver",
                        Height = 1.76,
                        Birthday = new DateTime(1977, 09, 10),
                        Image = "asrht35e4t.jfif",
                        Bio = "Sigourney Weaver is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                        CountryId = 1
                    };

                    Actor a7 = new()
                    {
                        FirstName = "Zoe",
                        LastName = "Saldana",
                        Height = 1.7,
                        Birthday = new DateTime(1978, 06, 19),
                        Image = "asraa35e4t.jfif",
                        Bio = "Zoe Saldana is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                        CountryId = 1
                    };

                    Actor a8 = new()
                    {
                        FirstName = "Christian",
                        LastName = "Bale",
                        Height = 1.83,
                        Birthday = new DateTime(1974, 01, 30),
                        Image = "asrer35e4t.jfif",
                        Bio = "Christian Bale is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                        CountryId = 5
                    };

                    Actor a9 = new()
                    {
                        FirstName = "Health",
                        LastName = "Ledger",
                        Height = 1.85,
                        Birthday = new DateTime(1979, 04, 04),
                        Image = "attet35e4t.jfif",
                        Bio = "Health Ledger is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                        CountryId = 4
                    };

                    Actor a10 = new()
                    {
                        FirstName = "Gary",
                        LastName = "Oldman",
                        Height = 1.76,
                        Birthday = new DateTime(1958, 04, 11),
                        Image = "avtev35evt.jfif",
                        Bio = "Gary Oldman is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                        CountryId = 5
                    };

                    Actor a11 = new()
                    {
                        FirstName = "Aaron",
                        LastName = "Eckhart",
                        Height = 1.86,
                        Birthday = new DateTime(1968, 03, 12),
                        Image = "avtii35evt.jfif",
                        Bio = "Aaron Eckhart is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                        CountryId = 1
                    };

                    Actor a12 = new()
                    {
                        FirstName = "Joaquin",
                        LastName = "Phoenix",
                        Height = 1.76,
                        Birthday = new DateTime(1974, 11, 11),
                        Image = "vbhii35evt.jfif",
                        Bio = "Joaquin Phoenix is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                        CountryId = 1
                    };

                    Actor a13 = new()
                    {
                        FirstName = "Robert",
                        LastName = "De Niro",
                        Height = 1.75,
                        Birthday = new DateTime(1954, 11, 12),
                        Image = "vbhopp5evt.jfif",
                        Bio = "Robert De Niro is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                        CountryId = 1
                    };

                    context.AddRange(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13);

                    context.SaveChanges();
                }

                if (!context.Directors.Any())
                {
                    // DIRECTORS
                    Director d1 = new()
                    {
                        FirstName = "Alejandro",
                        LastName = "González Iñárritu",
                        Height = 1.84,
                        Birthday = new DateTime(1963, 08, 15),
                        CountryId = 7,
                        Image = "vytoep5evt.jfif",
                        Bio = "Alejandro González Iñárritu is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    };

                    Director d2 = new()
                    {
                        FirstName = "Christopher",
                        LastName = "Nolan",
                        Height = 1.81,
                        Birthday = new DateTime(1970, 06, 30),
                        CountryId = 5,
                        Image = "vy888p5evt.jfif",
                        Bio = "Christopher Nolan is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    };

                    Director d3 = new()
                    {
                        FirstName = "James",
                        LastName = "Cameron",
                        Height = 1.87,
                        Birthday = new DateTime(1954, 08, 16),
                        CountryId = 2,
                        Image = "34toep51vt.jfif",
                        Bio = "James Cameron is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    };

                    Director d4 = new()
                    {
                        FirstName = "Todd",
                        LastName = "Phillips",
                        Height = 1.83,
                        Birthday = new DateTime(1970, 12, 20),
                        CountryId = 1,
                        Image = "vypiet5evt.jfif",
                        Bio = "Todd Phillips is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    };

                    Director d5 = new()
                    {
                        FirstName = "David",
                        LastName = "Fincher",
                        Height = 1.84,
                        Birthday = new DateTime(1963, 08, 28),
                        CountryId = 1,
                        Image = "2wrty7uiop.jfif",
                        Bio = "David Fincher is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
                    };

                    context.AddRange(d1, d2, d3, d4, d5);

                    context.SaveChanges();
                }

                if (!context.Movies.Any())
                {
                    // MOVIES
                    Movie m1 = new()
                    {
                        Title = "Birdman",
                        Description = "Birdman or (The Unexpected Virtue of Ignorance) is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                        Year = 2014,
                        Views = 23561,
                        Voters = 300,
                        Stars = 2700,
                        Duration = 120,
                        Image = "r435t34984.jpg",
                        VideoFileName = "t349848111.mp4",
                        DirectorId = 1,
                    };

                    Movie m2 = new()
                    {
                        Title = "Avatar",
                        Description = "Avatar is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                        Year = 2009,
                        Views = 27561,
                        Voters = 320,
                        Stars = 2814,
                        Duration = 160,
                        Image = "t3g98483jr.jpg",
                        VideoFileName = "t349148991.mp4",
                        DirectorId = 3,
                    };

                    Movie m3 = new()
                    {
                        Title = "The Dark Knight",
                        Description = "The Dark Knight is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                        Year = 2008,
                        Views = 18751,
                        Voters = 270,
                        Stars = 2450,
                        Duration = 152,
                        Image = "t8g96483gg.jpg",
                        VideoFileName = "t349148a91.mp4",
                        DirectorId = 2,
                    };

                    Movie m4 = new()
                    {
                        Title = "Joker",
                        Description = "Joker is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                        Year = 2019,
                        Views = 40512,
                        Voters = 781,
                        Stars = 6541,
                        Duration = 122,
                        Image = "48g06483rr.jpg",
                        VideoFileName = "t559148991.mp4",
                        DirectorId = 4,
                    };

                    Movie m5 = new()
                    {
                        Title = "Fight Club",
                        Description = "Fight Club is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                        Year = 1999,
                        Views = 35612,
                        Voters = 845,
                        Stars = 7812,
                        Duration = 139,
                        Image = "wertyuhgfv.jfif",
                        VideoFileName = "34redftgyu.mp4",
                        DirectorId = 5,
                    };

                    context.AddRange(m1, m2, m3, m4, m5);

                    context.SaveChanges();
                }

                
                if (!context.ActorMovies.Any())
                {
                    ActorMovie am1 = new() { ActorId = 1, MovieId = 1 };
                    ActorMovie am2 = new() { ActorId = 2, MovieId = 1 };
                    ActorMovie am3 = new() { ActorId = 3, MovieId = 1 };
                    ActorMovie am4 = new() { ActorId = 4, MovieId = 1 };

                    ActorMovie am5 = new() { ActorId = 5, MovieId = 2 };
                    ActorMovie am6 = new() { ActorId = 6, MovieId = 2 };
                    ActorMovie am7 = new() { ActorId = 7, MovieId = 2 };

                    ActorMovie am8 = new() { ActorId = 8, MovieId = 3 };
                    ActorMovie am9 = new() { ActorId = 9, MovieId = 3 };
                    ActorMovie am10 = new() { ActorId = 10, MovieId = 3 };
                    ActorMovie am11 = new() { ActorId = 11, MovieId = 3 };

                    ActorMovie am12 = new() { ActorId = 12, MovieId = 4 };
                    ActorMovie am13 = new() { ActorId = 13, MovieId = 4 };

                    ActorMovie am14 = new() { ActorId = 2, MovieId = 5 };

                    context.AddRange(am1, am2, am3, am4, am5, am6, am7, am8, am9, am10, am11, am12, am13, am14);

                    context.SaveChanges();
                }

                if (!context.CountryMovies.Any())
                {
                    CountryMovie cm1 = new() { CountryId = 1, MovieId = 1 };
                    CountryMovie cm2 = new() { CountryId = 2, MovieId = 1 };

                    CountryMovie cm3 = new() { CountryId = 5, MovieId = 2 };
                    CountryMovie cm4 = new() { CountryId = 1, MovieId = 2 };

                    CountryMovie cm5 = new() { CountryId = 1, MovieId = 3 };
                    CountryMovie cm6 = new() { CountryId = 5, MovieId = 3 };

                    CountryMovie cm7 = new() { CountryId = 2, MovieId = 4 };
                    CountryMovie cm8 = new() { CountryId = 1, MovieId = 4 };

                    context.AddRange(cm1, cm2, cm3, cm4, cm5, cm6, cm7, cm8);

                    context.SaveChanges();
                }

                if (!context.GenreMovies.Any())
                {
                    GenreMovie gm1 = new() { GenreId = 1, MovieId = 1 };
                    GenreMovie gm2 = new() { GenreId = 3, MovieId = 1 };

                    GenreMovie gm3 = new() { GenreId = 4, MovieId = 1 };
                    GenreMovie gm4 = new() { GenreId = 6, MovieId = 1 };

                    GenreMovie gm5 = new() { GenreId = 10, MovieId = 3 };
                    GenreMovie gm6 = new() { GenreId = 4, MovieId = 3 };
                    GenreMovie gm7 = new() { GenreId = 7, MovieId = 3 };

                    GenreMovie gm8 = new() { GenreId = 7, MovieId = 4 };
                    GenreMovie gm9 = new() { GenreId = 2, MovieId = 4 };
                    GenreMovie gm10 = new() { GenreId = 4, MovieId = 4 };

                    GenreMovie gm11 = new() { GenreId = 1, MovieId = 5 };
                    GenreMovie gm12 = new() { GenreId = 4, MovieId = 5 };

                    context.AddRange(gm1, gm2, gm3, gm4, gm5, gm6, gm7, gm8, gm9, gm10, gm11, gm12);

                    context.SaveChanges();
                }

            }
        } 
    }
}
