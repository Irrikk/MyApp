using System;
using System.Collections.Generic;
using System.Numerics;

namespace MauiApp1
{
    public class EventBus
    {
        public readonly Event<Node> nodeTapped;
        public readonly Event<Channel> channelTapped;

        public readonly Event<Node> nodeSelected;
        public readonly Event<Node> nodeUnselected;
        public readonly Event<NodePositionChangedArgs> nodePositionChanged;

        public readonly Event<Channel> channelSelected;
        public readonly Event<Channel> channelUnselected;
        public readonly Event<ChannelValueChangedEventArgs> channelValueChanged;

        public readonly Event<NodesLinkedEventArgs> nodesLinked;
        public readonly Event<NodesUnlinkedEventArgs> nodesUnlinked;


        public EventBus()
        {
            nodeTapped = new();
            channelTapped = new();

            nodeSelected = new();
            nodeUnselected = new();
            nodePositionChanged = new();

            channelSelected = new();
            channelUnselected = new();
            channelValueChanged = new();

            nodesLinked = new();
            nodesUnlinked = new();

        }
    }
}
