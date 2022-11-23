//----------------------------------------------------------------------------------
//
// PARAM_CMPTIME
//
//----------------------------------------------------------------------------------

using FusionX.Application;
using FusionX.Services;

namespace FusionX.Params
{	
	public class PARAM_CMPTIME:CParam
	{
		public int timer;
		public int loops;
		public short comparaison;
		
		public override void  load(CRunApp app,CFile file)
		{
			timer = file.readAInt();
			loops = file.readAInt();
			comparaison = file.readAShort();
		}
	}
}