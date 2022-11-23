using System;
using System.Runtime.InteropServices;
using FusionX.Services;

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
    public static byte[] TranslateImage(int width,int height, byte[] imageData,int trans, bool alpha)
    {
        byte[] colorArray = null;
        colorArray = new byte[width * height * 4];

        IntPtr resultAllocated = Marshal.AllocHGlobal(width * height * 4);
        IntPtr imageAllocated = Marshal.AllocHGlobal(imageData.Length);
        Marshal.Copy(imageData, 0, imageAllocated, imageData.Length);

        NativeLib.ReadPoint(resultAllocated, width, height, alpha ? 1 : 0,
            imageData.Length, imageAllocated, trans);
        Marshal.Copy(resultAllocated, colorArray, 0, colorArray.Length);
        Marshal.FreeHGlobal(resultAllocated);
        Marshal.FreeHGlobal(imageAllocated);
        return colorArray;
    }
    
}