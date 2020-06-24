using UnityEngine;

namespace ConceptDemo.Scripts.Config
{
    [CreateAssetMenu( fileName = "GlobalConfig", menuName = "GlobalConfig/GlobalConfig" )]

    public class GlobalConfig:ScriptableObject
    {
        [Header( "正常打字机速率" )]
        public float normalDialogueInterval;

        [Header( "加速打字机速率" )]
        public float speedUpDialogueInterval;

        [Header( "测试对话文本" )]
        public string testDialogueTxt;

        [Header( "ui设计分辨率宽" )]
        public int designResolutionX;

        [Header( "ui设计分辨率高" )]
        public int designResolutionY;
    }
}