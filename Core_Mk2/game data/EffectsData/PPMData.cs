using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Mk2
{
    public static partial class EffectData
    {
        public static readonly List<PassiveParameterModifier> PPMEffects= new List<PassiveParameterModifier>();
        private static void PPMInit()
        {
            var PPMbuilder = new PassiveParameterModifier.PPMBuilder();
            var currentEffect = PPMbuilder
                .Name("Живучесть.")
                .Description("Увеличивает максимальное здоровье на 10.")
                .ComposeLink(EPlayerType.Self)
                .ComposeLink(ECharacteristic.Endurance)
                .ComposeLink(EDerivative.MaxHealth)
                .ComposeLink(EVariable.C2)
                .AddLink()
                .AddValue(10)
                .BuildWithReset();
            PPMEffects.Add(currentEffect);
        }
    }
}
