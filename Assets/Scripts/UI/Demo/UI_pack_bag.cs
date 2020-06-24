/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ui.Demo
{
    public partial class UI_pack_bag : GComponent
    {
        public Controller state;
        public GButton close_btn;
        public GList list;
        public GButton dispaly_btn;
        public Transition display_btn;
        public Transition hide_bag_panel;
        public Transition t2;
        public Transition sign_out;
        public const string URL = "ui://ct91jj21pywwfx";

        public static UI_pack_bag CreateInstance()
        {
            return (UI_pack_bag)UIPackage.CreateObject("Demo", "pack_bag");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            state = GetControllerAt(0);
            close_btn = (GButton)GetChildAt(5);
            list = (GList)GetChildAt(6);
            dispaly_btn = (GButton)GetChildAt(7);
            display_btn = GetTransitionAt(0);
            hide_bag_panel = GetTransitionAt(1);
            t2 = GetTransitionAt(2);
            sign_out = GetTransitionAt(3);
        }
    }
}