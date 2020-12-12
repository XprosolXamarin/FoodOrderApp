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
    public class AddCategoryData
    {
        FirebaseClient client;
        public List<Category> Categories { get; set; }
        public AddCategoryData()
        {
            client = new FirebaseClient("https://estoreapp-7a3b9.firebaseio.com/");
            Categories = new List<Category>()
            {
                new Category
                {
                    CategoryID=1,
                    CategoryName="Pizza",
                    CategoryPoster="MainPoster",
                    ImageUrl="Burger.png"


                },
                new Category
                {
                    CategoryID=2,
                    CategoryName="Pizza",
                    CategoryPoster="MainPoster",
                    ImageUrl="Burger.png"

                },
                new Category
                {
                    CategoryID=3,
                    CategoryName="Pizza",
                    CategoryPoster="MainPoster",
                    ImageUrl="Burger.png"

                },
                new Category
                {
                    CategoryID=4,
                    CategoryName="Pizza",
                    CategoryPoster="MainPoster",
                    ImageUrl="Burger.png"

                },
                new Category
                {
                    CategoryID=5,
                    CategoryName="Pizza",
                    CategoryPoster="MainPoster",
                    ImageUrl="Burger.png"

                },
                new Category
                {
                    CategoryID=6,
                    CategoryName="Pizza",
                    CategoryPoster="MainPoster",
                    ImageUrl="Burger.png"

                }
            };
        }
        public async Task AddCategoriesAsync()
        {
            try
            {
                foreach(var category in Categories)
                {
                    await client.Child("Categories").PostAsync(new Category()
                    {
                        CategoryID = category.CategoryID,
                        CategoryName = category.CategoryName,
                        CategoryPoster = category.CategoryPoster,
                        ImageUrl = category.ImageUrl
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
