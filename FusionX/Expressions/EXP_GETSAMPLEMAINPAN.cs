//----------------------------------------------------------------------------------
//
// SAMPLE MAIN PAN
//
//----------------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_GETSAMPLEMAINPAN:CExp
	{
		public override void  evaluate(CRun rhPtr)
		{
            rhPtr.getCurrentResult().forceInt(rhPtr.rhApp.soundPlayer.getMainPan());
		}
	}
}