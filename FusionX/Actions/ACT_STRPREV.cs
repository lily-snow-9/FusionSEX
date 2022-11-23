// -----------------------------------------------------------------------------
//
// PREVIOUS STRING
//
// -----------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_STRPREV:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			CObject pHo = rhPtr.rhEvtProg.get_ActionObjects(this);
			if (pHo != null)
			{
				CText pText = (CText) pHo;
				int num = pText.rsMini - 1;
				if (num < 0)
					num = 0;
				if (pText.txtChange(num))
				{
					pHo.roc.rcChanged = true;
					pHo.display();
				}
			}
		}
	}
}