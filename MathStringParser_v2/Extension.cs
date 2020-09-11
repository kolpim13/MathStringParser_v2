using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathStringParser_v2
{
    //Перечисление, которая отображает как закончилась та или иная операция
    public enum Rezult
    {
        FAILED = 0,
        SUCCESS = 1
    };

    #region //Расширения для класса Cell
    public partial class Cell
    {
        //словарь старшинства операций
        private static Dictionary<char, int> ActionPrecedence = new Dictionary<char, int>
        {
            { '+', 1 },
        };
        //словарь простых математических операций между 2 "Cell"
        private static Dictionary<char, Func<double, double, double>> Actions = new Dictionary<char, System.Func<double, double, double>>
        {
            { '+', new Func<double, double, double>(AddCells) }
        };

        //Символы, что уже используются в программе.
        private static List<char> ReservedSigns = new List<char>
        {
            { '+' },
        };

        //добавление в словарь новых пар (знак - метод) и в словарь старшинства (знак - старшиснтво операции). Возвращает значение успешно прошла оперцаия или нет
        public static Rezult AddAction(char sign, Func<double, double, double> action, int precedence = 1)
        {
            if (ReservedSigns.Contains(sign))
                return Rezult.FAILED;

            Actions.Add(sign, action);
            ActionPrecedence.Add(sign, precedence);
            ReservedSigns.Add(sign);
            return Rezult.SUCCESS;
        }

        //Оперции доступные для действия с клетками по умолчанию
        private static double AddCells(double left, double right)
        {
            return left + right;
        }
        #endregion
    }
}
