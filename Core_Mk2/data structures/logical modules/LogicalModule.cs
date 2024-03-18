using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Mk2
{
    public abstract class LogicalModule
    {
        protected CharacterSlot _owner;
        protected CharacterSlot _enemy;
        //StepExecution, Death,
        protected EEvent? _type1Data;
        //DamageEmitting, DamageAccepting, DamageBlocking, DamageTaking,
        protected (EEvent eEvent, EDamageType damageType, float value)? _type2Data;
        //DeltaFireMana, DeltaWaterMana, DeltaAirMana, DeltaEarthMana,
        //DeltaXP, DeltaHP, DeltaGold
        protected (EEvent eEvent, float value)? _type3Data;

        public void Installation(CharacterSlot owner, CharacterSlot enemy)
        {
            _owner = owner;
            _enemy = enemy;
        }

        public void SetData(EEvent arg)
        {
            _type1Data = arg;
        }
        public void SetData((EEvent eEvent, EDamageType damageType, float value) arg)
        {
            _type2Data = arg;
        }
        public void SetData((EEvent eEvent, float args) arg)
        {
            _type3Data = arg;
        }
        public abstract bool IsActivate();
        public abstract LogicalModule Clone();
    }

    /// <summary>
    /// Модуль, всегда возвращающий True
    /// </summary>
    public class LM_CONSTANT_TRUE : LogicalModule
    {
        public override LogicalModule Clone()
        {
            return new LM_CONSTANT_TRUE();
        }

        public override bool IsActivate()
        {
            return true;
        }
    }

    /// <summary>
    /// Модуль, где нужно, чтобы _type3Data содержал value больше, чем triggerThreshold. При Удовлетворение условия значение _type3Data стирается
    /// </summary>
    public class LM_01 : LogicalModule
    {
        private readonly float _triggerThreshold;
        public LM_01(float triggerThreshold) { _triggerThreshold = triggerThreshold;  }

        public override bool IsActivate()
        {
            if (_type3Data?.value >= _triggerThreshold)
            {
                _type3Data = null;
                return true;
            }
            return false;
        }
        public override LogicalModule Clone() { return new LM_01(_triggerThreshold); }
    }
}
