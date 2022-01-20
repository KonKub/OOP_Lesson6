using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lesson6
{
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
    abstract class Figure
    {
        public ConsoleColor _color { get; set; }
        public bool _visible { get; set; }

        public Figure(ConsoleColor color, bool visibility)
        {
            _color = color;
            _visible = visibility;
        }

        public void MoveVertical(int step) { }
        public void MoveHorizontal(int step) { }

        public void SetColor(ConsoleColor color) 
        {
            _color = color;
        }
        public void SetVisibility(bool visibility) 
        {
            _visible = visibility;
        }

        public void ShowInfo() 
        {
            Console.WriteLine($"Цвет: {_color}. Видимость: {_visible}.");
        }
        public override string ToString()
        {
            return $"Фигура. Цвет: {_color}. Видимость: {_visible}";
        }
    }

    class Point : Figure
    {
        public int _x { get; set; }
        public int _y { get; set; }

        public Point(int x, int y) : base (ConsoleColor.Green, true)
        {
            _x = x;
            _y = y;
        }

        public new void MoveVertical(int step)
        {
            _y = _y + step;
        }

        public new void MoveHorizontal(int step)
        {
            _x = _x + step;
        }

        public override string ToString()
        {
            return $"Объект точка. X={_x}. Y={_y}. Цвет: {base._color}. Видимость: {_visible}";
        }
    }

    class Circle : Point
    {
        private int _radius { get; set; }

        public Circle(int x, int y, int radius) : base(x, y)
        {
            _radius = radius;
        }

        public double Square()
        {
            return Math.PI * _radius;
        }

        public override string ToString()
        {
            return $"Объект окружность. X={_x}. Y={_y}. Радиус= {_radius}. Цвет: {_color}. Видимость: {_visible}";
        }
    }

    class Rectangle : Point
    {
        public int _side1 { get; set; }
        public int _side2 { get; set; }

        public Rectangle(int x, int y, int side1, int side2) : base(x, y)
        {
            _side1 = side1;
            _side2 = side2;
        }

        public double Square()
        {
            return _side1 * _side2;
        }

        public override string ToString()
        {
            return $"Объект прямоугольник. X={_x}. Y={_y}. Сторона1= {_side1}. Сторона= {_side2}. Цвет: {_color}. Видимость: {_visible}";
        }
    }
}
