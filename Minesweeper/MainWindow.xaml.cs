using System;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Minesweeper
{
  public partial class MainWindow : Window
    {
    public WrapPanel FieldContainer_ { get; private set; }
    /// <summary>
    /// Constructor of the MainWindow class.
    /// Starts the game.
    /// </summary>
    public MainWindow()
    {
      InitializeComponent();
      Uri iconUri = new Uri("pack://application:,,,/Resources/Images/MinesweeperIcon.ico", UriKind.RelativeOrAbsolute);
      this.Icon = BitmapFrame.Create(iconUri);

      FieldContainer_ = FieldContainer;

      UI gameUi = new UI();
      Board board = new Board(8, 8, 10, gameUi);

    }

    /// <summary>
    /// This method gets called on every tick of the timer.
    /// Actually, the count of seconds since the first click on a button gets incremented and
    /// a method for updating the display of elapsed time gets called.
    /// Since this runs in a separat thread, we need the Dispatcher to invoke the UI update.
    /// Note: Threading is an advanced toping and therefore not part of this module!
    /// </summary>
    /// <param name="sender">The timer instance which triggered this method.</param>
    /// <param name="e">Event arguments.</param>
    private void TimerTick(object sender, ElapsedEventArgs e)
    {
        // TODO: Increment count of elapsed seconds...

        Dispatcher?.Invoke(UpdateTimerDisplay);
    }

    /// <summary>
    /// This method gets called by the timer tick event handler.
    /// Its primary purpose is to update the text label containing the count of elapsed seconds with a three-digit value.
    /// Values below 100 are padded (left) with zeroes.
    /// </summary>
    private void UpdateTimerDisplay()
    {
        // TODO: Implement this method...
    }

    /// <summary>
    /// Since the Window has style "None", this method restores the possibility to move the window on screen.
    /// It does not add actually add any relevant functionality for the game.
    /// </summary>
    /// <param name="sender">The window object on which the mouse-down event occured.</param>
    /// <param name="e">Mouse down event arguments.</param>
    public void Window_MouseDown(object sender, MouseButtonEventArgs e)
    {
        DragMove();
    }

  }
}
