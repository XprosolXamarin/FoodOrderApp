using FoodOrderApp.Models;
using FoodOrderApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Essentials;

namespace FoodOrderApp.ViewModels
{
   public class ProductViewModel:BaseViewModel
    {
        private string _UserName;

        public string UserName
        {
            get { return _UserName; }
            set 
            {   _UserName = value;
                OnPropertyChanged();
            }
        }
        private int _UserCartItemsCount;

        public int UserCartItemsCount
        {
            get { return _UserCartItemsCount; }
            set
            {
                _UserCartItemsCount = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<FoodItem> LatestItems { get; set; }
        public ProductViewModel()
        {
            var uname = Preferences.Get("Username", string.Empty);
            if (String.IsNullOrEmpty(uname))
                UserName = "Guest";
            else
                UserName = uname;

            UserCartItemsCount = new CartItemService().GetUserCartCount();
            Categories = new ObservableCollection<Category>();
            LatestItems = new ObservableCollection<FoodItem>();
            GetCategories();
            GetLatestItems();
        }

    }
}
