using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bisycles.Models.ViewModels
{
    public class EditViewModel
    {
        public string UserName { get; set; }
        [Required]
        public int Year { get; set; }

    }
}
