using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lesson6
{
    class Program
    {
        //1. Для класса банковский счет переопределить операторы == и != для сравнения информации в двух счетах.
        //   Переопределить метод Equals аналогично оператору ==, не забыть переопределить метод GetHashCode().
        //   Переопределить метод ToString() для печати информации о счете.
        //   Протестировать функционирование переопределенных методов и операторов на простом примере.

        //(*)Создать класс Figure для работы с геометрическими фигурами.
        //   В качестве полей класса задаются цвет фигуры, состояние «видимое/невидимое».
        //   Реализовать операции:
        //                        передвижение геометрической фигуры по горизонтали, по вертикали,
        //                        изменение цвета,
        //                        опрос состояния (видимый/невидимый).
        //   Метод вывода на экран должен выводить состояние всех полей объекта.
        //   Создать класс Point (точка) как потомок геометрической фигуры.
        //   Создать класс Circle (окружность) как потомок точки.
        //   В класс Circle добавить метод, который вычисляет площадь окружности.
        //   Создать класс Rectangle (прямоугольник) как потомок точки, реализовать метод вычисления площади прямоугольника.
        //   Точка, окружность, прямоугольник должны поддерживать методы передвижения по горизонтали и вертикали, изменения цвета.

        static void Main(string[] args)
        {
            BankAccount Account1 = new BankAccount(100, AccountType.Current);
            Account1.Number = 111;
            BankAccount Account2 = new BankAccount(100, AccountType.Current);
            Account2.Number = 111;
            BankAccount Account3 = new BankAccount(300, AccountType.Savings);
            Account3.Number = 2222;

            Console.WriteLine($"Счёт 1. {Account1.ToString()}");
            Console.WriteLine($"Счёт 2. {Account2.ToString()}");
            Console.WriteLine($"Счёт 3. {Account3.ToString()}");
            Console.WriteLine();
            if (Account1 == Account2) Console.WriteLine($"1. Счета равны.");
            if (Account1 != Account2) Console.WriteLine($"2. Счета не равны.");
            if (Account1 == Account3) Console.WriteLine($"3. Счета равны.");
            if (Account1 != Account3) Console.WriteLine($"4. Счета не равны.");

            Console.ReadKey();

            Console.WriteLine();

            string S;

            Point PointObject = new Point(1, 1);

            S = PointObject.ToString();
            Console.WriteLine(S);
            PointObject.SetColor(ConsoleColor.Red);
            PointObject.SetVisibility(true);
            PointObject.MoveVertical(5);
            PointObject.MoveHorizontal(100);
            S = PointObject.ToString();
            Console.WriteLine(S);
            Console.WriteLine();

            Circle CircleObject = new Circle(10,10,5);

            S = CircleObject.ToString();
            Console.WriteLine(S);
            CircleObject.SetColor(ConsoleColor.Yellow);
            CircleObject.SetVisibility(false);
            CircleObject.MoveVertical(12);
            CircleObject.MoveHorizontal(-15);
            S = CircleObject.ToString();
            Console.WriteLine(S);
            Console.WriteLine();


            Rectangle RectangleObject = new Rectangle(5,20,3,7);

            S = RectangleObject.ToString();
            Console.WriteLine(S);
            RectangleObject.SetColor(ConsoleColor.Gray);
            RectangleObject.SetVisibility(true);
            RectangleObject.MoveVertical(33);
            RectangleObject.MoveHorizontal(-100);
            S = RectangleObject.ToString();
            Console.WriteLine(S);

            Console.ReadKey();
        }
    }
}
