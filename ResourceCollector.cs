using System.Diagnostics;
using System.Management;

namespace GetServerResource
{
	internal class ResourceCollector
	{
		public void GetCpuUsage()
		{
			var searcher = new ManagementObjectSearcher("select * from Win32_Processor");
			foreach (var obj in searcher.Get())
			{
				var managementObject = (ManagementObject)obj;
				Console.WriteLine($"Name: {managementObject["Name"]}");
				Console.WriteLine($"Cores: {managementObject["NumberOfCores"]}");
				Console.WriteLine($"Logical Processors: {managementObject["NumberOfLogicalProcessors"]}");
			}
		}

		public void GetMemoryInfo()
		{
			var searcher = new ManagementObjectSearcher("select * from Win32_ComputerSystem");
			foreach (var obj in searcher.Get())
			{
				var managementObject = (ManagementObject)obj;
				double totalMemory = Convert.ToDouble(managementObject["TotalPhysicalMemory"]) / (1024 * 1024 * 1024);
				Console.WriteLine($"Total Physical Memory: {totalMemory:F2} GB");
			}

			var availableMemory = new PerformanceCounter("Memory", "Available MBytes");
			Console.WriteLine($"Available Memory: {availableMemory.NextValue()} MB");
		}

		public void GetDiskInfo()
		{
			var drives = DriveInfo.GetDrives();
			foreach (var drive in drives.Where(d => d.IsReady))
			{
				Console.WriteLine($"Drive {drive.Name}");
				Console.WriteLine($"  File System: {drive.DriveFormat}");
				Console.WriteLine($"  Total Size: {drive.TotalSize / (1024 * 1024 * 1024)} GB");
				Console.WriteLine($"  Free Space: {drive.TotalFreeSpace / (1024 * 1024 * 1024)} GB");
			}
		}
	}
}
