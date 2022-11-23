//----------------------------------------------------------------------------------
//
// PARAM_SHORT : un parametre sur un short
//
//----------------------------------------------------------------------------------

using FusionX.Application;
using FusionX.Services;

namespace FusionX.Params
{	
	public class PARAM_SHORT:CParam
	{
		public short value;
		
		public override void  load(CRunApp app,CFile file)
		{
			value = file.readAShort();
		}
	}
}