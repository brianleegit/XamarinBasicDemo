using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XaDemo.Data;
using Xamarin.Forms;
using XaDemo.Services;

namespace XaDemo.View
{
	public partial class RestaurantLayout : ContentPage
	{
        RestaurantManager restaurant;

        public RestaurantLayout ()
		{
			InitializeComponent ();
            // Restaurant_name.Text = "麥當勞";

            // 測試資料
            //list<restaurant> restaurant = new list<restaurant> {
            //    new restaurant ("麥當勞", "高雄市鹽埕區大勇路110號", "經營多年的經典快餐連鎖店，主營漢堡，薯條和奶昔。","速食餐廳"),
            //    new restaurant ("麥當勞2", "高雄市鹽埕區大勇路111號", "經營多年的經典快餐連鎖店，主營漢堡，薯條和奶昔。","速食餐廳")
            //};
            //var rand = new random();
            //var user = restaurant[rand.next(restaurant.count)];

            restaurant = new RestaurantManager();
            //HI  
            generateData(true);
            //Restaurant_name.Text = user.Name;
            //Restaurant_type.Text = user.Type;
            //Restaurant_location.Text = user.Location;
            //Restaurant_note.Text = user.Description;


            Restaurant_img.Source = ImageSource.FromUri(new Uri("http://i.imgur.com/0j3D4Gp.png"));
            
            //Restaurant_img.Aspect = Aspect.AspectFit;
            //Restaurant_img.Source = ImageSource.FromFile("mac.png");
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
