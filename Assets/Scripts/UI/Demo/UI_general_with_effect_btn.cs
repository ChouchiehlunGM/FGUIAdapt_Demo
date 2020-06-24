/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ui.Demo
{
    public partial class UI_general_with_effect_btn : GButton
    {
        public Transition effect_transtion;
        public const string URL = "ui://ct91jj21aj50hj";

        public static UI_general_with_effect_btn CreateInstance()
        {
            return (UI_general_with_effect_btn)UIPackage.CreateObject("Demo", "general_with_effect_btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            effect_transtion = GetTransitionAt(0);
        }
    }
}