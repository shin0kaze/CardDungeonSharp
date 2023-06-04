using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDungeon.Utils
{
    internal class ChangeFlag<T>
    {
        public bool Changed { get; set; }
        private T _value;
        public T Value
        {
            get { return _value; }
            set
            {
                bool equals = EqualityComparer<T>.Default.Equals(_value, value);
                if (equals) return;
                Changed = true;
                _value = value;
            }
        }

        public ChangeFlag(T value)
        {
            _value = value;
        }
    }
    internal class ChangeFlag<I,O>
    {
        public delegate O Convert(I inValue);
        public Convert convert;
        private I input;
        private O output;
        public ChangeFlag(Convert convert, I input, O output)
        {
            this.convert = convert;
            this.input = input;
            this.output = output;
        }
        public dynamic Value
        {
            get { return output!; }
            set
            {
                bool equals = EqualityComparer<I>.Default.Equals(input, value);
                if (equals) return;
                input = value;
                output = convert(input);
            }
        }
    }
}
