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

namespace TaschenrechnerWPF
{
  /// <summary>
  /// Interaktionslogik für MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    //lokale Variablen
    private long zwischenwert = 0;
    private long resultat = 0;
    private char operation = '+';
    public MainWindow()
    {
      InitializeComponent();
    }
    private void SetAnzeige()
    {
      txtAnzeige.Text = zwischenwert.ToString();
    }

    private void cmd0_Click(object sender, RoutedEventArgs e)
    {
      zwischenwert = zwischenwert * 10;
      SetAnzeige();
    }
    private void cmd1_Click(object sender, RoutedEventArgs e)
    {
      zwischenwert = zwischenwert * 10 + 1;
      SetAnzeige();
    }

    private void cmd2_Click(object sender, RoutedEventArgs e)
    {
    zwischenwert = zwischenwert * 10 + 2;
    SetAnzeige();
    }
    private void cmd3_Click(object sender, RoutedEventArgs e)
    {
    zwischenwert = zwischenwert * 10 + 3;
    SetAnzeige();
    }
    private void cmd4_Click(object sender, RoutedEventArgs e)
    {
    zwischenwert = zwischenwert * 10 + 4;
    SetAnzeige();
    }
    private void cmd5_Click(object sender, RoutedEventArgs e)
    {
    zwischenwert = zwischenwert * 10 + 5;
    SetAnzeige();
    }
    private void cmd6_Click(object sender, RoutedEventArgs e)
    {
    zwischenwert = zwischenwert * 10 + 6;
    SetAnzeige();
    }
    private void cmd7_Click(object sender, RoutedEventArgs e)
    {
    zwischenwert = zwischenwert * 10 + 7;
    SetAnzeige();
    }
    private void cmd8_Click(object sender, RoutedEventArgs e)
    {
    zwischenwert = zwischenwert * 10 + 8;
    SetAnzeige();
    }
    private void cmd9_Click(object sender, RoutedEventArgs e)
    {
    zwischenwert = zwischenwert * 10 + 9;
    SetAnzeige();
    }
    private void cmdClr_Click(object sender, RoutedEventArgs e)
    {
    zwischenwert = 0;
    SetAnzeige();
    }
    private void cmdAdd_Click(object sender, RoutedEventArgs e)
    {
    resultat = zwischenwert;
    operation = '+';
    zwischenwert = 0;
    SetAnzeige();
    }
    private void cmdSub_Click(object sender, RoutedEventArgs e)
    {
    resultat = zwischenwert;
    operation = '‐';
    zwischenwert = 0;
    SetAnzeige();
    }
    private void cmdMul_Click(object sender, RoutedEventArgs e)
    {
    resultat = zwischenwert;
    operation = '*';
    zwischenwert = 0;
    SetAnzeige();
    }
    private void cmdDiv_Click(object sender, RoutedEventArgs e)
    {
    resultat = zwischenwert;
    operation = '/';
    zwischenwert = 0;
    SetAnzeige();
    }
    private void cmdRes_Click(object sender, RoutedEventArgs e)
    {
    switch (operation)
      {
      case '+':
        {
        resultat += zwischenwert;
        break;
      }
      case '‐':
        {
        resultat -= zwischenwert;
        break;
      }
      case '*':
        {
        resultat *= zwischenwert;
        break;
      }
      case '/':
      {
        if (zwischenwert == 0)
        {
          MessageBox.Show("Achtung: Division duch 0 ist nicht erlaubt!");
        }
        else
        {
          resultat /= zwischenwert;
        }
        break;
      }
    }
  zwischenwert = resultat;
  SetAnzeige();
  }

  }
  }
