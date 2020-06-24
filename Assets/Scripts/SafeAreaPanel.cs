using UnityEngine;

namespace UI
{
    public class SafeAreaPanel:MonoBehaviour
    {
        private RectTransform target;

#if UNITY_EDITOR
        [SerializeField]
        private bool Simulate_X = false;
#endif


        public static Rect GetSafeArea()
        {
            float x, y, w, h;
#if UNITY_IOS && !UNITY_EDITOR
           return Screen.safeArea;
#else
            x = 0;
            y = 0;
            w = Screen.width;
            h = Screen.height;
#endif
            return new Rect( x, y, w, h );
        }
        
        void Awake()
        {
            target = GetComponent<RectTransform>() == null ? this.gameObject.AddComponent<RectTransform>() : GetComponent<RectTransform>();
            ApplySafeArea();
        }

        public static Vector2 lastSafeAreaAnchorMin;
        public static Vector2 lastSafeAreaAnchorMax;
        
        void ApplySafeArea()
        {
            var area = GetSafeArea();

#if UNITY_EDITOR

            /*
            iPhone X 横持手机方向:
            iPhone X 分辨率
            2436 x 1125 px
    
            safe area
            2172 x 1062 px
    
            左右边距分别
            132px
    
            底边距 (有Home条)
            63px
    
            顶边距
            0px
            */

            float Xwidth = 2436f;
            float Xheight = 1125f;
            float Margin = 69;
            float InsetsBottom = 63f;

            if( Game.Instance.isIPhoneX )
            {
                Simulate_X = true;
            }

            if( Simulate_X )
            {
                var insets = area.width * Margin / Xwidth;
                var positionOffset = new Vector2( insets, 0 );
                var sizeOffset = new Vector2( insets , 0 );
                area.position = area.position + positionOffset;
                area.size = area.size - sizeOffset * 2;
                Debug.Log( $"insets: {insets} positionOffset: {positionOffset} sizeOffset: {sizeOffset} " +
                           $"area.size: {area.size}  area.position: { area.position}" );

            }
#endif

            lastSafeAreaAnchorMin = area.position;
            lastSafeAreaAnchorMax = area.position + area.size;
            lastSafeAreaAnchorMin.x /= Screen.width;
            lastSafeAreaAnchorMin.y /= Screen.height;
            lastSafeAreaAnchorMax.x /= Screen.width;
            lastSafeAreaAnchorMax.y /= Screen.height;
            
            target.anchorMin = lastSafeAreaAnchorMin;
            target.anchorMax = lastSafeAreaAnchorMax;
            Debug.Log( $"------------------- lastSafeAreaAnchorMin: {lastSafeAreaAnchorMin} " +
                       $"lastSafeAreaAnchorMax: {lastSafeAreaAnchorMax}" );
        }
    }
}