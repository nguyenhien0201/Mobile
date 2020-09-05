using System;
using System.Collections.Generic;
using System.Mvc;
using System.Text;

namespace Mobile.Views.Device
{
    class Default: XamlRenderer<DevicePage,object>, IRootPage
    {
        public string Title => "Device List";
    }
}
