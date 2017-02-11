using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*************************************************************************************
 * 
 *			Class       : AStar
 *			Date        : 28/07/2014 12:53:23
 *			Author      : Matthieu
 *			Comment		: Manage AStar
 * 
*************************************************************************************/

namespace AStarPathfinding
{
    /// ---------------------------------------------------------------------
    /// <summary>
    /// This class defined a AStar
    /// </summary>
    /// ---------------------------------------------------------------------

    class AStar
    {
        #region Properties
        #endregion

        #region Public Fields
        #endregion

        #region Protected Fields
        #endregion

        #region Private Fields
        char[,] _env;
        Node _end;
        #endregion

        #region Constructors

        #endregion

        #region Public Methods
       

        public List<Node> Start(Node start, Node end,char[,] environement)
        {
            _env = environement;
            _end = end;

            List<Node> open = new List<Node>();
            List<Node> closed = new List<Node>();
            Node current = null;
            open.Add(start);
            while(true)
            {
                
                if (open.Count < 1)
                {
                    return new List<Node>();
                }
                current = open[0];
                open.RemoveAt(0);
                closed.Add(current);
            
                if (Goal(current)) {
                    return BuildPath(start, current);
                }
                foreach(Node child in Sucessors(current))
                {
                    child.G = current.G + child.Cost;
                    child.Parent = current;
                    
                    if(closed.Contains(child) )
                    {
                       
                       Node fnd = closed.Find(x=>x.Equals(child));
                       
                       if(Evaluation(child)<= Evaluation(fnd))
                       {
                           closed.Remove(fnd);
                           open.Add(child);
                           open.Sort(delegate(Node first, Node second){ int h1 = Evaluation(first); int h2 = Evaluation(second); if(h1==h2)return 0; else if(h1<h2)return -1;else return 1;  });
                       }
                    }
                    else if (open.Contains(child))
                    {
                        
                        Node fnd = open.Find(x => x.Equals(child));

                        if (Evaluation(child) <= Evaluation(fnd))
                        {
                            open.Remove(fnd);
                            open.Add(child);
                          
                        }
                    }else
                    {
                    
                           open.Add(child);

                    }
                    open.Sort(delegate(Node first, Node second) { int h1 = Evaluation(first); int h2 = Evaluation(second); if (h1 == h2)return 0; else if (h1 < h2)return -1; else return 1; });

                }


            }
                
        }

        #endregion

        #region Private Methods
        private List<Node> BuildPath(Node start , Node end)
        {
            List<Node> rslt = new List<Node>();
            rslt.Add(end);
            Node current = end;
            while (current.Parent != start)
            {
                rslt.Add(current.Parent);
                current = current.Parent;
            }
            rslt.Add(start);
            rslt.Reverse();
           
            return rslt;
        }
        private bool Goal(Node n)
        {
            return n == _end;
        }

        private List<Node> Sucessors(Node n)
        {
            List<Node> rslt = new List<Node>();
            if (n.Y - 1 >= 0 && _env[n.Y - 1, n.X] != 'x')
                rslt.Add(new Node( n.X,n.Y - 1));
            if (n.X - 1 >= 0 && _env[n.Y, n.X-1] != 'x')
                rslt.Add(new Node(n.X - 1, n.Y));
            if(n.Y+1 < _env.GetLength(0) && _env[n.Y+1, n.X] != 'x')
                rslt.Add(new Node(n.X,n.Y + 1));
            if (n.X + 1 < _env.GetLength(1) && _env[n.Y, n.X+1] != 'x')
                rslt.Add(new Node(n.X+1,n.Y));
            
            return rslt;

        }

        private int Evaluation(Node n)
        {
            return n.G + Heuristic(n, _end);
        }

        private int Heuristic(Node from, Node to)
        {
            return from.DistanceTo(to); 
        }

        #endregion
    }
}
