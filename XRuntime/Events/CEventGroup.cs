//----------------------------------------------------------------------------------
//
// CEVENTGROUP: Groupe d'evenements
//
//----------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RuntimeXNA.Params;
using RuntimeXNA.Application;
using RuntimeXNA.Actions;
using RuntimeXNA.Conditions;
using RuntimeXNA.Services;

namespace RuntimeXNA.Events
{	
	public class CEventGroup
	{
		public byte evgNCond;
		public byte evgNAct;
		public ushort evgFlags;
		public ushort evgInhibit;
		public short evgInhibitCpt;
		public ushort evgIdentifier;
		public CEvent[] evgEvents = null;
		
		// Internal flags of eventgroups
		public const ushort EVGFLAGS_ONCE = (ushort) (0x0001);
		public const ushort EVGFLAGS_NOTALWAYS = (ushort) (0x0002);
		public const ushort EVGFLAGS_REPEAT = (ushort) (0x0004);
		public const ushort EVGFLAGS_NOMORE = (ushort) (0x0008);
		public const ushort EVGFLAGS_SHUFFLE = (ushort) (0x0010);
		public const ushort EVGFLAGS_EDITORMARK = (ushort) (0x0020);
		public const ushort EVGFLAGS_UNDOMARK = (ushort) (0x0040);
		public const ushort EVGFLAGS_COMPLEXGROUP = (ushort) (0x0080);
		public const ushort EVGFLAGS_BREAKPOINT = (ushort) (0x0100);
		public const ushort EVGFLAGS_ALWAYSCLEAN = (ushort) (0x0200);
		public const ushort EVGFLAGS_ORINGROUP = (ushort) (0x0400);
		public const ushort EVGFLAGS_STOPINGROUP = (ushort) (0x0800);
		public const ushort EVGFLAGS_ORLOGICAL = (ushort) (0x1000);
		public const ushort EVGFLAGS_GROUPED = (ushort) (0x2000);
		public const ushort EVGFLAGS_INACTIVE = (ushort) (0x4000);
		public static ushort EVGFLAGS_NOGOOD = 0x8000;
		//UPGRADE_NOTE: Final was removed from the declaration of 'EVGFLAGS_LIMITED '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		public static readonly ushort EVGFLAGS_LIMITED = (ushort) (EVGFLAGS_SHUFFLE + EVGFLAGS_NOTALWAYS + EVGFLAGS_REPEAT + EVGFLAGS_NOMORE);
		//UPGRADE_NOTE: Final was removed from the declaration of 'EVGFLAGS_DEFAULTMASK '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		public static readonly ushort EVGFLAGS_DEFAULTMASK = (ushort) (EVGFLAGS_BREAKPOINT + EVGFLAGS_GROUPED);
		
		public CEventGroup()
		{
		}
		public static CEventGroup create(CRunApp app,CFile file)
		{
			int debut = file.getFilePointer();
			
			short size = file.readAShort(); // evgSize
			CEventGroup evg = new CEventGroup();
			
			evg.evgNCond = (byte) file.readByte();
			evg.evgNAct = (byte) file.readByte();
			Console.WriteLine($"Conditions: {evg.evgNCond}. Actions: {evg.evgNAct}");
			evg.evgFlags = (ushort)file.readAShort();
			file.readAShort();
			evg.evgInhibit = (ushort)file.readAInt();
			evg.evgInhibitCpt = (short)file.readAInt();
			//evg.evgInhibit = (ushort)file.readAShort();
			//evg.evgInhibitCpt = (short)file.readAShort();
			//evg.evgIdentifier = (ushort)file.readAShort();
			//file.skipBytes(2); // evgUndo
			
			evg.evgEvents = new CEvent[evg.evgNCond + evg.evgNAct];
			int n;
			int count = 0;
			for (n = 0; n < evg.evgNCond; n++)
			{
				evg.evgEvents[count++] = CCnd.create(app,file);
			}
			
			for (n = 0; n < evg.evgNAct; n++)
			{
				evg.evgEvents[count++] = CAct.create(app,file);
			}
			
			// Positionne en fin de groupe
			file.seek(debut - size);
			
			return evg;
		}
	}
}