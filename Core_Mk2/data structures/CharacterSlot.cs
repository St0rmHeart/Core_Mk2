using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Mk2
{
    /// <summary>
    /// Структура хранения всей информации для каждого из двух игроков, необходимой для "сражения"
    /// </summary>
    public class CharacterSlot
    {
        #region _____________________STATIC_____________________
        //Бонусны за совмещение 3/4/5 камней одного типа в ряд
        private static readonly float[] combinationMultiplier = { 1.0f, 1.3f, 1.8f };
        #endregion

        #region _____________________EVENT_____________________
        //Событие инициализации всех эффектов.Долджно вызываться только в классе - владельце и
        //в качестве параметра должен передаваться текущий противник владельца
        public event EventHandler<CharacterSlot> Initialization;

        //Событие начала сражение, необходимое болше всего для "пассивных эффектов"
        public event EventHandler GameStart;

        //Событие о завершении хода владельцем
        public event EventHandler StepExecution;

        //Событие о гибели владельца
        public event EventHandler Death;



        //Событие об ипускании владельцем value едениц EDamageType урона
        public event EventHandler<(EDamageType damageType, float value)> DamageEmitting;

        //Событие о принятии владельцем value едениц EDamageType урона
        public event EventHandler<(EDamageType damageType, float value)> DamageAccepting;

        //Событие о блокировании владельцем value едениц EDamageType урона
        public event EventHandler<(EDamageType damageType, float value)> DamageBlocking;

        //Событие о получении владельцем value едениц EDamageType урона
        public event EventHandler<(EDamageType damageType, float value)> DamageTaking;

        //Событие о изменении количества очков опыта у владельца
        public event EventHandler<float> DeltaXP;

        //Событие о изменении количества очков здоровья у владельца 
        public event EventHandler<float> DeltaHP;

        //Событие о изменении количества золота у владельца 
        public event EventHandler<float> DeltaGold;



        //Событие о изменении количества маны огня у владельца 
        public event EventHandler<float> DeltaFireMana;

        //Событие о изменении количества маны воды у владельца 
        public event EventHandler<float> DeltaWaterMana;

        //Событие о изменении количества маны воздуха у владельца 
        public event EventHandler<float> DeltaAirMana;

        //Событие о изменении количества маны земли у владельца 
        public event EventHandler<float> DeltaEarthMana;
        #endregion

        #region _________________________ПОЛЯ_________________________
        //модуль для получения случайных значений
        private readonly Random RandomModule = new Random();


        //ссылка на переключатель хода
        public TurnSwitch TurnSwitcherModule { private get; set; }


        //ссылка на модуль боевой системы, через который персонаж наносит и плучает урон
        public DamageModule DamageModule { private get; set; }


        //ccылка на текущего оппонента в сражении
        public CharacterSlot CurrentOpponent { private get; set; }


        //персонаж - владелец
        public Character Character { get; private set; }


        //различные динамически высчитываемые параетры персонажа
        public DerivativesEnumeration Data { get; private set; }
        #endregion

        #region ______________________КОНСТРУКТОР______________________
        /// <summary>
        /// Стандартный конструктор ячейки персонажа
        /// </summary>
        /// <param name="character">Указатель на объект-персонажа </param>
        public CharacterSlot(Character character)
        {
            //установка персонажа
            Character = character;

            //Рассчет всех производных параметров персонажа
            Data = new DerivativesEnumeration(character);

            //инициализация всех эффектов в снаряжении персонажа
            foreach (Equipment item in Character.Equipment.Values)
            {
                foreach (Effect effect in item.Effects)
                {
                    Initialization += effect.Installation;
                }
            }
        }
        #endregion

        #region ______________________СВОЙСТВА______________________
        //Здоровье персонажа
        public float Health
        {
            get
            {
                if (Data[ECharacteristic.Endurance][EDerivative.CurrentHealth] is CurrentParameter current)
                    return current.CurrentValue;
                else 
                    throw new InvalidOperationException("Некорректный класс по адресу.");
            }
            private set
            {
                if (Data[ECharacteristic.Endurance][EDerivative.CurrentHealth] is CurrentParameter current)
                    current.CurrentValue = value;
                else
                    throw new InvalidOperationException("Некорректный класс по адресу.");
            }
        }


        //Опыт персонажа
        public int Xp
        {
            get { return Character.Xp; }
            private set { Character.Xp = value; }
        }


        //Золото персонажа
        public int Gold
        {
            get { return Character.Gold; }
            private set { Character.Gold = value; }
        }


        //Мана огня персонажа
        public float ManaFire
        {
            get
            {
                if (Data[ECharacteristic.Fire][EDerivative.CurrentMana] is CurrentParameter current)
                    return current.CurrentValue;
                else
                    throw new InvalidOperationException("Некорректный класс по адресу.");
            }
            private set
            {
                if (Data[ECharacteristic.Fire][EDerivative.CurrentMana] is CurrentParameter current)
                    current.CurrentValue = value;
                else
                    throw new InvalidOperationException("Некорректный класс по адресу.");
            }
        }


        //Мана воды персонажа
        public float ManaWater
        {
            get
            {
                if (Data[ECharacteristic.Water][EDerivative.CurrentMana] is CurrentParameter current)
                    return current.CurrentValue;
                else
                    throw new InvalidOperationException("Некорректный класс по адресу.");
            }
            private set
            {
                if (Data[ECharacteristic.Water][EDerivative.CurrentMana] is CurrentParameter current)
                    current.CurrentValue = value;
                else
                    throw new InvalidOperationException("Некорректный класс по адресу.");
            }
        }


        //Мана земли персонажа
        public float ManaEarth
        {
            get
            {
                if (Data[ECharacteristic.Earth][EDerivative.CurrentMana] is CurrentParameter current)
                    return current.CurrentValue;
                else
                    throw new InvalidOperationException("Некорректный класс по адресу.");
            }
            private set
            {
                if (Data[ECharacteristic.Earth][EDerivative.CurrentMana] is CurrentParameter current)
                    current.CurrentValue = value;
                else
                    throw new InvalidOperationException("Некорректный класс по адресу.");
            }
        }


        //Мана воздуха персонажа
        public float ManaAir
        {
            get
            {
                if (Data[ECharacteristic.Air][EDerivative.CurrentMana] is CurrentParameter current)
                    return current.CurrentValue;
                else
                    throw new InvalidOperationException("Некорректный класс по адресу.");
            }
            private set
            {
                if (Data[ECharacteristic.Air][EDerivative.CurrentMana] is CurrentParameter current)
                    current.CurrentValue = value;
                else
                    throw new InvalidOperationException("Некорректный класс по адресу.");
            }
        }


        //Имя персонажа
        public string GetName
        {
            get { return Character.Name; }
        }
        #endregion

        #region _____________________МЕТОДЫ_____________________

        /// <summary>
        /// Пробрасывает связи между А, В, C, где:
        /// А - события;
        /// В - методы, реагирующие на события;
        /// С - данные, на которые методы оказывают влияние.
        /// Должен вызываться только персонажем-владельцем.
        /// </summary>
        /// <param name="enemy">Текущий противник</param>
        public void InitializeEffects(CharacterSlot enemy)
        {
            Initialization?.Invoke(this, enemy);
        }

        /// <summary>
        /// Завершить ход и вызвать событие о завершении хода.
        /// </summary>
        public void CompleteStep()
        {
            StepExecution?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Обработать совмещение персонажем комбинации камней.
        /// </summary>
        /// <param name="stoneType">Тип скомбинированных камней.</param>
        /// <param name="amount">Количество скомбинированных камней: от 3 до 5.</param>
        public void StoneCombination(EStoneType stoneType, int amount)
        {
            //обработчик исключений
            if (stoneType == EStoneType.None) throw new ArgumentOutOfRangeException("Недопустимое использование None.");
            if (amount < 3 || amount > 5) throw new ArgumentOutOfRangeException("amount мне диапазона от 3 до 5.");

            //достаём нужные коэффициенты
            var referenceCharacteristic = (ECharacteristic)(int)stoneType;
            float currentAddTurnChance = Data[referenceCharacteristic][EDerivative.AddTurnChance].FinalValue;

            //проверка на то, нужно ли завершить ход
            TurnSwitcherModule.Switcher = false;
            if (amount < 4 && currentAddTurnChance < RandomModule.NextDouble())
            {
                TurnSwitcherModule.Switcher = true;
            }
            //начисления бонуса за 4 или 5 камней
            float combinationResult = amount * combinationMultiplier[amount - 3];
            //поглощение камней и получение эффекта поглощения
            StoneAbsorption(stoneType, combinationResult);
        }

        /// <summary>
        /// Обработать поглощение персонажем камней.
        /// </summary>
        /// <param name="stoneType">Тип поглощаемых камней.</param>
        /// <param name="amount">Количество поглощаемых камней.</param>
        public void StoneAbsorption(EStoneType stoneType, float amount)
        {
            //обработчик исключений
            if (stoneType == EStoneType.None) throw new ArgumentOutOfRangeException("Недопустимое использование None.");
            if (amount <= 0) new ArgumentOutOfRangeException("Количество поглощаемых камней не может быть меньше еденицы.");

            //связанная с камнем характеристика
            var referenceCharacteristic = (ECharacteristic)(int)stoneType;

            //множитель эффекта поглощения камней
            float currentTerminationMultiplier = Data[referenceCharacteristic][EDerivative.TerminationMult].FinalValue;

            //результат поглощения
            float absorptionResult = amount * currentTerminationMultiplier;

            //в зависимости от типа поглощенного камня вызываем соответствующую реакцию у версонажа с уведомлением
            switch (stoneType)
            {
                case EStoneType.Skull:
                    DamageModule.AddAttack(this, CurrentOpponent, EDamageType.PhysicalDamage, absorptionResult, true, true, true);
                    break;
                case EStoneType.Gold:
                    ChangeGold_WithNotification(absorptionResult);
                    break;
                case EStoneType.Experience:
                    ChangeXp_WithNotification(absorptionResult);
                    break;
                case EStoneType.FireStone:
                case EStoneType.WaterStone:
                case EStoneType.EarthStone:
                case EStoneType.AirStone:
                    ChangeMp_WithNotification(referenceCharacteristic, absorptionResult);
                    break;
            }
        }

        /// <summary>
        /// Обработать изменение опыта у персонажа.
        /// </summary>
        /// <param name="value">Значение, на которое нужно изменить опыт.</param>
        /// <returns>Фактическое изменение опыта.</returns>
        public int ChangeXp(float value)
        {
            int currentLevel = Character.Level;
            int currentMinimum = Character.levelBoundaries[currentLevel - 2];
            int delta = (int)Math.Round(value);
            int oldXp = Xp;
            int newXp = oldXp + delta;
            if (newXp < currentMinimum)
            {
                Xp = currentMinimum;
                return currentMinimum - oldXp;
            }
            else
            {
                Character.AddExp(delta);
                return delta;
            }
        }

        /// <summary>
        /// Обработать изменение очков опыта у персонажа и вызвать уведомление с фактическим значением изменения.
        /// </summary>
        /// <param name="value">Значение, на которое нужно изменить очки опыта.</param>
        public void ChangeXp_WithNotification(float value)
        {
            int result = ChangeXp(value);
            if (result != 0) { DeltaXP?.Invoke(this, result); }
        }

        /// <summary>
        /// Обработать изменение золота у персонажа.
        /// </summary>
        /// <param name="value">Значение, на которое нужно изменить золото.</param>
        /// <returns>Фактическое изменение золота.</returns>
        public int ChangeGold(float value)
        {
            int delta = (int)Math.Round(value);
            int oldGold = Gold;
            int newGold = oldGold + delta;
            if (newGold < 0)
            {
                Gold = 0;
                return -oldGold;
            }
            else
            {
                Gold += delta;
                return delta;
            }
        }

        /// <summary>
        /// Обработать изменение золота у персонажа и вызвать уведомление с фактическим значением изменения.
        /// </summary>
        /// <param name="value">Значение, на которое нужно изменить золото.</param>
        public void ChangeGold_WithNotification(float value)
        {
            int result = ChangeGold(value);
            if (result != 0) { DeltaGold?.Invoke(this, result); }
        }

        /// <summary>
        /// Обработать изменение маны определённого типа у персонажа.
        /// </summary>
        /// <param name="characteristic">Характеристика мастерства стихии.</param>
        /// <param name="delta">На сколько нужно попытаться изменить количество маны.</param>
        /// <returns>Фактическое измененеие маны</returns>
        public float ChangeMp(ECharacteristic characteristic, float delta)
        {
            //Обработчик исключений
            if (!(characteristic == ECharacteristic.Fire ||
                characteristic == ECharacteristic.Water ||
                characteristic == ECharacteristic.Earth ||
                characteristic == ECharacteristic.Air))
                throw new ArgumentOutOfRangeException("Передана некорректная характеристика");
            if (Data[characteristic][EDerivative.MaxMana] is not CurrentParameter curent)
                throw new InvalidOperationException("Некорректный класс по адресу.");

            //максимально допустимое количество маны
            float maxMana = curent.FinalValue;

            //текущее значение маны
            float oldMana = curent.CurrentValue;

            //обработка ситуаций, когда изменение количества маны невозможно
            if ((maxMana == oldMana && delta > 0) || (oldMana == 0 && delta < 0)) { return 0; }

            //в иных случаях - вычисляем, насколько изменился запас маны
            float newMana = oldMana + delta;

            // Устанавливаем CurrentMana в MaxMana, если новое значение больше MaxMana
            if (newMana > maxMana)
            {
                curent.CurrentValue = maxMana;
                return maxMana - oldMana;
            }
            // Устанавливаем CurrentMana в 0, если новое значение меньше 0
            else if (newMana < 0)
            {
                curent.CurrentValue = 0;
                return -oldMana;
            }
            // В остальных случаях устанавливаем CurrentMana равным newMana
            else
            {
                curent.CurrentValue = newMana;
                return delta;
            }
        }

        /// <summary>
        /// Обработать изменение маны определённого типа у персонажа и вызвать уведомление с фактическим значением изменения.
        /// </summary>
        /// <param name="characteristic">Характеристика мастерства стихии.</param>
        /// <param name="delta">На сколько нужно попытаться изменить количество маны.</param>
        public void ChangeMp_WithNotification(ECharacteristic characteristic, float delta)
        {
            float result = ChangeMp(characteristic, delta);
            if (result != 0)
                switch (characteristic)
                {
                    case ECharacteristic.Fire: DeltaFireMana?.Invoke(this, delta); break;
                    case ECharacteristic.Water: DeltaWaterMana?.Invoke(this, delta); break;
                    case ECharacteristic.Earth: DeltaEarthMana?.Invoke(this, delta); break;
                    case ECharacteristic.Air: DeltaAirMana?.Invoke(this, delta); break;
                }
        }

        /// <summary>
        /// Обработать изменение очков здоровья у персонажа.
        /// </summary>
        /// <param name="delta">Значение, на которое нужно изменить очки опыта.</param>
        /// <returns>Фактическое измененеие очков здоровья.</returns>
        public float ChangeHp(float delta)
        {
            float maxHp = Data[ECharacteristic.Endurance][EDerivative.MaxHealth].FinalValue;
            float oldHp = Health;
            if (maxHp == oldHp && delta > 0) { return 0; }
            float newHp = oldHp + delta;

            if (newHp > maxHp)
            {
                Health = maxHp;
                return maxHp - oldHp;
            }
            else if (newHp < 0)
            {
                Health = 0;
                Death?.Invoke(this, EventArgs.Empty);
                return 0;
            }
            else
            {
                Health = newHp;
                return delta;
            }
        }

        /// <summary>
        /// Обработать изменение очков здоровья у персонажа и вызвать уведомление с фактическим значением изменения.
        /// </summary>
        /// <param name="delta">Значение, на которое нужно изменить очки опыта.</param>
        public void ChangeHp_WithNotification(float delta)
        {
            float result = ChangeHp(delta);
            if (result != 0) { DeltaHP?.Invoke(this, result); }
        }

        /// <summary>
        /// Вызвать уведомелление об ипускании владельцем value едениц damageType урона.
        /// </summary>
        /// <param name="damageType">Тип испускаемого урона.</param>
        /// <param name="value">Количество урона.</param>
        public void EmitDamageNotification(EDamageType damageType, float value)
        {
            var data = (damageType, value);
            DamageEmitting?.Invoke(this, data);
        }

        /// <summary>
        /// Вызвать уведомелление о блокировании владельцем value едениц damageType урона.
        /// </summary>
        /// <param name="damageType">Тип блокируевомого урона.</param>
        /// <param name="value">Количество урона.</param>
        public void BlockDamageNotification(EDamageType damageType, float value)
        {
            var data = (damageType, value);
            DamageBlocking?.Invoke(this, data);
        }

        /// <summary>
        /// Вызвать уведомелление о принятии владельцем value едениц damageType урона.
        /// </summary>
        /// <param name="damageType">Тип принимаемого урона.</param>
        /// <param name="value">Количество урона</param>
        public void AcceptDamageNotification(EDamageType damageType, float value)
        {
            var data = (damageType, value);
            DamageAccepting?.Invoke(this, data);
        }

        /// <summary>
        /// Вызвать уведомелление о получении владельцем value едениц damageType урона.
        /// </summary>
        /// <param name="damageType">Тип получаемого урона.</param>
        /// <param name="value">Количество урона.</param>
        public void TakeDamageNotification(EDamageType damageType, float value)
        {
            var result = ChangeHp(-value);
            DeltaHP?.Invoke(this, result);
            var data = (damageType, result);
            DamageTaking?.Invoke(this, data);
        }
        #endregion
    }
}
