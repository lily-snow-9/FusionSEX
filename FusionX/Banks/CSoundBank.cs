//----------------------------------------------------------------------------------
//
// CSOUNDBANK : Stockage des sons
//
//----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using FusionX.Application;

namespace FusionX.Banks
{
    public class CSoundBank : IEnum
    {
	    CRunApp app;
	    private Dictionary<int, CSound> sounds = new Dictionary<int, CSound>();
	    int nHandlesReel;
	    int nHandlesTotal;
	    int nSounds;
	    int[] handleToIndex;
	    int[] useCount;
//        int enumIndex;

	    public void preLoad(CRunApp a)
	    {
            app=a;
		
			// Nombre de handles
			nHandlesReel=app.file.readAInt();
			
			
			int n;
			int offset;
			for (n=0; n<nHandlesReel; n++)
			{
				
				CSound sound=new CSound(a);

			    sound.loadHandle();
			    sounds.Add(sound.handle,sound);
			}

			Console.WriteLine("done loading sounds");
			// Reservation des tables
			//useCount=new int[nHandlesReel];

	    }

	    public CSound getSoundFromHandle(short handle)
	    {
		    return sounds[handle];
	    }
	    public CSound getSoundFromIndex(int index)
	    {
			if (index>=0 && index<nSounds)
			    return sounds[index];
			return null;
	    }
/*      public CSound getFirstSound()
        {
            for (enumIndex = 0; enumIndex < nSounds; enumIndex++)
            {
                if (sounds[enumIndex] != null)
                {
                    return sounds[enumIndex];
                }
            }
            return null;
        }
        public CSound getNextSound()
        {
            for (enumIndex++; enumIndex < nSounds; enumIndex++)
            {
                if (sounds[enumIndex] != null)
                {
                    return sounds[enumIndex];
                }
            }
            return null;
        }
*/
        public void resetToLoad()
	    {
			int n;
			for (n=0; n<nHandlesReel; n++)
			{
			    useCount[n]=0;
			}
	    }	    
	    public void setToLoad(short handle)
	    {
			useCount[handle]++;
	    }

	    public short enumerate(short num)
	    {
			setToLoad(num);
			return -1;
	    }

	    public void load()
	    {
		    return;
			int n;
			
			// Combien d'images?
			nSounds=0;
			for (n=0; n<nHandlesReel; n++)
			{
			    if (useCount[n]!=0)
					nSounds++;
			}
		
			// Charge les images
			CSound[] newSounds=new CSound[nSounds];
			int count=0;
			int h;
			for (h=0; h<nHandlesReel; h++)
			{
			    if (useCount[h]!=0)
			    {
					if (sounds!=null && handleToIndex[h]!=-1 && sounds[handleToIndex[h]]!=null)
					{
					    newSounds[count]=sounds[handleToIndex[h]];
					    newSounds[count].useCount=useCount[h];
					}
					else
					{
					    //newSounds[count]=new CSound(app);
                        //app.file.seek(offsetsToSounds[h]);
                        //newSounds[count].load();
					    //newSounds[count].useCount=useCount[h];
					}
					count++;
			    }
			}
			
		
			// Cree la table d'indirection
			handleToIndex=new int[nHandlesReel];
			for (n=0; n<nHandlesReel; n++)
			{
			    handleToIndex[n]=-1;
			}
			for (n=0; n<nSounds; n++)
			{
			    handleToIndex[sounds[n].handle]=n;
			}
			nHandlesTotal=nHandlesReel;
			
			// Plus rien a charger
			resetToLoad();
	    }

    }
}
