// ------------------------------------------------------------------------------
// 
// INTERFACE POUR CHOOSEVALUE1
// 
// ------------------------------------------------------------------------------

using FusionX.Objects;

namespace FusionX.Conditions
{
    public interface IChooseValue
    {
        bool evaluate(CObject pHo, int v);
    }
}
