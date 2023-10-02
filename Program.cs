using System;
using System.Collections.Generic;
using System.Threading;

namespace Triangle3
{
	internal class Program
	{
		public delegate double Area();
		static void Main(string[] args)
		{
			Triangle triangle1 = new Triangle();
			Triangle triangle2 = new Triangle();
			Square square1 = new Square(), square2 = new Square();
			int chooise = -1;
            double a, h, sideSquare;
            double areaTriangle1, areaSquare1, areaTriangle2, areaSquare2 = 0;
            while (chooise < 9)
			{ 
				Console.WriteLine("Wybierz rodzaj figury");
				Console.WriteLine("1 - trojakt");
				Console.WriteLine("2 - kwadrat");
                Console.WriteLine("3 - licz pola i porównaj");
                chooise = Convert.ToInt32(Console.ReadLine());

				switch (chooise)
				{
					case 1:

						Console.WriteLine("Podaj wymiary pierwszego trójkąta");
						Console.WriteLine("Podstawę");
						a = Convert.ToDouble(Console.ReadLine());
						Console.WriteLine("Wysokość");
						h = Convert.ToDouble(Console.ReadLine());
						triangle1 = new Triangle(a, h);


                        Console.WriteLine("Podaj wymiary pierwszego trójkąta");
                        Console.WriteLine("Podstawę");
                        a = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Wysokość");
                        h = Convert.ToDouble(Console.ReadLine());
                        triangle2 = new Triangle(a, h);

                        break;

					case 2:

						Console.WriteLine("Podaj wymiary prostokąta");
						Console.WriteLine("Bok");
						a = Convert.ToDouble(Console.ReadLine());
						square1 = new Square(a);

                        Console.WriteLine("Podaj wymiary prostokąta");
                        Console.WriteLine("Bok");
                        a = Convert.ToDouble(Console.ReadLine());
                        square2 = new Square(a);
                        break;

					case 3:
						

						Console.WriteLine("Licz pole figur");
						//Area d = triangle1.Area;
                       // areaTriangle1 = d();
						Console.WriteLine($"pole trójkąta wynosi {triangle1.Area()}");

						//areaSquare1 = (d = square1.Area)();
						Console.WriteLine($"pole kwadrata wynosi {square1.Area()}");
                        
                      
                        Console.WriteLine($"pole kwadrata wynosi {square2.Area()}");

                        
                        Console.WriteLine($"pole trójkąta wynosi {triangle2.Area()}");
                        break;
				}
            }
        }
	}

	public class CompareObject
	{
        public  bool EqualsType(object obj, object obj2)
        {
            if (obj == null && obj2 == null)
			{
				return false;
			}

			if ( obj.GetType() != obj2.GetType())
			{
				return false;
			}

			return true;
        }
    }


	//to value object ??
	public class Square
	{ 
		//A change to Side
		public double A { get; private set; }
		public Square()
		{
			A = -1;
		}
		public Square(double a)
		{
			
			A = a;
		}

		public double Area()
		{
			return A * A;
		}
	}

    //to value object ??
    public class Triangle
	{
		//A change to base
		public double A { get; private set; }
		//H change to height
		public double H { get; private set; }
		public Triangle()
		{
			A = -1;
			H = -1;
		}
		public Triangle(double a, double h)
		{
			
			A = a;
			H = h;
		}

		public double Area()
		{
			return (A * H) / 2;
		}
	}

	public class BuildFigures
	{
		public List<Triangle> triangles { get; private set; }
		public List<Square> squares  { get; private set; }

		private Validation validation { get; set; }
        public BuildFigures(Validation validation)
        {
			triangles = new List<Triangle> ();	
			squares = new List<Square> ();
			this.validation = validation;
        }
        /// <summary>
		/// value get from reflection maybe?
		/// </summary>
		/// <param name="a"></param>
		/// <param name="h"></param>
        public void CreateNewTriangle(double a, double h)
		{
            validation.ValidationLength(a, "triangle", "base");
            validation.ValidationLength(h, "triangle", "height");
            triangles.Add(new Triangle(a,h)); 
		}

		public void CreateNewSquare(double a)
		{
			validation.ValidationLength(a, "square", "base");
			squares.Add( new Square(a));
        }
    }

	public class Validation
	{
		
		public void ValidationLength(double a, string typeObject, string typeValue)
		{
			if (a <= 0)
			{
				throw new ArgumentException($"the length of the {typeValue} of the {typeObject} must be greater than zero");
			}
		}
	}
}
