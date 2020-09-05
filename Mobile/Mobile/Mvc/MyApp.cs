using System;
using System.Collections.Generic;
using System.Text;
using System.Mvc;
using Xamarin.Forms;

namespace Mobile
{
    class MyApp : Engine
    {
        public static void Init(Application app)
        {
            Register(app, result =>
            {
                var view = (IRenderer)result.View;
                var page = (Page)view.GetResult();
                if (view is INavigationItemPage)
                {
                    page.Title = ((INavigationItemPage)view).Title;
                    if (view is IRootPage)
                    {
                        page = new NavigationPage(page);
                    }
                    else
                    {
                        app.MainPage.Navigation.PushAsync(page);
                        return;
                    }
                }
                app.MainPage = page;
            });
        }
    }
}
