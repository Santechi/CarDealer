using System.Diagnostics;
using System.Windows.Input;

namespace CarDealer.WPF
{
    public class BaseCommand : ICommand
    {
        private readonly Func<object?, Task> execute;
        private readonly Func<object?, bool>? canExecute;

        public BaseCommand(Func<object?, Task> execute, Func<object?, bool>? canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object? parameter) => canExecute == null || canExecute(parameter);

        public async void Execute(object? parameter)
        {
            try
            {
                await execute(parameter);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception in AsyncCommand: {ex}");
            }
        }
    }
}
