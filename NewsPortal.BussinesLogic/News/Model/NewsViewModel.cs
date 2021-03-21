using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPortal.BusinessLogic.News.Model
{
    public class NewsViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Date { get; set; }
    }
}
