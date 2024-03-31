using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Mk2
{
    public static partial class EffectData
    {
        public static readonly List<LogicalModuleEffect> LMEEffects = new List<LogicalModuleEffect>();
        private static void LMEInit()
        {
            var LMEbuilder = new LogicalModuleEffect.LMEBuilder();
            var currentEffect = LMEbuilder
                .Name("Стена огня")
                .Description(
                    "!!ДЛЯ ТЕСТА!! При поглощении маны земли. !!ДЛЯ ТЕСТА!!\n" +
                    "Теперь урон наносится вашей красной мане. Каждый ход уменьшает запас красной маны на 2." +
                    "Длится пока красная мана не опустится до нуля.")
                .TriggerlogicalModule(new LM_01_deltaThreshold(threshold: 0))
                .TicklogicalModule(new LM_03_manaShieldTickModule(element: ECharacteristic.Fire, costOfMaintenance: 2))
                .AddTriggerEvent(EPlayerType.Self, EEvent.DeltaEarthMana)
                .AddTickEventt(EPlayerType.Self, EEvent.DamageAccepting)
                .AddTickEventt(EPlayerType.Self, EEvent.StepExecution)
                .Build();
            LMEEffects.Add(currentEffect);
        }
    }
}
