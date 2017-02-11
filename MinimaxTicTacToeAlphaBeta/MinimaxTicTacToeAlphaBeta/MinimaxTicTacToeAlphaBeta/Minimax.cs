using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*************************************************************************************
 * 
 *			Class       : Minimax
 *			Date        : 25/07/2014 16:01:31
 *			Author      : Matthieu
 *			Comment		: Manage Minimax
 * 
*************************************************************************************/

namespace MinimaxTicTacToeAlphaBeta
{
    /// ---------------------------------------------------------------------
    /// <summary>
    /// This class defined a Minimax
    /// </summary>
    /// ---------------------------------------------------------------------

    class Minimax
    {
        #region Properties
        #endregion

        #region Public Fields
        #endregion

        #region Protected Fields
        #endregion

        #region Private Fields
        private const int _MAXVAL = 10000;
        

       
        #endregion

        #region Constructors

        #endregion

        #region Public Methods
        public Point GetBestPoint(TicTacToeGame game)
        {
             int alpha = int.MinValue;
             int beta = int.MaxValue;

            List<TicTacToeGame> gResult = new List<TicTacToeGame>(); // contacting the best moves
            int max = -_MAXVAL;
            foreach(TicTacToeGame cg in game.GetSuccessors(PlayerType.COMPUTER))
            {
                int sonValue = this.MiniVal(cg,  alpha,  beta);
                if(sonValue>max)
                {
                    gResult.Clear();
                    max = sonValue;
                    gResult.Add(cg);
                }
                if (max >= beta) break;
                alpha = Math.Max(alpha, sonValue);
                 
            }

            Random rnd = new Random();
            return gResult[rnd.Next(gResult.Count)].ComputerMove;

        }




        #endregion

        #region Private Methods

        private int MiniVal(TicTacToeGame game,  int alpha,  int beta)
        {
            if (game.EndState) return game.Value;

            int min = _MAXVAL;
            foreach(TicTacToeGame cg in game.GetSuccessors(PlayerType.HUMAN))
            {
                int sonValue = this.MaxVal(cg,  alpha,  beta);
                min = Math.Min(min, sonValue);
                if (sonValue <= alpha) return min;
                beta = Math.Min(beta, sonValue);
            }

            return min;
        }


        private int MaxVal(TicTacToeGame game,  int alpha,  int beta)
        {
            if (game.EndState) return game.Value;
            int max = -_MAXVAL;
            foreach (TicTacToeGame cg in game.GetSuccessors(PlayerType.COMPUTER))
            {
                int sonValue = this.MiniVal(cg,  alpha,  beta);
                max = Math.Max(max, sonValue);
                if (max >= beta) return max;
                alpha = Math.Max(alpha, sonValue);
            }
            return max;
        }

        #endregion
    }
}
