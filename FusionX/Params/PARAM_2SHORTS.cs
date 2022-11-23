//----------------------------------------------------------------------------------
//
// PARAM_2SHORTS : deux shorts
//
//----------------------------------------------------------------------------------

using FusionX.Application;
using FusionX.Services;

namespace FusionX.Params
{
	
	public class PARAM_2SHORTS:CParam
	{
		public short value1;
		public short value2;
		
		public override void  load(CRunApp app,CFile file)
		{
			value1 = file.readAShort();
			value2 = file.readAShort();
		}
	}
}