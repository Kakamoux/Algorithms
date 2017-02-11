using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*************************************************************************************
 * 
 *			Class       : TicTacToeGame
 *			Date        : 25/07/2014 12:42:13
 *			Author      : Matthieu
 *			Comment		: Manage TicTacToeGame
 * 
*************************************************************************************/

namespace MinimaxTicTacToeAlphaBeta
{
    /// ---------------------------------------------------------------------
    /// <summary>
    /// This class defined a TicTacToeGame in a precise state
    /// </summary>
    /// ---------------------------------------------------------------------
    class TicTacToeGame
    {
        #region Properties
        public int Value { get { return _value; } }
        public Player[,] PlayersPos { get { return _playerPos; } set { _playerPos = value; } }
        public Point ComputerMove { get { return _computerMove; } set { _computerMove = value; } }
        public Point[] WinnerLocation { get { return _winnerLocation; } set { _winnerLocation = value; } }

        public bool EndState
        {
            get
            {
                PlayerType winner = PlayerType.NONE;
                if (IsGameFinished(out winner))
                {
                    if (winner != PlayerType.NONE)
                    {
                        this._value = ( winner == PlayerType.COMPUTER) ? 100 : -100;
                    }
                    else this._value = 0;
                    return true;
                }
                this._value = 0;
                return false;
            }
        }


        #endregion

        #region Public Fields
        #endregion

        #region Protected Fields
        #endregion

        #region Private Fields

        private int _value = 0;
        private Player[,] _playerPos = new Player[3, 3];
        private Point _computerMove = Point.Empty;
        private Point[] _winnerLocation = null;


        private static int[,] _winnings = {
                                           {0,0,0,1,0,2},
                                           {1,0,1,1,1,2},
                                           {2,0,2,1,2,2},
                                           {0,0,1,0,2,0},
                                           {0,1,1,1,2,1},
                                           {0,2,1,2,2,2},
                                           {0,0,1,1,2,2},
                                           {2,0,1,1,0,2}
                                       };


        #endregion

        #region Constructors
        public TicTacToeGame()
        {
            for (int i = 0; i < _playerPos.GetLength(0); i++)
            {
                for (int j = 0; j < _playerPos.GetLength(1); j++)
                {
                    _playerPos[i, j] = new Player(PlayerType.NONE, Shape.CIRCLE);
                }
            }


        }

        public TicTacToeGame(Player[,] players)
        {
            this._playerPos = players;
        }

        #endregion

        #region Public Methods

        public bool CanPlay(Point pt)
        {
            return this.PlayersPos[pt.X, pt.Y].PlayerType == PlayerType.NONE;
        }
        public bool CanPlay()
        {
            for (int i = 0; i < this.PlayersPos.GetLength(0); i++)
            {
                for (int j = 0; j < this.PlayersPos.GetLength(1); j++)
                {
                    if (this.PlayersPos[i, j].PlayerType == PlayerType.NONE) return true;
                }
            }
            return false;
        }



        public void Play(Player player, Point pt)
        {
            this.PlayersPos[pt.X, pt.Y] = player;
        }

        public List<TicTacToeGame> GetSuccessors(PlayerType player)
        {
            List<TicTacToeGame> rslt = new List<TicTacToeGame>();
            Player[,] players;
            for (int i = 0; i < _playerPos.GetLength(0); i++)
            {
                for (int j = 0; j < _playerPos.GetLength(1); j++)
                {
                    if (this._playerPos[i, j].PlayerType == PlayerType.NONE)
                    {
                       players = new Player[3,3];

                        for (int g = 0; g < _playerPos.GetLength(0); g++)
                        {
                            for (int h = 0; h < _playerPos.GetLength(1); h++)
                            {
                                players[g, h] = new Player(_playerPos[g, h].PlayerType, _playerPos[g, h].Shape);
                            }
                        }


                        players[i, j].PlayerType = player;
                        TicTacToeGame t = new TicTacToeGame(players);
                        t.ComputerMove = new Point(i, j);
                        rslt.Add(t);

                    }
                }
            }
            return rslt;

          /*  List<TicTacToeGame> gameCol = new List<TicTacToeGame>();
            for (int i = 0; i < this._playerPos.GetLength(0); i++)
            {
                for (int j = 0; j < this._playerPos.GetLength(1); j++)
                {
                    if (this._playerPos[i, j].PlayerType == PlayerType.NONE)
                    {
                        Player[,] players = this._playerPos.Clone() as Player[,];
                        players[i, j].PlayerType = player;
                        TicTacToeGame game = new TicTacToeGame(players);
                        game.ComputerMove = new Point(i, j);
                        gameCol.Add(game);
                    }
                }
            }
            return gameCol;*/
        }

        #endregion

        #region Private Methods

        private bool IsGameFinished(out PlayerType winner)
        {
            winner = PlayerType.NONE;
            bool isFull = true;


            for (int i = 0; i < _winnings.GetLength(0); i++)
            {
                PlayerType player = PlayerType.NONE;
                bool isWinner = true;
                for (int j = 0; j < _winnings.GetLength(1); j += 2)
                {
                    PlayerType p = PlayersPos[_winnings[i, j], _winnings[i, j + 1]].PlayerType;
                    if (p == PlayerType.NONE)
                    {
                        isFull = false;
                    }

                    if (j == 0)
                    {
                        player = p;
                    }
                    else if (p != player)
                    {
                        isWinner = false;
                        break;
                    }
                }

                if (isWinner && player != PlayerType.NONE)
                {
                    winner = player;
                    break;
                }

            }

            return (winner != PlayerType.NONE || isFull);
        }
        #endregion
    }
}
