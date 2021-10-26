using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library_BusinessLogic.BindingModels;
using Library_BusinessLogic.Enums;
using Library_BusinessLogic.Interfaces;
using Library_BusinessLogic.ViewModels;
using LibraryDatabase.Models;

namespace LibraryDatabase.Implements
{
    public class GenreStorage:IGenreStorage
    {
        public List<GenreViewModel> GetFullList()
        {
            using (var context = new LibraryDatabase())
            {
                return context.Genres.Select(rec => new GenreViewModel
                {
                    Id = rec.Id,
                    GenreName = rec.GenreName

            }).ToList();
            }
        }
        public GenreViewModel GetElement(GenreBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new LibraryDatabase())
            {
                var genre = context.Genres.FirstOrDefault
                    (rec => rec.GenreName == model.GenreName || rec.Id == model.Id);
                return genre != null ? new GenreViewModel
                {
                    Id = genre.Id,
                    GenreName = genre.GenreName
                } :
                null;
            }
        }
        public void Insert(GenreBindingModel model)
        {
            using (var context = new LibraryDatabase())
            {
                context.Genres.Add(CreateModel(model, new BookGenre()));
                context.SaveChanges();
            }
        }
        public void Update(GenreBindingModel model)
        {
            using (var context = new LibraryDatabase())
            {
                var element = context.Genres.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }
        public void Delete(GenreBindingModel model)
        {
            using (var context = new LibraryDatabase())
            {
                BookGenre element = context.Genres.FirstOrDefault(rec => rec.GenreName == model.GenreName || rec.Id == model.Id);
                if (element != null)
                {
                    context.Genres.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        private BookGenre CreateModel(GenreBindingModel model, BookGenre genre)
        {
            genre.GenreName = model.GenreName;
            return genre;
        }
    }
}
