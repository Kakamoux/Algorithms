using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*************************************************************************************
 * 
 *			Class       : Node
 *			Date        : 29/07/2014 11:50:35
 *			Author      : Matthieu
 *			Comment		: Manage Node
 * 
*************************************************************************************/

namespace SimulatedAnneling
{
    /// ---------------------------------------------------------------------
    /// <summary>
    /// This class defined a Node
    /// </summary>
    /// ---------------------------------------------------------------------

    class Node
    {
        #region Properties
        

        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }
       

        public List<Node> Childs
        {
            get { return _childs; }
            set { _childs = value; }
        }
        
        
        #endregion

        #region Public Fields
        #endregion

        #region Protected Fields
        #endregion

        #region Private Fields
        private int _value =0;
        private List<Node> _childs = new List<Node>();
        #endregion

        #region Constructors
        #endregion

        #region Public Methods
        #endregion

        #region Private Methods
        #endregion
    }
}
