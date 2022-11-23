//----------------------------------------------------------------------------------
//
// CPARAMEVERY: duree
//
//----------------------------------------------------------------------------------

using FusionX.Application;
using FusionX.Services;

namespace FusionX.Params
{	
	public class PARAM_EVERY:CParam
	{
		public int delay;
		public int compteur;
		
		public override void  load(CRunApp app,CFile file)
		{
			delay = file.readAInt();
			compteur = file.readAInt();
		}
	}
}