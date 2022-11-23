//----------------------------------------------------------------------------------
//
// CDEFOBJECT : Classe abstraite de definition d'un objet'
//
//----------------------------------------------------------------------------------

using FusionX.Banks;
using FusionX.Services;

namespace FusionX.OI
{
    public class CDefObject
    {
        virtual public void load(CFile file) { }
        virtual public void enumElements(IEnum enumImages, IEnum enumFonts) { }
    }
}
