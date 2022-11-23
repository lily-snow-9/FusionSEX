//----------------------------------------------------------------------------------
//
// PARAM_ZONE: zone a l'ecran
//
//----------------------------------------------------------------------------------

using FusionX.Application;
using FusionX.Services;

namespace FusionX.Params
{	
	public class PARAM_ZONE:CParam
	{
		public short x1;
		public short y1;
		public short x2;
		public short y2;
		
		public override void  load(CRunApp app,CFile file)
		{
			x1 = file.readAShort();
			y1 = file.readAShort();
			x2 = file.readAShort();
			y2 = file.readAShort();
		}
	}
}