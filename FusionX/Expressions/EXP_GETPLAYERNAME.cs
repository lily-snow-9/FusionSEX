//----------------------------------------------------------------------------------
//
// PLAYER NAME
//
//----------------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_GETPLAYERNAME:CExpOi
	{
		public override void  evaluate(CRun rhPtr)
		{
            rhPtr.getCurrentResult().forceString(rhPtr.rhApp.playerNames[oi]);
		}
	}
}