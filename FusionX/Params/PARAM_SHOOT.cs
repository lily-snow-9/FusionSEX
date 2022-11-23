//----------------------------------------------------------------------------------
//
// PARAM_SHOOT : creation d'objets
//
//----------------------------------------------------------------------------------

using FusionX.Application;
using FusionX.Services;

namespace FusionX.Params
{	
	public class PARAM_SHOOT:CCreate
	{
		public short shtSpeed; // Speed
		
		public override void  load(CRunApp app,CFile file)
		{
			posOINUMParent = file.readAShort();
			posFlags = file.readAShort();
			posX = file.readAShort();
			posY = file.readAShort();
			posSlope = file.readAShort();
			posAngle = file.readAShort();
			posDir = file.readAInt();
			posTypeParent = file.readAShort();
			posOiList = file.readAShort();
			posLayer = file.readAShort();
			cdpHFII = file.readAShort();
			cdpOi = file.readAShort();
			file.skipBytes(4); //cdpFree
			shtSpeed = file.readAShort();
		}
	}
}