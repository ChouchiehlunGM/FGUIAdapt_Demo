using ui.Demo;
using UnityEngine;

namespace View
{
    public class SettingView : MonoBehaviour
    {
        private UI_setting ui;

        public void Init(UI_setting settingUi)
        {
            ui = settingUi;
            ui.contine_btn.onClick.Set(() =>
            {
                Game.Instance.UIControl.ClosePanelView<UI_setting>();
            });
            
            ui.game_over_btn.onClick.Set(() =>
            {
                Game.Instance.UIControl.ClosePanelView<UI_setting>();
            });
        }
    }
}