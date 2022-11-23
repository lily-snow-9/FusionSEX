//----------------------------------------------------------------------------------
//
// CFILE : chargement des fichiers dans le bon sens
//
//----------------------------------------------------------------------------------

using System;
using System.IO;

namespace FusionX.Services
{
    public class CFile
    {
 
        public bool bUnicode=true;
        public BinaryReader reader;

        public CFile()
        {
        }
        public CFile(CFile file)
        {
            //data = file.data;
            //pointer = 0;
        }
        public CFile(byte[] dt)
        {
            reader = new BinaryReader(new MemoryStream(dt));
        }
        public CFile(CFile source, int length)
        {
            /*data = new byte[length];
            int n;
            for (n = 0; n < length; n++)
            {
                data[n] = source.data[source.pointer + n];
            }
            source.pointer += n;
            bUnicode = source.bUnicode;*/
        }
        public bool isEOF()
        {
            return reader.BaseStream.Position >= reader.BaseStream.Length;
        }


       

        public int readUnsignedByte()
        {
            return reader.ReadByte();
        }

        

        public byte readByte()
        {

            return reader.ReadByte();
        }
        public byte[] readArray()
        {
            return reader.ReadBytes((int)(reader.BaseStream.Length-reader.BaseStream.Position));
        }
        public byte[] readArray(int size)
        {
            return reader.ReadBytes(size);
        }

        public int read(byte[] dest, int size)
        {
            int n;
            var newData = reader.ReadBytes(size);
            for (n = 0; n < size; n++)
            {
                dest[n] = newData[n];
            }
            return n;
        }

        public int read(byte[] dest)
        {
            int n;
            var newData = reader.ReadBytes(dest.Length);
            for (n = 0; n < dest.Length; n++)
            {
                dest[n] = newData[n];
            }
            return n;
        }

        public void skipBytes(int n)
        {
            reader.BaseStream.Position += n;
        }

        public void skipBack(int n)
        {
            reader.BaseStream.Position -= n;
        }

        public void seek(int pos)
        {
            reader.BaseStream.Seek(pos,SeekOrigin.Begin);
        }
 
        public int getFilePointer()
        {
            return (int)reader.BaseStream.Position;
        }

        public void setUnicode(bool unicode)
        {
            bUnicode = unicode;
        }

        public byte readAByte()
        {
            return reader.ReadByte();
        }

        public short readAShort()
        {
            return reader.ReadInt16();
        }

        public char readAChar()
        {
            return Convert.ToChar(reader.ReadInt16());
        }

        public void readAChar(char[] b) 
        {
            int b1, b2;
            int n;
            for (n=0; n<b.Length; n++)
            {
                b[n] = readAChar();
            }
        }

        public int readAInt()
        {
            return reader.ReadInt32();
        }

        public int readAColor()
        {
            int b1, b2, b3;
            b1 = readUnsignedByte();
            b2 = readUnsignedByte();
            b3 = readUnsignedByte();
            readUnsignedByte();
            return b1 * 0x00010000 + b2 * 0x00000100 + b3;
        }

        public float readAFloat()
        {

            return reader.ReadSingle();
        }

        public double readADouble()
        {

            return reader.ReadDouble();
        }

        public string readAString(int size)
        {
            if (bUnicode==false)
            {
                byte[] b = new byte[size];
                read(b);
                int n;
                for (n = 0; n < size; n++)
                {
                    if (b[n] == 0)
                    {
                        break;
                    }
                }
                int m;
                char[] bb = new char[n];
                for (m = 0; m < n; m++)
                {
                    bb[m] = (char)b[m];
                }
                return new String(bb, 0, n);
            }
            else
            {
                char[] b=new char[size];
                readAChar(b);
                int n;
                for (n=0; n<size; n++)
                {
                    if (b[n]==0)
                    {
                        break;
                    }
                }
                int m;
                char[] bb=new char[n];
                for (m=0; m<n; m++)
                {
                    bb[m]=b[m];
                }
                return new String(bb, 0, n);
            }
        }

        public String readAString()
        {
            string ret = "";
            int debut = getFilePointer();
            if (bUnicode == false)
            {
                int b;
                do
                {
                    b = readUnsignedByte();
                } while (b != 0);
                int end = getFilePointer();
                seek(debut);
                if (end >= debut + 2)
                {
                    int l = (int)(end - debut - 1);
                    char[] c = new char[l];
                    int n;
                    for (n = 0; n < l; n++)
                    {
                        c[n] = (char)readUnsignedByte();
                    }
                    ret = new String(c, 0, l);
                }
                skipBytes(1);
            }
            else
            {
                char b;
                do
                {
                    b = readAChar();
                } while (b != 0);
                int end = getFilePointer();
                seek(debut);
                if (end >= debut + 2)
                {
                    int l = (int)(end - debut - 2) / 2;
                    char[] c = new char[l];
                    readAChar(c);
                    ret = new String(c, 0, l);
                }
                skipBytes(2);
            }
            return ret;
        }

        public String readAStringEOL()
        {
            int debut = getFilePointer();
            String ret = "";

            if (bUnicode==false)
            {
                int b = readUnsignedByte();
                while (b != 10 && b != 13)
                {
                    if (isEOF())
                    {
                        break;
                    }
                    b = readUnsignedByte();
                }
                int end = getFilePointer();
                seek(debut);
                int delta = 1;
                if (b != 10 && b != 13)
                {
                    delta = 0;
                }
                if (end > debut + delta)
                {
                    int l = (int)(end - debut - delta);
                    char[] c = new char[l];
                    int n;
                    for (n = 0; n < l; n++)
                    {
                        c[n] = (char)readUnsignedByte();
                    }
                    ret = new String(c, 0, c.Length);
                }
                if (b == 10 || b == 13)
                {
                    skipBytes(1);
                    int bb = readUnsignedByte();
                    if (b == 10 && bb != 13)
                    {
                        skipBack(1);
                    }
                    if (b == 13 && bb != 10)
                    {
                        skipBack(1);
                    }
                }
            }
            else
            {
                char b = readAChar();
                while (b != 10 && b != 13)
                {
                    if (isEOF())
                    {
                        break;
                    }
                    b = readAChar();
                }
                int end = getFilePointer();
                seek(debut);
                int delta = 2;
                if (b != 10 && b != 13)
                {
                    delta = 0;
                }
                if (end > debut + delta)
                {
                    int l=(int) (end - debut - delta)/2;
                    char[] c = new char[l];
                    readAChar(c);
                    ret = new String(c, 0, c.Length);
                }
                if (b == 10 || b == 13)
                {
                    skipBytes(2);
                    char bb = readAChar();
                    if (b == 10 && bb != 13)
                    {
                        skipBack(2);
                    }
                    if (b == 13 && bb != 10)
                    {
                        skipBack(2);
                    }
                }
            }
            return ret;
        }

        public void skipAString()
        {
            if (bUnicode==false)
            {
                int b;
                do
                {
                    b = readUnsignedByte();
                } while (b != 0);
            }
            else
            {
                int b;
                do
                {
                    b = readAShort();
                } while (b != 0);
            }
        }

        public CFontInfo readLogFont()
        {
            CFontInfo info = new CFontInfo();

            info.lfHeight = readAInt();
            if (info.lfHeight < 0)
            {
                info.lfHeight = -info.lfHeight;
            }
            skipBytes(12);	// width - escapement - orientation
            info.lfWeight = readAInt();
            info.lfItalic = (byte)readAByte();
            info.lfUnderline = (byte)readAByte();
            info.lfStrikeOut = (byte)readAByte();
            skipBytes(5);
            info.lfFaceName = readAString(32);

            return info;
        }

        public CFontInfo readLogFont16()
        {
            CFontInfo info = new CFontInfo();

            info.lfHeight = readAShort();
            if (info.lfHeight < 0)
            {
                info.lfHeight = -info.lfHeight;
            }
            skipBytes(6);	// width - escapement - orientation
            info.lfWeight = readAShort();
            info.lfItalic = (byte)readAByte();
            info.lfUnderline = (byte)readAByte();
            info.lfStrikeOut = (byte)readAByte();
            skipBytes(5);
            bool oldUnicode = bUnicode;
            bUnicode = false;
            info.lfFaceName = readAString(32);
            bUnicode = oldUnicode;

            return info;
        }
    }
}
