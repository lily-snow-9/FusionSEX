// -----------------------------------------------------------------------------
//
// PREVIOUS FRAME
//
// -----------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_CCAPREVIOUSFRAME:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			CObject pHo = rhPtr.rhEvtProg.get_ActionObjects(this);
			if (pHo == null)
				return ;
			
			((CCCA) pHo).previousFrame();
		}
	}
}