using System.Globalization;

namespace TaskManagerApp
{
	public class TaskManager
	{
		private TaskStorage  _storage;
		private List<TaskItem> tasks;
		private TaskItem? task;
		public TaskManager(TaskStorage taskStorage)
		{
			_storage = taskStorage;
			tasks = _storage.Load();
		}

		public void CreateTask()
		{
			task = new TaskItem();
			task.Id = tasks.Count + 1; 
			task.Title = Run("Task Title : ");
			task.Description = Run("Description : ");

			DateTime parseDeadline;
			string deadline = Run("Deadline (dd.MM.yyyy) : ");

			bool ok = DateTime.TryParseExact(deadline, "dd.MM.yyyy",
					CultureInfo.InvariantCulture, DateTimeStyles.None, out parseDeadline);
			if(ok)
			{
				task.DeadLine = parseDeadline.AddDays(1).AddSeconds(-1);
				task.CreatedAt = DateTime.Now;
				task.Status = Status.UnCompleted;
				tasks.Add(task);
				Console.Write("Task created successfully");
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.Write("Wrong date format");
			}
		}
		public void ViewTasks(Status taskStatus)
		{
			if(!tasks.Any(task => task.Status == taskStatus))
			{
				Console.WriteLine($"No {taskStatus} tasks");
				return;
			}
			foreach(TaskItem task in tasks.Where(t => t.Status == taskStatus))
			{
				Console.WriteLine($"Id : {task.Id} | Title : {task.Title} | Description : {task.Description} | Deadline : {task.DeadLine} | Created : {task.CreatedAt}");
			}
		}
		public void MarkTaskAsCompleted()
		{
			string input = Run("Task Id : ");

			if(int.TryParse(input, out int id) && id > 0 && id <= tasks.Count)
			{
				var task = tasks.FirstOrDefault(t => t.Id == id);
				task.Status = Status.Completed;
				Console.Write("Task marked as completed");
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.Write("Enter correct id...");
			}
		}

		public void DeleteTask()
		{
			string input = Run("Task Id : ");

			if(int.TryParse(input,out int id) && id > 0 && id <= tasks.Count)
			{
				tasks.RemoveAt(id - 1);
				ReIndex(id - 1);
				Console.Write("Task deleted successfully");
				return;
			}
			Console.ForegroundColor = ConsoleColor.Red;
			Utility.Print("Enter correct id...");
		}
		public void SaveToStorage()
		{
			_storage.Save(tasks);
		}
		private string Run(string message)
		{
			Utility.Print(message);
			string result = Console.ReadLine() ?? "";
			return result;
		}
		private void ReIndex(int startIndex)
		{
			for(int i = startIndex; i < tasks.Count; i++)
			{
				tasks[i].Id = i + 1;	 
			}
		}
	}
}
