using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace sflistviewimageissue.Helpers
{
    public static class ImagesHelper
    {

        //private static ImageInfoRepository _imagesRepo;

        public static Dictionary<int, string> AccountImagesDictionary = new Dictionary<int, string>()
        {
            { 0,"empty" },
            { 1,"cash" },
            { 2, "bank" }
        };

    }
}
