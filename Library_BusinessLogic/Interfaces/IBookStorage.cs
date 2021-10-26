using System;
using System.Collections.Generic;
using System.Text;
using Library_BusinessLogic.BindingModels;
using Library_BusinessLogic.ViewModels;

namespace Library_BusinessLogic.Interfaces
{
    public interface IBookStorage
    {
        List<BookViewModel> GetFullList();
        List<BookViewModel> GetFilteredList(BookBindingModel model);
        BookViewModel GetElement(BookBindingModel model);
        void Insert(BookBindingModel model);
        void Update(BookBindingModel model);
        void Delete(BookBindingModel model);
    }
}
