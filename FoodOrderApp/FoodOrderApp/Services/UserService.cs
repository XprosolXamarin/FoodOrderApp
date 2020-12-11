using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrderApp.Services
{
   public  class UserService
    {
        FirebaseClient client;
        public UserService()
        {
            client = new FirebaseClient("https://foodorderapp-2b06f.firebaseio.com/");
        }
    }
}
