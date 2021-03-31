namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccessLayer.LibraryModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataAccessLayer.LibraryModel context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            ///////////////// Genres
            var novela = new Genre() { Name = "Novela" };
            context.Genres.AddOrUpdate(novela);

            var fiction = new Genre() { Name = "Fiction" };
            context.Genres.AddOrUpdate(fiction);

            var humour = new Genre() { Name = "Humour" };
            context.Genres.AddOrUpdate(humour);

            var drama = new Genre() { Name = "Drama" };
            context.Genres.AddOrUpdate(drama);

            var gothicFiction = new Genre() { Name = "Gothic fiction" };
            context.Genres.AddOrUpdate(gothicFiction);
            
            context.SaveChanges();

            ///////////////// Authors
            var gogol = new Author()
            {
                FirstName = "Nikolai",
                LastName = "Gogol",
                BirthDate = new DateTime(1809, 4, 1)
            };
            context.Authors.AddOrUpdate(gogol);

            var franko = new Author()
            {
                FirstName = "Ivan",
                LastName = "Franko",
                BirthDate = new DateTime(1856, 8, 27)
            };
            context.Authors.AddOrUpdate(franko);

            context.SaveChanges();

            ///////////////// Books
            context.Books.AddOrUpdate(new Book()
            {
                Title = "Zakhar Berkut",
                Pages = 1410,
                AuthorId = franko.Id,
                GenreId = fiction.Id
            });
            context.Books.AddOrUpdate(new Book()
            {
                Title = "Moses",
                Pages = 680,
                AuthorId = franko.Id,
                GenreId = drama.Id
            });
            context.Books.AddOrUpdate(new Book()
            {
                Title = "Dead Souls",
                Pages = 1340,
                AuthorId = gogol.Id,
                GenreId = novela.Id
            });
            context.Books.AddOrUpdate(new Book()
            {
                Title = "The overcoat and selected stories",
                Pages = 890,
                AuthorId = gogol.Id,
                GenreId = gothicFiction.Id
            });
            context.Books.AddOrUpdate(new Book()
            {
                Title = "Taras Bulba",
                Pages = 770,
                AuthorId = gogol.Id,
                GenreId = novela.Id
            });
            context.SaveChanges();
        }
    }
}
