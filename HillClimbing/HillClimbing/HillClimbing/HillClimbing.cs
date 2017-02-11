using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*************************************************************************************
 * 
 *			Class       : HillClimbing
 *			Date        : 29/07/2014 12:16:09
 *			Author      : Matthieu
 *			Comment		: Manage HillClimbing
 * 
*************************************************************************************/

namespace HillClimbing
{
    /// ---------------------------------------------------------------------
    /// <summary>
    /// This class defined a HillClimbing
    /// </summary>
    /// ---------------------------------------------------------------------

    class HillClimbing
    {
        #region Properties
        #endregion

        #region Public Fields
        #endregion

        #region Protected Fields
        #endregion

        #region Private Fields
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
        public Node Start(Node startNode, bool maximise)
        {
            Node valuableChild;
            while(true)
            {
                valuableChild = maximise ? GetBestSuccessor(startNode) : GetWorstSuccessor(startNode);
                Node rslt = maximise ? Maximise(startNode, valuableChild) : Minimise(startNode, valuableChild);
                if (rslt == null)
                    return startNode;
                startNode = valuableChild;

            }
        }
        #endregion

        #region Private Methods


        private Node Maximise(Node start, Node valuable)
        {
            if (Evaluate(valuable) <= Evaluate(start))
                return null;
            return valuable;
        }

        private Node Minimise(Node start, Node valuable)
        {
            if (Evaluate(valuable) >= Evaluate(start))
                return null;
            return valuable;
        }

        private List<Node> GetSuccesor(Node node)
        {
            // return the list of node successor
            return node.Childs;
        }

        /// <summary>
        /// Return the most valuable successor
        /// </summary>
        /// <param name="node"></param>
        /// <returns>most valuable child node</returns>
        private Node GetBestSuccessor(Node node)
        {
            int value = int.MinValue;
            Node selectedNode = node;
            foreach(Node n in GetSuccesor(node))
            {
                if(Evaluate(n) > value)
                {
                    selectedNode = n;
                    value = Evaluate(n);
                }
            }
            return selectedNode;
        }
        /// <summary>
        /// Return the worst valuable successor
        /// </summary>
        /// <param name="node"></param>
        /// <returns>worst valuable child node</returns>
        private Node GetWorstSuccessor(Node node)
        {
            int value = int.MaxValue;
            Node selectedNode = node;
            foreach (Node n in GetSuccesor(node))
            {
                if (Evaluate(n) < value)
                {
                    selectedNode = n;
                    value = Evaluate(n);
                }
            }
            return selectedNode;
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
