using FFImageLoading.Svg.Maui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sflistviewimageissue.CustomControls
{
    public class CustomImage : ContentView
    {
        public static readonly BindableProperty SourceProperty = BindableProperty.Create(nameof(Source), typeof(ImageSource), typeof(CustomImage));

        public ImageSource Source
        {
            get => (ImageSource)GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }

        public CustomImage()
        {
            if (DeviceInfo.Platform == DevicePlatform.Android || DeviceInfo.Platform == DevicePlatform.iOS)
            {
                //On Android, add SvgCacheImage
                var image = new SvgCachedImage();
                image.SetBinding(SvgCachedImage.SourceProperty, new Binding(nameof(Source), source: this));

                this.Content = image;
            }
            else
            {
                //On all other add Image
                var image = new Image();
                image.SetBinding(Image.SourceProperty, new Binding(nameof(Source), source: this));
                this.Content = image;
            }
        }

    }
}
