//----------------------------------------------------------------------------------
//
// MINIMUM
//
//----------------------------------------------------------------------------------

using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class EXP_MIN:CExp
	{
		
		public override void  evaluate(CRun rhPtr)
		{
			rhPtr.rh4CurToken++;
			CValue aValue = rhPtr.get_ExpressionAny();
			rhPtr.rh4CurToken++;
			CValue bValue = rhPtr.get_ExpressionAny();
			if (aValue.type == CValue.TYPE_INT && bValue.type == CValue.TYPE_INT)
			{
				int a = aValue.intValue;
				int b = bValue.intValue;
				if (a < b)
				{
                    rhPtr.getCurrentResult().forceInt(a);
				}
				else
				{
                    rhPtr.getCurrentResult().forceInt(b);
				}
			}
			else
			{
                rhPtr.getCurrentResult().forceDouble(System.Math.Min(aValue.getDouble(), bValue.getDouble()));
			}
		}
	}
}