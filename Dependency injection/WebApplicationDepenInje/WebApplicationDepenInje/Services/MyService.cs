namespace WebApplicationDepenInje.Services
{
    public class MyService
    {
        public async Task<string> myHelloasync(string user)
        {
            // Simulate an asynchronous operation (e.g., a delay)
            await Task.Delay(100);  // Example of async behavior

            return $"hello world {user}";
        }
     
    }
}

//1- create service (dependency)
//2- register the service
//3-consume the service in controller

public class Car
{
    // Properties of Car
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }

    // Constructor with parameters
    public Car(string brand, string model, int year)
    {
        Brand = brand;    // Set Brand using the parameter
        Model = model;    // Set Model using the parameter
        Year = year;      // Set Year using the parameter
    }

    // Method to display car details
    public void DisplayCarInfo()
    {
        Console.WriteLine($"Brand: {Brand}, Model: {Model}, Year: {Year}");
    }
}
