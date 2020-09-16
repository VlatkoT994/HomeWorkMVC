using PizzaApp.Helper;
using PizzaApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApp.Models.DomainModels
{
    public class Review
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int CustomerId { get; set; }
        public DateTime DateMade { get; set; }
        public Customer Customer { get; set; }

        public Review(int customerId)
        {
            var rng = new Random();
            Id = rng.Next(1, 1000000000);
            CustomerId = customerId;
            Customer = Data.Customers.FirstOrDefault(c => c.Id == customerId);
            DateMade = DateTime.Now;
        }
        public Review()
        {
        }

        public Review(string comment, int customerId)
        {
            var rng = new Random();
            Id = rng.Next(1, 1000000000);
            Comment = comment;
            CustomerId = customerId;
            Customer = Data.Customers.FirstOrDefault(c => c.Id == customerId);
            DateMade = DateTime.Now;
        }

        public static ReviewViewModel ToViewModel(Review review)
        {
            return new ReviewViewModel
            {
                Id = review.Id,
                Comment = review.Comment,
                CustomerId = review.CustomerId,
                Customer = Customer.ToViewModel(review.Customer),
                DateMade = review.DateMade
                
            };

        }

    }
}
