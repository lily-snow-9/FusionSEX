//----------------------------------------------------------------------------------
//
// CPARAMTIME: un parametre duree
//
//----------------------------------------------------------------------------------

using FusionX.Application;
using FusionX.Services;

namespace FusionX.Params
{
	
	public class PARAM_TIME:CParam
	{
		public int timer;
		public int loops;
		
		public override void  load(CRunApp app,CFile file)
		{
			timer = file.readAInt();
			loops = file.readAInt();
		}
	}
}