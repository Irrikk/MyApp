using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public class BoolChannel : ValueChannel<float>
    {
        public BoolChannel(Size size, ValueChannelType type, string title = "bool") : base(
            size: size, 
            title: title,
            type: type,
            passColor: Colors.Green
        )
        {

        }
    }
}
