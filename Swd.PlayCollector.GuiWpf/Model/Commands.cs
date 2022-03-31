using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace playcollector.gui.wpf.Model
{
    
    
    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }





    public static class CustomCommands
    {

        public static readonly RoutedUICommand NewCollectorItem = new RoutedUICommand
            (
                "New",
                "New",
                typeof(CustomCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.N, ModifierKeys.Control)
                }
            );

        public static readonly RoutedUICommand UpdateCollectorItem = new RoutedUICommand
       (
           "Update",
           "Update",
           typeof(CustomCommands),
           new InputGestureCollection()
           {
                    new KeyGesture(Key.S, ModifierKeys.Control)
           }
       );


        public static readonly RoutedUICommand DeleteCollectorItem = new RoutedUICommand
        (
           "Delete",
           "Delete",
           typeof(CustomCommands),
           new InputGestureCollection()
           {
                 new KeyGesture(Key.D, ModifierKeys.Control)
           }
        );


        public static readonly RoutedUICommand ShowListView = new RoutedUICommand
        (
           "ShowListView",
           "ShowListView",
           typeof(CustomCommands),
           new InputGestureCollection()
           {
                new KeyGesture(Key.L, ModifierKeys.Control)
           }
        );


        public static readonly RoutedUICommand ShowGridView = new RoutedUICommand
        (
           "ShowGridView",
           "ShowGridView",
           typeof(CustomCommands),
           new InputGestureCollection()
           {
                new KeyGesture(Key.D, ModifierKeys.Control)
           }
        );
    }
}
