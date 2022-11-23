//----------------------------------------------------------------------------------
//
// CPARAMSAMPLE: un son
//
//----------------------------------------------------------------------------------

using FusionX.Application;
using FusionX.Services;

namespace FusionX.Params
{	
	public class PARAM_SAMPLE:CParam
	{
		public short sndHandle;
		public short sndFlags;
		
		public override void  load(CRunApp app,CFile file)
		{
			sndHandle = file.readAShort();
			sndFlags = file.readAShort();
		}
	}
}