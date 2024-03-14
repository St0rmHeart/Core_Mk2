using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Mk2
{
    public class DamageModule
    {
        #region _____________________ПОЛЯ_____________________

        private bool _isActive;
        private int _counter;

        private EDamageType _attackerDamageType;
        public float AttackerDamageMultiplier {  get; set; }
        public float AttackerDamageSummand { get; set; }
        public float DefenderDamageMultiplier { get; set; }
        public float DefenderDamageSummand { get; set; }


        private List<(
            CharacterSlot attacker,
            CharacterSlot defender,
            (EDamageType type, float value, bool isblockable, bool isAttackerReact, bool isDefenderReact) damageData)> _attacksList
            = new List<(CharacterSlot attacker, CharacterSlot defender, (EDamageType type, float value, bool isblockable, bool isAttackerReact, bool isDefenderReact) damageData)>();

        #endregion

        #region ______________________КОНСТРУКТОР______________________

        public DamageModule() { Reset(); }

        #endregion

        #region _____________________МЕТОДЫ_____________________

        private void Reset()
        {
            _isActive = false;
            _counter = 0;
            _attackerDamageType = EDamageType.None;
            AttackerDamageMultiplier = 1;
            AttackerDamageSummand = 0;
            DefenderDamageMultiplier = 1;
            DefenderDamageSummand = 0;
            _attacksList.Clear();
        }
        public void AddAttack(CharacterSlot attacker, CharacterSlot defender, EDamageType damageType, float damageBaseValue, bool isblockable, bool isAttackerReact, bool isDefenderReact)
        {
            _attacksList.Add((attacker, defender, (damageType, damageBaseValue, isblockable, isAttackerReact, isDefenderReact)));
            if (!_isActive) InitAttack();
        }
        private void InitAttack()
        {
            _isActive = true;
            for (_counter = 0; _counter < _attacksList.Count; _counter++)
            {
                //установка всех стартовых параметров
                CharacterSlot attacker = _attacksList[_counter].attacker;
                CharacterSlot defender = _attacksList[_counter].defender;
                _attackerDamageType = _attacksList[_counter].damageData.type;
                var attackerDamageBaseValue = _attacksList[_counter].damageData.value;
                AttackerDamageMultiplier = 1;
                AttackerDamageSummand = 0;

                if (_attacksList[_counter].damageData.isAttackerReact)
                {
                    //запускаме ивент на испускание базового урона у атакующего пенрсонажа
                    attacker.EmitDamageNotification(_attackerDamageType, attackerDamageBaseValue);
                    //принимают винальные значения поля:
                    //AttackerDamageMultiplier - на сколько относительно базовго значения должен измениться испускаемый урон 
                    //AttackerDamageSummand - на сколько должен абсолютно должен измениться испускаемый урон
                    //_AttackdamageType должно содержать окончательное значение элемента урона
                }
                //вычисляем итоговое значение урона, который испускает атакующий персонаж
                float attackerDamageFinalValue = attackerDamageBaseValue * AttackerDamageMultiplier + AttackerDamageSummand;

                if (_attacksList[_counter].damageData.isDefenderReact)
                {
                    float defenderAcceptedDamage = attackerDamageBaseValue;
                    if (_attacksList[_counter].damageData.isblockable)
                    {
                        //выясняем сопротивление к урону данного типа у защищающегося персонажа
                        float defenderResistance = defender.Data[(ECharacteristic)(int)_attackerDamageType][EDerivative.Resistance].FinalValue;
                        //вычсляем заблокированный урон
                        float defenderBlockedDamage = attackerDamageFinalValue * defenderResistance;
                        //вычисляем принимаемый урон
                        defenderAcceptedDamage = attackerDamageFinalValue - defenderBlockedDamage;
                        //запускаем ивент на блокирование урона у защищающегося персонажа
                        defender.BlockDamageNotification(_attackerDamageType, defenderBlockedDamage);
                    }
                    //запускаем ивент на принятие урона у защищающегося персонажа
                    defender.AcceptDamageNotification(_attackerDamageType, defenderAcceptedDamage);
                    //по итогу должны быть заполнены поля:
                    //DefenderDamageMultiplier - на сколько относительно базовго значения должен измениться принимаемый урон 
                    //DefenderDamageSummand - на сколько должен абсолютно должен измениться принимаемый урон

                    //вычисляем итоговое значение урона, который получает защищающийся персонад
                    float resultDamage = defenderAcceptedDamage * DefenderDamageMultiplier + DefenderDamageSummand;
                    //запускаем ивент на получение урона у защищающегося персонажа
                    defender.TakeDamageNotification(_attackerDamageType, resultDamage);
                }
                else
                {
                    //запускаем ивент на изменение здоровья у защищающегося персонажа
                    defender.ChangeHp_WithNotification(-attackerDamageFinalValue);
                }  
            }
            Reset();
        }
        #endregion
    }
}
