//----------------------------------------------------------------------------------
//
// NOMBRE DE JOUEURS
//
//----------------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_GAMNPLAYER:CExp
	{
		public override void  evaluate(CRun rhPtr)
		{
            rhPtr.getCurrentResult().forceInt(rhPtr.rhNPlayers);
		}
	}
}