namespace DelegatesPractice.Processing
{
    public delegate void LogsAction(string str);

	public class Loggers
	{
		private List<string> _messgaeList = new List<string>();
		private int _count;
		public int Count => _count;
		public void PrintMessage(string message) 
			=> Console.WriteLine($"{DateTime.Now}: {message}");

		public void AddMessageToList(string message) 
			=> _messgaeList.Add(message);

		public void IncrementCount(string message) 
			=> _count++;

		public void ShowInfo()
		{
			foreach (string message in _messgaeList)
			{
                Console.WriteLine(message);
			}
		}


	}

}
