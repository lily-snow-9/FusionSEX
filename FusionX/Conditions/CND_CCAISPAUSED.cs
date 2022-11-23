// ------------------------------------------------------------------------------
// 
// CCA PAUSED?
// 
// ------------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.RunLoop;

namespace FusionX.Conditions
{
	
	public class CND_CCAISPAUSED:CCnd, IEvaObject
	{
		public override bool eva1(CRun rhPtr, CObject hoPtr)
		{
			return eva2(rhPtr);
		}
		public override bool eva2(CRun rhPtr)
		{
			return evaObject(rhPtr, this);
		}
		public virtual bool evaObjectRoutine(CObject hoPtr)
		{
			return ((CCCA) hoPtr).isPaused();
		}
	}
}