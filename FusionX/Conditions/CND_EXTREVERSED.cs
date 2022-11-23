// ------------------------------------------------------------------------------
// 
// IS REVERSED?
// 
// ------------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.RunLoop;

namespace FusionX.Conditions
{
	
	public class CND_EXTREVERSED:CCnd, IEvaObject
	{
		public override bool eva1(CRun rhPtr, CObject hoPtr)
		{
			return evaObject(rhPtr, this);
		}
		public override bool eva2(CRun rhPtr)
		{
			return evaObject(rhPtr, this);
		}
		public virtual bool evaObjectRoutine(CObject hoPtr)
		{
			if (hoPtr.rom.rmReverse == 0)
				return negaFALSE();
			return negaTRUE();
		}
	}
}