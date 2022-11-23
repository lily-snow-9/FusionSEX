// -----------------------------------------------------------------------------
//
// RESUME
//
// -----------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_CCARESUMEAPP:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			CObject pHo = rhPtr.rhEvtProg.get_ActionObjects(this);
			if (pHo == null)
				return ;
			
			((CCCA) pHo).resume();
		}
	}
}