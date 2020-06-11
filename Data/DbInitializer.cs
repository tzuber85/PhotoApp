namespace PhotoApp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(PhotoDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}