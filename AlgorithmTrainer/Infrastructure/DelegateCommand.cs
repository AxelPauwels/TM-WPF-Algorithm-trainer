using System;
using System.Windows.Input;

namespace AlgorithmTrainer.Infrastructure
{
	public class DelegateCommand<T> : ICommand
	{
		private readonly Predicate<object> _canExecute;
		private readonly Action<T> _execute;

		public DelegateCommand(Action<T> execute)
			: this(execute, null)
		{
		}

		public DelegateCommand(Action<T> execute,
		                       Predicate<object> canExecute)
		{
			_execute = execute;
			_canExecute = canExecute;
		}

		#region ICommand Members

		public event EventHandler CanExecuteChanged;

		public virtual bool CanExecute(object parameter)
		{
			return _canExecute == null || _canExecute(parameter);
		}

		public virtual void Execute(object parameter)
		{
			_execute((T) parameter);
		}

		#endregion

		public void RaiseCanExecuteChanged()
		{
			if (CanExecuteChanged != null)
			{
				CanExecuteChanged(this, EventArgs.Empty);
			}
		}
	}
}