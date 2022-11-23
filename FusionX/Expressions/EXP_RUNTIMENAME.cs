//----------------------------------------------------------------------------------
//
// PLAYER NAME
//
//----------------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Expressions
{
	public class EXP_RUNTIMENAME:CExpOi
	{
		public override void  evaluate(CRun rhPtr)
		{
            rhPtr.getCurrentResult().forceString("FusionX");
		}
	}
}