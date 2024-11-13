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

