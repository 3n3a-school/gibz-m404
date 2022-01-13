using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Memory
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Player[] players;
        private MemoryCard[] memoryCards;

        private int currentPlayer { get; set; }
        private bool gameStarted { get; set; } = false;
        private List<MemoryCard> UncoveredCards { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            players = new Player[2];
            memoryCards = new MemoryCard[36];
            UncoveredCards = new List<MemoryCard>();
            players[0] = new Player();
            players[1] = new Player();
        }


        private void StartGameBtn_Click(object sender, RoutedEventArgs e)
        {
            String p1 = Player1Name.Text;
            String p2 = Player2Name.Text;

            if ((p1 != "" && p2 != "") && (p1.Length < 20 && p2.Length < 20))
            {
                StartGame(p1, p2);
            }
            else
            {
                MessageBox.Show("Please make sure you entered both PlayerNames, which should be shorter than 20 characters.");
            }
        }

        private void StartGame(string p1, string p2)
        {
            players[0].Name = p1;
            players[1].Name = p2;
            Player1Name.IsEnabled = false;
            Player2Name.IsEnabled = false;
            StartGameBtn.IsEnabled = false;

            SelectStartingPlayer();
            MessageBox.Show($"Player {currentPlayer} ({players[currentPlayer].Name}) starts the Game.");

            BootstrapPlayingField();
            gameStarted = true;
        }


        private void SelectStartingPlayer()
        {
            Random random = new Random();
            int startingPlayer = random.Next(1, 2);
            currentPlayer = startingPlayer;
        }

        private void BootstrapPlayingField()
        {
            int[] takenImages = new int[18];
            Random random = new Random();
            
            int addedCards = 0;
            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 6; col++)
                {
                    int randomImage = random.Next(0, 36);
                    int imageId = addedCards + 1;
                    if (addedCards + 1 > 18)
                    {
                        imageId -= 18;
                    }
                    memoryCards[addedCards] = new MemoryCard(addedCards, imageId, row, col);
                    addedCards++;
                }
            }
        }
        public void OnClick(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int btnInt = int.Parse(btn.Name.Replace("btn", ""));
            memoryCards[btnInt].Flip();
            UncoveredCards.Add(memoryCards[btnInt]);

            if (UncoveredCards.Count == 2 && UncoveredCards[0] != null && UncoveredCards[1] != null)
            {
                if (UncoveredCards[0].ImageId == UncoveredCards[1].ImageId)
                {
                    MessageBox.Show("You have found a pair");
                    
                    foreach (MemoryCard card in UncoveredCards)
                    {
                        card.Remove();

                    }

                    players[currentPlayer].AddPoint();
                    SwapPlayers();
                }
                else
                {
                    foreach (MemoryCard card in UncoveredCards)
                    {
                        card.Flip();
                    }
                    SwapPlayers();
                }

                UncoveredCards = new List<MemoryCard>();
            } 

        }


        private void SwapPlayers()
        {
            if (currentPlayer == 0)
            {
                currentPlayer = 1;
            }
            else
            {
                currentPlayer = 0;
            }
            MessageBox.Show($"Player {currentPlayer}'s Turn");
        }

    }
}
