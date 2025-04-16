using System;

namespace NerdyToolBox.Models
{
    public class WindowInfo
    {
        public IntPtr Handle { get; set; }
        public string Title { get; set; }
        public override string ToString() => Title;
    }
}
