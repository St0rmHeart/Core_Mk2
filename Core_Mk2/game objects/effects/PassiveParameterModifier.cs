using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace Core_Mk2
{
    /// <summary>
    /// Эффект, модифицирующий набор указанных переменных в указанных параметрах в начале сражения. Может либо мофицировать все ссылки одним значением,
    /// либо модифицировать каждую ссылку своим уникальным значением
    /// </summary>
    public class PassiveParameterModifier : IEffect
    {
        private PassiveParameterModifier(
            string name,
            string description,
            List<double> values,
            List<(EPlayerType, ECharacteristic, EDerivative, EVariable)> links)
        {
            Name = name;
            Description = description;
            _values = values;
            _links = links;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        private readonly List<double> _values;
        private readonly List<(EPlayerType target, ECharacteristic characteristic, EDerivative derivative, EVariable variable)> _links;

        public void Installation(CharacterSlot owner, CharacterSlot enemy)
        {
            for (int i = 0; i < _values.Count; i++)
            {
                var link = _links[i];
                var target = (link.target == EPlayerType.Self) ? owner : enemy;
                var currentParameter = target.Data[link.characteristic][link.derivative];
                currentParameter.ChangeVariable(link.variable, _values[i]);
            }
        }

        public IEffect Clone()
        {
            return new PassiveParameterModifier(
                Name,
                Description,
                new List<double>(_values),
                new List<(EPlayerType, ECharacteristic, EDerivative, EVariable)>(_links));
        }





        public class PPMBuilder
        {
            private string _name;

            private string _description;

            private readonly List<double> _values = new List<double>();

            private readonly List<(EPlayerType target, ECharacteristic characteristic, EDerivative derivative, EVariable variable)> _links = new List<(EPlayerType, ECharacteristic, EDerivative, EVariable)>();

            private EPlayerType _target;

            private ECharacteristic _characteristic;

            private EDerivative _derivative;

            private EVariable _variable;

            public PPMBuilder()
            {
                Reset();
            }
            public PPMBuilder Reset()
            {
                _name = null;
                _description = null;
                _values.Clear();
                _links.Clear();
                _target = EPlayerType.None;
                _characteristic = ECharacteristic.None;
                _derivative = EDerivative.None;
                _variable = EVariable.None;
                return this;
            }
            public PPMBuilder Name(string value)
            {
                _name = value; return this;
            }
            public PPMBuilder Description(string value)
            {
                _description = value;
                return this;
            }
            public PPMBuilder ComposeLink(string name)
            {
                _name = name;
                return this;
            }
            public PPMBuilder ComposeLink(EPlayerType target)
            {
                _target = target;
                return this;
            }
            public PPMBuilder ComposeLink(ECharacteristic characteristic)
            {
                _characteristic = characteristic;
                return this;
            }
            public PPMBuilder ComposeLink(EDerivative derivative)
            {
                _derivative = derivative;
                return this;
            }
            public PPMBuilder ComposeLink(EVariable variable)
            {
                if (variable == EVariable.A0) throw new ArgumentException("Нельзя модифицировать A0 переменную");
                _variable = variable;
                return this;
            }
            public PPMBuilder AddLink()
            {
                if (_target == EPlayerType.None || _characteristic == ECharacteristic.None || _derivative == EDerivative.None || _variable == EVariable.None)
                {
                    throw new ArgumentException("Один из элементов ссылки не заполнен");
                }
                if (!CONSTANT.CHAR_DER_PAIRS[_characteristic].Contains(_derivative))
                {
                    throw new ArgumentException("Невозможная ссылка. У " + nameof(_characteristic) + " нет производной " + nameof(_derivative) + ".");
                }

                var newLink = (_target, _characteristic, _derivative, _variable);

                if (_links.Contains(newLink))
                {
                    throw new ArgumentException("Указанная ссылка уже существует.");
                }

                _links.Add(newLink);
                return this;
            }
            public PPMBuilder AddValue(double value)
            {
                _values.Add(value);
                return this;
            }
            public PassiveParameterModifier Build()
            {
                if (_name == null) throw new ArgumentException("Отсутствует название эффекта.");
                if (_description == null) throw new ArgumentException("Отсутствует описание эффекта.");
                if (_values.Count == 0) throw new ArgumentException("Отсутствует значение эффекта.");
                if (_links.Count == 0) throw new ArgumentException("Отсутствует ссылка.");

                List<double> values;
                if (_values.Count == 1)
                {
                    values = new List<double>(new int[_links.Count].Select(x => _values[0]));
                }
                else
                {
                    if (_values.Count != _links.Count)
                    {
                        throw new ArgumentException("_values.Count должно быть либо равно 1, рибо быть равным _links.Count");
                    }
                    values = _values;
                }
                return new PassiveParameterModifier(
                    _name,
                    _description,
                    new List<double>(values),
                    new List<(EPlayerType, ECharacteristic, EDerivative, EVariable)>(_links));
            }
            public PassiveParameterModifier BuildWithReset()
            {
                var passiveParameterModifier = Build();
                Reset();
                return passiveParameterModifier;
            }
        }
    }
}
