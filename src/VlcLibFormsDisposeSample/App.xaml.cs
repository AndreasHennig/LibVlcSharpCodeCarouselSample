using VlcLibFormsDisposeSample.Views;
using Xamarin.Forms;

namespace VlcLibFormsDisposeSample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            LibVLCSharp.Shared.Core.Initialize();

            MainPage = new VideoCarouselView();
        }
    }
}
