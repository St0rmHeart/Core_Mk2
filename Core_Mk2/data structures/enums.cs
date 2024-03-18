using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Mk2
{
    /// <summary>
    /// Виды ивентов Арены
    /// </summary>
    public enum EEvent
    {
        Constant = -1,
        None = 0,
        //Виды ивентов
        StepExecution,
        Death,

        DamageEmitting,
        DamageAccepting,
        DamageBlocking,
        DamageTaking,

        DeltaFireMana,
        DeltaWaterMana,
        DeltaAirMana,
        DeltaEarthMana,

        DeltaXP,
        DeltaHP,
        DeltaGold,
    }

    public enum EDamageType
    {
        None = 0,
        //Виды урона
        PhysicalDamage = ECharacteristic.Strength,
        FireDamage = ECharacteristic.Fire,
        WaterDamage = ECharacteristic.Water,
        AirDamage = ECharacteristic.Air,
        EarthDamage = ECharacteristic.Earth,
    }

    /// <summary>
    /// Виды камней на игровой доске
    /// </summary>
    public enum EStoneType
    {
        None = 0,
        //Виды камней
        Skull = ECharacteristic.Strength,
        Gold = ECharacteristic.Dexterity,
        Experience = ECharacteristic.Endurance,
        FireStone = ECharacteristic.Fire,
        WaterStone = ECharacteristic.Water,
        AirStone = ECharacteristic.Air,
        EarthStone = ECharacteristic.Earth,

    }
    /// <summary>
    /// Указатели для адресации к игроку или противнику игрока
    /// </summary>
    public enum EPlayerType
    {
        None = 0,
        //виды указателей
        Self,
        Enemy,
    }
    /// <summary>
    /// Все характеристики, необходимые для описания параметров персонажа, снаряжения, перков, заклинаний, эффектов и всего прочего
    /// </summary>
    public enum ECharacteristic
    {
        None = 0,
        //характеристики персонажа
        Strength,       //сила
        Dexterity,      //ловкость
        Endurance,      //выносливость
        Fire,           //мастерство огня
        Water,          //мастерство воды
        Air,            //мастерство воздуха
        Earth,          //мастерство земли
    }
    /// <summary>
    /// Всевозможное производные параметры от каждой <see cref="ECharacteristic"/>.
    /// у КАЖДОЙ <see cref="ECharacteristic"/> может быть СВОЙ набор из <see cref="EDerivative"/>
    /// </summary>
    public enum EDerivative
    {
        None = 0,
        //возможные производные характеристик
        Value,          //значение характеристики
        MaxMana,        //максимальный запас маны
        CurrentMana,    //текущий(стартовый) запас маны
        TerminationMult,//мультипликатор эффекта уничтожения камня, связанного с характеристикой производной 
        AddTurnChance,  //шанс доп хода при уничтожении камня, связанного с характеристикой производной
        Resistance,     //сопротивления урону, связанному с этой характеристикой
        MaxHealth,      //максимальный запас здоровья
        CurrentHealth,  //текущий(стартовый) запас здоровья
    }
    public static class ENUMS_CONSTANT_DATA
    {
        static ENUMS_CONSTANT_DATA()
        {

        }

        public static readonly Dictionary<ECharacteristic, Dictionary<EDerivative, List<ECharacteristic>>> DERIVATIVE_SUBSCRIPTIONS = new Dictionary<ECharacteristic, Dictionary<EDerivative, List<ECharacteristic>>>()
        { 
            {
                ECharacteristic.Strength, new Dictionary<EDerivative, List<ECharacteristic>>()
                {
                    {
                        EDerivative.TerminationMult, new List<ECharacteristic>()
                        {
                            ECharacteristic.Strength
                        } 
                    },

                    {
                        EDerivative.AddTurnChance, new List<ECharacteristic>()
                        {
                            ECharacteristic.Strength
                        }
                    },
                    
                    {
                        EDerivative.Resistance, new List<ECharacteristic>()
                        {
                            ECharacteristic.Strength
                        }
                    },
                }
            },

            {
                ECharacteristic.Endurance, new Dictionary<EDerivative, List<ECharacteristic>>()
                {
                    {
                        EDerivative.TerminationMult, new List<ECharacteristic>()
                        {
                            ECharacteristic.Endurance
                        }
                    },

                    {
                        EDerivative.AddTurnChance, new List<ECharacteristic>()
                        {
                            ECharacteristic.Endurance
                        }
                    },

                    {
                        EDerivative.MaxHealth, new List<ECharacteristic>()
                        {
                            ECharacteristic.Endurance
                        }
                    },
                }
            },

            {
                ECharacteristic.Dexterity, new Dictionary<EDerivative, List<ECharacteristic>>()
                {
                    {
                        EDerivative.TerminationMult, new List<ECharacteristic>()
                        {
                            ECharacteristic.Dexterity
                        }
                    },

                    {
                        EDerivative.AddTurnChance, new List<ECharacteristic>()
                        {
                            ECharacteristic.Dexterity
                        }
                    },
                }
            },

            {
                ECharacteristic.Fire, new Dictionary<EDerivative, List<ECharacteristic>>()
                {
                    {
                        EDerivative.TerminationMult, new List<ECharacteristic>()
                        {
                            ECharacteristic.Fire
                        }
                    },

                    {
                        EDerivative.AddTurnChance, new List<ECharacteristic>()
                        {
                            ECharacteristic.Fire
                        }
                    },

                    {
                        EDerivative.MaxMana, new List<ECharacteristic>()
                        {
                            ECharacteristic.Fire
                        }
                    },

                    {
                        EDerivative.Resistance, new List<ECharacteristic>()
                        {
                            ECharacteristic.Fire
                        }
                    },
                }
            },

            {
                ECharacteristic.Water, new Dictionary<EDerivative, List<ECharacteristic>>()
                {
                    {
                        EDerivative.TerminationMult, new List<ECharacteristic>()
                        {
                            ECharacteristic.Water
                        }
                    },

                    {
                        EDerivative.AddTurnChance, new List<ECharacteristic>()
                        {
                            ECharacteristic.Water
                        }
                    },

                    {
                        EDerivative.MaxMana, new List<ECharacteristic>()
                        {
                            ECharacteristic.Water
                        }
                    },

                    {
                        EDerivative.Resistance, new List<ECharacteristic>()
                        {
                            ECharacteristic.Water
                        }
                    },
                }
            },

            {
                ECharacteristic.Earth, new Dictionary<EDerivative, List<ECharacteristic>>()
                {
                    {
                        EDerivative.TerminationMult, new List<ECharacteristic>()
                        {
                            ECharacteristic.Earth
                        }
                    },

                    {
                        EDerivative.AddTurnChance, new List<ECharacteristic>()
                        {
                            ECharacteristic.Earth
                        }
                    },

                    {
                        EDerivative.MaxMana, new List<ECharacteristic>()
                        {
                            ECharacteristic.Earth
                        }
                    },

                    {
                        EDerivative.Resistance, new List<ECharacteristic>()
                        {
                            ECharacteristic.Earth
                        }
                    },
                }
            },

            {
                ECharacteristic.Air, new Dictionary<EDerivative, List<ECharacteristic>>()
                {
                    {
                        EDerivative.TerminationMult, new List<ECharacteristic>()
                        {
                            ECharacteristic.Air
                        }
                    },

                    {
                        EDerivative.AddTurnChance, new List<ECharacteristic>()
                        {
                            ECharacteristic.Air
                        }
                    },

                    {
                        EDerivative.MaxMana, new List<ECharacteristic>()
                        {
                            ECharacteristic.Air
                        }
                    },

                    {
                        EDerivative.Resistance, new List<ECharacteristic>()
                        {
                            ECharacteristic.Air
                        }
                    },
                }
            },

        };

        public static readonly Dictionary<ECharacteristic, List<EDerivative>> CHAR_DER_PAIRS = new Dictionary<ECharacteristic, List<EDerivative>>()
        {
            {
                ECharacteristic.Strength, new List<EDerivative>()
                {
                    EDerivative.Value,
                    EDerivative.TerminationMult,
                    EDerivative.AddTurnChance,
                    EDerivative.Resistance,
                }
            },

            {
                ECharacteristic.Endurance, new List<EDerivative>()
                {
                    EDerivative.Value,
                    EDerivative.TerminationMult,
                    EDerivative.AddTurnChance,
                    EDerivative.MaxHealth,
                    EDerivative.CurrentHealth,
                }
            },

            {
                ECharacteristic.Dexterity, new List<EDerivative>()
                {
                    EDerivative.Value,
                    EDerivative.TerminationMult,
                    EDerivative.AddTurnChance,
                }
            },

            {
                ECharacteristic.Fire, new List<EDerivative>()
                {
                    EDerivative.Value,
                    EDerivative.TerminationMult,
                    EDerivative.AddTurnChance,
                    EDerivative.MaxMana,
                    EDerivative.CurrentMana,
                    EDerivative.Resistance
                }
            },

            {
                ECharacteristic.Water, new List<EDerivative>()
                {
                    EDerivative.Value,
                    EDerivative.TerminationMult,
                    EDerivative.AddTurnChance,
                    EDerivative.MaxMana,
                    EDerivative.CurrentMana,
                    EDerivative.Resistance
                }
            },

            {
                ECharacteristic.Air, new List<EDerivative>()
                {
                    EDerivative.Value,
                    EDerivative.TerminationMult,
                    EDerivative.AddTurnChance,
                    EDerivative.MaxMana,
                    EDerivative.CurrentMana,
                    EDerivative.Resistance
                }
            },

            {
                ECharacteristic.Earth, new List<EDerivative>()
                {
                    EDerivative.Value,
                    EDerivative.TerminationMult,
                    EDerivative.AddTurnChance,
                    EDerivative.MaxMana,
                    EDerivative.CurrentMana,
                    EDerivative.Resistance
                }
            },
        };
    }

    /// <summary>
    /// 6 "слотов" в в которые можно одевать снаряжение соответсвующего типа
    /// </summary>
    public enum EBodyPart
    {
        None = 0,
        //Набор слолов под снаряжение 
        Head,           //голова
        Body,           //тело
        Hands,          //руки
        Feet,           //ноги
        Weapon,         //оружие
        Extra,          //экста
    }
    public enum EVariable
    {
        None = 0,
        //Набор переменных для формулы кончеого значения производной
        A0,
        B1,
        B2,
        C1,
        C2,
        D1,
        D2,
    }

}
