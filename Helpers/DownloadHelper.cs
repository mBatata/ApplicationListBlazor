using System.Reflection;
using System.Text;

public static class DownloadHelper
{
	public static string? GetFileData<T>(IEnumerable<T> inputData)
		where T : class, new()
	{
        using var stream = GetFileDataStream(inputData);
        return Convert.ToBase64String(stream.ToArray());
	}
	
	public static MemoryStream GetFileDataStream<T>(IEnumerable<T> inputData)
		where T : class, new()
	{
		var stream = new MemoryStream();
		var streamWriter = new StreamWriter(stream);

		var properties = inputData.First().GetType().GetProperties();

		// Fill Header
		foreach (var property in properties)
		{
			streamWriter.Write($"{property.Name};");
		}

		// Fill Data
		foreach (var data in inputData)
		{
			streamWriter.Write(streamWriter.NewLine);

			foreach (var property in properties)
			{
				streamWriter.Write($"{property.GetValue(data) ?? string.Empty};");
			}
		}
		
		return stream;
	}
}
