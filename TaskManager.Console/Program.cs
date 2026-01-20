using TaskManagerApp;

class Program
{
	static void Main(string[] args)
	{
		try
		{
			TaskStorage taskStorage = new TaskStorage();
			Status unCompleted = Status.UnCompleted;
			Status completed = Status.Completed;
			TaskManager taskManager = new TaskManager(taskStorage);
			while (true)
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.Clear();
				Console.WriteLine("====== TaskManager ======\n1.Add new task\n2.View completed tasks\n3.View uncompleted tasks\n4.Mark task as completed\n5.Delete task\n6.Exit");
				Console.Write("Option : ");
				string option = Console.ReadLine() ?? "";

				if (int.TryParse(option, out int value))
				{
					switch (value)
					{
						case 1: taskManager.CreateTask(); break;
						case 2: taskManager.ViewTasks(completed); break;
						case 3: taskManager.ViewTasks(unCompleted); break;
						case 4: taskManager.MarkTaskAsCompleted(); break;
						case 5: taskManager.DeleteTask(); break;
						case 6: taskManager.SaveToStorage(); return;
						default: Utility.Print("Please enter correct option..."); break;
					}
				}
				else
				{
					Utility.Print("Please enter just number...");
				}
				Console.ReadKey();
			} 
		}
		catch (Exception ex)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(ex.Message);
		}
	}
}