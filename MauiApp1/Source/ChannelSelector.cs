using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Source
{
    public class ChannelSelector : IDisposable
    {
        private EventBus _eventBus;

        public Channel? Channel { get; private set; }

        public ChannelSelector(AppContext context)
        {
            _eventBus = context.EventBus;

            _eventBus.channelTapped.Subscribe(_OnChannelTapped);
        }

        public void Dispose()
        {
            _eventBus.channelTapped.Unsubscribe(_OnChannelTapped);
        }

        private void _OnChannelTapped(Channel channel)
        {
            if (Channel != null)
            {
                Channel unselected = Channel;
                Channel = null;
                _eventBus.channelUnselected.Invoke(unselected);
            }
            Channel = channel;
            _eventBus.channelSelected.Invoke(channel);
        }
    }
}
