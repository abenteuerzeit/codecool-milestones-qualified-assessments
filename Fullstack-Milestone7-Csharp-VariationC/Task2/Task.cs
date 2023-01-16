namespace CSharpMilestone
{
    public class Book
    {
        public string Title { get; set; }
        public string Author {get; set; }
        public int Pages { get; set; }
        public int StarRating { get; set; }
        
        public Book(string title, string author, int pages, int starRating)
        {
           Title = title;
           Author = author;
           Pages = pages;
           StarRating = starRating;
        }
        
        public string GetDisplayInfo() => $"{Title} by {Author} - {Pages} pages - Rating: {new string('*', StarRating)}";
        
        public double GetReadTime(int pagesPerMinute) => Pages/(double)pagesPerMinute;
    }
}
