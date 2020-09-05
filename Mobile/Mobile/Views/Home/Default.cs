using System;
using System.Collections.Generic;
using System.Mvc;
using System.Text;
using Xamarin.Forms;

namespace Mobile.Views.Home
{
    class Default : Renderer<object>
    {

        public override void Render(Controller controller)
        {
            base.Render(controller);

            var un = new Entry()
            {
                Placeholder = "Nhập tên người dùng",
                ClassId = "Username"
            };

            var pw = new Entry()
            {
                Placeholder = "Nhập mật khẩu",
                IsPassword = true,
                ClassId = "Password"
            };

            Button btn = new Button()
            {
                Text = "Đăng nhập",
                BackgroundColor = Color.FromHex("#0c0"),
            };
            btn.Clicked += (s, e) =>
            {
                MyApp.Execute("Device");
            };

            MainContent.Add(new StackLayout {
                Margin = new Thickness(30),
                VerticalOptions = LayoutOptions.Center,
                Children = { un, pw, btn },
            });
            
            //MainContent.AddRow(un);
            //MainContent.AddRow(pw);
            //MainContent.AddRow(btn);

        }
    }
}
