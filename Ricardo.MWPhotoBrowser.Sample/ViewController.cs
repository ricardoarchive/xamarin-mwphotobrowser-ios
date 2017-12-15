using System;
using UIKit;
using Ricardo.LibMWPhotoBrowser.iOS;
using System.Collections.Generic;
using Foundation;

namespace Ricardo.RMWPhotoBrowser.Sample
{
    public partial class ViewController : UIViewController, IMWPhotoBrowserDelegate
    {
        List<MWPhoto> photos;

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            InitPhotos();
        }

        partial void ShowGalleryButton_TouchUpInside(UIButton sender)
        {
            using (MWPhotoBrowser photoBrowser = new MWPhotoBrowser(this))
            {
                NavigationController.PushViewController(photoBrowser, true);
            }
        }

        private void InitPhotos()
        {
            photos = new List<MWPhoto>();
            var urls = new string[] {
                "https://communication.ricardo.ch/wp-content/uploads/2017/12/collage-tischdeko_1.jpg",
                "https://communication.ricardo.ch/wp-content/uploads/2017/12/header-image_festliche-Weihnachtsdeko.jpg",
                "https://communication.ricardo.ch/wp-content/uploads/2017/10/1Design.png" };

            foreach (string url in urls)
            {
                using (var nsurl = new NSUrl(url))
                {
                    photos.Add(MWPhoto.FromUrl(nsurl));
                }
            }
        }

		public MWPhoto GetPhoto(MWPhotoBrowser photoBrowser, nuint index) => photos[(int)index];
		
		public nuint NumberOfPhotosInPhotoBrowser(MWPhotoBrowser photoBrowser) => (nuint)photos.Count;
    }
}
