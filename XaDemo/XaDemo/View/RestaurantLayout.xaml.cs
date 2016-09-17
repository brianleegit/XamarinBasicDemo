using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XaDemo.Data;
using Xamarin.Forms;

namespace XaDemo.View
{
	public partial class RestaurantLayout : ContentPage
	{
		public RestaurantLayout ()
		{
			InitializeComponent ();
            // Restaurant_name.Text = "麥當勞";

            // 測試資料
            List<Restaurant> Restaurant = new List<Restaurant> {
                new Restaurant ("麥當勞", "高雄市鹽埕區大勇路120號", "經營多年的經典快餐連鎖店，主營漢堡，薯條和奶昔。","速食餐廳"),
                new Restaurant ("麥當勞2", "高雄市鹽埕區大勇路121號", "經營多年的經典快餐連鎖店，主營漢堡，薯條和奶昔。","速食餐廳")
            };
            var rand = new Random();
            var user = Restaurant[rand.Next(Restaurant.Count)];
            Restaurant_name.Text = user.Name;
            Restaurant_type.Text = user.Type;
            Restaurant_location.Text = user.Location;
            Restaurant_note.Text = user.Description;

            // Restaurant_img.Source = ImageSource.FromUri(new Uri("http://i.imgur.com/0j3D4Gp.png"));
            Restaurant_img.Source = ImageSource.FromFile("test.jpg");
        }
	}
}
