using System;
using static System.Math;

namespace Triangle
{
    public class Triangle
    {
        /// <summary> Полупериметр </summary>
        private readonly double _p;

        /// <summary> Создание нового треугольника </summary>
        /// <exception cref="ArgumentException">Возникает при отрицательных длинах сторон треугольника 
        /// и если треугольник не прямоугольный</exception>
        /// <param name="a">Сторона треугольника</param>
        /// <param name="b">Сторона треугольника</param>
        /// <param name="c">Сторона треугольника</param>
        public Triangle(double a, double b, double c)
        {
            IsValid(a, b, c);

            A = a;
            B = b;
            C = c;

            _p = (A + B + C)/2;
        }

        /// <summary> Сторона треугольника </summary>
        public double A { get; }

        /// <summary> Сторона треугольника </summary>
        public double B { get; }

        /// <summary> Сторона треугольника </summary>
        public double C { get; }

        /// <summary>
        /// Проверка сторон треугольника на валидность
        /// </summary>
        /// <exception cref="ArgumentException">Возникает при отрицательных длинах сторон треугольника 
        /// и если треугольник не прямоугольный</exception>
        /// <param name="a">Сторона треугольника</param>
        /// <param name="b">Сторона треугольника</param>
        /// <param name="c">Сторона треугольника</param>
        /// <param name="tolerance">Точность</param>
        private static void IsValid(double a, double b, double c, double tolerance = 1E-15)
        {
            if ((a <= 0.0) || (b <= 0.0) || (c <= 0.0))
                throw new ArgumentException("Неверные длины сторон");

            var catetA = Min(a, c);
            var catetB = Min(b, c);
            var hypotenuse = Max(Max(a, b), c);

            if (Abs(hypotenuse*hypotenuse - (catetA*catetA + catetB*catetB)) < tolerance) return;
            throw new ArgumentException("Треугольник не прямоугольный");
        }

        /// <summary> Вычисляет площадь</summary>
        /// <returns>Площадь треугольника</returns>
        public double Area() => Sqrt(_p*(_p - A)*(_p - B)*(_p - C));

        /// <summary> Вычисляет площадь</summary>
        /// <returns>Площадь треугольника</returns>
        public static double Area(double a, double b, double c)
        {
            IsValid(a, b, c);
            var p = (a + b + c)/2;
            return Sqrt(p*(p - a)*(p - b)*(p - c));
        }
    }
}