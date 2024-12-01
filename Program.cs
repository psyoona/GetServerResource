using GetServerResource;

ResourceCollector resourceCollector = new ResourceCollector(); 

Console.WriteLine("=== CPU Information ===");
resourceCollector.GetCpuUsage();

Console.WriteLine("\n=== Memory Information ===");
resourceCollector.GetMemoryInfo();

Console.WriteLine("\n=== Disk Information ===");
resourceCollector.GetDiskInfo();