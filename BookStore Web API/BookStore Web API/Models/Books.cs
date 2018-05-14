using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample_Web_API.Models
{
    public class Books
    {
        public int Book_ID { get; set; }

        public string Book_Name { get; set; }

        public string Author { get; set; }

        public double ? Price { get; set; }

        public string Book_Desc { get; set; }

        public string Book_URL { get; set; }

        public string Img_URL { get; set; }

        public int ? Pages { get; set; }

        public string Publisher { get; set; }

        public string Language { get; set; }

        public long ? ISBN { get; set; }
    }
}
