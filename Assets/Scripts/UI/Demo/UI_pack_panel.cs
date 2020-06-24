/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ui.Demo
{
    public partial class UI_pack_panel : GComponent
    {
        public UI_pack_bag pack_bag;
        public Transition programme_2;
        public const string URL = "ui://ct91jj21pywwff";

        public static UI_pack_panel CreateInstance()
        {
            return (UI_pack_panel)UIPackage.CreateObject("Demo", "pack_panel");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            pack_bag = (UI_pack_bag)GetChildAt(1);
            programme_2 = GetTransitionAt(0);
        }
    }
}