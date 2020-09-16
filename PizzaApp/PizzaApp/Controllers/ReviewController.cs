using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaApp.Helper;
using PizzaApp.Models.DomainModels;
using PizzaApp.Models.ViewModels;

namespace PizzaApp.Controllers
{
    public class ReviewController : Controller
    {
        public IActionResult Index()
        {
            var reviews = Data.Reviews.Select(Review.ToViewModel).ToList();
            return View(reviews);
        }
        
        public IActionResult Add()
        {
            var review = new ReviewViewModel();
            return View(review);
        }

        public IActionResult Edit(int id)
        {
            var review = Data.Reviews.FirstOrDefault(r => r.Id == id);
            if (review == null)
                return NotFound();

            return View(Review.ToViewModel(review));
        }

        [HttpPost]
        public IActionResult Update(ReviewViewModel review)
        {
            if (review == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return View("Edit", review);
            var reviewFromDb = Data.Reviews.FirstOrDefault(r => r.Id == review.Id);
            if (reviewFromDb == null)
                return NotFound();
            Data.Reviews.Remove(reviewFromDb);
            Data.Reviews.Add(new Review
            {
                Id = review.Id,
                Comment = review.Comment,
                CustomerId = review.CustomerId,
                Customer = Data.Customers.FirstOrDefault(c => c.Id == review.CustomerId),
                DateMade = review.DateMade
            });
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Save(ReviewViewModel review)
        {
            if (review == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return View("Add", review);
            var reviewFromDb = Data.Reviews.FirstOrDefault(r => r.Id == review.Id);
            Data.Reviews.Add(new Review(review.Comment, review.CustomerId));

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var review = Data.Reviews.FirstOrDefault(r => r.Id == id);
            if (review == null)
                return NotFound();
            Data.Reviews.Remove(review);
            return RedirectToAction("Index");
        }
    }
    
}
