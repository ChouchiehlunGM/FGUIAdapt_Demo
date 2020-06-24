using FairyGUI;

namespace UI
{
    public class TipLayer : GComponent
    {
        public static TipLayer CreateInstance()
        {
            var layer = new TipLayer();
            layer.displayObject.gameObject.name = "TipLayer";
            return layer;
        }
    }
}