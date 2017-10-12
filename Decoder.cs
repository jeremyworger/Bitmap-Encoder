using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitmap_Encoder
{
    class Decoder
    {
        public static void Decode(string file, Bitmap data)
        {
            int x = data.Width, y = data.Height;

            List<byte> bytes = new List<byte>(x * y);
            
            for (int j = y; j-- > 0;)
            {
                for (int i = 0; i < x; i++)
                {
                    var pix = data.GetPixel(i, j);
                    bytes.Add(pix.B);
                    bytes.Add(pix.G);
                    bytes.Add(pix.R);
                }
            }
            File.WriteAllBytes(file, bytes.Skip(4).ToArray());            
        }
    }
}
