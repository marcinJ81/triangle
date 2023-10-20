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
                                        Console.WriteLine($"Pole trójkąta wynosi {figure.Area()}");
                                        break;
                                    case Square square:
                                        Console.WriteLine($"Pole kwadrata wynosi {figure.Area()}");
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

                            if (trianglelist.Count > 1)
                            {
                                //licz pole i porównaj  
                                for (int i = 0; i < trianglelist.Count; i++) 
                                {
                                    if (i % 2 == 0 && i < trianglelist.Count - 1)
                                    {
                                        if(trianglelist[i].Area() == trianglelist[i+1].Area())
                                        {
                                            Console.WriteLine($"{trianglelist[i].Name} pole wynosi {trianglelist[i].Area()}" +
                                                $" jest równe {trianglelist[i+1].Name} którego pole wynosi {trianglelist[i+1].Area()}");
                                        }
                                        if (trianglelist[i].Area() > trianglelist[i + 1].Area())
                                        {
                                            Console.WriteLine($"{trianglelist[i].Name} pole wynosi {trianglelist[i].Area()}" +
                                                $" jest większe od {trianglelist[i + 1].Name} którego pole wynosi {trianglelist[i + 1].Area()}");
                                        }
                                        else
                                        {
                                            Console.WriteLine($"{trianglelist[i].Name} pole wynosi {trianglelist[i].Area()}" +
                                               $" jest mniejsze od {trianglelist[i + 1].Name} którego pole wynosi {trianglelist[i + 1].Area()}");
                                        }
                                    }
                                }
                            }
                            if (squareList.Count > 1 )
                            {
                                for (int i = 0; i < squareList.Count; i++)
                                {
                                    if (i % 2 == 0 && i < squareList.Count - 1)
                                    {
                                        if (squareList[i].Area() == squareList[i + 1].Area())
                                        {
                                            Console.WriteLine($"{squareList[i].Name} pole wynosi {squareList[i].Area()}" +
                                                $" jest równe {squareList[i + 1].Name} którego pole wynosi {squareList[i + 1].Area()}");
                                        }
                                        if (squareList[i].Area() > squareList[i + 1].Area())
                                        {
                                            Console.WriteLine($"{squareList[i].Name} pole wynosi {squareList[i].Area()}" +
                                                $" jest większe od {squareList[i + 1].Name} którego pole wynosi {squareList[i + 1].Area()}");
                                        }
                                        else
                                        {
                                            Console.WriteLine($"{squareList[i].Name} pole wynosi {squareList[i].Area()}" +
                                               $" jest mniejsze od {squareList[i + 1].Name} którego pole wynosi {squareList[i + 1].Area()}");
                                        }
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
	
}
