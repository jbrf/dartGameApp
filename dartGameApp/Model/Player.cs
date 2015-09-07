using BusinessFlowModelEngine.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dartGameApp.Model
{
    class Player : BindableBase
    {
        private string _name;
        public string Name 
        {
            get
            {
                return _name;
            }
            set
            {
                ChangeProperty(ref _name, value);
            }
        }

    }
}
