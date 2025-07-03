using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace GoHCalculator
{
    public static class Programp
	{
		public static void Main()
		{
			Console.CursorVisible = false;
			Console.WriteLine(@"Game of Homes......");
			var rawData = new Simulation().Run();
			var output = rawData.ToDictionary(p => p.Key.ToString(), p =>
			{
				var values = new List<double>();

				for (var t = 0; t < p.Value.GetLength(0); t++)
				{
					values.Add(p.Value[t].Average());
					
				}
				return values;
			});

			Console.WriteLine("Creating output json file......");
			var jsonString = JsonSerializer.Serialize(output);
			File.WriteAllText(Path.Combine("..", "..", "Source","GoHDashboard","Blazor-Dashboard","wwwroot","results.json"), jsonString);
		}
	}
}
