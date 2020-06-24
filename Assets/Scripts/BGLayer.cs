using FairyGUI;

namespace UI
{
    public class BGLayer : GComponent
    {
        public static BGLayer CreateInstance()
        {
            var layer = new BGLayer();
            layer.displayObject.gameObject.name = "BGLayer";
            return layer;
        }
    }
}