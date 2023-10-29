using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

class Vehicle
{
    public string Type { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
    public int Horsepower { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        List<Vehicle> mainList = new List<Vehicle>();
        List<string> secondList = new List<string>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] vehicleInfo = input.Split();
            string type = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(vehicleInfo[0].ToLower());
            string model = vehicleInfo[1];
            string color = vehicleInfo[2];
            int horsepower = int.Parse(vehicleInfo[3]);

            Vehicle vehicle = new Vehicle
            {
                Type = type,
                Model = model,
                Color = color,
                Horsepower = horsepower
            };

            mainList.Add(vehicle);
        }

        double totalCarsHorsepower = 0;
        int carsCount = 0;
        double totalTrucksHorsepower = 0;
        int trucksCount = 0;

        foreach (var vehicle in mainList)
        {
            if (vehicle.Type == "Car")
            {
                totalCarsHorsepower += vehicle.Horsepower;
                carsCount++;
            }
            else if (vehicle.Type == "Truck")
            {
                totalTrucksHorsepower += vehicle.Horsepower;
                trucksCount++;
            }
        }

        double averageCarsHorsepower = carsCount > 0 ? totalCarsHorsepower / carsCount : 0;
        double averageTrucksHorsepower = trucksCount > 0 ? totalTrucksHorsepower / trucksCount : 0;

        while ((input = Console.ReadLine()) != "Close the Catalogue")
        {
            secondList.Add(input);
        }

        foreach (var model in secondList)
        {
            Vehicle vehicle = mainList.FirstOrDefault(v => v.Model == model);

            if (vehicle != null)
            {
                Console.WriteLine($"Type: {vehicle.Type}");
                Console.WriteLine($"Model: {vehicle.Model}");
                Console.WriteLine($"Color: {vehicle.Color}");
                Console.WriteLine($"Horsepower: {vehicle.Horsepower}");
            }
        }

        Console.WriteLine($"Cars have average horsepower of: {averageCarsHorsepower:F2}.");
        Console.WriteLine($"Trucks have average horsepower of: {averageTrucksHorsepower:F2}.");
    }
}
