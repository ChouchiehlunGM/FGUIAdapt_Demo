/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ui.Demo
{
    public partial class UI_setting : GComponent
    {
        public UI_general_with_effect_btn contine_btn;
        public UI_general_with_effect_btn game_over_btn;
        public Transition t0;
        public const string URL = "ui://ct91jj21kz0jhd";

        public static UI_setting CreateInstance()
        {
            return (UI_setting)UIPackage.CreateObject("Demo", "setting");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            contine_btn = (UI_general_with_effect_btn)GetChildAt(1);
            game_over_btn = (UI_general_with_effect_btn)GetChildAt(2);
            t0 = GetTransitionAt(0);
        }
    }
}