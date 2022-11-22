//----------------------------------------------------------------------------------
//
// CIMAGEBANK : Stockage des images
//
//----------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CTFAK.Memory;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using RuntimeXNA.Services;
using RuntimeXNA.Sprites;
using RuntimeXNA.Application;

namespace RuntimeXNA.Banks
{
    public class CImage
    {
        public CRunApp app;
        public int handle;
        public short width;
        public short height;
        public short xSpot;
        public short ySpot;
        public short xAP;
        public short yAP;
        public short useCount;
        public Texture2D image;
	    public CMask maskNormal;
	    public CMask maskPlatform;	    
	    public const int maxRotatedMasks=10;
		public CArrayList maskRotation=null;
    	public short mosaic=0;

        public void loadHandle(CFile file)
        {
            handle = file.readAInt();
            file.skipBytes(12);
        }

        public void load(CRunApp a,CFile file,bool doMosaic)
        {
            app = a;
            handle = (short)(app.file.readAInt()-1);
            

            var imgData = Decompressor.Decompress(file, out _);
            var imgFile = new CFile(imgData);

            var checksum = imgFile.readAInt();
            var references = imgFile.readAInt();
            var size = imgFile.readAInt();
            width = imgFile.readShort();
            height = imgFile.readShort();
            imgFile.readShort();


            mosaic = 0;
           
            

            string imgName = handle.ToString("D4");
            imgName = "Img" + imgName;
            image = Texture2D.FromFile(app.graphicsDevice,
	            @"D:\KostyasLair\kostyasparty2.png"); //app.content.Load<Texture2D>(imgName);
        }
        public CMask getMask(int flags, int angle, float scaleX, float scaleY)
        {
	        if ((flags & CMask.GCMF_PLATFORM) == 0)
	        {
        		if (maskNormal==null)
        		{
        			maskNormal=new CMask();
        			maskNormal.createMask(this, flags);
        		}
	        	if (angle==0 && scaleX==1.0 && scaleY==1.0)
	        	{
        			return maskNormal;
	        	}
	        	
	        	// Returns the rotated mask
	        	CRotatedMask rMask;
	        	if (maskRotation==null)
	        	{
	        		maskRotation=new CArrayList();
	        	}
	        	int n;
	        	int tick=0x7FFFFFFF;
	        	int nOldest=-1;
	        	for (n=0; n<maskRotation.size(); n++)
	        	{
	        		rMask=(CRotatedMask)maskRotation.get(n);
	        		if (angle==rMask.angle && scaleX==rMask.scaleX && scaleY==rMask.scaleY)
	        		{
	        			return rMask.mask; 
	        		}
	        		if (rMask.tick<tick)
	        		{
	        			tick=rMask.tick;
	        			nOldest=n;
	        		}
	        	}
	        	if (maskRotation.size()<maxRotatedMasks)
	        	{
	        		nOldest=-1;
	        	}
        		rMask=new CRotatedMask();
				rMask.mask=new CMask();
				rMask.mask.createRotatedMask(maskNormal, angle, scaleX, scaleY);
	        	rMask.angle=angle;
	        	rMask.scaleX=scaleX;
	        	rMask.scaleY=scaleY;
	        	rMask.tick=(int)app.timer;
	        	if (nOldest<0)
	        	{
	        		maskRotation.add(rMask);
	        	}
	        	else
	        	{
	        		maskRotation.set(nOldest, rMask);
	        	}
	        	return rMask.mask;
	        }
	        else
	        {
        		if (maskPlatform==null)
        		{
        			maskPlatform=new CMask();
        			maskPlatform.createMask(this, flags);
        		}
        		return maskPlatform;
	        }
        }




    }
}
