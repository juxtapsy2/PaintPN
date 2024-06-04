using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21110603_Paint
{
    static class FlickerSolver
    {
        public static void SetDoubleBuffered(this PictureBox picturebox)
        {
            typeof(PictureBox).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                null, picturebox, new object[] { true });
        }
    }
}
