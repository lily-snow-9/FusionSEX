//----------------------------------------------------------------------------------
//
// CCREATE: parametre position donnes creation
//
//----------------------------------------------------------------------------------

using FusionX.Application;
using FusionX.Services;

namespace FusionX.Params
{	
	public abstract class CCreate:CPosition
	{
		public short cdpHFII; // FrameItemInstance number
		public short cdpOi; // OI of the object to create
		
		public CCreate()
		{
		}
		public abstract override void  load(CRunApp app,CFile file);
	}
}