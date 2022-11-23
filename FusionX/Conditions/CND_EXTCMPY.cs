// ------------------------------------------------------------------------------
// 
// COMPARE TO Y POSITION
// 
// ------------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.RunLoop;

namespace FusionX.Conditions
{
	
	public class CND_EXTCMPY:CCnd, IEvaExpObject
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
			return CRun.compareTer(hoPtr.hoY, value_Renamed, comp);
		}
	}
}