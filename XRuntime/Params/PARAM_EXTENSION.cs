//----------------------------------------------------------------------------------
//
// PARAM_EXTENSION : un parametre extension
//
//----------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RuntimeXNA.Application;
using RuntimeXNA.Services;

namespace RuntimeXNA.Params
{	
	public class PARAM_EXTENSION:CParam
	{
		public byte[] data = null;
		
		public override void  load(CRunApp app,CFile file)
		{
			short size = file.readAShort();
			file.skipBytes(4); // type + code
			if (size > 6)
			{
				data = new byte[size - 6];
				file.read(data);
			}
		}
	}
}