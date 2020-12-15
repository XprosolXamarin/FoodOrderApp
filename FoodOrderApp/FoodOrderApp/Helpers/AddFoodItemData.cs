using Firebase.Database;
using Firebase.Database.Query;
using FoodOrderApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FoodOrderApp.Helpers
{
    public class AddFoodItemData
    {
        FirebaseClient client;
        public List<FoodItem> FoodItems { get; set; }
        public AddFoodItemData()
        {
            client = new FirebaseClient("https://estoreapp-7a3b9.firebaseio.com/");
            FoodItems = new List<FoodItem>()
            {
                new FoodItem
                {
                    ProductID=1,
                    CategoryId=1,
                    ImageUrl="Burger.png",
                    Name="Burger",
                    Description="Buger-dgdg-dhdh",
                    Rating=" 4.4",
                    RatingDetail=" (120 raaitings)",
                    HomeSelected="CompleteHeart",
                    Price=45
                },
                 new FoodItem
                {
                    ProductID=2,
                    CategoryId=1,
                    ImageUrl="Burger.png",
                    Name="Burger",
                    Description="Buger-dgdg-dhdh",
                    Rating=" 4.4",
                    RatingDetail=" (120 raaitings)",
                    HomeSelected="CompleteHeart",
                    Price=45
                },
                   new FoodItem
                {
                    ProductID=3,
                    CategoryId=1,
                    ImageUrl="Burger.png",
                    Name="Burger",
                    Description="Buger-dgdg-dhdh",
                    Rating=" 4.4",
                    RatingDetail=" (120 raaitings)",
                    HomeSelected="CompleteHeart",
                    Price=45
                },
                                   new FoodItem
                {
                    ProductID=4,
                    CategoryId=2,
                    ImageUrl="Burger.png",
                    Name="Burger",
                    Description="Buger-dgdg-dhdh",
                    Rating=" 4.4",
                    RatingDetail=" (120 raaitings)",
                    HomeSelected="CompleteHeart",
                    Price=45
                },
                 new FoodItem
                {
                    ProductID=5,
                    CategoryId=2,
                    ImageUrl="Burger.png",
                    Name="Burger",
                    Description="Buger-dgdg-dhdh",
                    Rating=" 4.4",
                    RatingDetail=" (120 raaitings)",
                    HomeSelected="CompleteHeart",
                    Price=45
                },
                 
                                   new FoodItem
                {
                    ProductID=6,
                    CategoryId=3,
                    ImageUrl="Burger.png",
                    Name="Burger",
                    Description="Buger-dgdg-dhdh",
                    Rating=" 4.4",
                    RatingDetail=" (120 raaitings)",
                    HomeSelected="CompleteHeart",
                    Price=45
                },
                 new FoodItem
                {
                    ProductID=7,
                    CategoryId=3,
                    ImageUrl="Burger.png",
                    Name="Burger",
                    Description="Buger-dgdg-dhdh",
                    Rating=" 4.4",
                    RatingDetail=" (120 raaitings)",
                    HomeSelected="CompleteHeart",
                    Price=45
                },
            };
        }
        public async Task AddFoodItemsAsync()
        {
            try
            {
                foreach (var item in FoodItems)
                {
                    await client.Child("FoodItems").PostAsync(new FoodItem()
                    {
                      CategoryId=item.CategoryId,
                      ProductID=item.ProductID,
                      Description=item.Description,
                      HomeSelected=item.HomeSelected,
                      ImageUrl=item.ImageUrl,
                      Name=item.Name,
                      Price=item.Price,
                      Rating=item.Rating,
                      RatingDetail=item.RatingDetail
                    });

                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "ok");
            }

        }

    }
}
