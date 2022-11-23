//----------------------------------------------------------------------------------
//
// CHANNEL VOLUME
//
//----------------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_GETCHANNELVOL:CExp
	{
		public override void  evaluate(CRun rhPtr)
		{
            rhPtr.rh4CurToken++;
            int channel = rhPtr.get_ExpressionInt();
            rhPtr.getCurrentResult().forceInt(rhPtr.rhApp.soundPlayer.getVolumeChannel(channel - 1));
        }
	}
}