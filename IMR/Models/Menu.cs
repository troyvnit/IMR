﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMR.Models
{
    public class Menu
    {
        public int MenuId { get; set; }
        public string Name { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}