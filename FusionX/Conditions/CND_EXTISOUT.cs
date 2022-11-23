// ------------------------------------------------------------------------------
// 
// IS OUT OF THE PLAYFIELD?
// 
// ------------------------------------------------------------------------------

using FusionX.Objects;
using FusionX.RunLoop;

namespace FusionX.Conditions
{
	
	public class CND_EXTISOUT:CCnd, IEvaObject
	{
		public override bool eva1(CRun rhPtr, CObject hoPtr)
		{
			return evaObject(rhPtr, this);
		}
		public override bool eva2(CRun rhPtr)
		{
			return evaObject(rhPtr, this);
		}
		public virtual bool evaObjectRoutine(CObject pHo)
		{
			int x1 = pHo.hoX - pHo.hoImgXSpot;
			int x2 = x1 + pHo.hoImgWidth;
			int y1 = pHo.hoY - pHo.hoImgYSpot;
			int y2 = y1 + pHo.hoImgHeight;
			if (pHo.hoAdRunHeader.quadran_In(x1, y1, x2, y2) != 0)
			{
				return negaTRUE();
			}
			return negaFALSE();
		}
	}
}