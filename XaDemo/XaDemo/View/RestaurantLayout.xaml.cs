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

            ResultData.BindingContext = new Restaurant();   //初始化欄位"loading..."
            restaurant = new RestaurantManager();   //初始化
     
            showRestaurant();   //讀取並顯示餐廳資料
        }
        public async void showRestaurant()
        {
            using (var scope = new ActivityIndicatorScope(syncIndicator, true))     //跑loading圈圈
            {
                try
                {
                    Restaurant_img.Source = ImageSource.FromFile("hourglass.png");  //顯示出loading圖片(沙漏)
                    
                    Object choose = await restaurant.GetRandomRestaurant();     //從資料庫隨機抓取一筆資料
                    if (choose == null)   //防呆
                    {
                        await DisplayAlert("找不到學校", "找不到學校QAQQQQQ", "確定");
                        Navigation.RemovePage(Navigation.NavigationStack[1]);
                    }
                    ResultData.BindingContext = (Restaurant)choose;             //傳入資料
                    Restaurant_img.Source = ImageSource.FromUri(new Uri(((Restaurant)choose).Image));   //從網路載入圖片
                    Restaurant_img.Aspect = Aspect.AspectFit;                   //使圖片符合介面大小
                   
                }
                //例外處理
                catch      
                {
                    await DisplayAlert("網路連線", "請連線網路後繼續", "確定");
                    Navigation.RemovePage(Navigation.NavigationStack[1]);
                }
              
            }
         
        }
               
      /*  public async void generateData(bool showActivityIndicator)
        {
            using (var scope = new ActivityIndicatorScope(syncIndicator, showActivityIndicator))
            {
                await restaurant.GenerateRandomData();
            }
        }
      */

        //控制loading圈圈
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
