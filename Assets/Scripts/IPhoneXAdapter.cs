using UnityEngine;

public class IphoneXAdapter:MonoBehaviour
{
    private static Rect GetSafeArea()
    {
#if UNITY_EDITOR

        float margin = 0;
        float insertBottom = 0;
        float width = Screen.width;
        float height = Screen.height;
        return new Rect( margin, insertBottom, width, height );
#endif
        return Screen.safeArea;
    }

    public static Vector2 lastSafeAreaAnchorMin;
    public static Vector2 lastSafeAreaAnchorMax;

    static void CacheSafeArea( Rect area )
    {

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
        float width = 2436f;
        float height = 1125f;
        float margin = 66;
        float insetsBottom = 63f;

        if( Game.Instance.isIPhoneX )
        {
            var insets = area.width * (margin / 2) / width;
            var positionOffset = new Vector2( insets, 0 );
            var sizeOffset = new Vector2( insets, 0 );
            area.position = area.position + positionOffset;
            area.size = area.size - sizeOffset ;
            Debug.Log( $"insets: {insets} positionOffset: {positionOffset} sizeOffset: {sizeOffset} " +
                       $"area.size: {area.size}  area.position: {area.position}" );
        }
#endif

        lastSafeAreaAnchorMin = area.position;
        lastSafeAreaAnchorMax = area.position + area.size;
        lastSafeAreaAnchorMin.x /= Screen.width;
        lastSafeAreaAnchorMin.y /= Screen.height;
        lastSafeAreaAnchorMax.x /= Screen.width;
        lastSafeAreaAnchorMax.y /= Screen.height;

        Debug.Log( $"------------------- lastSafeAreaAnchorMin: {lastSafeAreaAnchorMin} " +
                   $"lastSafeAreaAnchorMax: {lastSafeAreaAnchorMax}" );
    }


    void Awake()
    {
        IsEnabled = true;
        ApplySafeArea();
    }

    private void ApplySafeArea()
    {
        Rect safeArea = GetSafeArea();
        CacheSafeArea( safeArea );
    }


    public static bool IsPhoneX
    {
        get
        {
#if UNITY_EDITOR
            return Game.Instance != null && Game.Instance.isIPhoneX;
#endif

#if UNITY_IOS
                var deviceId = SystemInfo.deviceModel;
                //iPhone X
                switch( UnityEngine.iOS.Device.generation )
                {
                    case UnityEngine.iOS.DeviceGeneration.iPhoneX:
                    case UnityEngine.iOS.DeviceGeneration.iPhoneXS:
                    case UnityEngine.iOS.DeviceGeneration.iPhoneXSMax:
                    case UnityEngine.iOS.DeviceGeneration.iPhoneXR:
                    case UnityEngine.iOS.DeviceGeneration.iPhone11:
                    case UnityEngine.iOS.DeviceGeneration.iPhone11Pro:
                    case UnityEngine.iOS.DeviceGeneration.iPhone11ProMax:
                        return true;
                }

                return false;
            }
#else
            return false;
        }
#endif
    }

    public static bool IsEnabled { get; set; }
}