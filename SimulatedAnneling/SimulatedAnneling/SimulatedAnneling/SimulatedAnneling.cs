using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*************************************************************************************
 * 
 *			Class       : SimulatedAnneling
 *			Date        : 29/07/2014 12:16:09
 *			Author      : Matthieu
 *			Comment		: Manage SimulatedAnneling
 * 
*************************************************************************************/

namespace SimulatedAnneling
{
    /// ---------------------------------------------------------------------
    /// <summary>
    /// This class defined a SimulatedAnneling
    /// </summary>
    /// ---------------------------------------------------------------------

    class SimulatedAnnelingAndTaboo
    {
        #region Properties
    

	    public double Epsilon
	    {
		    get { return _epsilon;}
		    set { _epsilon = value;}
	    }



	public double Alpha
	{
		get { return _alpha;}
		set { _alpha = value;}
	}
	
	
        #endregion

        #region Public Fields
        #endregion

        #region Protected Fields
        #endregion

        #region Private Fields
            private double _alpha=0.999;
            private double _epsilon = 0.001;
            Random _rnd = new Random();
        #endregion

        #region Constructors
        #endregion

        #region Public Methods
        /// <summary>
        /// Execute hill climbing from the selected node
        /// </summary>
        /// <param name="startNode">Search from this node</param>
        /// <param name="maximise">true : search the most valuable node otherwhise , search the worst valuable node</param>
        /// <returns></returns>
        public Node Start(Node startNode, double startTemperature, double epsilon, double alpha, bool minima)
        {
            double temperature = startTemperature;
            Node curent = startNode;
            Node next;
            double delta;
            while (temperature>epsilon)
            {
                next = GetRandomSuccessor(curent);
                delta = minima ? Evaluate(next) - Evaluate(curent) : Evaluate(curent) - Evaluate(next);
                if(CritMetropolis(delta,temperature))
                {
                    curent = next;
                }

                temperature *= alpha;
            }
            return curent;
        }

        

        public Node Start(Node startNode, double startTemperature)
        {


            return Start(startNode, startTemperature, _epsilon, _alpha,true);
        }

        public Node Start(Node startNode, double startTemperature,bool minima)
        {


            return Start(startNode, startTemperature, _epsilon, _alpha, minima);
        }


        private bool CritMetropolis(double delta, double temperature)
        {
            if (delta < 0) return true;

            double dbl = _rnd.NextDouble();
            double proba = Math.Exp(-delta / temperature);
            Console.WriteLine(dbl + " " + proba);
            if (dbl < proba) return true;
            return false;
        }

        private List<Node> GetSuccesor(Node node)
        {
            // return the list of node successor
            return node.Childs;
        }

        private Node GetRandomSuccessor(Node node)
        {
            Random rnd = new Random();
            List<Node> childs = GetSuccesor(node);

            return childs[rnd.Next(childs.Count)];
        }

        private Node GetRandomSuccessorTaboo(Node node, List<Node> taboo)
        {
            Random rnd = new Random();
            List<Node> childs = GetSuccesor(node).Where(c => !taboo.Any(p => p == c)).ToList();
            if (childs.Count < 1) return node;

            return childs[rnd.Next(childs.Count)];
        }



        /// <summary>
        /// Evaluate the utility of the given node
        /// </summary>
        /// <param name="n"></param>
        /// <returns>the utility</returns>

        private int Evaluate(Node n)
        {
            return n.Value;
        }

        #endregion
    }
}
