//----------------------------------------------------------------------------------
//
// VAR BY INDEX
//
//----------------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.RunLoop;
using FusionX.Values;

namespace FusionX.Expressions
{
	
	public class EXP_EXTVARBYINDEX:CExpOi
	{
		public override void  evaluate(CRun rhPtr)
		{
			CObject pHo = rhPtr.rhEvtProg.get_ExpressionObjects(oiList);
			rhPtr.rh4CurToken++;
			int num = rhPtr.get_ExpressionInt();
			if (pHo == null || num < 0 || num >= CRVal.VALUES_NUMBEROF_ALTERABLE)
			{
                rhPtr.getCurrentResult().forceInt(0);
				return ;
			}
            rhPtr.getCurrentResult().forceValue(pHo.rov.getValue(num));
		}
	}
}