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

        //
        private const int GridSize = 8;
        //
        private EStoneType[,] StoneGrid = new EStoneType[GridSize,GridSize];
        //
        private Random RandomStoneGenerator = new Random();
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
                    foreach (IEffect effect in item.Effects)
                    {
                        effect.Installation(pointer1, pointer2);
                    }
                }
            }
            foreach (CharacterSlot characterSlot in initArray)
            {
                foreach (ECharacteristic characteristic in CONSTANT.CHAR_DER_PAIRS.Keys)
                {
                    characterSlot.Data[characteristic][EDerivative.Value].SetFinalValue();
                }
                foreach (ECharacteristic characteristic in CONSTANT.CHAR_DER_PAIRS.Keys)
                {
                    foreach (EDerivative derivative in CONSTANT.CHAR_DER_PAIRS[characteristic])
                    {
                        (characterSlot.Data[characteristic][derivative] as CommonParameter)?.UpdateA0();
                    }
                }
                (characterSlot.Data[ECharacteristic.Endurance][EDerivative.CurrentHealth] as CurrentCommonParameter).CurrentValue = 
                    characterSlot.Data[ECharacteristic.Endurance][EDerivative.MaxHealth].FinalValue; ;
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
        public EStoneType RandomStone()
        {
            int rndI = RandomStoneGenerator.Next(7);
            switch (rndI)
            {
                case 0:
                    return EStoneType.Skull;
                case 1:
                    return EStoneType.Gold;
                case 2:
                    return EStoneType.Experience;
                case 3:
                    return EStoneType.FireStone;
                case 4:
                    return EStoneType.WaterStone;
                case 5:
                    return EStoneType.AirStone;
                case 6:
                    return EStoneType.EarthStone;
                default:
                    return EStoneType.Skull;
            }
        }
        public void InitializeGrid()
        {
            for (int i = 0; i < GridSize; i++)
                for (int j = 0; j < GridSize; j++)
                    StoneGrid[i,j] = RandomStone();
        }
        public void StoneFall(int x , int y)
        {
            for (int i = y;  i > 0; i--)
                StoneGrid[x, i] = StoneGrid[x, i-1];
            StoneGrid[x, 0] = RandomStone();
        }
        public void RemoveStones(List<int> RemovedStonesX, List<int> RemovedStonesY)
        {
            for (int i = 0; i < RemovedStonesX.Count(); i++)
                StoneFall(RemovedStonesX[i], RemovedStonesY[i]);
        }
        public void CheckForCombination(int x, int y)
        {
            EStoneType InitStoneType = StoneGrid[x,y];
            int CombinationSizeX = 0;
            List<int> CSXX = new List<int>();
            List<int> CSXY = new List<int>();
            List<int> CSYX = new List<int>();
            List<int> CSYY = new List<int>();
            int CombinationSizeY = 0;
            for (int i = Math.Max(x - 2, 0); i < Math.Min(x + 2, GridSize); i++)
                if (StoneGrid[i, y] == InitStoneType)
                {
                    CombinationSizeX++;
                    CSXX.Add(i);
                    CSXY.Add(y);
                }
                else
                {
                    CombinationSizeX = 0;
                    CSXX.Clear();
                    CSXY.Clear();
                }
            for (int i = Math.Max(y - 2, 0); i < Math.Min(y + 2, GridSize); i++)
                if (StoneGrid[x, i] == InitStoneType)
                {
                    CombinationSizeY++;
                    CSYX.Add(x);
                    CSYY.Add(i);
                }
                else
                {
                    CombinationSizeY = 0;
                    CSYX.Clear();
                    CSYY.Clear();
                }
            if (CombinationSizeX >= 3)
            {
                StoneCombination(InitStoneType, CombinationSizeX);
                RemoveStones(CSXX, CSXY);
                ScanField();
            }
            if (CombinationSizeY >= 3)
            {
                StoneCombination(InitStoneType, CombinationSizeY);
                RemoveStones(CSYX, CSYY);
                ScanField();
            }
        }
        public void ScanField()
        {
            for (int i = 0; i < GridSize; i++)
                for (int j = 0; j < GridSize; j++)
                    CheckForCombination(i, j);
        }
        public void SwapStones(int x1, int y1, int x2, int y2)
        {
            var temp = StoneGrid[x1, y1];
            StoneGrid[x1, y1] = StoneGrid[x2, y2];
            StoneGrid[x2,y2] = temp;
        }
        public int GetGridSize()
        {
            return GridSize;
        }
        public EStoneType[,] GetStoneGrid()
        {
            return StoneGrid;
        }
        #endregion
    }
}
