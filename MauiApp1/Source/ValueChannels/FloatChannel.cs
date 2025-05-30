using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public class FloatChannel : ValueChannel<float>
    {
        public FloatChannel(Size size, ValueChannelType type, string title = "float") : base(
            size: size, 
            title: title,
            type: type,
            passColor: Colors.Yellow
        )
        {

        }
    }
}
