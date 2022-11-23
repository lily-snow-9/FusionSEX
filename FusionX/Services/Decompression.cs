//#define USE_IONIC
using System;
using System.IO;
using Ionic.Zlib;
using Joveler.Compression.ZLib;
using DeflateStream = Joveler.Compression.ZLib.DeflateStream;



namespace FusionX.Services
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
#if USE_IONIC
            return ZlibStream.UncompressBuffer(reader.readArray(size));
#else
            ZLibDecompressOptions decompOpts = new ZLibDecompressOptions();

            using (MemoryStream fsComp = new MemoryStream(reader.readArray(size)))
            using (MemoryStream fsDecomp = new MemoryStream())
            using (ZLibStream zs = new ZLibStream(fsComp, decompOpts))
            {
                zs.CopyTo(fsDecomp);
                var newData = fsDecomp.GetBuffer();
                Array.Resize<byte>(ref newData, decompSize);
                return newData;
            }
#endif
            // Trimming array to decompSize,
            // because ZlibStream always pads to 0x100

        }

        public static byte[] DecompressBlock(CFile reader, int size)
        {
#if USE_IONIC
            return ZlibStream.UncompressBuffer(reader.readArray(size));

#else
            ZLibDecompressOptions decompOpts = new ZLibDecompressOptions();

            using (MemoryStream fsComp = new MemoryStream(reader.readArray(size)))
            using (MemoryStream fsDecomp = new MemoryStream())
            using (ZLibStream zs = new ZLibStream(fsComp, decompOpts))
            {
                zs.CopyTo(fsDecomp);
                var newData = fsDecomp.GetBuffer();
                return newData;
            }
#endif
        }




    }
}