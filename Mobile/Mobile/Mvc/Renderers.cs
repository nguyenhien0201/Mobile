using System;
using System.Collections.Generic;
using System.Text;
using System.Mvc;
using Xamarin;
using Xamarin.Forms;

namespace Mobile
{
    interface INavigationItemPage
    {
        string Title { get; }
    }
    interface IRootPage : INavigationItemPage
    {
    }

    class XamlRenderer<TPage, TModel> : System.Mvc.Renderer<TPage, TModel>
        where TPage: Page, new()
    {
        public override object GetResult()
        {
            return MainContent;
        }
    }
    class Renderer<TModel> : System.Mvc.Renderer<MyTableLayout, TModel>
    {
        public override object GetResult()
        {
            return new ContentPage { Content = MainContent };
        }
    }
}
