//----------------------------------------------------------------------------------
//
// EXTENSION
//
//----------------------------------------------------------------------------------

using FusionX.Events;
using FusionX.Objects;
using FusionX.RunLoop;

namespace FusionX.Expressions
{
	
	public class CExpExtension:CExpOi
	{
		public override void  evaluate(CRun rhPtr)
		{
			CObject pHo = rhPtr.rhEvtProg.get_ExpressionObjects(oiList);
			if (pHo == null)
			{
                rhPtr.getCurrentResult().forceInt(0);
				return ;
			}
			CExtension pExt = (CExtension) pHo;
			int exp = (int) ((code>>16)&0xFFFF) - CEventProgram.EVENTS_EXTBASE; // Vire le type
			CValue result = pExt.expression(exp);
			rhPtr.getCurrentResult().forceValue(result);
		}
	}
}