/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ui.Demo
{
    public partial class UI_pack_bag_cell : GButton
    {
        public Controller hold_status;
        public Controller count_status;
        public GImage selected_img;
        public GLoader icon_loader;
        public GTextField count_txt;
        public UI_item_tip tip_comp;
        public Transition t0;
        public const string URL = "ui://ct91jj21pywwg0";

        public static UI_pack_bag_cell CreateInstance()
        {
            return (UI_pack_bag_cell)UIPackage.CreateObject("Demo", "pack_bag_cell");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            hold_status = GetControllerAt(1);
            count_status = GetControllerAt(2);
            selected_img = (GImage)GetChildAt(2);
            icon_loader = (GLoader)GetChildAt(3);
            count_txt = (GTextField)GetChildAt(5);
            tip_comp = (UI_item_tip)GetChildAt(6);
            t0 = GetTransitionAt(0);
        }
    }
}