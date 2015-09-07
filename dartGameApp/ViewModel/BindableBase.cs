using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace BusinessFlowModelEngine.ViewModel
{
    public abstract class BindableBase : INotifyPropertyChanged
    {

        protected BindableBase()
        {
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

	    protected bool ChangeProperty<T>(ref T obj, T value, [CallerMemberName] String propertyName = null)
	    {
		    if (Equals(obj, value)) return false;
            obj = value;
			OnPropertyChanged(propertyName);
		    return true;
	    }
    }
}
