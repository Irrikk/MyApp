using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public class BoolChannel : Channel
    {
        public BoolChannel(
            AppContext context,
            Node parentNode,
            ValueChannelType type,
            string title = "bool",
            Size? size = null
        )
            : base(
                context: context,
                rootNode: parentNode,
                size: size,
                title: title,
                type: type,
                defaultValue: false,
                color: Colors.Green
            )
        {

        }
    }
}
