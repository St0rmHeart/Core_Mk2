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
        public List<Effect> Effects { get; set; } = new List<Effect>();
        #endregion

        #region _____________________КОНСТРУКТОР_____________________

        /// <summary>
        /// Стандартный конструктор предмета снаряжения
        /// </summary>
        /// <param name="bodyPart">Часть тела, на которую можно надеть предмет</param>
        /// <param name="name">Название предмета</param>
        public Equipment(EBodyPart bodyPart, string name)
        {
            Name = name;
            BodyPart = bodyPart;
        }
        #endregion

        #region _____________________МЕТОДЫ_____________________

        #endregion
    }
}
