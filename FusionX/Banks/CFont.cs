//----------------------------------------------------------------------------------
//
// CFONT : une fonte
//
//----------------------------------------------------------------------------------

using System;
using FusionX.Application;
using FusionX.Services;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpriteFontPlus;

namespace FusionX.Banks
{
    public class CFont
    {
        public short useCount = 0;
        public short handle = 0;
        public int lfHeight = 0;
        public byte lfItalic = 0;
        public int lfWeight = 0;
        public string lfFaceName = null;
        public DynamicSpriteFont spriteFont=null;
        private ContentManager content;

        

        public void load(CFile file, ContentManager c)
        {
            content = c;

            handle = (short)file.readAInt();
            var dataReader = Decompressor.DecompressAsReader(file, out _);
            var check = dataReader.readAInt();
            var references = dataReader.readAInt();
            var size = dataReader.readAInt();

            lfHeight = dataReader.readAInt();
            var width = dataReader.readAInt();
            var escapement = dataReader.readAInt();
            var orientation = dataReader.readAInt();
            lfWeight = dataReader.readAInt();
            lfItalic = dataReader.readAByte();
            var underline = dataReader.readAByte();
            var strikeout = dataReader.readAByte();
            var charset = dataReader.readAByte();
            var outPrecision = dataReader.readAByte();
            var clipPrecision = dataReader.readAByte();
            var quality = dataReader.readAByte();
            var pitchAndFamily = dataReader.readAByte();
            lfFaceName = dataReader.readAString(32);
        }

        public CFontInfo getFontInfo()
        {
            CFontInfo info = new CFontInfo();
            info.lfHeight = lfHeight;
            info.lfWeight = lfWeight;
            info.lfItalic = lfItalic;
            info.lfFaceName = lfFaceName;
            return info;
        }

        public static CFont createFromFontInfo(CFontInfo info, CRunApp app)
        {
            CFont font = new CFont();
            font.content = app.content;
            font.lfHeight = info.lfHeight;
            font.lfWeight = info.lfWeight;
            font.lfItalic = info.lfItalic;
            font.lfFaceName = info.lfFaceName;
            return font;
        }

        public DynamicSpriteFont getFont()
        {
            return spriteFont;
            // Cree la fonte
            if (spriteFont == null)
            {
                string name=lfFaceName;
                do
                {
                    int pos = name.IndexOf(' ');
                    if (pos < 0)
                    {
                        break;
                    }
                    name = name.Substring(0, pos) + name.Substring(pos + 1);
                } while (true);
                name+=lfHeight.ToString();
                if (lfWeight>400)
                {
                    name+="Bold";
                }
                if (lfItalic!=0)
                {
                    name+="Italic";
                }
                //spriteFont = content.Load<SpriteFont>(name);
            }

            return null; //spriteFont;
        }
    }
}
