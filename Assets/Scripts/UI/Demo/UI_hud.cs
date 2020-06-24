/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ui.Demo
{
    public partial class UI_hud : GComponent
    {
        public GButton bag_btn;
        public GButton fish_btn;
        public GButton menu_btn;
        public GButton test_dialogue_btn;
        public const string URL = "ui://ct91jj21avqfb0";

        public static UI_hud CreateInstance()
        {
            return (UI_hud)UIPackage.CreateObject("Demo", "hud");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bag_btn = (GButton)GetChildAt(0);
            fish_btn = (GButton)GetChildAt(1);
            menu_btn = (GButton)GetChildAt(2);
            test_dialogue_btn = (GButton)GetChildAt(3);
        }
    }
}