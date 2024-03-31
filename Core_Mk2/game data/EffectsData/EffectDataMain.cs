using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Mk2
{
    public static partial class EffectData
    {
        public static readonly List<IEffect> effects = new List<IEffect>();
        static EffectData()
        {
            PPMInit();
            TPMInit();
            LMEInit();

            effects.Clear();
            effects.AddRange(PPMEffects);
            effects.AddRange(TPMEffects);
            effects.AddRange(LMEEffects);
        }
    }

}
