using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MauiApp1
{
    public class NodeLinker : IDisposable
    {
        private EventBus _eventBus;
        private Channel? _input;
        private Channel? _output;

        public NodeLinker(AppContext context)
        {
            _eventBus = context.EventBus;
            _eventBus.channelTapped.Subscribe(_OnNodeChannelTapped);
            _eventBus.channelValueChanged.Subscribe(_OnChannelValueChanged);
        }

        public void Dispose()
        {
            _eventBus.channelTapped.Subscribe(_OnNodeChannelTapped);
            _eventBus.channelValueChanged.Subscribe(_OnChannelValueChanged);
        }

        public void Link(Channel output, Channel input, bool invokeEvent = true)
        {
            output.RootNode.ChildNode = input.RootNode;
            input.RootNode.ParentNodes.Add(output.RootNode);
            output.LinkedChild = input;
            input.LinkedParent = input;
            output.IsHighlighted = true;
            input.IsHighlighted = true;
            if (invokeEvent) _eventBus.nodesLinked.Invoke(new(output, input));
            Debug.WriteLine($"{output.Title} linked to {input.Title}");
        }

        public void Unlink(Channel output, Channel input, bool invokeEvent = true)
        {
            output.RootNode.ChildNode = null;
            input.RootNode.ParentNodes.Remove(output.RootNode);
            output.LinkedChild = null;
            input.LinkedParent = null;
            output.IsHighlighted = false;
            input.IsHighlighted = false;
            if (invokeEvent) _eventBus.nodesLinked.Invoke(new(output, input));
            Debug.WriteLine($"link {output.Title} - {input.Title} removed");
        }

        private void _OnNodeChannelTapped(Channel channel)
        {
            if (channel.Type == ValueChannelType.Output)
            {
                _output = channel;
            }
            else if (channel.Type == ValueChannelType.Input)
            {
                if (channel != _input)
                {
                    _input = channel;
                }
                else if (_input.LinkedParent != null)
                {
                    Unlink(_input.LinkedParent, _input);
                    _input = null;
                    _output = null;
                }
            }

            if (_input != null && _output != null)
            {
                Link(_output, _input);
                _input = null;
                _output = null;
            }
        }

        private void _OnChannelValueChanged(ChannelValueChangedEventArgs args)
        {
            if (args.channel.LinkedChild == null) return;
            args.channel.LinkedChild.Value = args.channel.Value;
        }
    }
}
