using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using Ionic.Zlib;
using RuntimeXNA.Services;
using ZLibStream = System.IO.Compression.ZLibStream;


namespace CTFAK.Memory
{
    public static class Decompressor
    {

        public static byte[] Decompress(CFile exeReader, out int decompressed)
        {
            Int32 decompSize = exeReader.readAInt();
            Int32 compSize = exeReader.readAInt();
            decompressed = decompSize;
            return DecompressBlock(exeReader, compSize, decompSize);
        }

        public static CFile DecompressAsReader(CFile exeReader, out int decompressed) =>
            new CFile(Decompress(exeReader, out decompressed));

        public static byte[] DecompressBlock(CFile reader, int size, int decompSize)
        {
            var newData = ZlibStream.UncompressBuffer(reader.readArray(size));
            // Trimming array to decompSize,
            // because ZlibStream always pads to 0x100
            Array.Resize<byte>(ref newData, decompSize);
            return newData;
        }

        public static byte[] DecompressBlock(CFile reader, int size)
        {
            // We have no original size, so we are gonna just leave everything as is
            return ZlibStream.UncompressBuffer(reader.readArray(size));
        }




    }
}