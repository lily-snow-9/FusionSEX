// ------------------------------------------------------------------------------
// 
// END OF PATH?
// 
// ------------------------------------------------------------------------------

using FusionX.Movements;
using FusionX.Objects;
using FusionX.RunLoop;

namespace FusionX.Conditions
{
	
	public class CND_EXTENDPATH:CCnd, IEvaObject
	{
		public override bool eva1(CRun rhPtr, CObject hoPtr)
		{
			return true;
		}
		public override bool eva2(CRun rhPtr)
		{
			return evaObject(rhPtr, this);
		}
		public virtual bool evaObjectRoutine(CObject hoPtr)
		{
			if (hoPtr.roc.rcMovementType != CMoveDef.MVTYPE_TAPED)
				return false;
			return checkMark(hoPtr.hoAdRunHeader, hoPtr.hoMark2);
		}
	}
}