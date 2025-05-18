using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Triangle3.Extension;
using Triangle3.Figures;
using Triangle3.ServiceComparer;

namespace Triangle3.Menu
{
    public class MenuHandler
    {
        private readonly CompareFigures<Triangle> _compareTriangle;
        private readonly CompareFigures<Square> _compareSquare;
        private readonly CompareFigures<Circle> _compareCircle;

        public MenuHandler()
        {
            _compareTriangle = new CompareFigures<Triangle>();
            _compareSquare = new CompareFigures<Square>();
            _compareCircle = new CompareFigures<Circle>();
        }

        public void Run()
        {
            int choice = -1;

            while (choice != 9)
            {
                DisplayMenu();
                choice = Convert.ToInt32(Console.ReadLine());

                try
                {
                    HandleChoice(choice);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Błąd: {ex.Message}");
                }
            }
        }

        private void DisplayMenu()
        {
            Console.WriteLine("Wybierz rodzaj figury");
            Console.WriteLine("1 - buduj trojkat");
            Console.WriteLine("2 - buduj kwadrat");
            Console.WriteLine("3 - buduj okrąg");
            Console.WriteLine("4 - licz pola");
            Console.WriteLine("5 - Porównaj figury");
            Console.WriteLine("6 - klonuj trójkąt");
            Console.WriteLine("9 - Koniec");
        }

        private void HandleChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    BuildTriangle();
                    break;

                case 2:
                    BuildSquare();
                    break;

                case 3:
                    BuildCircle();
                    break;

                case 4:
                    CalculateAreas();
                    break;

                case 5:
                    CompareFigures();
                    break;

                case 6:
                    CloneTriangle();
                    break;

                case 9:
                    Console.WriteLine("Koniec programu.");
                    break;

                default:
                    Console.WriteLine("Niepoprawny wybór.");
                    break;
            }
        }

        private void BuildTriangle()
        {
            Console.WriteLine("Podaj wymiary trójkąta");
            double a = ReadDouble("Podstawę:");
            double h = ReadDouble("Wysokość:");
            Console.WriteLine("Nazwa:");
            string name = Console.ReadLine();

            FigureFactory.CreateFigure(new FigureDescriptionParameters
            {
                BaseSide = a,
                Height = h,
                FigureType = nameof(Triangle),
                Name = name
            });
        }

        private void BuildSquare()
        {
            Console.WriteLine("Podaj wymiary kwadratu");
            double side = ReadDouble("Bok:");
            Console.WriteLine("Nazwa:");
            string name = Console.ReadLine();

            FigureFactory.CreateFigure(new FigureDescriptionParameters
            {
                Side = side,
                FigureType = nameof(Square),
                Name = name
            });
        }

        private void BuildCircle()
        {
            Console.WriteLine("Podaj wymiary okręgu");
            double radius = ReadDouble("Promień:");
            Console.WriteLine("Nazwa:");
            string name = Console.ReadLine();

            FigureFactory.CreateFigure(new FigureDescriptionParameters
            {
                Radius = radius,
                FigureType = nameof(Circle),
                Name = name
            });
        }

        private void CalculateAreas()
        {
            Console.WriteLine("Licz pole figur");
            if (!FigureFactory.FigureList.Any())
            {
                Console.WriteLine("Brak zdefiniowanych figur");
                return;
            }

            foreach (var figure in FigureFactory.FigureList)
            {
                Console.WriteLine($"Pole figury {figure.Name} typu {figure.GetType().Name} wynosi {figure.Area()}");
            }
        }

        private void CompareFigures()
        {
            Console.WriteLine("Porównanie pól figur");

            if (!FigureFactory.FigureList.Any())
            {
                Console.WriteLine("Brak zdefiniowanych figur");
                return;
            }

            var triangleList = FigureFactory.FigureList.OfType<Triangle>().ToList();
            var squareList = FigureFactory.FigureList.OfType<Square>().ToList();
            var circleList = FigureFactory.FigureList.OfType<Circle>().ToList();

            foreach (var item in _compareTriangle.Compare(triangleList))
            {
                Console.WriteLine(item);
            }

            foreach (var item in _compareSquare.Compare(squareList))
            {
                Console.WriteLine(item);
            }

            foreach (var item in _compareCircle.Compare(circleList))
            {
                Console.WriteLine(item);
            }
        }

        private void CloneTriangle()
        {
            Console.WriteLine("Funkcja klonowania trójkąta nie została jeszcze zaimplementowana.");
        }

        private double ReadDouble(string prompt)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine();
            return Convert.ToDouble(input.ReplaceDotWithComma());
        }
    }
}
