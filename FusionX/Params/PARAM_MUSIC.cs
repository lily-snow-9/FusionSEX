//----------------------------------------------------------------------------------
//
// CPARAMMUSIC: une musique
//
//----------------------------------------------------------------------------------

using FusionX.Application;
using FusionX.Services;

namespace FusionX.Params
{	
	public class PARAM_MUSIC:CParam
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