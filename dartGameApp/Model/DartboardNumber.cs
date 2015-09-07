using BusinessFlowModelEngine.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dartGameApp.Model
{
    class DartboardNumber : BindableBase
    {
        /// <summary>
        /// Draws the gamesignum of "/", "X" or "O" to indicate if it has one, two or three hits
        /// "O" stands for closed number
        /// </summary>
        private string _dashCrossOrRing;
        public string DashCrossOrRing 
        { 
            get { return _dashCrossOrRing; }
            set { ChangeProperty(ref _dashCrossOrRing, value); } 
        }

        /// <summary>
        /// False if the number isn't closed, true if it is
        /// </summary>
        private bool _numberClosed;
        public bool NumberClosed
        {
            get { return _numberClosed; }
            set { ChangeProperty(ref _numberClosed, value); }
        }

        /// <summary>
        /// Indicates the value of the number hit
        /// </summary>
        private int _numberValue;
        public int NumberValue
        {
            get { return _numberValue; }
            set { ChangeProperty(ref _numberValue, value); }
        }
        /// <summary>
        /// Player 1 or Player 2
        /// </summary>
        private string _playerId;
        public string PlayerId
        {
            get { return _playerId; }
            set { ChangeProperty(ref _playerId, value); }
        }
    }
}
