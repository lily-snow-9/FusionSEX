// -----------------------------------------------------------------------------
//
// ADD TO LIVES
//
// -----------------------------------------------------------------------------

using FusionX.Params;
using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_ADDLIVES:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			int value = rhPtr.get_EventExpressionInt((CParamExpression) evtParams[0]); // Expression
			int joueur = evtOi; // Joueur
			value = rhPtr.rhApp.lives[joueur] + value;
			rhPtr.actPla_FinishLives(joueur, value);
		}
	}
}