// ------------------------------------------------------------------------------
// 
// COMPARE TO X POSITION
// 
// ------------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.RunLoop;

namespace FusionX.Conditions
{
	
	public class CND_EXTCMPX:CCnd, IEvaExpObject
	{
		public override bool eva1(CRun rhPtr, CObject hoPtr)
		{
			return evaExpObject(rhPtr, this);
		}
		public override bool eva2(CRun rhPtr)
		{
			return evaExpObject(rhPtr, this);
		}
		public virtual bool evaExpRoutine(CObject hoPtr, int value_Renamed, short comp)
		{
			return CRun.compareTer(hoPtr.hoX, value_Renamed, comp);
		}
	}
}