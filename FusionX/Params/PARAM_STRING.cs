//----------------------------------------------------------------------------------
//
// PARAM_STRING : une chaine
//
//----------------------------------------------------------------------------------

using FusionX.Application;
using FusionX.Services;

namespace FusionX.Params
{	
	public class PARAM_STRING:CParam
	{
		public System.String pString;
		
		public override void  load(CRunApp app,CFile file)
		{
			pString = file.readAString();
		}
	}
}