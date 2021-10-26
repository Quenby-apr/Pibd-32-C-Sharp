using System;
using System.Collections.Generic;
using System.Text;
using Library_BusinessLogic.BindingModels;
using Library_BusinessLogic.ViewModels;

namespace Library_BusinessLogic.Interfaces
{
    public interface IGenreStorage
    {
        List<GenreViewModel> GetFullList();
        GenreViewModel GetElement(GenreBindingModel model);
        void Insert(GenreBindingModel model);
        void Update(GenreBindingModel model);
        void Delete(GenreBindingModel model);
    }
}
