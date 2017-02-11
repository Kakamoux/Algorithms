using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*************************************************************************************
 * 
 *			Class       : Node
 *			Date        : 28/07/2014 12:30:59
 *			Author      : Matthieu
 *			Comment		: Manage Node
 * 
*************************************************************************************/

namespace AStarPathfinding
{
    /// ---------------------------------------------------------------------
    /// <summary>
    /// This class defined a Node
    /// </summary>
    /// ---------------------------------------------------------------------

    class Node
    {
        #region Properties


        public int Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }



        public bool Blocked
        {
            get { return _blocked; }
            set { _blocked = value; }
        }



        public bool End
        {
            get { return _end; }
            set { _end = value; }
        }




        public Node Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        public int G
        {
            get { return _g; }
            set { _g = value; }
        }


        public int X { get; set; }
        public int Y { get; set; }
        #endregion

        #region Public Fields
        #endregion

        #region Protected Fields
        #endregion

        #region Private Fields
        private int _cost = 1;
        private int _g = 0;
        private Node _parent;
        private bool _blocked = false;
        private bool _end = false;
        #endregion

        #region Constructors
        public Node(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Node(int x, int y, int cost)
            : this(x, y)
        {
            this.Cost = cost;
        }

        public Node(int x, int y, int cost, bool blocked)
            : this(x, y, cost)
        {
            this._blocked = blocked;
        }

        public Node(int x, int y, bool blocked)
            : this(x, y)
        {
            this._blocked = blocked;
        }
        #endregion

        #region Public Methods
        public int DistanceTo(Node to)
        {
            //euclidean distance
            return Convert.ToInt32(Math.Sqrt(Math.Pow(X - to.X, 2) + Math.Pow(Y - to.Y, 2)));

        }

        public static bool operator ==(Node from, Node to)
        {
            return to.X == from.X ? (to.Y == from.Y ? true : false) : false;
        }

        public static bool operator !=(Node from, Node to)
        {
            
            return to.X == from.X ? (to.Y == from.Y ? false : true) : true;
        }

        public override bool Equals(object obj)
        {
            return ((Node)obj).X == X ? (((Node)obj).Y == Y ? true : false) : false;
        }

        #endregion

        #region Private Methods
        #endregion
    }
}
