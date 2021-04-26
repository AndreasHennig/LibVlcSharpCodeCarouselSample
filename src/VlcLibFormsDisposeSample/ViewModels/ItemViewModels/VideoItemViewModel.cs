using System;
using System.Diagnostics;
using LibVLCSharp.Shared;
using MvvmHelpers;

namespace VlcLibFormsDisposeSample.ViewModels.ItemViewModels
{
    public class VideoItemViewModel : BaseViewModel
    {
        readonly LibVLC libVlcBackingStore;
        readonly string videoUri;

        private LibVLC libVLC;
        public LibVLC LibVLC
        {
            get => libVLC;
            private set => SetProperty(ref libVLC, value);
        }

        private MediaPlayer mediaPlayer;
        public MediaPlayer MediaPlayer
        {
            get => mediaPlayer;
            private set => SetProperty(ref mediaPlayer, value);
        }

        public VideoItemViewModel(string title, string videoUri, LibVLC libVLC)
        {
            Title = title;
            this.videoUri = videoUri;
            this.libVlcBackingStore = libVLC;
        }

        public void Setup()
        {
            Debug.WriteLine($"Setup {Title}");

            LibVLC = libVlcBackingStore;

            var media = new Media(LibVLC, new Uri(videoUri));

            MediaPlayer = new MediaPlayer(media) { EnableHardwareDecoding = true };
            media.Dispose();
            MediaPlayer.Play();
        }

        public void TearDown()
        {
            Debug.WriteLine($"Tear down {Title}");

            LibVLC = null;
            MediaPlayer.Dispose();
        }
    }
}
