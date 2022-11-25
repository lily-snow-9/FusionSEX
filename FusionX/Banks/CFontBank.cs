//----------------------------------------------------------------------------------
//
// CFONTBANK :banque de fontes
//
//----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using FusionX.Application;
using FusionX.Services;

namespace FusionX.Banks
{
    public class CFontBank : IEnum
    {
        CRunApp app;
        CFile file;
        public Dictionary<int,CFont> fonts = new Dictionary<int, CFont>();          /// List of CFonts
        int[] offsetsToFonts;
        int nFonts = 0;
        short[] handleToIndex;
        public int nHandlesReel;
        public int nHandlesTotal;
        short[] useCount;

        public CFontBank()
        {
        }
        public CFontBank(CRunApp a)
        {
            app = a;
            file = app.file;
        }

        public void preLoad()
        {
            // Nombre d'elements
            
            nHandlesReel = file.readAInt();
            
            int n;

            offsetsToFonts = new int[nHandlesReel];

            // Explore les handles
            int debut = file.getFilePointer();
            for (n = 0; n < nHandlesReel; n++)
            {
                CFont font = new CFont();
                font.load(file,app.content);
                fonts.Add(font.handle,font);
            }
            useCount = new short[nHandlesReel];
            
        }

        public void load()
        {
            
        }

        public CFont getFontFromHandle(short handle)
        {
            return fonts[0];
            // Protection jeux niques
            if (handle == -1)
            {
                return fonts[0];
            }
            // Retourne la fonte
            if (handle >= 0 && handle < nHandlesTotal)
            {
                if (handleToIndex[handle] != -1)
                {
                    return fonts[handleToIndex[handle]];
                }
            }
            return null;
        }

        public CFont getFontFromIndex(short index)
        {
            if (index >= 0 && index < nFonts)
            {
                return fonts[index];
            }
            return null;
        }

        public CFontInfo getFontInfoFromHandle(short handle)
        {
            if (handle < 0)
            {
                return fonts[0].getFontInfo();
            }
            CFont font = getFontFromHandle(handle);
            return font.getFontInfo();
        }

        public void resetToLoad()
        {
            int n;
            for (n = 0; n < nHandlesReel; n++)
            {
                useCount[n] = 0;
            }
        }

        public void setToLoad(short handle)
        {
            // Protection jeux niques
            if (handle == -1)
            {
                if (fonts != null)
                {
//                    nullFont = fonts[0];
                }
                return;
            }
            useCount[handle]++;
        }

        public short enumerate(short num)
        {
            //setToLoad(num);
            return -1;
        }

        public short addFont(CFontInfo info)
        {
            int h;

            // Cherche une fonte identique
            int n;
            for (n = 0; n < nFonts; n++)
            {
                if (fonts[n] == null)
                {
                    continue;
                }
                if (fonts[n].lfHeight != info.lfHeight)
                {
                    continue;
                }
                if (fonts[n].lfWeight != info.lfWeight)
                {
                    continue;
                }
                if (fonts[n].lfItalic != info.lfItalic)
                {
                    continue;
                }
                if (string.Compare(fonts[n].lfFaceName, info.lfFaceName, StringComparison.OrdinalIgnoreCase) != 0)
                {
                    continue;
                }
                break;
            }
            if (n < nFonts)
            {
                return fonts[n].handle;
            }

            // Cherche un handle libre
            short hFound = -1;
            for (h = nHandlesReel; h < nHandlesTotal; h++)
            {
                if (handleToIndex[h] == -1)
                {
                    hFound = (short) h;
                    break;
                }
            }

            // Rajouter un handle
            if (hFound == -1)
            {
                short[] newHToI = new short[nHandlesTotal + 10];
                for (h = 0; h < nHandlesTotal; h++)
                {
                    newHToI[h] = handleToIndex[h];
                }
                for (; h < nHandlesTotal + 10; h++)
                {
                    newHToI[h] = -1;
                }
                hFound = (short) nHandlesTotal;
                nHandlesTotal += 10;
                handleToIndex = newHToI;
            }

            // Cherche une fonte libre
            int f;
            int fFound = -1;
            for (f = 0; f < nFonts; f++)
            {
                if (fonts[f] == null)
                {
                    fFound = f;
                    break;
                }
            }

            // Rajouter une image?
            if (fFound == -1)
            {
                CFont[] newFonts = new CFont[nFonts + 10];
                for (f = 0; f < nFonts; f++)
                {
                    newFonts[f] = fonts[f];
                }
                for (; f < nFonts + 10; f++)
                {
                    newFonts[f] = null;
                }
                fFound = nFonts;
                nFonts += 10;
                //fonts = newFonts;
            }

            // Ajoute la nouvelle image
            handleToIndex[hFound] = (short) fFound;
            fonts[fFound] = new CFont();
            fonts[fFound].handle = hFound;
            fonts[fFound].lfHeight = info.lfHeight;
            fonts[fFound].lfWeight = info.lfWeight;
            fonts[fFound].lfItalic = info.lfItalic;
            fonts[fFound].lfFaceName = info.lfFaceName;

            return hFound;
        }

    }
}
