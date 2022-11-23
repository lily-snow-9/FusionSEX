// -----------------------------------------------------------------------------
//
// DISPLAY STRING
//
// -----------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_STRDISPLAYSTRING:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			CObject pHo = rhPtr.rhEvtProg.get_ActionObjects(this);
			if (pHo != null)
			{
				CText pText = (CText) pHo;
				if (pText.txtChange(- 1))
				{
					pHo.roc.rcChanged = true;
					pHo.display();
				}
			}
		}
	}
}