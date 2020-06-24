using System.Collections.Generic;
using Config;
using FairyGUI;
using ui.Demo;
using UnityEngine;

namespace View
{
    public class DialogueView : MonoBehaviour
    {
        private UI_dialogue _ui;
        TypingEffect effect;
        private TimerCallback _timerCallback;
        private bool canCloseUi = false;
        private Queue<string> dialogueContentsQueue;
        private bool typingEffectIsPlaying = false;
        private bool isSpeedUp = false;

        public void InitUI(UI_dialogue dialogueUi, List<string> dialogueContents)
        {
            _ui = dialogueUi;
            _ui.onClick.Set(() =>
            {
                if (!canCloseUi)
                {
                    if (!typingEffectIsPlaying)
                    {
                        PlayTypingEffect();
                    }
                    else
                    {
                        // 加速显示
                        if( isSpeedUp )
                        {
                            return;
                        }
                        effect?.PrintAll(ClientConfig.GlobalConfig.speedUpDialogueInterval);
                        isSpeedUp = true;
                    }

                    return;
                }

                Game.Instance.UIControl.ClosePanelView<UI_dialogue>();
                Game.Instance.ClearDialogueView();
            });

            InitDialogueQueue(dialogueContents);
            PlayTypingEffect();
        }

        private void PlayTypingEffect()
        {
            if (dialogueContentsQueue != null && dialogueContentsQueue.Count > 0)
            {
                isSpeedUp = false;
                SetTypingEffect(dialogueContentsQueue.Dequeue());
            }
        }

        private void InitDialogueQueue(List<string> dialogueContents)
        {
            if (dialogueContentsQueue == null)
            {
                dialogueContentsQueue = new Queue<string>();
            }

            if (dialogueContents != null)
            {
                for (int i = 0; i < dialogueContents.Count; i++)
                {
                    dialogueContentsQueue.Enqueue(dialogueContents[i]);
                }
            }
        }

        private void SetTypingEffect(string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                canCloseUi = true;
                return;
            }

            _ui.dialogue_txt.text = content;

            if (effect == null)
            {
                effect = new TypingEffect(_ui.dialogue_txt);
            }

            effect.Start();
            _ui.title_bar.dot_effect.Play();
            _timerCallback = TimerCallback;
            Timers.inst.Add(ClientConfig.GlobalConfig.normalDialogueInterval, 0, _timerCallback);
            canCloseUi = false;
            typingEffectIsPlaying = true;
        }

        private void TimerCallback(object param)
        {
            if (!effect.Print())
            {
                Timers.inst.Remove(_timerCallback);
                _timerCallback = null;
                effect = null;
                typingEffectIsPlaying = false;

                if (dialogueContentsQueue != null && dialogueContentsQueue.Count > 0)
                {
                    canCloseUi = false;
                }

                if ((dialogueContentsQueue != null && dialogueContentsQueue.Count == 0) || dialogueContentsQueue == null)
                {
                    canCloseUi = true;
                }
            }
        }
    }
}