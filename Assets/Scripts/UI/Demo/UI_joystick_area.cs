/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ui.Demo
{
    public partial class UI_joystick_area : GComponent
    {
        public UI_joystick bar;
        public GGraph area;
        public const string URL = "ui://ct91jj21avqf99";

        public static UI_joystick_area CreateInstance()
        {
            return (UI_joystick_area)UIPackage.CreateObject("Demo", "joystick_area");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bar = (UI_joystick)GetChildAt(0);
            area = (GGraph)GetChildAt(1);
        }
    }
}