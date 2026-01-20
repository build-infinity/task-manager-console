
namespace TaskManagerApp
{
	public static class Utility
	{
		public static void Print(string message)
		{
			for (int i = 0; i < message.Length; i++)
			{
				Console.Write(message[i]);
				Thread.Sleep(25);
			}
		}
	}
}
