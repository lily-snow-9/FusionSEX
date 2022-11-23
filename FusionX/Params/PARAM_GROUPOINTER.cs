//----------------------------------------------------------------------------------
//
// PARAM_GROUPOINTER pointeur sur groupe d'evenements 
//
//----------------------------------------------------------------------------------

using FusionX.Application;
using FusionX.Services;

namespace FusionX.Params
{	
	public class PARAM_GROUPOINTER:CParam
	{
		public short pointer;
		public short id;
		
		public override void  load(CRunApp app,CFile file)
		{
			file.skipBytes(4);
			id = file.readAShort();
		}
	}
}