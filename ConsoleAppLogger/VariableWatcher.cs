using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppLogger
{
    public class VariableWatcher<T>
    {
        private T _value;
        public T Value
        {
            get { return _value; }
            set
            {
                if (!value.Equals(_value))
                {
                    ValueChanged?.Invoke(this, new ValueChangedEventArgs<T>(_value, value));
                }
                _value = value;
            }
        }

            public event EventHandler<ValueChangedEventArgs<T>> ValueChanged;
    }

    public class ValueChangedEventArgs<T> : EventArgs
    {
        public T OldValue { get; }
        public T NewValue { get; }

        public ValueChangedEventArgs(T oldValue, T newValue)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
}
