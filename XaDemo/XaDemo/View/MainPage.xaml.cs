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
		}
        private async void OnFindBtnClicked(object sender, EventArgs e)
        {
            // Page appearance not animated
            await Navigation.PushAsync(new RestaurantLayout(), true);
        }
    }
}
