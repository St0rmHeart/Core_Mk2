using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Core_Mk2
{
    public class TriggerParameterModifier : IEffect
    {
        private TriggerParameterModifier(
            string name,
            string description,
            List<float> values,
            LogicalModule triggerlogicalModule,
            LogicalModule ticklogicalModule,
            int duration,
            int maxStack,
            List<(EPlayerType, ECharacteristic, EDerivative, EVariable)> links,
            List<(EPlayerType, EEvent)> triggerEvents,
            List<(EPlayerType, EEvent)> tickEvents)
        {
            Name = name;
            Description = description;
            _values = values;
            _triggerlogicalModule = triggerlogicalModule;
            _ticklogicalModule = ticklogicalModule;
            _duration = duration;
            _maxStack = maxStack;
            _links = links;
            _triggerEvents = triggerEvents;
            _tickEvents = tickEvents;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }

        private readonly LogicalModule _triggerlogicalModule;

        private readonly LogicalModule _ticklogicalModule;

        private readonly int _duration;

        private readonly int _maxStack;

        private readonly List<float> _values;

        private readonly List<(EPlayerType target, EEvent type)> _triggerEvents;

        private readonly List<(EPlayerType target, EEvent type)> _tickEvents;

        private readonly List<(EPlayerType target, ECharacteristic characteristic, EDerivative derivative, EVariable variable)> _links;

        private readonly List<Parameter> _parameters = new List<Parameter>();

        private bool _isActive;

        private int _counterTick;

        private int _counterStack;







        public void Installation(CharacterSlot owner, CharacterSlot enemy)
        {
            _isActive = false;

            for (int i = 0; i < _values.Count; i++)
            {
                var link = _links[i];
                var target = (link.target == EPlayerType.Self) ? owner : enemy;
                var currentParameter = target.Data[link.characteristic][link.derivative];
                _parameters.Add(currentParameter);
            }
            foreach (var triggerEvent in _triggerEvents)
            {
                SubscribeTrigger(owner, enemy, triggerEvent);
            }
            foreach (var tickEvent in _tickEvents)
            {
                SubscribeTick(owner, enemy, tickEvent);
            }
            _triggerlogicalModule.Installation(owner, enemy);
            _ticklogicalModule.Installation(owner, enemy);
        }
        private void SubscribeTrigger(CharacterSlot owner, CharacterSlot enemy, (EPlayerType target, EEvent type) triggerEvent)
        {
            var target = (triggerEvent.target == EPlayerType.Self) ? owner : enemy;
            switch (triggerEvent.type)
            {
                case EEvent.StepExecution: target.StepExecution += Activation; break;
                case EEvent.DamageEmitting: target.DamageEmitting += Activation; break;
                case EEvent.DamageAccepting: target.DamageAccepting += Activation; break;
                case EEvent.DamageBlocking: target.DamageBlocking += Activation; break;
                case EEvent.DamageTaking: target.DamageTaking += Activation; break;
                case EEvent.DeltaFireMana: target.DeltaFireMana += Activation; break;
                case EEvent.DeltaWaterMana: target.DeltaWaterMana += Activation; break;
                case EEvent.DeltaAirMana: target.DeltaAirMana += Activation; break;
                case EEvent.DeltaEarthMana: target.DeltaEarthMana += Activation; break;
                case EEvent.DeltaXP: target.DeltaXP += Activation; break;
                case EEvent.DeltaHP: target.DeltaHP += Activation; break;
                case EEvent.DeltaGold: target.DeltaGold += Activation; break;
                default: throw new NotImplementedException();
            }
        }
        private void SubscribeTick(CharacterSlot owner, CharacterSlot enemy, (EPlayerType target, EEvent type) tickEvent)
        {
            var target = (tickEvent.target == EPlayerType.Self) ? owner : enemy;
            switch (tickEvent.type)
            {
                case EEvent.StepExecution: target.StepExecution += Tick; break;
                case EEvent.DamageEmitting: target.DamageEmitting += Tick; break;
                case EEvent.DamageAccepting: target.DamageAccepting += Tick; break;
                case EEvent.DamageBlocking: target.DamageBlocking += Tick; break;
                case EEvent.DamageTaking: target.DamageTaking += Tick; break;
                case EEvent.DeltaFireMana: target.DeltaFireMana += Tick; break;
                case EEvent.DeltaWaterMana: target.DeltaWaterMana += Tick; break;
                case EEvent.DeltaAirMana: target.DeltaAirMana += Tick; break;
                case EEvent.DeltaEarthMana: target.DeltaEarthMana += Tick; break;
                case EEvent.DeltaXP: target.DeltaXP += Tick; break;
                case EEvent.DeltaHP: target.DeltaHP += Tick; break;
                case EEvent.DeltaGold: target.DeltaGold += Tick; break;
                default: throw new NotImplementedException();
            }
        }

        public void Activation()
        {
            if (_triggerlogicalModule.IsActivate())
            {
                _isActive = true;
                _counterTick = _duration;
                if (_counterStack < _maxStack)
                {
                    for (int i = 0; i < _parameters.Count; i++)
                    {
                        _parameters[i].ChangeVariable(_links[i].variable, _values[i]);
                    }
                    _counterStack++;
                }
            }
        }
        public void Activation(object sender, EEvent arg)
        {
            _triggerlogicalModule.SetData(arg);
            Activation();
        }
        public void Activation(object sender, (EEvent eEvent, EDamageType damageType, float value) arg)
        {
            _triggerlogicalModule.SetData(arg);
            Activation();
        }
        public void Activation(object sender, (EEvent eEvent, float args) arg)
        {
            _triggerlogicalModule.SetData(arg);
            Activation();
        }

        public void Tick()
        {
            if (_isActive && _ticklogicalModule.IsActivate())
            {
                if (_counterTick > 0)
                {
                    _counterTick--;
                }
                else
                {
                    for (int i = 0; i < _parameters.Count; i++)
                    {
                        _parameters[i].ChangeVariable(_links[i].variable, - (_values[i]) * _counterStack);
                    }
                    _isActive = false;
                    _counterStack = 0;
                }
            }
        }
        public void Tick(object sender, EEvent arg)
        {
            _ticklogicalModule.SetData(arg);
            Tick();
        }
        public void Tick(object sender, (EEvent eEvent, EDamageType damageType, float value) arg)
        {
            _ticklogicalModule.SetData(arg);
            Tick();
        }
        public void Tick(object sender, (EEvent eEvent, float args) arg)
        {
            _ticklogicalModule.SetData(arg);
            Tick();
        }

        public IEffect Clone()
        {
            return new TriggerParameterModifier(
                name: Name,
                description: Description,
                values: new List<float>(_values),
                triggerlogicalModule: _triggerlogicalModule.Clone(),
                ticklogicalModule: _ticklogicalModule.Clone(),
                duration: _duration,
                maxStack: _maxStack,
                links: new List<(EPlayerType, ECharacteristic, EDerivative, EVariable)>(_links),
                triggerEvents: new List<(EPlayerType, EEvent)>(_triggerEvents),
                tickEvents: new List<(EPlayerType, EEvent)>(_tickEvents));
        }





        public class TPMBuilder
        {
            private string _name;
            private string _description;
            private LogicalModule _triggerlogicalModule;
            private LogicalModule _ticklogicalModule;
            private int _duration;
            private int _maxStack;
            private List<float> _values = new List<float>();
            private List<(EPlayerType target, EEvent type)> _triggerEvents = new List<(EPlayerType target, EEvent type)>();
            private EPlayerType _targetTriggerEvent;
            private EEvent _eventTypeTriggerEvent;
            private List<(EPlayerType target, EEvent type)> _tickEvents = new List<(EPlayerType target, EEvent type)>();
            private EPlayerType _targetTickEvent;
            private EEvent _eventTypeTickEvent;
            private List<(EPlayerType target, ECharacteristic characteristic, EDerivative derivative, EVariable variable)> _links = new List<(EPlayerType target, ECharacteristic characteristic, EDerivative derivative, EVariable variable)>();
            private EPlayerType _targetLink;
            private ECharacteristic _characteristicLink;
            private EDerivative _derivativeLink;
            private EVariable _variableLink;

            public TPMBuilder() { Reset(); }

            public void Reset()
            {
                _name = null;
                _description = null;
                _triggerlogicalModule = null;
                _ticklogicalModule = null;
                _duration = 0;
                _maxStack = 0;
                _values.Clear();
                _triggerEvents.Clear();
                _tickEvents.Clear();
                _links.Clear();
                _targetTriggerEvent = EPlayerType.None;
                _eventTypeTriggerEvent = EEvent.None;
                _targetTickEvent = EPlayerType.None;
                _eventTypeTickEvent = EEvent.None;
                _targetLink = EPlayerType.None;
                _characteristicLink = ECharacteristic.None;
                _derivativeLink = EDerivative.None;
                _variableLink = EVariable.None;
            }
            public TPMBuilder Name(string value) {  _name = value; return this; }
            public TPMBuilder Description(string value) { _description = value; return this; }
            public TPMBuilder TriggerlogicalModule(LogicalModule value) { _triggerlogicalModule = value; return this; }
            public TPMBuilder TicklogicalModule(LogicalModule value) { _ticklogicalModule = value; return this; }
            public TPMBuilder Duration(int value) { _duration = value; return this; }
            public TPMBuilder MaxStack(int value) { _maxStack = value; return this; }
            public TPMBuilder AddValue(float value) { _values.Add(value); return this; }
            public TPMBuilder ComposeLink(EPlayerType value)
            {
                _targetLink = value;
                return this;
            }
            public TPMBuilder ComposeLink(ECharacteristic value)
            {
                _characteristicLink = value;
                return this;
            }
            public TPMBuilder ComposeLink(EDerivative value)
            {
                _derivativeLink = value;
                return this;
            }
            public TPMBuilder ComposeLink(EVariable value)
            {
                _variableLink = value;
                return this;
            }
            public TPMBuilder SetLink()
            {
                if (_targetLink == EPlayerType.None || _characteristicLink == ECharacteristic.None || _derivativeLink == EDerivative.None || _variableLink == EVariable.None)
                    throw new ArgumentException("Один из элементов ссылки не заполнен");
                if (!ENUMS_CONSTANT_DATA.CHAR_DER_PAIRS[_characteristicLink].Contains(_derivativeLink))
                    throw new ArgumentException("Невозможная ссылка. У " + nameof(_characteristicLink) + " нет производной " + nameof(_derivativeLink) + ".");
                if (_variableLink == EVariable.A0)
                    throw new ArgumentException("Нельзя модифицировать A0 переменную");

                _links.Add((_targetLink, _characteristicLink, _derivativeLink, _variableLink));
                return this;
            }
            public TPMBuilder ComposeTriggerEvent(EPlayerType value)
            {
                _targetTriggerEvent = value;
                return this;
            }
            public TPMBuilder ComposeTriggerEvent(EEvent value)
            {
                _eventTypeTriggerEvent = value;
                return this;
            }
            public TPMBuilder SetTriggerEvent()
            {
                _triggerEvents.Add((_targetTriggerEvent, _eventTypeTriggerEvent));
                return this;
            }
            public TPMBuilder ComposeTickEvent(EPlayerType value)
            {
                _targetTickEvent = value;
                return this;
            }
            public TPMBuilder ComposeTickEvent(EEvent value)
            {
                _eventTypeTickEvent = value;
                return this;
            }
            public TPMBuilder SetTickEventt()
            {
                _tickEvents.Add((_targetTickEvent, _eventTypeTickEvent));
                return this;
            }

            public TriggerParameterModifier Build()
            {
                return new TriggerParameterModifier(
                name: _name,
                description: _description,
                values: new List<float>(_values),
                triggerlogicalModule: _triggerlogicalModule.Clone(),
                ticklogicalModule: _ticklogicalModule.Clone(),
                duration: _duration,
                maxStack: _maxStack,
                links: new List<(EPlayerType, ECharacteristic, EDerivative, EVariable)>(_links),
                triggerEvents: new List<(EPlayerType, EEvent)>(_triggerEvents),
                tickEvents: new List<(EPlayerType, EEvent)>(_tickEvents));
            }
        }
    }
}
