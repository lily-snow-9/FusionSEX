//----------------------------------------------------------------------------------
//
// PARAM_PROGRAM un programme a faire fonctionner
//
//----------------------------------------------------------------------------------

using FusionX.Application;
using FusionX.Services;

namespace FusionX.Params
{
	
	public class PARAM_PROGRAM:CParam
	{
		public short flags;
		public System.String filename;
		public System.String command;
		public const short PRGFLAGS_WAIT = (short) (0x0001);
		public const short PRGFLAGS_HIDE = (short) (0x0002);
		
		public override void  load(CRunApp app,CFile file)
		{
			flags = file.readAShort();
			int debut = file.getFilePointer();
			filename = file.readAString();
			file.seek(debut + 260); // _MAX_PATH
			command = file.readAString();
		}
	}
}