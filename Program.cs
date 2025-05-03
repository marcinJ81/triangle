using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading;
using Triangle3.Figures;

namespace Triangle3
{
	internal class Program
	{
        static string GetTypeName<T>(List<T> list)
        {
            Type type = typeof(T);
            return type.Name;
        }

        static string GetTypeName<T>(T param)
        {
            Type type = typeof(T);
            return type.Name;
        }

        public delegate double Area();
		static void Main(string[] args)
		{
			BuildFigures buildFigures = new BuildFigures();
			int chooise = -1;
            double a, h, sideSquare;
            string name = string.Empty;

            while (chooise < 9)
			{ 
				Console.WriteLine("Wybierz rodzaj figury");
				Console.WriteLine("1 - trojakt");
				Console.WriteLine("2 - kwadrat");
                Console.WriteLine("3 - licz pola");
                Console.WriteLine("4 - Porównaj figury");
                Console.WriteLine("9 - Koniec");
                chooise = Convert.ToInt32(Console.ReadLine());
				try
				{
                    switch (chooise)
                    {
                        case 1:

                            Console.WriteLine("Podaj wymiary trójkąta");
                            Console.WriteLine("Podstawę");
                            a = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Wysokość");
                            h = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Nazwa");
                            name = Console.ReadLine();
                            buildFigures.AddFigure(new Triangle(a,h,name));
                            break;

                        case 2:

                            Console.WriteLine("Podaj wymiary prostokąta");
                            Console.WriteLine("Bok");
                            a = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Nazwa");
                            name = Console.ReadLine();
                            buildFigures.AddFigure(new Square(a, name));
                            break;

                        case 3:

                            Console.WriteLine("Licz pole figur");
                            if (!buildFigures.Figures.Any())
                            { 
                            
                                Console.WriteLine($"Brak zdefiniowanych figur");
                                break;
                            }
                           
                            var triangles = buildFigures.Figures.OfType<Triangle>().ToList();
                            var squares = buildFigures.Figures.OfType<Square>().ToList();
                            Console.WriteLine($"Brak zdefiniowanych {GetTypeName(triangles.Any() ? typeof(Triangle) : typeof(Square))} ");

                            foreach (var triangle in triangles)
                                    {
                                        Area d = triangle.Area;
                                        Console.WriteLine($"pole {GetTypeName(triangle)} wynosi {d()}");
                                    }

                            foreach (var square in squares)
                            {
                                Area d = square.Area;
                                Console.WriteLine($"pole {GetTypeName(square)} wynosi {d()}");
                            }
                           
                            break;

                        case 4:
                            Console.WriteLine("Porównanie trójkątów");
                            var trianglesToEquals = buildFigures.Figures.OfType<Triangle>().ToList();

                            if (!trianglesToEquals.Any())
                            {
                                Console.WriteLine($"Brak zdefiniowanych {typeof(Triangle)}");
                                break;
                            }
                           
                            for (int i = 0; i < trianglesToEquals.Count; i ++)
                            {
                                if (i % 2 == 0 && i < trianglesToEquals.Count - 1)
                                {
                                    if(trianglesToEquals[i].Area() == trianglesToEquals[i+1].Area())
                                    {
                                        Console.WriteLine($"Pola są równe");
                                    }
                                    if (trianglesToEquals[i].Area() > trianglesToEquals[i + 1].Area())
                                    {
                                        Console.WriteLine($"Pole  trójkata {trianglesToEquals[i].GetName()} równe {trianglesToEquals[i].Area()}" +
                                            $" jest większe od pola trójkta {trianglesToEquals[i+1].GetName()} równego {trianglesToEquals[i+1].Area()}");
                                    }
                                    else 
                                    {
                                        Console.WriteLine($"Pole  trójkata {trianglesToEquals[i].GetName()} równe {trianglesToEquals[i].Area()}" +
                                            $" jest mniejsze od pola trójkata {trianglesToEquals[i + 1].GetName()} równego {trianglesToEquals[i + 1].Area()}");
                                    }
                                }
                            }
                            break;
                    }
                }
                catch (Exception ex)
				{
                    Console.WriteLine(ex.Message);
                }
				
            }
        }
        private static double ReadPositiveDouble(string prompt)
        {
            double value;
            do
            {
                Console.WriteLine(prompt);
            } while (!double.TryParse(Console.ReadLine(), out value) || value <= 0);

            return value;
        }
	}
	
}
