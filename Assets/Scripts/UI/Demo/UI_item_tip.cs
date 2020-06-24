/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ui.Demo
{
    public partial class UI_item_tip : GComponent
    {
        public GTextField title_txt;
        public const string URL = "ui://ct91jj21k56yhk";

        public static UI_item_tip CreateInstance()
        {
            return (UI_item_tip)UIPackage.CreateObject("Demo", "item_tip");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            title_txt = (GTextField)GetChildAt(2);
        }
    }
}