using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Mk2
{
    public class EffectBuilder
    {
        private float _value;

        private float _triggerThreshold;

        private int _duration;

        private int _maxStack;

        private (EPlayerType, EEvent) _triggerEvent;

        private (EPlayerType, EEvent) _tickEvent;

        private (EPlayerType, ECharacteristic, EDerivative, EVariable) _link;

        public EffectBuilder()
        {
            Reset();
        }

        public EffectBuilder WithValue(float value)
        {
            _value = value;
            return this;
        }
        public EffectBuilder WithTriggerThreshold(float triggerThreshold)
        {
            _triggerThreshold = triggerThreshold;
            return this;
        }
        public EffectBuilder WithDuration(int duration)
        {
            _duration = duration;
            return this;
        }
        public EffectBuilder WithLink(EPlayerType playerType, ECharacteristic characteristic, EDerivative derivative, EVariable variable)
        {
            _link = (playerType, characteristic, derivative, variable);
            return this;
        }

        public EffectBuilder WithTriggerEvent(EPlayerType playerType, EEvent eventType)
        {
            _triggerEvent = (playerType, eventType);
            return this;
        }
        public EffectBuilder WithTickEvent(EPlayerType playerType, EEvent eventType)
        {
            _tickEvent = (playerType, eventType);
            return this;
        }

        public EffectBuilder WithMaxStack(int value)
        {
            _maxStack = value;
            return this;
        }

        public Effect Build()
        {
            if (_value != 0 &&
                _duration != 0 &&
                _maxStack != 0 &&
                _link.Item1 != 0 &&
                _link.Item2 != 0 &&
                _link.Item3 != 0 &&
                _link.Item4 != 0 &&
                _triggerEvent.Item1 != 0 &&
                _triggerEvent.Item2 != 0 &&
                _tickEvent.Item1 != 0 &&
                _tickEvent.Item2 != 0)
            {
                var effect = new Effect(
                _value,
                _triggerThreshold,
                _duration,
                _maxStack,
                _link,
                _triggerEvent,
                _tickEvent);
                return effect;
            }
            else
                throw new InvalidOperationException("Невозможная комбанция параметров строителя");

        }
        public void Reset()
        {
            _value = 0;
            _triggerThreshold = 0;
            _duration = 0;
            _maxStack = 0;
            _link.Item1 = 0;
            _link.Item2 = 0;
            _link.Item3 = 0;
            _link.Item4 = 0;
            _triggerEvent.Item1 = 0;
            _triggerEvent.Item2 = 0;
            _tickEvent.Item1 = 0;
            _tickEvent.Item2 = 0;
        }
    }
}
