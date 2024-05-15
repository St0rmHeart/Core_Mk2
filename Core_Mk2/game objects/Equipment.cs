using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Mk2
{
    /// <summary>
    /// Предмет снаряжения, который можно одеть в соответсвующий ему слот
    /// </summary>
    public class Equipment
    {
        #region _____________________ПОЛЯ_____________________
        //название предмета
        public string Name { get; private set; }
        //Часть тела, на которую можно надеть предмет
        public EBodyPart BodyPart { get; private set; }
        //список эффектов, реализующий действие снаряжения
        public List<IEffect> Effects { get; set; } = new List<IEffect>();
        #endregion

        #region _____________________КОНСТРУКТОР_____________________

        /// <summary>
        /// Стандартный конструктор предмета снаряжения
        /// </summary>
        /// <param name="bodyPart">Часть тела, на которую можно надеть предмет</param>
        /// <param name="name">Название предмета</param>
        public Equipment(string name, EBodyPart bodyPart, List<IEffect> effects = null)
        {
            Name = name;
            BodyPart = bodyPart;
            Effects = effects ?? new List<IEffect>();
        }
        #endregion

        #region _____________________МЕТОДЫ_____________________
        public Equipment Clone()
        {
            List<IEffect> cloneEffects = new List<IEffect>();
            foreach (var originalEffect in Effects)
            {
                cloneEffects.Add(originalEffect.Clone());
            }

            return new Equipment(
                Name,
                BodyPart,
                cloneEffects
                );
        }
        #endregion
    }
}
