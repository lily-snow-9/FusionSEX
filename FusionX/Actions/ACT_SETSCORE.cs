// -----------------------------------------------------------------------------
//
// SET SCORE
//
// -----------------------------------------------------------------------------

using FusionX.OI;
using FusionX.Params;
using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_SETSCORE:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			int value = rhPtr.get_EventExpressionInt((CParamExpression) evtParams[0]); // Expression
			int joueur = evtOi; // Joueur
			int[] scores = rhPtr.rhApp.scores;
			scores[joueur] = value; // Change la valeur
			
			rhPtr.update_PlayerObjects(joueur, COI.OBJ_SCORE, scores[joueur]);
		}
	}
}