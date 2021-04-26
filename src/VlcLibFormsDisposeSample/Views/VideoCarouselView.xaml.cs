using VlcLibFormsDisposeSample.ViewModels;

namespace VlcLibFormsDisposeSample.Views
{
    public partial class VideoCarouselView
    {
        public VideoCarouselView()
        {
            InitializeComponent();

            BindingContext = new VideoCarouselViewViewModel();
        }
    }
}
