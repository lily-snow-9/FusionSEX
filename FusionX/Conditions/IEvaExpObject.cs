// ------------------------------------------------------------------------------
// 
// INTERFACE IEVAEXPOBJECT pour l'exploration des objets d'une condition
// 
// ------------------------------------------------------------------------------

using FusionX.Objects;

namespace FusionX.Conditions
{
    public interface IEvaExpObject
    {
        bool evaExpRoutine(CObject hoPtr, int v, short comp);
    }
}
