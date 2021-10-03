using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bisycles.Models
{
    public class SortOptions
    {
        public Dictionary<string, int> CategoryNameSortOption { get; set; }

        public SortOptions()
        {
            CategoryNameSortOption = new Dictionary<string, int>();
        }
    }
}
