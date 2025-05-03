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
            double a, h, sideSquare, radius;
            FigureFactory figureFactory = new FigureFactory();
            CompareFigures<Triangle> compareTriangle = new CompareFigures<Triangle>();
            CompareFigures<Square> compareSquare = new CompareFigures<Square>();
            CompareFigures<Circle> compareCircle = new CompareFigures<Circle>();

            string name = string.Empty;

            while (chooise < 9)
			{ 
				Console.WriteLine("Wybierz rodzaj figury");
				Console.WriteLine("1 - buduj trojkat");
				Console.WriteLine("2 - buduj kwadrat");
                Console.WriteLine("3 - buduj okrąg");
                Console.WriteLine("4 - licz pola");
                Console.WriteLine("5 - Porównaj figury");
                Console.WriteLine("6 - klonuj trójkąt"); //choose saved triangle
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
                            FigureFactory.CreateFigure(new FigureDescriptionParameters
                            {
                                BaseSide = a,
                                Height = h,
                                FigureType = nameof(Triangle),
                                Name = name
                            });
                            break;

                        case 2:

                            Console.WriteLine("Podaj wymiary kweadratu");
                            Console.WriteLine("Bok");
                            a = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Nazwa");
                            name = Console.ReadLine();
                            FigureFactory.CreateFigure(new FigureDescriptionParameters
                            {
                                Side = a,
                                FigureType = nameof(Square),
                                Name = name
                            });
                            break;

                        case 3:

                            Console.WriteLine("Podaj wymiary okręgu");
                            Console.WriteLine("Promień");
                            radius = Convert.ToDouble(Console.ReadLine());
                            FigureFactory.CreateFigure(new FigureDescriptionParameters
                            {
                                Radius = radius,
                                FigureType = nameof(Circle),
                                Name = name
                            });
                            break;

                        case 4:

                            Console.WriteLine("Licz pole figur");
                            if (!FigureFactory.FigureList.Any())
                            { 
                            
                                Console.WriteLine($"Brak zdefiniowanych figur");
                                break;
                            }
                           
                            foreach (var figure in FigureFactory.FigureList)
                            {
                                Console.WriteLine($"Pole {figure.Name} wynosi {figure.Area()}");
                            }
                            break;

                        case 5:
                            Console.WriteLine("Porównanie pól figur");
                           
                            if (!FigureFactory.FigureList.Any())
                            {
                                Console.WriteLine($"Brak zdefiniowanych {typeof(Triangle)}");
                                break;
                            }
                            List<Triangle> trianglelist = new List<Triangle>();
                            List<Square> squareList = new List<Square>();
                            List<Circle> circleList = new List<Circle>();
                            foreach (var figure in FigureFactory.FigureList)
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
                            foreach (var item in compareCircle.Compare(circleList))
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
