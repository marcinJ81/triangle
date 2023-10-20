using System;
using System.Collections.Generic;
using System.ComponentModel;
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
			int chooise = -1;
            double a, h, sideSquare;
            FigureFactory figureFactory = new FigureFactory();
            CompareFigures<Triangle> compareTriangle = new CompareFigures<Triangle>();
            CompareFigures<Square> compareSquare = new CompareFigures<Square>();

            while (chooise < 9)
			{ 
				Console.WriteLine("Wybierz rodzaj figury");
				Console.WriteLine("1 - buduj trojakt");
				Console.WriteLine("2 - buduj kwadrat");
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
                            //buildFigures.CreateNewTriangle(a, h);
                            figureFactory.CreateTriangle(a, h);
                            break;

                        case 2:

                            Console.WriteLine("Podaj wymiary prostokąta");
                            Console.WriteLine("Bok");
                            a = Convert.ToDouble(Console.ReadLine());
                            //buildFigures.CreateNewSquare(a);
                            figureFactory.CreateSquera(a);
                            break;

                        case 3:

                            Console.WriteLine("Licz pole figur");
                            if (!figureFactory.FigureList.Any())
                            {
                                Console.WriteLine($"Brak zdefiniowanych figur");
                                break;
                            }

                            foreach (var figure in figureFactory.FigureList)
                            {
                                switch (figure)
                                {
                                    case Triangle triangle:
                                        Console.WriteLine($"Pole trójkąta {figure.Name} wynosi {figure.Area()}");
                                        break;
                                    case Square square:
                                        Console.WriteLine($"Pole kwadrata {figure.Name} wynosi {figure.Area()}");
                                        break;
                                }
                            }
                            break;

                        case 4:
                            Console.WriteLine("Porównanie pól figur");
                            if (!figureFactory.FigureList.Any())
                            {
                                Console.WriteLine($"Brak zdefiniowanych figur");
                                break;
                            }

                            List<Triangle> trianglelist = new List<Triangle>();
                            List<Square> squareList = new List<Square>();
                            foreach (var figure in figureFactory.FigureList)
                            {
                                if (figure as Triangle != null)
                                {
                                    trianglelist.Add(figure as Triangle);
                                }

                                if (figure as Square != null)
                                {
                                    squareList.Add(figure as Square);
                                }
                            }
                            foreach (var item in compareTriangle.Compare(trianglelist))
                            {
                                Console.WriteLine(item);
                            }
                            foreach (var item in compareSquare.Compare(squareList))
                            {  
                                Console.WriteLine(item); 
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
	
}
