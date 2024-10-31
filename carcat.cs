using System;

class Car
{
    private string name;
    private int productionYear;
    private int maxSpeed;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int ProductionYear
    {
        get { return productionYear; }
        set { productionYear = value; }
    }

    public int MaxSpeed
    {
        get { return maxSpeed; }
        set { maxSpeed = value; }
    }

    public Car(string name, int productionYear, int maxSpeed)
    {
        Name = name;
        ProductionYear = productionYear;
        MaxSpeed = maxSpeed;
    }
}

class CarComparer : IComparer<Car>
{
    private string sortBy;

    public CarComparer(string sortBy)
    {
        this.sortBy = sortBy;
    }

    public int Compare(Car x, Car y)
    {
        switch (sortBy)
        {
            case "Name":
                return x.Name.CompareTo(y.Name);
            case "ProductionYear":
                return x.ProductionYear.CompareTo(y.ProductionYear);
            case "MaxSpeed":
                return x.MaxSpeed.CompareTo(y.MaxSpeed);
            default:
                return 0;
        }
    }
}

class CarCatalog
{
    private List<Car> cars = new List<Car>();

    public void AddCar(Car car)
    {
        cars.Add(car);
    }

    public IEnumerable<Car> ForwardIteration()
    {
        foreach (var car in cars)
        {
            yield return car;
        }
    }

    public IEnumerable<Car> ReverseIteration()
    {
        for (int i = cars.Count - 1; i >= 0; i--)
        {
            yield return cars[i];
        }
    }

    public IEnumerable<Car> YearFilter(int year)
    {
        foreach (var car in cars)
        {
            if (car.ProductionYear == year)
            {
                yield return car;
            }
        }
    }

    public IEnumerable<Car> SpeedFilter(int speed)
    {
        foreach (var car in cars)
        {
            if (car.MaxSpeed == speed)
            {
                yield return car;
            }
        }
    }
}

class lab043
{
    static void Main()
    {
        CarCatalog catalog = new CarCatalog();

        catalog.AddCar(new Car("Lada Granda", 2015, 150));
        catalog.AddCar(new Car("Lada Sport", 2023, 2000));
        catalog.AddCar(new Car("Zaporozhec", 1977, 500));
        catalog.AddCar(new Car("YAZ", 1980, 8934));

        int i = 0; while (i != 1)
        {
            Console.WriteLine("\nChoose the type of sort (don't take bads):"); string type = Console.ReadLine();
            switch (type)
            {
                case "Forward":
                    Console.WriteLine("Nice!");

                    foreach (var car in catalog.ForwardIteration())
                    {
                        Console.WriteLine(car.Name);
                    }
                    i++;
                    break;
                case "Reverse":
                    Console.WriteLine("\nNot bad!");

                    foreach (var car in catalog.ReverseIteration())
                    {
                        Console.WriteLine(car.Name);
                    }
                    i++;
                    break;
                case "Year":
                    Console.WriteLine("So good! Now choose a year:");
                    int a = int.Parse(Console.ReadLine());

                    foreach (var car in catalog.YearFilter(a))
                    {
                        Console.WriteLine(car.Name);
                    }
                    i++;
                    break;
                case "Speed":
                    Console.WriteLine("\nOkay...  Now choose a speed:");
                    int b = int.Parse(Console.ReadLine());

                    foreach (var car in catalog.SpeedFilter(b))
                    {
                        Console.WriteLine(car.Name);
                    }
                    i++;
                    break;
                default:
                    Console.WriteLine("Ypu can better. Try again");
                    break;
            }
        }





    }
}
