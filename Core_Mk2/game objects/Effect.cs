using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Mk2
{
    public class Effect
    {
        public Effect(float value, float triggerThreshold, int duration, int maxStack, (EPlayerType, ECharacteristic, EDerivative, EVariable) link, (EPlayerType, EEvent) triggerEvent, (EPlayerType, EEvent) tickEvent)
        {
            _value = value;
            _triggerThreshold = triggerThreshold;
            _duration = duration;
            _maxStack = maxStack;
            _link = link;
            _triggerEvent = triggerEvent;
            _tickEvent = tickEvent;
        }

        private readonly float _value;

        private readonly float _triggerThreshold;

        private readonly int _duration;

        private readonly int _maxStack;

        private readonly (EPlayerType, EEvent) _triggerEvent;

        private readonly (EPlayerType, EEvent) _tickEvent;

        private readonly (EPlayerType, ECharacteristic, EDerivative, EVariable) _link;

        private bool _isActive;

        private int _counterTick;

        private int _counterStack;

        private Derivative _derivative;

        public void Installation(object sender, CharacterSlot enemy)
        {
            if (sender is CharacterSlot owner)
            {
                _isActive = false;
                var target = (_link.Item1) switch
                {
                    EPlayerType.Self => owner,
                    EPlayerType.Enemy => enemy,
                    _ => throw new NotImplementedException(),
                };
                _derivative = target.Data[_link.Item2][_link.Item3];

                SubscribeTrigger(owner, enemy);
                SubscribeTick(owner, enemy);

            }
            else { throw new NotImplementedException(); }
        }

        private void SubscribeTrigger(CharacterSlot owner, CharacterSlot enemy)
        {
            CharacterSlot target = (_triggerEvent.Item1) switch
            {
                EPlayerType.Self => owner,
                EPlayerType.Enemy => enemy,
                _ => throw new NotImplementedException(),
            };
            switch (_triggerEvent.Item2)
            {
                case EEvent.DeltaGold: target.StepExecution += Tick; break;
            }
        }

        private void SubscribeTick(CharacterSlot owner, CharacterSlot enemy)
        {
            CharacterSlot target = (_tickEvent.Item1) switch
            {
                EPlayerType.Self => owner,
                EPlayerType.Enemy => enemy,
                _ => throw new NotImplementedException(),
            };
            switch (_tickEvent.Item2)
            {
                case EEvent.StepExecution:
                    target.DeltaGold += Activation;
                    break;
            }
        }

        public void Activation(object sender, float value)
        {
            if (value > _triggerThreshold)
            {
                _isActive = true;
                _counterTick = _duration;
                if (_counterStack < _maxStack)
                {
                    _derivative.ChangeVariable(_link.Item4, _value);
                    _counterStack++;
                }
            }
        }

        /// <summary>
        /// Перегрузка счетчика для подписки на событие завершения хода 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="value"></param>
        public void Tick(object sender, EventArgs args)
        {
            if (_isActive)
            {
                if (_counterTick > 0)
                {
                    _counterTick--;
                }
                else
                {
                    _derivative.ChangeVariable(_link.Item4, -_value * _counterStack);
                    _isActive = false;
                    _counterStack = 0;
                }
            }
        }
    }
}
