using Microsoft.Xna.Framework.Content;

namespace FusionX;

public class BinaryRead
{
    public class Data
    {
        // Token: 0x06000004 RID: 4 RVA: 0x00002084 File Offset: 0x00000284
        public void Read(ContentReader input)
        {
            int count = (int)input.BaseStream.Length;
            this.data = input.ReadBytes(count);
        }

        // Token: 0x04000001 RID: 1
        public byte[] data;
    }
    public class BinaryReader : ContentTypeReader<Data>
    {
        // Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
        protected override Data Read(ContentReader input, Data data)
        {
            Data data2 = new Data();
            data2.Read(input);
            return data2;
        }
    }
}