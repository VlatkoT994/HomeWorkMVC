using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApp.Models.ViewModels
{
    public class ReviewViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Comment { get; set; }
        [Required]
        [DisplayName("Customer")]
        public int CustomerId { get; set; }
        public CustomerViewModel Customer { get; set; }
        public DateTime DateMade { get; set; }

    }
}
