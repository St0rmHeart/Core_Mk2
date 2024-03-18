using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Mk2
{
    public class Arena
    {
        #region _____________________ПОЛЯ_____________________

        //
        public CharacterSlot _player;
        //
        public CharacterSlot _enemy;
        //
        private CharacterSlot _activePlayer;
        //
        private CharacterSlot _passivePlayer;



        //
        private TurnSwitch _isTurnEnd = new TurnSwitch();
        //
        private DamageModule _damageModule = new DamageModule();

        #endregion

        #region ______________________КОНСТРУКТОР______________________

        /// <summary>
        /// Конструктор Арены, где устанавливается персонаж игрока и персонаж противника,
        /// а так же призводится и полная предварительная настройка и подготовка к сражению
        /// </summary>
        /// <param name="player">Персонаж игрока</param>
        /// <param name="enemy"> персонаж противника</param>
        public Arena(Character player, Character enemy)
        {
            //Установка персонажей игрока противника-компьютера
            _player = new CharacterSlot(player);
            _enemy = new CharacterSlot(enemy);

            //проброска ссылок между всеми объектами
            CharacterSlot[] initArray = new CharacterSlot[2] { _player, _enemy };
            for (int i = 0; i < initArray.Length; i++)
            {
                var pointer1 = initArray[i];
                var pointer2 = initArray[(i + 1) % 2];

                //установка ссылки на переключателя хода
                pointer1.TurnSwitcherModule = _isTurnEnd;
                //установка ссылки на модуль урона
                pointer1.DamageModule = _damageModule;
                //установка ссылки на оппонента
                pointer1.CurrentOpponent = pointer2;

                //инициализация всех эффектов в снаряжении персонажа
                foreach (Equipment item in pointer1.Character.Equipment.Values)
                {
                    foreach (TriggerParameterModifier effect in item.Effects)
                    {
                        effect.Installation(pointer1, pointer2);
                    }
                }
            }

            //У кого из персонажей больше ловкость - тот и начинает ход первым
            var playerDexterity = _player.Data[ECharacteristic.Dexterity][EDerivative.Value].FinalValue;
            var enemyDexterity = _enemy.Data[ECharacteristic.Dexterity][EDerivative.Value].FinalValue;
            if (playerDexterity >= enemyDexterity)
            { _activePlayer = _player; _passivePlayer = _enemy; }
            else
            { _activePlayer = _enemy; _passivePlayer = _player; }
            //инициализация эффектов у обоих персонажей
        }
        #endregion

        #region _____________________МЕТОДЫ_____________________

        /// <summary>
        /// Пока реализует совмещение активным игроком какой-либо комбинации камней, на игровой доске.
        /// </summary>
        /// <param name="stoneType">Тип камня.</param>
        /// <param name="amount">Количество.</param>
        public void StoneCombination(EStoneType stoneType, int amount)
        {
            _activePlayer.StoneCombination(stoneType, amount);
            if (_isTurnEnd.Switcher)
            {
                _activePlayer.CompleteStep();
                (_passivePlayer, _activePlayer) = (_activePlayer, _passivePlayer);
            }
        }
        #endregion
    }
}
