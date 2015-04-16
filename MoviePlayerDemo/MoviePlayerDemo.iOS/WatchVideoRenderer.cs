using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;

using MoviePlayerDemo;
using MoviePlayerDemo.iOS;

using UIKit;

using Xamarin.Forms;

[assembly: ExportRenderer(typeof(WatchVideo), typeof(WatchVideoRenderer))]

namespace MoviePlayerDemo.iOS
{
    using CoreGraphics;
    using MediaPlayer;
    using Xamarin.Forms.Platform.iOS;

    class WatchVideoRenderer : PageRenderer
    {
        MPMoviePlayerController moviePlayer;

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            var url =  new NSUrl("http://192.168.12.4:8085/MediaUploads/1/211/520140731170618/DPM202.mp4");
            moviePlayer = new MPMoviePlayerController();
            moviePlayer.ContentUrl = url;
            moviePlayer.View.Frame = new CGRect((float)((NativeView.Bounds.Width - 600) / 2), (float)((NativeView.Bounds.Height - 450) / 2), 600, 400);

            MPMoviePlayerController.Notifications.ObserveLoadStateDidChange(OnLoadStateChanged);
            MPMoviePlayerController.Notifications.ObservePlaybackDidFinish(OnPlaybackComplete);

            View.AddSubview(moviePlayer.View);
            
            moviePlayer.PrepareToPlay();
            moviePlayer.ShouldAutoplay = true;
            moviePlayer.Play();
        }

        private void OnLoadStateChanged(object sender, NSNotificationEventArgs e)
        {
            if (moviePlayer.LoadState == MPMovieLoadState.Playable)
            {
               
            }
        }

        private void OnPlaybackComplete(object sender, MPMoviePlayerFinishedEventArgs e)
        {
           
        }
    }
}