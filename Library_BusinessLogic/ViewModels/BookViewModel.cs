using System;
using System.Collections.Generic;
using System.Text;
using Library_BusinessLogic.Enums;

namespace Library_BusinessLogic.ViewModels
{
    public class BookViewModel
    {
        public string Id { get; set; }
        public string BookName { get; set; }
        public string Description { get; set; }
        public string BookGenre { get; set; }
        public string Cost { get; set; }
    }
}
