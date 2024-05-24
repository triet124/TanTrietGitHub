using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookTemplate.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string BookName { get; set; }

        public string Type { get; set; }

        public double Price { get; set; }

        public DateTime Date { get; set; }

        public List<string> Condition { get; set; }
    }
}