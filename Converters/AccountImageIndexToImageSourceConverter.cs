using sflistviewimageissue.Helpers;
using sflistviewimageissue.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sflistviewimageissue.Converters
{
    public class AccountImageIndexToImageSourceConverter : IValueConverter
    {
        #region Constructor

        GlobalDataRepository _imagesRepo;

        #endregion

        #region Convert

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (_imagesRepo == null)
            {
                GlobalDataRepository imagesRepo = ServiceHelper.Current.GetService<GlobalDataRepository>();
                _imagesRepo = imagesRepo;
            }

            if (!(value is int))
            {
                return null;
            }

            int imageIndex = (int)value;

            ImageSource result = null;

            if (ImagesHelper.AccountImagesDictionary.ContainsKey(imageIndex))
            {
                string imageName = ImagesHelper.AccountImagesDictionary[imageIndex];
                result = $"{imageName}.png";
            }
            else if (_imagesRepo != null)
            {
                byte[] imageData = null;

                imageData = _imagesRepo.GetImageData(imageIndex);

                result = ImageSource.FromStream(() => new MemoryStream(imageData));


            }
            //else if (_imagesRepo is not null && _imagesRepo.AccountImages.Any(i => i.ImageIndex == imageIndex))
            //{
            //    result = _imagesRepo.AccountImages.First(i => i.ImageIndex == imageIndex).ImageSource;
            //}

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        #endregion
    }
}
