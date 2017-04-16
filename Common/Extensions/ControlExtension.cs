using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Common.Extensions
{
    public static class ControlExtension
    {
        public static IEnumerable<Control> GetAllControlsOfType(this Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(x => GetAllControlsOfType(x, type)).Concat(controls).Where(c => c.GetType() == type);
        }
    }
}
