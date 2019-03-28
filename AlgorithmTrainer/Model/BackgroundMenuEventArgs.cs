using System;

namespace AlgorithmTrainer.Model
{
	public delegate void FileMenuHandler(object sender, BackgroundMenuEventArgs args);
	public class BackgroundMenuEventArgs : EventArgs
	{
		public BackgroundMenuEventArgs()
			: this(string.Empty)
		{

		}
		public BackgroundMenuEventArgs(string commandName)
		{
			CommandName = CommandName;
		}
		public string CommandName
		{
			get;
			set;
		}
	}
}
