// ------------------------------------------------------------------------------
// 
// NO SAMPLE PLAYING?
// 
// ------------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.RunLoop;

namespace FusionX.Conditions
{
	
	public class CND_NOSAMPLAYING:CCnd
	{
		public override bool eva1(CRun rhPtr, CObject hoPtr)
		{
			return eva2(rhPtr);
		}
		public override bool eva2(CRun rhPtr)
		{
			return !rhPtr.rhApp.soundPlayer.isSoundPlaying();
		}
	}
}