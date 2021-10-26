using System;
using System.Collections.Generic;
using System.Text;
using Library_BusinessLogic.Enums;

namespace Library_BusinessLogic.BindingModels
{
    public class BookBindingModel
    {
        public int? Id { get; set;}
        public string BookName { get; set; }
        public string Description { get; set; }
        public string BookGenre { get; set; }
        public int? Cost { get; set; }
    }
}
