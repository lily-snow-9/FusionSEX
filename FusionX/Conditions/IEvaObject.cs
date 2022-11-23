// ------------------------------------------------------------------------------
// 
// IEVAOBJECT : interface pour les conditions
// 
// ------------------------------------------------------------------------------

using FusionX.Objects;

namespace FusionX.Conditions
{
    public interface IEvaObject
    {
        bool evaObjectRoutine(CObject hoPtr);
    }
}
