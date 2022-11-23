using System;

namespace FusionX.Banks;

public static class ImageHelper
{
    static int GetPadding(int width, int pointSize, int bytes = 2)
    {
        int pad = bytes - ((width * pointSize) % bytes);
        if (pad == bytes)
        {
            return 0;
        }

        return (int)Math.Ceiling((double)((float)pad / (float)pointSize));
    }
    public static byte[] TranslateImage(int width,int height, byte[] imageData,byte[] trans)
    {
        byte[] result = new byte[4 * width * height];
        int stride = width * 4;
        int pad = GetPadding(width, 3);
        int position = 0;
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                int newPos = (y * stride) + (x * 4);
                result[newPos + 0] = imageData[position + 2];
                result[newPos + 1] = imageData[position + 1];
                result[newPos + 2] = imageData[position + 0];
                result[newPos + 3] = 255;
                if (true)//!alpha)
                {
                    
                    byte d1 = imageData[position];
                    byte d2 = imageData[position + 1];
                    byte d3 = imageData[position + 2];
                    byte t1 = trans[0];
                    byte t2 = trans[1];
                    byte t3 = trans[2];
                    if (d3 == t1 && d2 == t2 && d1 == d3)
                    {
                        result[newPos + 3] = 0;
                        result[newPos + 2] = 0;
                        result[newPos + 1] = 0;
                        result[newPos + 0] = 0;
                    }
                }
                position += 3;
            }

            position += pad * 3;
        }

        return result;
    }
    
}