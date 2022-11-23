//----------------------------------------------------------------------------------
//
// SAMPLE MAIN VOLUME
//
//----------------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_GETSAMPLEMAINVOL:CExp
	{
		public override void  evaluate(CRun rhPtr)
		{
            rhPtr.getCurrentResult().forceInt(rhPtr.rhApp.soundPlayer.getMainVolume());
		}
	}
}