/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ui.Demo
{
    public partial class UI_operation : GComponent
    {
        public UI_joystick_area player_joystick;
        public GGroup Player;
        public GButton player_jump_btn;
        public GButton player_run_btn;
        public GGroup operation;
        public const string URL = "ui://ct91jj21avqf98";

        public static UI_operation CreateInstance()
        {
            return (UI_operation)UIPackage.CreateObject("Demo", "operation");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            player_joystick = (UI_joystick_area)GetChildAt(0);
            Player = (GGroup)GetChildAt(1);
            player_jump_btn = (GButton)GetChildAt(2);
            player_run_btn = (GButton)GetChildAt(3);
            operation = (GGroup)GetChildAt(4);
        }
    }
}