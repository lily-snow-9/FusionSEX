// -----------------------------------------------------------------------------
//
// SHUFFLE
//
// -----------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_EXTSHUFFLE:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			CObject pHo = rhPtr.rhEvtProg.get_ActionObjects(this);
			if (pHo == null)
				return ;
			
			rhPtr.rhEvtProg.rh2ShuffleBuffer.add(pHo);
		}
	}
}