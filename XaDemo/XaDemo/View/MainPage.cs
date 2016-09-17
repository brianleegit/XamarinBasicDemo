using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace XaDemo.View
{
	public class MainPage : ContentPage
	{
        public MainPage()
        {
            Xamarin.Forms.Label header = new Xamarin.Forms.Label
            {
                Text = "Welcome",
                TextColor = Color.Blue,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Xamarin.Forms.Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            Button button = new Button
            {
                Text = "Click Me!",
                Font = Font.SystemFontOfSize(NamedSize.Large),
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            button.Clicked += goToDetail;
            Xamarin.Forms.Label label = new Xamarin.Forms.Label
            {
                Text = "Find Restaurant!",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Xamarin.Forms.Label)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            // Accomodate iPhone status bar.
            //this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            this.Content = new StackLayout
            {
                Children =
                {
                    header,
                    button,
                    label
                }
            };

        }

        async void goToDetail(object sender, EventArgs e)
        {
            // await Navigation.PushAsync(new View.RestaurantPage());
            await Navigation.PushAsync(new View.RestaurantLayout());
        }
    }
}
