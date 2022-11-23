//----------------------------------------------------------------------------------
//
// SCORE
//
//----------------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_PLASCORE:CExpOi
	{
		public override void  evaluate(CRun rhPtr)
		{
			int[] scores = rhPtr.rhApp.scores;
            rhPtr.getCurrentResult().forceInt(scores[oi]);
		}
	}
}