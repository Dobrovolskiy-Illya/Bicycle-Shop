using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bisycles.Models
{
    public class Pagination
    {
        public int CurrentPage { get; set; }
        public int MaxPages { get; set; }
        public int IntemsOnPage { get; set; }
        public List<Bicycle> Bicycles { get; set; }

        public Pagination()
        {
            Bicycles = new List<Bicycle>();
        }
    }
}
