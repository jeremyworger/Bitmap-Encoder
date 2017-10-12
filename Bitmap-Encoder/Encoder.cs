using System;
using System.Collections.Generic;
using System.IO;
using SixLabors.ImageSharp;
using System.Text;
using SixLabors.ImageSharp.PixelFormats;

namespace Bitmap_Encoder
{
    public class Encoder
    {

        (int x, int y) GuessSize(int size)
        {
            size = RoundThree(size) / 3;
            size = (int) Math.Ceiling(Math.Sqrt(size));
            return (size, size);
        }

        int RoundThree(int size)
        {
            return size + (size % 3 == 0 ? 0 : 3 - size % 3);
        }

        public void Encode(string bitmap, byte[] data)
        {
            (int x, int y) = GuessSize(data.Length);
            Array.Resize(ref data, x * y * 3);

            using (Image<Rgb24> image = new Image<Rgb24>(x, y))
            {
                int iter = 0;
                for (int j = y; j-- > 0;)
                {
                    for (int i = 0; i < x; i++)
                    {
                        byte a = data[iter++], b = data[iter++], c = data[iter++];
                        image[i, j] = new Rgb24(c, b, a);
                    }
                }

                image.Save(bitmap);
            }
        }


    }
}
