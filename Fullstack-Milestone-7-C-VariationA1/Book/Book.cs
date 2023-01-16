namespace CSharpMilestone
{
    public class Book
    {
        public string Title { get; }
        public string Author { get; }
        public int Pages { get; }
        public int StarRating { get; }

        public Book(string title, string author, int pages, int starRating)
        {
            Title = title;
            Author = author;
            Pages = pages;
            StarRating = starRating;
        }

        public string GetDisplayInfo() => $"{Title} by {Author} - {Pages} pages - Rating: {new string('*', StarRating)}";

        public double GetReadTime(int pagesPerMinute) => Pages / (double)pagesPerMinute;
    }
}
