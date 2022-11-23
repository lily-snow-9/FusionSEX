//----------------------------------------------------------------------------------
//
// PARAM_GROUP groupe d'evenements
//
//----------------------------------------------------------------------------------

using FusionX.Application;
using FusionX.Services;

namespace FusionX.Params
{	
	public class PARAM_GROUP:CParam
	{
		public short grpFlags; // Active / Unactive?
		public short grpId; // Group identifier
		public const short GRPFLAGS_INACTIVE = (short) (0x0001);
		public const short GRPFLAGS_CLOSED = (short) (0x0002);
		public const short GRPFLAGS_PARENTINACTIVE = (short) (0x0004);
		public const short GRPFLAGS_GROUPINACTIVE = (short) (0x0008);
		public const short GRPFLAGS_GLOBAL = (short) (0x0010);
		
		public override void  load(CRunApp app,CFile file)
		{
			grpFlags = file.readAShort();
			grpId = file.readAShort();
		}
	}
}