using FoodOrderApp.Models;
using FoodOrderApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FoodOrderApp.ViewModels
{
   public class CategoryViewModel:BaseViewModel
    {
        private Category _SelectedCategory;

        public Category SelectedCategory
        {
            get 
            { 
                return _SelectedCategory;
            }
            set 
            { 
                _SelectedCategory = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<FoodItem> FoodItemByCategory { get; set; }
        private int _TotalFoodItems;

        public int TotalFoodItems
        {
            get
            {
                return _TotalFoodItems;
            }
            set
            {
                _TotalFoodItems = value;
                OnPropertyChanged();
            }
        }
        public CategoryViewModel(Category category)
        {
            SelectedCategory = category;
            FoodItemByCategory = new ObservableCollection<FoodItem>();
            GetFoodItems(category.CategoryID);

        }

        private async void GetFoodItems(int categoryID)
        {
            var data = await new FoodItemService().GetFoodItemsByCategoryAsync(categoryID);
            FoodItemByCategory.Clear();
            foreach(var item in data)
            {
                FoodItemByCategory.Add(item);
            }
            TotalFoodItems = FoodItemByCategory.Count;
        }
    }
}
