using FairyGUI;

namespace UI
{
    public class HUDLayer : GComponent
    {
        public static HUDLayer CreateInstance()
        {
            var layer = new HUDLayer();
            layer.displayObject.gameObject.name = "HUDLayer";
            return layer;
        }
    }
}