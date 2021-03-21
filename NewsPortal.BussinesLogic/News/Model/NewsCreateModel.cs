using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NewsPortal.BusinessLogic.News.Model
{
    public class NewsCreateModel
    {
        [Required]
        public string Text { get; set; }
    }
}
