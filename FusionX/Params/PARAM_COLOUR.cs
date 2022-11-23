//----------------------------------------------------------------------------------
//
// PARAM_COLOUR : une valeur RGB
//
//----------------------------------------------------------------------------------

using FusionX.Application;
using FusionX.Services;

namespace FusionX.Params
{	
	public class PARAM_COLOUR:CParam
	{
		public int color;
		
		public override void  load(CRunApp app,CFile file)
		{
			color = file.readAColor();
		}
	}
}