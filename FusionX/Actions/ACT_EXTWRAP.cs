// -----------------------------------------------------------------------------
//
// WRAP
//
// -----------------------------------------------------------------------------

using FusionX.Movements;
using FusionX.Objects;
using FusionX.RunLoop;

namespace FusionX.Actions
{
	
	public class ACT_EXTWRAP:CAct
	{
		public override void  execute(CRun rhPtr)
		{
			CObject pHo = rhPtr.rhEvtProg.get_ActionObjects(this);
			if (pHo == null)
				return ;
			
			if (pHo.rom != null)
			{
				pHo.rom.rmEventFlags |= CRMvt.EF_WRAP; // Il faut wrapper
			}
		}
	}
}