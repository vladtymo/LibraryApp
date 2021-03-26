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

            var novela = context.Genres.Add(new Genre() { Name = "Novela" });
            var fiction = context.Genres.Add(new Genre() { Name = "Fiction" });
            var humour = context.Genres.Add(new Genre() { Name = "Humour" });
            var drama = context.Genres.Add(new Genre() { Name = "Drama" }); 
            var gothicFiction = context.Genres.Add(new Genre() { Name = "Gothic fiction" }); 
            context.SaveChanges();

            var gogol = context.Authors.Add(new Author()
            {
                FirstName = "Nikolai",
                LastName = "Gogol",
                BirthDate = new DateTime(1809, 4, 1)
            });
            var franko = context.Authors.Add(new Author()
            {
                FirstName = "Ivan",
                LastName = "Franko",
                BirthDate = new DateTime(1856, 8, 27)
            });
            context.SaveChanges();

            
            context.Books.Add(new Book()
            {
                Title = "Zakhar Berkut",
                Pages = 1410,
                AuthorId = franko.Id,
                GenreId = fiction.Id
            });
            context.Books.Add(new Book()
            {
                Title = "Moses",
                Pages = 680,
                AuthorId = franko.Id,
                GenreId = drama.Id
            });
            context.Books.Add(new Book()
            {
                Title = "Dead Souls",
                Pages = 1340,
                AuthorId = gogol.Id,
                GenreId = novela.Id
            });
            context.Books.Add(new Book()
            {
                Title = "The overcoat and selected stories",
                Pages = 890,
                AuthorId = gogol.Id,
                GenreId = gothicFiction.Id
            });
            context.Books.Add(new Book()
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
