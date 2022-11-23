//----------------------------------------------------------------------------------
//
// CPARAMSAMPLE: un son
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
	public class PARAM_SAMPLE:CParam
	{
		public short sndHandle;
		public short sndFlags;
		
		public override void  load(CRunApp app,CFile file)
		{
			sndHandle = file.readAShort();
			sndFlags = file.readAShort();
		}
	}
}