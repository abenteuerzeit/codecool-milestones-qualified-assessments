using System;
namespace CSharpMilestone
{
    public class Book
    {
        public string Title {get; set;}
        public string Author {get; set;}
        public int Pages {get; set;}
        public int StarRating {get; set;}
        
        public Book(string title, string author, int pages, int starRating)
        {
            this.Title = title;
            this.Author = author;
            this.Pages = pages;
            this.StarRating = starRating;
        }
        
        public string GetDisplayInfo()
        {            
            string rating = "";
            for (int i = 0; i < this.StarRating; i++ )
            {
                rating += '*';
            }
            return $"{this.Title} by {this.Author} - {this.Pages} pages - Rating: {rating}";
        }
        
        public double GetReadTime(int pagesPerMinute)
        {
            return (double)Decimal.Divide(this.Pages, pagesPerMinute);
        }
   
    }
}
