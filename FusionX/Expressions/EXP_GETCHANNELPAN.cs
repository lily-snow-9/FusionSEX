//----------------------------------------------------------------------------------
//
// CHANNEL PAN
//
//----------------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_GETCHANNELPAN:CExp
	{
		public override void  evaluate(CRun rhPtr)
		{
            rhPtr.rh4CurToken++;
            int channel = rhPtr.get_ExpressionInt();
            rhPtr.getCurrentResult().forceInt(rhPtr.rhApp.soundPlayer.getPanChannel(channel - 1));
        }
	}
}