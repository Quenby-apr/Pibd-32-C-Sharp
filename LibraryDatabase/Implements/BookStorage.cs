using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library_BusinessLogic.BindingModels;
using Library_BusinessLogic.Interfaces;
using Library_BusinessLogic.ViewModels;
using LibraryDatabase.Models;

namespace LibraryDatabase.Implements
{
    public class BookStorage: IBookStorage
    {
        public List<BookViewModel> GetFullList()
        {
            using (var context = new LibraryDatabase())
            {
                return context.Books.Select(rec => new BookViewModel
                {
                    Id = rec.Id.ToString(),
                    BookName = rec.BookName,
                    Description = rec.Description,
                    BookGenre = rec.BookGenre,
                    Cost = rec.Cost.ToString()
                }).ToList();
            }
        }
        public List<BookViewModel> GetFilteredList(BookBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new LibraryDatabase())
            {
                return context.Books.Where(rec => rec.Cost == 0)
                    .Select(rec => new BookViewModel
                    {
                        Id = rec.Id.ToString(),
                        BookName = rec.BookName,
                        Description = rec.Description,
                        BookGenre = rec.BookGenre,
                        Cost = rec.Cost.ToString()
                    })
                    .ToList();
            }
        }
        public BookViewModel GetElement(BookBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new LibraryDatabase())
            {
                var book = context.Books.FirstOrDefault
                    (rec => rec.BookName == model.BookName || rec.Id == model.Id);
                return book != null ? new BookViewModel
                {
                    Id = book.Id.ToString(),
                    BookName = book.BookName,
                    Description = book.Description,
                    BookGenre = book.BookGenre,
                    Cost = book.Cost.ToString()
                } :
                null;
            }
        }
        public void Insert(BookBindingModel model)
        {
            using (var context = new LibraryDatabase())
            {
                context.Books.Add(CreateModel(model, new Book()));
                context.SaveChanges();
            }
        }
        public void Update(BookBindingModel model)
        {
            using (var context = new LibraryDatabase())
            {
                var element = context.Books.FirstOrDefault(rec => rec.Id == model.Id); 
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element); 
                context.SaveChanges();
            }
        }
        public void Delete(BookBindingModel model)
        {
            using (var context = new LibraryDatabase())
            {
                Book element = context.Books.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Books.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        private Book CreateModel(BookBindingModel model, Book book)
        {
            book.BookName = model.BookName;
            book.Description = model.Description;
            book.BookGenre = model.BookGenre;
            book.Cost = (int)model.Cost;
            return book;
        }
    }
}
