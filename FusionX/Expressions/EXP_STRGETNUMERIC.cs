//----------------------------------------------------------------------------------
//
// VALEUR NUMERIQUE DE LA CHAINE
//
//----------------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.RunLoop;
using FusionX.Services;

namespace FusionX.Expressions
{
	
	public class EXP_STRGETNUMERIC:CExpOi
	{
		public override void  evaluate(CRun rhPtr)
		{
			CObject pHo = rhPtr.rhEvtProg.get_ExpressionObjects(oiList);
			if (pHo == null)
			{
                rhPtr.getCurrentResult().forceInt(0);
				return ;
			}
			CText pText = (CText) pHo;
			if (pText.rsTextBuffer != null)
			{
				CFuncVal val = new CFuncVal();
				switch (val.parse(pText.rsTextBuffer))
				{					
					case 0:
                        rhPtr.getCurrentResult().forceInt(val.intValue);
						return ;
					
					case 1:
                        rhPtr.getCurrentResult().forceDouble(val.doubleValue);
						return ;
					}
			}
            rhPtr.getCurrentResult().forceInt(0);
		}
	}
}