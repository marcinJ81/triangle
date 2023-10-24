# A simple task, calculate the area of a triangle

The task has been expanded to include more figures:
- Square,
- Circle

In the beginnig triangle class was simple,  now is not.
```sh
[DisplayName("Trójkąt")]
public class Triangle : AClassNameAttribute<Triangle>, IArea
{
	private string Uuid { get; set; }
	[DisplayName("Podstawa")]
	public double Base { get; private set; }
	[DisplayName("Wysokość")]
	public double Height { get; private set; }
	public string Name { get; private set; }
	public Triangle(double a, double h)
		:base()
	{
		this.Uuid = base.Uuid;
		Base = a;
		Height = h;
		var propertiesName = base.GetDescription<Triangle>();
		Name = $"{Uuid} {GetDisplayName<Triangle>()} ({propertiesName[0]}: {Base} {propertiesName[1]}: {Height})";
	}

	public double Area()
	{
		return (Base * Height) / 2;
	}

}
```

### Build object list
Class FigureFactory

```sh
 public class FigureFactory : IFigureFactory
 {
     public List<IArea> FigureList { get; private set; }

     public FigureFactory()
     {
         FigureList = new List<IArea>();
     }

     public void CreateTriangle(double baseSide,double height)
     {
         FigureList.Add(new Triangle(baseSide, height));
     }

     public void CreateSquera(double side) 
     {
         FigureList.Add(new Square(side));
     }

     public void CreateCircle(double radius)
     {
         FigureList.Add(new Circle(radius));
     }
 }
```