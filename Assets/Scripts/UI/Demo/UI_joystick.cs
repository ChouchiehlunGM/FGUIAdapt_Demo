/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ui.Demo
{
    public partial class UI_joystick : GComponent
    {
        public GImage bg;
        public GImage ball;
        public const string URL = "ui://ct91jj21avqf9a";

        public static UI_joystick CreateInstance()
        {
            return (UI_joystick)UIPackage.CreateObject("Demo", "joystick");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GImage)GetChildAt(0);
            ball = (GImage)GetChildAt(1);
        }
    }
}