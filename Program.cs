using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading;

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
			BuildFigures buildFigures = new BuildFigures(new Validation());
			int chooise = -1;
            double a, h, sideSquare;
            
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
                            buildFigures.CreateNewTriangle(a, h);
                            break;

                        case 2:

                            Console.WriteLine("Podaj wymiary prostokąta");
                            Console.WriteLine("Bok");
                            a = Convert.ToDouble(Console.ReadLine());
                            buildFigures.CreateNewSquare(a);
                            break;

                        case 3:

                            Console.WriteLine("Licz pole figur");
                            if (!buildFigures.triangles.Any())
                            {
                                Console.WriteLine($"Brak zdefiniowanych {GetTypeName(buildFigures.triangles)}");
                                break;
                            }
                            if (!buildFigures.squares.Any())
                            {
                                Console.WriteLine($"Brak zdefiniowanych {GetTypeName(buildFigures.squares)} ");
                                break;
                            }

                            foreach (var triangle in buildFigures.triangles)
                            {
                                Area d = triangle.Area;
                                Console.WriteLine($"pole {GetTypeName(triangle)} wynosi {d()}");
                            }

                            foreach (var square in buildFigures.squares)
                            {
                                Area d = square.Area;
                                Console.WriteLine($"pole {GetTypeName(square)} wynosi {d()}");
                            }
                           
                            break;

                        case 4:
                            Console.WriteLine("Porównanie trójkątów");
                            if (!buildFigures.triangles.Any())
                            {
                                Console.WriteLine($"Brak zdefiniowanych {GetTypeName(buildFigures.triangles)}");
                                break;
                            }
                           
                            for (int i = 0; i < buildFigures.triangles.Count(); i ++)
                            {
                                if (i % 2 == 0 && i < buildFigures.triangles.Count() - 1)
                                {
                                    if(buildFigures.triangles[i].Area() == buildFigures.triangles[i+1].Area())
                                    {
                                        Console.WriteLine($"Pola są równe");
                                    }
                                    if (buildFigures.triangles[i].Area() > buildFigures.triangles[i + 1].Area())
                                    {
                                        Console.WriteLine($"jeden jest większy, tylko nie wiadomo który");
                                    }
                                    else 
                                    {
                                        Console.WriteLine($"albo odwrotnie");
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
	}

	//to value object ??
	public class Square
	{ 
		//A change to Side
		public double Side { get; private set; }
		public Square()
		{
            Side = -1;
		}
		public Square(double a)
		{

            Side = a;
		}

		public double Area()
		{
			return Side * Side;
		}
	}

    //to value object ??
    public class Triangle
	{
		//A change to base
		public double Base { get; private set; }
		//H change to height
		public double Height { get; private set; }
		public Triangle()
		{
            Base = -1;
            Height = -1;
		}
		public Triangle(double a, double h)
		{
			Base = a;
			Height = h;
		}

		public double Area()
		{
			return (Base * Height) / 2;
		}
	}
	
}
