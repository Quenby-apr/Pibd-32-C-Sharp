using System;
using System.Collections.Generic;
using System.Text;
using Library_BusinessLogic.BindingModels;
using Library_BusinessLogic.Interfaces;
using Library_BusinessLogic.ViewModels;

namespace Library_BusinessLogic.BusinessLogic
{
    public class GenreLogic
    {
        private readonly IGenreStorage genreStorage;
        public GenreLogic(IGenreStorage _genreStorage)
        {
            genreStorage = _genreStorage;
        }
        public List<GenreViewModel> Read(GenreBindingModel model)
        {
            if (model == null)
            {
                return genreStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<GenreViewModel> { genreStorage.GetElement(model) };
            }
            return null;
        }
        public void CreateOrUpdate(GenreBindingModel model)
        {
            var element = genreStorage.GetElement(new GenreBindingModel
            {
                GenreName = model.GenreName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть жанр с таким названием");
            }
            if (model.Id.HasValue)
            {
                genreStorage.Update(model);
            }
            else
            {
                genreStorage.Insert(model);
            }
        }
        public void Delete(GenreBindingModel model)
        {
            var element = genreStorage.GetElement(new GenreBindingModel { 
                Id = model.Id,
                GenreName = model.GenreName
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            genreStorage.Delete(model);
        }
    }
}
