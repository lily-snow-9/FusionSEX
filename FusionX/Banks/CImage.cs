//----------------------------------------------------------------------------------
//
// CIMAGEBANK : Stockage des images
//
//----------------------------------------------------------------------------------

using FusionX.Application;
using FusionX.Services;
using FusionX.Sprites;
using Ionic.Zlib;
using Microsoft.Xna.Framework.Graphics;

namespace FusionX.Banks
{
    public class CImage
    {
	    public BitDict Flags = new BitDict(new[]
	    {
		    "RLE",
		    "RLEW",
		    "RLET",
		    "LZX",
		    "Alpha",
		    "ACE",
		    "Mac"
	    });
        public CRunApp app;
        public int handle;
        public short width;
        public short height;
        public short xSpot;
        public short ySpot;
        public short xAP;
        public short yAP;
        public short useCount;

        public Texture2D Image
        {
	        get
	        {
		        
		        return _image;
	        }
        }

        private Texture2D _image;
       
	    public CMask maskNormal;
	    public CMask maskPlatform;	    
	    public const int maxRotatedMasks=10;
		public CArrayList maskRotation=null;
    	public short mosaic=0;
        private int trans;
        private byte[] theData;
        private bool isImageLoaded;
        private int dataSize;

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
            dataSize = imgFile.readAInt();
            width = imgFile.readAShort();
            height = imgFile.readAShort();
            var graphicMode = imgFile.readAByte();
            Flags.flag=imgFile.readAByte();
            imgFile.readAShort();
            xSpot = imgFile.readAShort();
            ySpot = imgFile.readAShort();
            xAP = imgFile.readAShort();
            yAP = imgFile.readAShort();
            trans = imgFile.readAInt();
            
            theData = imgFile.readArray();

            



           
            
            mosaic = 0;
           
            

            
            //image = Texture2D.FromFile(app.graphicsDevice, @"D:\KostyasLair\kostyasparty2.png"); 
            
        }
		
        public void loadData()
        {
	        if (!isImageLoaded)
	        {
		        _image = new Texture2D(app.graphicsDevice,width,height);
		        var newFile = new CFile(theData);
		        if (Flags["LZX"])
		        {
			        var decompressed = newFile.readAInt();

			        theData = Decompressor.DecompressBlock(newFile,
				        (int)(newFile.reader.BaseStream.Length - newFile.reader.BaseStream.Position));
		        }
		        else theData = newFile.readArray(dataSize);
		        _image.SetData(ImageHelper.TranslateImage(width,height,theData,trans,Flags["Alpha"]),0,4*width*height);
		        isImageLoaded = true;
	        }

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
