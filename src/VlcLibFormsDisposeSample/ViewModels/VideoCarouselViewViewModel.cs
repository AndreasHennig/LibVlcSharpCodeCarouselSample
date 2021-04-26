using System.Collections.Generic;
using System.Windows.Input;
using LibVLCSharp.Shared;
using MvvmHelpers;
using MvvmHelpers.Commands;
using VlcLibFormsDisposeSample.ViewModels.ItemViewModels;

namespace VlcLibFormsDisposeSample.ViewModels
{
    public class VideoCarouselViewViewModel : BaseViewModel
    {
        private IEnumerable<VideoItemViewModel> videos;
        private VideoItemViewModel currentItem;

        public IEnumerable<VideoItemViewModel> Videos
        {
            get => videos;
            set => videos = value;
        }

        public VideoItemViewModel CurrentItem
        {
            get => currentItem;
            private set => SetProperty(ref currentItem, value);
        }

        public ICommand ItemChanged { get; }

        public VideoCarouselViewViewModel()
        {
            ItemChanged = new Command<VideoItemViewModel>(ItemChangedImpl);

            var libVlc = new LibVLC();

            Videos = new List<VideoItemViewModel>
            {
                new VideoItemViewModel("Video A", "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4", libVlc),
                new VideoItemViewModel("Video B", "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4", libVlc),
                new VideoItemViewModel("Video C", "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4", libVlc),
                new VideoItemViewModel("Video D", "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4", libVlc),
            };
        }

        private void ItemChangedImpl(VideoItemViewModel videoItemViewModel)
        {
            CurrentItem?.TearDown();

            videoItemViewModel.Setup();
            CurrentItem = videoItemViewModel;
        }
    }
}
