using System.Collections.Generic;
using UI;
using ui.Demo;
using UnityEngine;
using View;

public class Game : MonoBehaviour
{
    public bool isIPhoneX;
    private static Game instance;
    public UIControl UIControl;

    public Game(bool isIPhoneX, Transform player)
    {
        this.isIPhoneX = isIPhoneX;
    }

    public static Game Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Game>();
            }

            return instance;
        }
    }

    private void Awake()
    {
        if (isIPhoneX || IphoneXAdapter.IsPhoneX)
        {
            gameObject.AddComponent<IphoneXAdapter>();
            // gameObject.AddComponent<SafeAreaPanel>();
        }
        // UIControl = new UIControl();

    }

    private void Start()
    {
        UIControl = new UIControl();
    }
        
    private DialogueView _demoDialogueView;
        
        
    // 设置对话 没有做成节点 直接给对话内容（多条）
    public void SetDialogueView(List<string> dialogueContents)
    {
        _demoDialogueView = Instance.UIControl.OpenPanelView<UI_dialogue, DialogueView>(out var dialogueUi);
        _demoDialogueView.InitUI(dialogueUi, dialogueContents);
    }

    // 设置对话 没有做成节点 直接给对话内容（单条）
    public void SetDialogueView(string dialogueContent)
    {
        _demoDialogueView = Instance.UIControl.OpenPanelView<UI_dialogue, DialogueView>(out var dialogueUi);
        _demoDialogueView.InitUI(dialogueUi, new List<string>() {dialogueContent});
    }

    public void ClearDialogueView()
    {
        _demoDialogueView = null;
    }
}