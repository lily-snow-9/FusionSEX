//----------------------------------------------------------------------------------
//
// HAUTEUR TERRAIN
//
//----------------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_PLAYHEIGHT:CExp
	{
		public override void  evaluate(CRun rhPtr)
		{
            rhPtr.getCurrentResult().forceInt(rhPtr.rhFrame.leHeight);
		}
	}
}