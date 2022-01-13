using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Memory
{
    internal class MemoryCard
    {
        MainWindow mainWindow = Application.Current.Windows[0] as MainWindow;

        private Button _card;
        public Button Card { get => _card; set => _card = value; }

        private int _id;
        public int Id { get => _id; set => _id = value; }

        public int Row { get; set; }
        public int Column { get; set; }

        public int ImageId { get; set; }

        private bool _IsUncovered = false;
        public bool Initialized { get; set; } = false;

        public MemoryCard(int id, int imageid, int row, int col)
        {
            Id = id;
            ImageId = imageid;
            Row = row;
            Column = col;
            Card = Init(imageid, row, col);
        }

        private Button Init(int imageid, int row, int col)
        {
            ImageBrush btnBack = new ImageBrush()
            {
                ImageSource = new BitmapImage(new Uri($"..\\..\\MemoryImages\\MemoryImage_{imageid}.png", UriKind.RelativeOrAbsolute))
            };
            ImageBrush btnFront = new ImageBrush()
            {
                ImageSource = new BitmapImage(new Uri(@"..\..\MemoryImages\BackSide.png", UriKind.RelativeOrAbsolute)),
            };
            Button btn = new Button()
            {
                Name = $"btn{Id}",
                Background = btnFront,
                Foreground = btnBack,
                Width = 100,
                Height = 100,
                Content = null,                
            };
            btn.AddHandler(Button.ClickEvent, new RoutedEventHandler(mainWindow.OnClick));
            Grid.SetColumn(btn, col);
            Grid.SetRow(btn, row);
            mainWindow.PlayingField.Children.Add(btn);
            return btn;
        }

        public void Flip()
        {
            Button btn = Card;
            ImageBrush temp = (ImageBrush)btn.Foreground;
            btn.Foreground = btn.Background;
            btn.Background = temp;
            _IsUncovered = !_IsUncovered;
        }

        public void Remove()
        {
            if (Card != null && _IsUncovered == true)
            {
                _card.Opacity = 0;
                _card.IsEnabled = false;
            }
        }
    }
}
