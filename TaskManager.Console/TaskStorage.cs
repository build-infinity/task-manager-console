using System.Text.Json;

namespace TaskManagerApp
{
	public class TaskStorage
	{
		private readonly string _filePath;
		private readonly static JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions() { WriteIndented = true };
		public TaskStorage()
		{
			string basePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

			string appFolder = Path.Combine(basePath, "TaskManager");
			Directory.CreateDirectory(appFolder);

			_filePath = Path.Combine(appFolder, "tasks.json");
		}

		public List<TaskItem> Load()
		{
			if(!File.Exists(_filePath))
				return new List<TaskItem>();

			string json = File.ReadAllText(_filePath);

			return JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
		}
		public void Save(List<TaskItem> taskItems)
		{
			string json = JsonSerializer.Serialize(taskItems, _jsonSerializerOptions);
			File.WriteAllText(_filePath, json);
		}
	}
}
