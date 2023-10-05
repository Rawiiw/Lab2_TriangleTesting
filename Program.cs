using System;
using System.Collections.Generic;
using System.Globalization;

public class Triangle
{
    public static (string, List<(int, int)>) GetTriangleInfo(string sideA, string sideB, string sideC)
    {
        if (float.TryParse(sideA, NumberStyles.Float, CultureInfo.InvariantCulture, out float a) &&
            float.TryParse(sideB, NumberStyles.Float, CultureInfo.InvariantCulture, out float b) &&
            float.TryParse(sideC, NumberStyles.Float, CultureInfo.InvariantCulture, out float c))
        {
            string triangleType = GetTriangleType(a, b, c);
            List<(int, int)> triangleVertices = GetTriangleVertices(a, b, c);
            return (triangleType, triangleVertices);
        }
        else
        {
            return ("", new List<(int, int)> { (-2, -2), (-2, -2), (-2, -2) });
        }
    }

    private static string GetTriangleType(float a, float b, float c)
    {
        if (a <= 0 || b <= 0 || c <= 0)
        {
            return "";
        }
        else if (a + b <= c || a + c <= b || b + c <= a)
        {
            return "не треугольник";
        }
        else if (a == b && b == c)
        {
            return "равносторонний";
        }
        else if (a == b || a == c || b == c)
        {
            return "равнобедренный";
        }
        else
        {
            return "разносторонний";
        }
    }

    private static List<(int, int)> GetTriangleVertices(float a, float b, float c)
    {
        var xA = 0;
        var yA = 0;

        var xB = (int)a;
        var yB = 0;

        float cosC = (a * a + b * b - c * c) / (2 * a * b);
        var xC = (int)(a - c * cosC);
        var yC = (int)(c * Math.Sin(Math.Acos(cosC)));

        return new List<(int, int)> { (xA, yA), (xB, yB), (xC, yC) };
    }

    static void Main(string[] args)
    {
        string sideA = "6";
        string sideB = "7";
        string sideC = "3";

        var result = Triangle.GetTriangleInfo(sideA, sideB, sideC);

        Console.WriteLine($"Тип треугольника: {result.Item1}");
        Console.WriteLine("Координаты вершин:");
        Console.WriteLine($"Вершина A: ({result.Item2[0].Item1}, {result.Item2[0].Item2})");
        Console.WriteLine($"Вершина B: ({result.Item2[1].Item1}, {result.Item2[1].Item2})");
        Console.WriteLine($"Вершина C: ({result.Item2[2].Item1}, {result.Item2[2].Item2})");
    }
}

