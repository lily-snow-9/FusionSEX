//----------------------------------------------------------------------------------
//
// CDEFCOUNTER : valeurs de depart counter
//
//----------------------------------------------------------------------------------

using FusionX.Services;

namespace FusionX.OI
{
    class CDefCounter : CDefObject
    {
        public int ctInit;				// Initial value
        public int ctMini;				// Minimal value
        public int ctMaxi;				// Maximal value

        public override void load(CFile file) 
        {
            file.skipBytes(2);              // Taille
            ctInit=file.readAInt();
            ctMini=file.readAInt();
            ctMaxi=file.readAInt();
        }
    }
}
