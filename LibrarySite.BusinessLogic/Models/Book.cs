﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySite.BusinessLogic.Models
{
    public class Book
    {
        public string Id { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }

        public decimal Price { get; set; }

        public DateTime PublishDate { get; set; }

        public string Description { get; set; }

        public User BorrowedBy { get; set; }
    }
}
