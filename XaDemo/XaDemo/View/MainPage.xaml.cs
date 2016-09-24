using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XaDemo.View
{
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();
            FindBtn.Clicked += OnFindBtnClicked;
            
            CoverImage.Source = ImageSource.FromUri(new Uri("https://cdn2.iconfinder.com/data/icons/mixed-1st-volume/512/Food-128.png"));
         //   CoverImage.Aspect = Aspect.AspectFit;
        }
        private async void OnFindBtnClicked(object sender, EventArgs e)
        {
            // Page appearance not animated
            await Navigation.PushAsync(new RestaurantLayout(), true);
        }
    }
}
