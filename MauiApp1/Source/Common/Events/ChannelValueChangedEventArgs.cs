using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public struct ChannelValueChangedEventArgs
    {
        public readonly Channel channel;
        public readonly string oldValue;
        public readonly string newValue;

        public ChannelValueChangedEventArgs(
            Channel channel,
            string oldValue,
            string newValue
        )
        {
            this.channel = channel;
            this.oldValue = oldValue;
            this.newValue = newValue;

        }
    }
}
