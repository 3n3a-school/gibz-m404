using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hangman
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private static readonly char[] wordArray = { 'a', 'm', 'a', 'g' };

    private bool IsPartOfWord(char inputChar, char[] wordArray)
    {
      return wordArray.Contains(inputChar);
    }

    private char GetInputChar()
    {
      char selectedChar = Convert.ToChar((int)Letter_Slider.Value);
      return selectedChar;
    }

    private void Guess_Btn_Click(object sender, RoutedEventArgs e)
    {
      char guessedChar = GetInputChar();

      switch (IsPartOfWord(guessedChar, wordArray))
      {
        case true:
          MessageBox.Show("Korrekt, der Buchstabe " + guessedChar + " ist im Wort enthalten.");
          break;
        case false:
          MessageBox.Show(guessedChar + " ist nicht Teil des Wortes.");
          break;
      }
    }

    private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
      char inputChar = GetInputChar();
      Selected_Char.Text = inputChar.ToString();
    }
  }
}
