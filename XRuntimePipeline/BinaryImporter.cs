using System;
using System.IO;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using MonoGame.Framework;
using MonoGame.Framework.Content.Pipeline;

namespace XRuntimePipeline
{
    [ContentProcessor(DisplayName = "XRuntimePipeline.BinaryProcessor")]
    public class BinaryProcessor : ContentProcessor<BinaryContainer, BinaryContainer>
    {
        // Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
        public override BinaryContainer Process(BinaryContainer input, ContentProcessorContext context)
        {
            return input;
        }
    }
    // Token: 0x02000004 RID: 4
    [ContentImporter(".ccx", DisplayName = "XRuntimePipeline.BinaryImporter", DefaultProcessor = "BinaryProcessor")]
    public class BinaryImporter : ContentImporter<BinaryContainer>
    {
        // Token: 0x06000008 RID: 8 RVA: 0x000020C4 File Offset: 0x000002C4
        public override BinaryContainer Import(string filename, ContentImporterContext context)
        {
            return new BinaryContainer(filename);
        }
    }
    public class BinaryContainer
    {
        // Token: 0x0600000A RID: 10 RVA: 0x000020E4 File Offset: 0x000002E4
        public BinaryContainer(string filename)
        {
            FileStream fileStream = File.OpenRead(filename);
            int num = (int)fileStream.Length;
            this.data = new byte[num];
            fileStream.Read(this.data, 0, num);
            fileStream.Close();
        }

        // Token: 0x0600000B RID: 11 RVA: 0x0000212B File Offset: 0x0000032B
        public void write(ContentWriter output)
        {
            output.Write(this.data);
        }

        // Token: 0x04000001 RID: 1
        private byte[] data;
    }
    [ContentTypeWriter]
    public class BinaryWriter : ContentTypeWriter<BinaryContainer>
    {
        // Token: 0x06000003 RID: 3 RVA: 0x0000206B File Offset: 0x0000026B
        protected override void Write(ContentWriter output, BinaryContainer value)
        {
            value.write(output);
        }

        // Token: 0x06000004 RID: 4 RVA: 0x00002078 File Offset: 0x00000278
        public override string GetRuntimeReader(TargetPlatform targetPlatform)
        {
            return "BinaryRead.BinaryReader, BinaryRead, Version=1.0.0.0, Culture=neutral";
        }

        // Token: 0x06000005 RID: 5 RVA: 0x00002090 File Offset: 0x00000290
        public override string GetRuntimeType(TargetPlatform targetPlatform)
        {
            return "BinaryRead.BinaryReader, BinaryRead, Version=1.0.0.0, Culture=neutral";
        }

        // Token: 0x06000006 RID: 6 RVA: 0x000020A8 File Offset: 0x000002A8
        protected override bool ShouldCompressContent(TargetPlatform targetPlatform, object value)
        {
            return false;
        }
    }
}