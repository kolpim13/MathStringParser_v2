using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathStringParser_v2
{
    #region //class Cell
    public partial class Cell
    {
        #region //properties
        //значение ячейки
        public double Value { get; private set; }
        //знак ячейки
        public char Sign { get; private set; }
        //является ли ячейка аргументом
        public bool IsArgument { get; private set; }
        //строка, отвечающая за то, как будет обозначаться аргумет(напр. "x"/"y"/"graph" и т.д.) Зарезервировано на будущее(может не понадобиться)
        public string argumentValue { get; private set; }
        #endregion
        #region //constructor
        public Cell(double value, char sign, bool isArgue = false)
        {
            Value = value;
            Sign = sign;
            IsArgument = isArgue;

            //////////////////////
            argumentValue = "hz :)";
        }
        #endregion
        #region //functions
        //Проверка есть ли данный знак в словаре знаков и соответсвующих им функций
        public static bool IsSign(char c)
        {
            if (Actions.ContainsKey(c))
                return true;
            return false;
        }

        //обьеденить (согласно знаку левой) 2 ячейки (правую и левую) и сохранить результат в левой, а знак оставить правой. Вернуть bool, которая укажетбылали произведена операция
        public static bool Merge(Cell leftCell, Cell rightCell)
        {
            if (IsSign(leftCell.Sign))
            {
                leftCell.Value = Actions[leftCell.Sign](leftCell.Value, rightCell.Value);
                leftCell.Sign = rightCell.Sign;
                return true;
            }
            return false;
        }
        #endregion
    }
    #endregion

    #region //class Parser
    public partial class Parser
    {
        private List<Cell> listToMerge;

        public Parser()
        {
            listToMerge = new List<Cell>();
        }

        //основная функция - раскладывает строку нужного формата на "Cell" и считает выражение
        public double SplitAndCalc(string data, ref int index, double arg = 1, int listIndex = 0)
        {
            Cell a = new Cell(10, '+');
            Cell b = new Cell(20, '+');
            Cell.Merge(a, b);
            return a.Value;
        }


    }
    #endregion

    #region //class StringProcessing

    #endregion
}
