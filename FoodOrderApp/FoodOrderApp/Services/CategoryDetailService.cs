using Firebase.Database;
using FoodOrderApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderApp.Services
{
   public class CategoryDetailService
    {
        FirebaseClient client;
        public CategoryDetailService()
        {
            client = new FirebaseClient("https://estoreapp-7a3b9.firebaseio.com/");
        }
        public async Task<List<Category>> GetCategoriesAsync()
        {
            var categories = (await client.Child("Categories")
                .OnceAsync<Category>())
                .Select(client => new Category
                {
                    CategoryID = client.Object.CategoryID,
                    CategoryName = client.Object.CategoryName,
                    CategoryPoster = client.Object.CategoryPoster,
                    ImageUrl=client.Object.ImageUrl
                }).ToList();
            return categories;
        }
    }
}
