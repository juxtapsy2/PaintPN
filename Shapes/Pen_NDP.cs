using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _21110603_Paint.Shapes
{
    public class Pen_NDP : Arc_NDP
    {
        //TODO: cho biết chọn chế độ xóa hay là không
        public bool isEraser { get; set; }

        public Pen_NDP()
        {
            name = "Pen";
        }

        public Pen_NDP(Color color)
        {
            name = "Pen";
            this.color = color;
        }

    }
}
