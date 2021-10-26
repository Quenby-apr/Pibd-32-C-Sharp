using System;
using System.Collections.Generic;
using System.Text;
using Library_BusinessLogic.BindingModels;
using Library_BusinessLogic.Interfaces;
using Library_BusinessLogic.ViewModels;

namespace Library_BusinessLogic.BusinessLogic
{
    public class BookLogic
    {
        private readonly IBookStorage bookStorage;
        public BookLogic(IBookStorage _bookStorage)
        {
            bookStorage = _bookStorage;
        }
        public List<BookViewModel> Read(BookBindingModel model)
        {
            if (model == null)
            {
                return bookStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<BookViewModel> { bookStorage.GetElement(model) };
            }
            return bookStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(BookBindingModel model)
        {
            var element = bookStorage.GetElement(new BookBindingModel
            {
                BookName = model.BookName
            });
            if (element != null && int.Parse(element.Id) != model.Id)
            {
                throw new Exception("Уже есть книга с таким названием");
            }
            if (model.Id.HasValue)
            {
                bookStorage.Update(model);
            }
            else
            {
                bookStorage.Insert(model);
            }
        }
        public void Delete(BookBindingModel model)
        {
            var element = bookStorage.GetElement(new BookBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            bookStorage.Delete(model);
        }
    }
}
