using Firebase.Database;
using FoodOrderApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderApp.Services
{
    
    class FoodItemService
    {
        FirebaseClient client;
        public FoodItemService()
        {
            client = new FirebaseClient("https://estoreapp-7a3b9.firebaseio.com/");

        }
        public async Task<List<FoodItem>> GetFoodItemsAsync()
        {
            var products = (await client.Child("FoodItems")
                .OnceAsync<FoodItem>())
                .Select(f => new FoodItem
                {
                   CategoryId=f.Object.CategoryId,
                   Description=f.Object.Description,
                   HomeSelected=f.Object.HomeSelected,
                   ImageUrl=f.Object.ImageUrl,
                   Name=f.Object.Name,
                   Price=f.Object.Price,
                   ProductID=f.Object.ProductID,
                   Rating=f.Object.Rating,
                   RatingDetail=f.Object.RatingDetail
                }).ToList();
            return products;
        }
        public async Task<ObservableCollection<FoodItem>> GetFoodItemsByCategoryAsync(int categoryID)
        {
            var foodItemsByCategory = new ObservableCollection<FoodItem>();
            var items = (await GetFoodItemsAsync()).Where(p => p.CategoryId == categoryID).ToList();
            foreach(var item in items)
            {
                foodItemsByCategory.Add(item);
            }
            return foodItemsByCategory;
        }
        public async Task<ObservableCollection<FoodItem>> GetLatestFoodItemsAsync()
        {
            var LatestfoodItems = new ObservableCollection<FoodItem>();
            var items = (await GetFoodItemsAsync()).OrderByDescending(f => f.ProductID).Take(3);
            foreach (var item in items)
            {
                LatestfoodItems.Add(item);
            }
            return LatestfoodItems;
        }
    }
}
