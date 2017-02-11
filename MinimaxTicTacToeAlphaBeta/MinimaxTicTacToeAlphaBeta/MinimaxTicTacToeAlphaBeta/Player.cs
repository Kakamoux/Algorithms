using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*************************************************************************************
 * 
 *			Class       : Player
 *			Date        : 25/07/2014 13:30:50
 *			Author      : Matthieu
 *			Comment		: Manage Player
 * 
*************************************************************************************/

namespace MinimaxTicTacToeAlphaBeta
{
    /// ---------------------------------------------------------------------
    /// <summary>
    /// This class defined a Player
    /// </summary>
    /// ---------------------------------------------------------------------

    class Player
    {
        #region Properties
        public string Name { get; set; }
        public PlayerType PlayerType { get; set; }

        public Shape Shape { get;  set; }

        #endregion

        #region Public Fields
        #endregion

        #region Protected Fields
        #endregion

        #region Private Fields
        
        #endregion

        #region Constructors
        public Player(PlayerType playerType, Shape shape)
        {
            this.PlayerType = playerType;
            this.Shape = shape;
        }

        
        #endregion

        #region Public Methods

        #region statics

        #region operators
        public static Player operator !(Player p)
        {
            Shape s = Shape.CIRCLE;
            PlayerType plt = PlayerType.NONE;
            switch(p.Shape)
            {
                case Shape.CIRCLE:
                    s = Shape.CROSS;
                    break;
                case Shape.CROSS:
                    s = Shape.CIRCLE;
                    break;

            }
            switch(p.PlayerType)
            {
                case PlayerType.HUMAN:
                    plt = PlayerType.COMPUTER;
                    break;
                case PlayerType.COMPUTER:
                    plt = PlayerType.HUMAN;
                    break;

            }
            return new Player(plt, s);
        }

        #endregion

        #region builders

        public static Player None
        {
            get
            {
                return new Player(PlayerType.NONE, Shape.CIRCLE);
            }
        }

        public static Player Human
        {
            get
            {
                return new Player(PlayerType.HUMAN, Shape.CIRCLE);
            }
        }

        public static Player Computer
        {
            get
            {
                return new Player(PlayerType.COMPUTER, Shape.CROSS);
            }
        }

        #endregion

        #endregion

        #endregion

        #region Private Methods
        #endregion
    }
}
