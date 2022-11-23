//----------------------------------------------------------------------------------
//
// LOGARYTHME
//
//----------------------------------------------------------------------------------

using System;
using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_LOG:CExp
	{
		
		public override void  evaluate(CRun rhPtr)
		{
			rhPtr.rh4CurToken++;
			double value = rhPtr.get_ExpressionDouble();
            rhPtr.getCurrentResult().forceDouble(Math.Log10(value));
		}
	}
}