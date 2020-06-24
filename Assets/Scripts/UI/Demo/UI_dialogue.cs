/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ui.Demo
{
    public partial class UI_dialogue : GComponent
    {
        public GImage bg;
        public GTextField dialogue_txt;
        public UI_dialogue_title_bar title_bar;
        public Transition t0;
        public Transition t1;
        public const string URL = "ui://ct91jj21k56yhm";

        public static UI_dialogue CreateInstance()
        {
            return (UI_dialogue)UIPackage.CreateObject("Demo", "dialogue");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GImage)GetChildAt(1);
            dialogue_txt = (GTextField)GetChildAt(2);
            title_bar = (UI_dialogue_title_bar)GetChildAt(4);
            t0 = GetTransitionAt(0);
            t1 = GetTransitionAt(1);
        }
    }
}