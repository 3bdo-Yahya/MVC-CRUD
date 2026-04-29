namespace Visual.Models.ViewModels
{
    public class HomeDashboardViewModel
    {
        public int TotalBooks { get; set; }

        public int AvailableCopies { get; set; }

        public int UniqueGenres { get; set; }

        public List<Book> RecentBooks { get; set; } = new();
    }
}
