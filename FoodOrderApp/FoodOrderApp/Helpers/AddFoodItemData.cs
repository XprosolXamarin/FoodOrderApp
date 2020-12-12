using FoodOrderApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrderApp.Helpers
{
    public class AddFoodItemData
    {
        public List<FoodItem> FoodItems { get; set; }
        public AddFoodItemData()
        {
            FoodItems=new List<FoodItem>()
            {
                new FoodItem
                {
                    ProductID=1,
                    CategoryId=1,
                    ImageUrl="Burger.png",
                    Name="Burger",
                    Description="Buger-dgdg-dhdh"
                }
            }
        }

    }
}
