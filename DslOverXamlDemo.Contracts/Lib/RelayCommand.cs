using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DslOverXamlDemo.Contracts.Lib
{
    public class RelayCommand<T> : ICommand
    {
        private readonly Func<T, Task> m_execute;
        private readonly Predicate<T> m_canExecute;

        private static Task MakeTask(Action<T> execute, T arg)
        {
            execute(arg);
            return Task.FromResult(true);
        }

        public RelayCommand(Action<T> execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
            : this(x => MakeTask(execute, x), canExecute)
        {
        }

        public RelayCommand(Func<T, Task> execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Func<T, Task> execute, Predicate<T> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));

            m_execute = execute;
            m_canExecute = canExecute ?? (param => true);
        }

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return m_canExecute((T) parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            var prm = (T) parameter;
            if (!CanExecute(prm))
                throw new InvalidOperationException("Command cannot be executed");

            m_execute(prm).ContinueWith(x =>
            {
                var exception = x.Exception;
                EventAggregator.Instance.Publish(new CommandException(exception));
            }, TaskContinuationOptions.OnlyOnFaulted);
        }
    }

    public class RelayCommand : RelayCommand<object>
    {
        public RelayCommand(Action execute)
            : base(param => execute())
        {
        }

        public RelayCommand(Action execute, Func<bool> canExecute)
            : base(param => execute(), param => canExecute())
        {
        }

        public RelayCommand(Func<Task> execute)
            : base(param => execute())
        {
        }

        public RelayCommand(Func<Task> execute, Func<bool> canExecute)
            : base(param => execute(), param => canExecute())
        {
        }
    }
}