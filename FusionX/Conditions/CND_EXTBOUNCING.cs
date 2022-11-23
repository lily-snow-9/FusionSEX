// ------------------------------------------------------------------------------
// 
// IS BOUNCING?
// 
// ------------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.RunLoop;

namespace FusionX.Conditions
{
	
	public class CND_EXTBOUNCING:CCnd, IEvaObject
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
			if (hoPtr.rom.rmBouncing == false)
				return negaFALSE();
			return negaTRUE();
		}
	}
}