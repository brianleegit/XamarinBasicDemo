using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XaDemo.Data;
using Xamarin.Forms;
using XaDemo.Services;
using System.Collections;

namespace XaDemo.View
{
	public partial class RestaurantLayout : ContentPage
	{
        
        RestaurantManager restaurant;

        public RestaurantLayout ()
		{

			InitializeComponent ();

            ResultData.BindingContext = new Restaurant();

            restaurant = new RestaurantManager();
            showRestaurant();
            //  generateData(true);
            // Restaurant_img.Source = ImageSource.FromUri(new Uri("http://i.imgur.com/0j3D4Gp.png"));
            Restaurant_img.Source = ImageSource.FromFile("hourglass.png");

            //Restaurant_img.Aspect = Aspect.AspectFit;
            //Restaurant_img.Source = ImageSource.FromFile("mac.png");
        }
        public async void showRestaurant()
        {
            using (var scope = new ActivityIndicatorScope(syncIndicator, true))
            {
                try
                {
                    Object choose = await restaurant.GetRandomRestaurant();
                    ResultData.BindingContext = (Restaurant)choose;
                }
                catch(Exception e)
                {
                    await DisplayAlert("網路連線", "請連線網路後繼續", "確定");
                }
              
            }
            
        }
        public async void generateData(bool showActivityIndicator)
        {
            using (var scope = new ActivityIndicatorScope(syncIndicator, showActivityIndicator))
            {
                await restaurant.GenerateRandomData();
            }
        }
      
        private class ActivityIndicatorScope : IDisposable
        {
            private bool showIndicator;
            private ActivityIndicator indicator;
            private Task indicatorDelay;

            public ActivityIndicatorScope(ActivityIndicator indicator, bool showIndicator)
            {
                this.indicator = indicator;
                this.showIndicator = showIndicator;

                if (showIndicator)
                {
                    indicatorDelay = Task.Delay(2000);
                    SetIndicatorActivity(true);
                }
                else
                {
                    indicatorDelay = Task.FromResult(0);
                }
            }

            private void SetIndicatorActivity(bool isActive)
            {
                this.indicator.IsVisible = isActive;
                this.indicator.IsRunning = isActive;
                
            }

            public void Dispose()
            {
                if (showIndicator)
                {
                    indicatorDelay.ContinueWith(t => SetIndicatorActivity(false), TaskScheduler.FromCurrentSynchronizationContext());
                }
            }
        }
    }
}
