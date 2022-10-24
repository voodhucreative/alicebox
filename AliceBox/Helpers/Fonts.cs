using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AliceBox.Helpers
{
    public static class Fonts
    {
        public enum FontName
        {
            TypeWriterRegular,
            TypeWriterBold
        }
        static Dictionary<FontName, string> fontDictionary;

        public static void Init()
        {
            if (Device.RuntimePlatform == Device.Android)
            {
                fontDictionary = new Dictionary<FontName, string>
                {
                    [FontName.TypeWriterRegular] = "XTypewriter-Regular.ttf#XTypewriter-Regular",
                    [FontName.TypeWriterBold] = "XTypewriter-Bold.ttf#XTypewriter-Bold"
                };
            }
            else if (Device.RuntimePlatform == Device.iOS)
            {
                fontDictionary = new Dictionary<FontName, string>
                {
                    [FontName.TypeWriterRegular] = "XTypewriter-Regular",
                    [FontName.TypeWriterBold] = "XTypewriter-Bold"
                };
            }
        }

        public static string GetFont(FontName font)
        {
            return fontDictionary[font];
        }

        public static string GetRegularAppFont()
        {
            return GetFont(FontName.TypeWriterRegular);
        }

        public static string GetBoldAppFont()
        {
            return GetFont(FontName.TypeWriterBold);
        }
    }
}

