using UnityEngine;

namespace UI
{
    public class SafeAreaUtils
    {
#if UNITY_IOS
    [DllImport("__Internal")]
    private static extern void GetSafeArea(out float x, out float y, out float w, out float h);
#endif


        /// <summary>
        /// 获取iPhone X 等苹果未来的异性屏幕的安全区域Safe are
        /// </summary>
        /// <param name="showInsetsBottom"></param>
        /// <returns></returns>
        public static Rect Get()
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
    }
}