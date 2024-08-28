using System;

namespace LINQ
{
    
    public class Books
    {
        
        public int BookId { get; set; }
        public string Title { get; set; }

       
        public Books(int bookId, string title)
        {
            this.BookId = bookId;
            this.Title = title;
        }
    }
}
