//----------------------------------------------------------------------------------
//
// OPERATEUR OR
//
//----------------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_OR:CExp
	{
		public override void  evaluate(CRun rhPtr)
		{
            rhPtr.getCurrentResult().orLog(rhPtr.getNextResult());
		}
	}
}