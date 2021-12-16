using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace Minesweeper
{
    /// <summary>
    /// This class enables the right-click functionality for fields on the playing grid.
    /// Its contents are NOT relevant parts of module 404 subjects. Students are therefore not required to fully understand it
    /// Of course, your very welcome to track it down and get a head start for module 120 :-)
    /// 
    /// The class ButtonRightClickCommand implements the ICommand interface (designated by the colon).
    /// </summary>
    public class ButtonRightClickCommand : ICommand
    {
        private readonly Action<Button> _action;

        public event EventHandler CanExecuteChanged;

        public ButtonRightClickCommand(Action<Button> action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            _action((Button)parameter);
        }

        public static void AddRightClick(Button button, Action<Button> handler)
        {
            MouseGesture mouseGesture = new MouseGesture { MouseAction = MouseAction.RightClick };
            MouseBinding mouseBinding = new MouseBinding
            {
                Gesture = mouseGesture,
                Command = new ButtonRightClickCommand(handler),
                CommandParameter = button,
            };
            button.InputBindings.Add(mouseBinding);
        }

    }
}
