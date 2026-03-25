using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_PD21
{
    internal class MessagePublisher
    {
        public event Action<string>? MessageSent;

        public void Send(string message)
        {
            MessageSent?.Invoke(message);
        }
    }
}
