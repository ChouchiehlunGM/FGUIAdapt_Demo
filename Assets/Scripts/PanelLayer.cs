using FairyGUI;

namespace UI
{
    public class PanelLayer : GComponent
    {
        public static PanelLayer CreateInstance()
        {
            var layer = new PanelLayer();
            layer.displayObject.gameObject.name = "PanelLayer";
            return layer;
        }
    }
}