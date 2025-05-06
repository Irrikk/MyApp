using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public class IntChannel : ValueChannel<int>
    {
        public IntChannel(Size size, ValueChannelType type, string title = "int") : base(
            size: size, 
            title: title,
            type: type,
            passColor: Colors.Blue
        )
        {

        }
    }
}
