using System;

namespace CSharpMilestone
{
    public class Book 
    {
        private string _title;
        private string _author;
        private int _pages;

        public string Title 
        { 
            get => _title;
            set 
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _title = value;
                }
                else
                {
                    throw new ArgumentNullException("Title cannot be null or empty");
                }
            }
        }
        public int Pages
        {
            get => _pages;
            set
            {
                if (value > 1)
                {
                    _pages = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
        public string Author { get; set; }
        public int StarRating { get; set; }


        public Book(string title, string author, int pages, int starRating)
        {
            if (string.IsNullOrEmpty(author))
            {
                throw new ArgumentNullException();
            }

            Title = title;
            Author = author;
            Pages = pages;
            StarRating = starRating;
        }

        public string GetDisplayInfo() => $"{Title} by {Author} - {Pages} pages - Rating: {new string('*', StarRating)}";
        public double GetReadTime(int pagesPerMinute) => Pages / (double)pagesPerMinute;
    }
}

