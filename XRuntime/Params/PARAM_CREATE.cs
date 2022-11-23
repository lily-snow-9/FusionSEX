//----------------------------------------------------------------------------------
//
// CPARAMCREATE: creation d'objets
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
	public class PARAM_CREATE:CCreate
	{
		public override void  load(CRunApp app,CFile file)
		{
			posOINUMParent = file.readAShort();
			posFlags = file.readAShort();
			posX = file.readAShort();
			posY = file.readAShort();
			posSlope = file.readAShort();
			posAngle = file.readAShort();
			posDir = file.readAInt();
			posTypeParent = file.readAShort();
			posOiList = file.readAShort();
			posLayer = file.readAShort();
			cdpHFII = file.readAShort();
			cdpOi = file.readAShort();
		}
	}
}