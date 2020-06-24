/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ui.Demo
{
    public partial class UI_dialogue_title_bar : GComponent
    {
        public Transition dot_effect;
        public const string URL = "ui://ct91jj21ryhtht";

        public static UI_dialogue_title_bar CreateInstance()
        {
            return (UI_dialogue_title_bar)UIPackage.CreateObject("Demo", "dialogue_title_bar");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            dot_effect = GetTransitionAt(0);
        }
    }
}