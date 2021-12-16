using System.Windows.Controls;

namespace Minesweeper
{
  /// <summary>
  /// The MainWindow class contains the code to draw and update the user interface.
  /// The UI class should contain as little business logic as possible.
  /// </summary>
  /// 

  public class UI
  {
    public WrapPanel fieldContainer { get; set; }
    public UI()
    {

    }

    public void DrawField()
    {
      // Add field to screen box
      Button fieldBtn = new Button();
      fieldBtn.Width = 10;
      fieldBtn.Height = 10;
      fieldContainer.Children.Add(fieldBtn);
      // divide screenbox into squares according w / h) / (row / col count
      // add fields
    }
  }
}
