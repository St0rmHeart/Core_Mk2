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
        private DamageModule _damageModule;

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

            //установка ссылок на переключателя хода, чтобы с одним переключателем могла работать как арена, так и персонажи
            _player.TurnSwitcherModule = _isTurnEnd;
            _enemy.TurnSwitcherModule = _isTurnEnd;

            //инициализация модуля урона
            _damageModule = new DamageModule();
            //установка ссылок на модуль урона
            _player.DamageModule = _damageModule;
            _enemy.DamageModule = _damageModule;


            //установка ссылок на оппонента для кажодого из персонажей
            _player.CurrentOpponent = _enemy;
            _enemy.CurrentOpponent = _player;

            //У кого из персонажей больше ловкость - тот и начинает ход первым
            var playerDexterity = _player.Data[ECharacteristic.Dexterity][EDerivative.Value].FinalValue;
            var enemyDexterity = _enemy.Data[ECharacteristic.Dexterity][EDerivative.Value].FinalValue;
            if (playerDexterity >= enemyDexterity)
            { _activePlayer = _player; _passivePlayer = _enemy; }
            else
            { _activePlayer = _enemy; _passivePlayer = _player; }
            //инициализация эффектов у обоих персонажей
            EffectsInitialization();
        }
        #endregion

        #region _____________________МЕТОДЫ_____________________
        /// <summary>
        /// Инициализировать эффектыв у обоих персонажей арены
        /// </summary>
        private void EffectsInitialization()
        {
            _player.InitializeEffects(_enemy);
            _enemy.InitializeEffects(_player);
        }

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
