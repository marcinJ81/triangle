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
		static void Main(string[] args)
		{
			BuildFigures buildFigures = new BuildFigures();
			int chooise = -1;
            double a, h, sideSquare;
            FigureFactory figureFactory = new FigureFactory();
            CompareFigures<Triangle> compareTriangle = new CompareFigures<Triangle>();
            CompareFigures<Square> compareSquare = new CompareFigures<Square>();
            CompareFigures<Circle> compareCircle = new CompareFigures<Circle>();

            string name = string.Empty;

            while (chooise < 9)
			{ 
				Console.WriteLine("Wybierz rodzaj figury");
				Console.WriteLine("1 - buduj trojakt");
				Console.WriteLine("2 - buduj kwadrat");
                Console.WriteLine("3 - buduj okrąg");
                Console.WriteLine("4 - licz pola");
                Console.WriteLine("5 - Porównaj figury");
                Console.WriteLine("6 - klonuj trójkąt");
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
                            //buildFigures.CreateNewTriangle(a, h);
                            figureFactory.CreateTriangle(a, h);
                            break;

                        case 2:

                            Console.WriteLine("Podaj wymiary kweadratu");
                            Console.WriteLine("Bok");
                            a = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Nazwa");
                            name = Console.ReadLine();
                            buildFigures.AddFigure(new Square(a, name));
                            break;

                        case 3:

                            Console.WriteLine("Podaj wymiary okręgu");
                            Console.WriteLine("Promień");
                            a = Convert.ToDouble(Console.ReadLine());
                            //buildFigures.CreateNewSquare(a);
                            figureFactory.CreateCircle(a);
                            break;

                        case 4:

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
                                    case Circle circle:
                                        Console.WriteLine($"Pole koła {figure.Name} wynosi {figure.Area()}");
                                        break;
                                }
                            }
                            break;

                        case 5:
                            Console.WriteLine("Porównanie pól figur");
                            if (!figureFactory.FigureList.Any())
                            {
                                Console.WriteLine($"Brak zdefiniowanych figur");
                                break;
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
                            List<Triangle> trianglelist = new List<Triangle>();
                            List<Square> squareList = new List<Square>();
                            List<Circle> circleList = new List<Circle>();
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

                                if (figure as Circle != null)
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
                                    circleList.Add(figure as Circle);
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
                            foreach (var item in compareCircle.Compare(circleList))
                            {
                                Console.WriteLine(item);
                            }

                            break;
                        case 6:
                            List<Triangle> trianglelist2 = new List<Triangle>();
                            foreach (var figure in figureFactory.FigureList)
                            {
                                if (figure as Triangle != null)
                                {
                                    var triangle = figure as Triangle;
                                    figureFactory.FigureList.Add(triangle.Clone());
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
