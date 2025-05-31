using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public class DoubleChannel : Channel
    {
        public DoubleChannel(
            AppContext context,
            Node parentNode,
            ValueChannelType type,
            string title = "double",
            Size? size = null
        )
            : base(
                  context: context,
                rootNode: parentNode,
                size: size,
                title: title,
                type: type,
                defaultValue: 0.0f,
                color: Colors.Yellow
            )
        {

        }
    }
}
