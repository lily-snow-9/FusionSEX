//----------------------------------------------------------------------------------
//
// CPARAMPOSITION: creation d'objets
//
//----------------------------------------------------------------------------------

using FusionX.Application;
using FusionX.Services;

namespace FusionX.Params
{	
	public class PARAM_POSITION:CPosition
	{
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
		}
	}
}