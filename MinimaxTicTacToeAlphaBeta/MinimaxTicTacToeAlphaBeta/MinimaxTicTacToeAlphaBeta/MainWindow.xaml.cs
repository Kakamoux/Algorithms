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


namespace MinimaxTicTacToeAlphaBeta
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        TicTacToeGame game;
        Minimax minimax;
        public Dictionary<System.Drawing.Point, Button> btns = new Dictionary<System.Drawing.Point, Button>();
        private Player _humanPlayer = Player.Human;
        private Player _computerPlayer = Player.Computer;
        public MainWindow()
        {
            InitializeComponent();

            game = new TicTacToeGame();
            minimax = new Minimax();

            #region dirty
            for (int i = 0; i < 3; i++)
			{
			  for (int j = 0; j < 3; j++)
			    {
			        Button btn = new Button();
                    btn.Click += BtnClick;
                    btn.Width = 50;
                    btn.Height = 50;
                    btn.Margin = new Thickness(i * 50, j * 50, this.Width - (50 * i + 1), this.Height - (50 * j + 1));
                    btn.Tag = new System.Drawing.Point(i, j);
                    this.Grid.Children.Add(btn);
                    btns.Add((System.Drawing.Point) btn.Tag, btn);
			    }
			}
            
            #endregion
        }

        private void BtnClick(object sender, RoutedEventArgs e)
        {
            System.Drawing.Point pt = (System.Drawing.Point)((Button)sender).Tag;
             if(!game.CanPlay(pt)) return;
            ((Button)sender).IsEnabled = false;
            ((Button)sender).Content = "O";
            game.Play(_humanPlayer, pt);
           

            System.Drawing.Point ia = minimax.GetBestPoint(game);
            btns[ia].Content = "X";
            btns[ia].IsEnabled = false;
            game.Play(_computerPlayer, ia);
         
           


        }
    }
}
