using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pulse.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public Address Address { get; set; }

    }
}