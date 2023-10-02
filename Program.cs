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

        public delegate double Area();
		static void Main(string[] args)
		{
			BuildFigures buildFigures = new BuildFigures(new Validation());
            List<Triangle> triangles = new List<Triangle>();
			List<Square> squares = new List<Square>();
			int chooise = -1;
            double a, h, sideSquare;
            //double areaTriangle1, areaSquare1, areaTriangle2, areaSquare2 = 0;
            while (chooise < 9)
			{ 
				Console.WriteLine("Wybierz rodzaj figury");
				Console.WriteLine("1 - trojakt");
				Console.WriteLine("2 - kwadrat");
                Console.WriteLine("3 - licz pola i porównaj");
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
                                Console.WriteLine($"Brak zdefiniowanych {GetTypeName(triangles)}");
                                break;
                            }
                            if (!buildFigures.squares.Any())
                            {
                                Console.WriteLine($"Brak zdefiniowanych {GetTypeName(squares)} ");
                                break;
                            }


                            foreach (var triangle in buildFigures.triangles)
                            {
                                Area d = triangle.Area;
                                Console.WriteLine($"pole trójkąta wynosi {d()}");
                            }
                            //areaTriangle1 = d();
                            //Console.WriteLine($"pole trójkąta wynosi {triangle1.Area()}");

                            ////areaSquare1 = (d = square1.Area)();
                            //Console.WriteLine($"pole kwadrata wynosi {square1.Area()}");


                            //                  Console.WriteLine($"pole kwadrata wynosi {square2.Area()}");


                            //                  Console.WriteLine($"pole trójkąta wynosi {triangle2.Area()}");
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
