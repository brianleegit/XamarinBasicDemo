using System;
using System.Collections.Generic;
using System.Text;
using XaDemo.Data;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;

namespace XaDemo.Services
{
    public class RestaurantManager
    {
        IMobileServiceTable<Restaurant> restaurants;
        MobileServiceClient client;

        public RestaurantManager()
        {
            this.client = new MobileServiceClient(Constants.ApplicationURL);
            this.restaurants = client.GetTable<Restaurant>();
        }

        public MobileServiceClient CurrentClient
        {
            get { return client; }
        }
        public async Task GenerateRandomData()
        {
            List<Restaurant> resList = new List<Restaurant> {
                new Restaurant("Burger King", "Tainan", "Fast food for burger", "Fast Food"),
                new Restaurant("Mac Donald", "US", "Best Burger for American", "Fast Food"),
                new Restaurant("KFC", "Tainan", "The Best Fried Chicked", "Fast Food"),
                new Restaurant("Subway", "Tainan", "Good Salad", "Fast Food")
            };

            foreach (var res in resList)
            {
                await restaurants.InsertAsync(res);
            }            
        }

    }
}
