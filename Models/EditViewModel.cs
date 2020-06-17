using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LivitWeb.Models
{
    public class EditViewModel
    {
        [Required]
        public string Title { get; set; }
        public string Descrition { get; set; }
        public string Date { get; set; }
        public string Location { get; set; }
        [Display(Name = "Group Activity?")]
        public bool isGroup { get; set; }
        [Display(Name = "Done?")]
        public bool isDone { get; set; }
        public int Id { get; set; }

    }
}
