using System;
using System.Collections.Generic;
using System.Text;

namespace Mobile.Views.Device
{
    class Current : Renderer<string>, INavigationItemPage
    {
        public string Title => Model;

    }
}
