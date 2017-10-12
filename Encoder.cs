using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitmap_Encoder
{
    public class Encoder
    {

        static int GuessSize(int size)
        {
            return (int)Math.Ceiling(Math.Sqrt(RoundThree(size) / 3));            
        }

        static int RoundThree(int size)
        {
            return size + (size % 3 == 0 ? 0 : 3 - size % 3);
        }

        public static void Encode(string bitmap, byte[] data)
        {
            int size = GuessSize(data.Length);
            Array.Resize(ref data, size * size * 3);
            
           
            using (Bitmap image = new Bitmap(size, size, PixelFormat.Format24bppRgb))
            {

                int iter = 0;
                for (int j = size; j-- > 0;)
                {
                    for (int i = 0; i < size; i++)
                    {
                        byte a = data[iter++], b = data[iter++], c = data[iter++];
                        image.SetPixel(i, j, Color.FromArgb(c, b, a));
                    }
                }

                image.Save(bitmap, ImageFormat.Bmp);
            }
        }


    }
}
