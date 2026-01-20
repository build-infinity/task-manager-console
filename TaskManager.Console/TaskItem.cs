
namespace TaskManagerApp
{
	public enum Status
	{
		Completed,
		UnCompleted
	}
	public class TaskItem
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime DeadLine { get; set; }
		public DateTime CreatedAt { get; set; }
		public Status Status { get; set; }
	}
}
