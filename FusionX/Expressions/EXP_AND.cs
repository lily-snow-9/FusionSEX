//----------------------------------------------------------------------------------
//
// OPERATEUR AND
//
//----------------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_AND:CExp
	{
		public override void  evaluate(CRun rhPtr)
		{
            rhPtr.getCurrentResult().andLog(rhPtr.getNextResult());
		}
	}
}