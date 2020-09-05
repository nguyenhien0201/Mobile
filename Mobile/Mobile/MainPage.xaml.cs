using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void SetValue(string un, string pw)
        {
            Username.Text = un;
            Password.Text = pw;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if(Username.Text=="admin")
                App.Current.MainPage.Navigation.PushAsync(new DevicePage());
            else DisplayAlert("Mời đăng nhập lại", "Username: " + Username.Text + "\nPassword: " + Password.Text + "\n", "OK");
            
        }
    }
}
