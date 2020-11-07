using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GofPatterns.Structural
{
    class Page
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Text { get; set; }
    }
    class PageContext // DbContext
    {
       // public DbSet<Page> Pages { get; set; }
    }

    interface IBook : IDisposable
    {
        Page GetPage(int number);
    }

    class BookStore : IBook
    {
        PageContext db;
        public BookStore()
        {
            db = new PageContext();
        }
        public Page GetPage(int number)
        {
            return new Page(); //return db.Pages.FirstOrDefault(p => p.Number == number);
        }

        public void Dispose()
        {
            //db.Dispose();
        }
    }

    class BookStoreProxy : IBook
    {
        List<Page> pages;
        BookStore bookStore;
        public BookStoreProxy()
        {
            pages = new List<Page>();
        }
        public Page GetPage(int number)
        {
            Page page = pages.FirstOrDefault(p => p.Number == number);
            if (page == null)
            {
                if (bookStore == null)
                    bookStore = new BookStore();
                page = bookStore.GetPage(number);
                pages.Add(page);
            }
            return page;
        }

        public void Dispose()
        {
            if (bookStore != null)
                bookStore.Dispose();
        }
    }
}
