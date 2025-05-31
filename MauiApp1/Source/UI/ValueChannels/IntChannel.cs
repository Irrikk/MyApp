using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public class IntChannel : Channel
    {
        public IntChannel(
            AppContext context,
            Node parentNode,
            ValueChannelType type, 
            string title = "int", 
            Size? size = null
        )
            : base(
                context: context,
                rootNode: parentNode,
                size: size,
                title: title,
                type: type,
                defaultValue: 0,
                color: Colors.Blue
            )
        {

        }
    }
}
