using System;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

// TODO:
// * mineCoutn not working
// * implement rightclick functin
// * 

namespace Minesweeper
{
  public partial class MainWindow : Window
    {

    private Board board { get; set; }
    public readonly int _fieldWidth;

    /// <summary>
    /// Constructor of the MainWindow class.
    /// Starts the game.
    /// </summary>
    public MainWindow()
    {
      InitializeComponent();
      Uri iconUri = new Uri("pack://application:,,,/Resources/Images/MinesweeperIcon.ico", UriKind.RelativeOrAbsolute);
      this.Icon = BitmapFrame.Create(iconUri);

      board = new Board(8, 8, 10);
      _fieldWidth = 250 / board._colCount;
      DrawFields();
    }

    private void DrawFields()
    {

      for (int i = 0; i < board._colCount; i++)
      {
        for (int j = 0; j < board._rowCount; j++)
        {
          // Fields[x, y]
          DrawField(board.Fields[i, j]);
        }
      }
    }

    private void DrawField(Field field)
    {
      // Add field to screen box
      Button fieldBtn = new Button();

      ImageBrush brush = new ImageBrush();
      Image button_content = new Image();
      button_content.Source = new BitmapImage(new Uri($"pack://application:,,,/Resources/Images/button.png", UriKind.RelativeOrAbsolute));

      String image_name = field.SurroundingMineCount.ToString();
      if (field.IsMine)
      {
        image_name = "mine-2";
      }
      brush.ImageSource = new BitmapImage(new Uri($"pack://application:,,,/Resources/Images/{image_name}.png", UriKind.RelativeOrAbsolute));

      fieldBtn.Width = _fieldWidth;
      fieldBtn.Height = _fieldWidth;
      fieldBtn.Content = button_content;
      fieldBtn.Tag = field;
      fieldBtn.Background = brush;
      fieldBtn.AddHandler(Button.ClickEvent, new RoutedEventHandler(OnClick));
      FieldContainer.Children.Add(fieldBtn);
    }

    private void OnClick(object sender, RoutedEventArgs e)
    {
      Button btn = (Button)sender;
      btn.Content = null;
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
