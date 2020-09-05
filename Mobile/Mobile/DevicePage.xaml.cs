using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile
{
    public class DeviceView : Frame
    {
        Label _caption;
        StackLayout _content;

        public string Caption
        {
            get => _caption.Text;
            set => _caption.Text = value;
        }
        public DeviceView()
        {
            _caption = new Label() { Margin = new Thickness(0, 0, 0, 7) };
            _content = new StackLayout() { Orientation = StackOrientation.Horizontal };

            var sp = new StackLayout()
            {
                Children = { _caption, _content },
            };
            var btn = new Button {
                BackgroundColor = Color.Transparent,
            };
            btn.Clicked += (s, e) => {
                MyApp.Execute("device/current", _caption.Text);
            };


            Margin = new Thickness(20,10);
            HeightRequest = 50;

            this.Content = new Grid { Children = { sp, btn } };
           
        }
        public void CreateSignal(string type, string text)
        {
            var sn = new SignalView(type, text);
            _content.Children.Add(sn);
        }
    }
    public class SignalView: StackLayout
    {
        public SignalView(string type, string text)
        {  
            Orientation = StackOrientation.Horizontal;
            this.Children.Add(new Led(type));
            this.Children.Add(new Label { Text = text });
            Margin = new Thickness(0, 0, 20,0);
        }
    }
    public class Led: BoxView
    {

        public Led(string type)
        {
            WidthRequest = HeightRequest = 15;
            CornerRadius = HeightRequest / 2;
            VerticalOptions = LayoutOptions.Center;
            Color = type == "IN" ? Color.FromHex("#c00") : Color.FromHex("#0c0");
            Margin = new Thickness(0, 0, 2,0);

            DevicePage.Leds.Add(this);

        }
        double _opac = 0.1;
        public void Blink()
        {
            var opac = this.Opacity + _opac;
            if (opac > 1)
            {
                opac = 1;
                _opac = -_opac;
            }
            if (opac < 0.3)
            {
                opac = 0.3;
                _opac = -_opac;
            }
            this.Opacity = opac;
        }
    }
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DevicePage : ContentPage
    {
        static List<Led> _leds;
        internal static List<Led> Leds
        {
            get
            {
                if (_leds == null)
                    _leds = new List<Led>();
                return _leds;
            }
        }
        
        public DevicePage()
        {
            InitializeComponent();

            var content = new StackLayout();
            for(int i=0; i<15; i++)
            {
                var dv = new DeviceView
                {
                    Caption = "Device " + (i + 1)
                };
                dv.CreateSignal("IN", "INPUT-0");
                dv.CreateSignal("OUT", "OUTPUT-0");
                //dv.GestureRecognizers.Add(new TapGestureRecognizer()
                //{
                //    Command = new Command(() => { Console.WriteLine("clicked"); })
                //});
                content.Children.Add(dv);
            }
            this.Content = new ScrollView() { Content = content };
            this.BackgroundColor = Color.FromHex("#80aaff");
            Device.StartTimer(TimeSpan.FromMilliseconds(50), () =>
            {
                foreach (var led in Leds)
                {
                    led.Blink();
                }
                return true;
            });
        }
    }
}