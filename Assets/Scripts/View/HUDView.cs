using System.Collections.Generic;
using Config;
using ui.Demo;
using UnityEngine;

namespace View
{
    public class HUDView:MonoBehaviour
    {
        private UI_hud _ui;

        public void InitUI( UI_hud ui )
        {
            this._ui = ui;
            ui.menu_btn.onClick.Set( () =>
            {
                var settingView =
                    Game.Instance.UIControl.OpenPanelView<UI_setting, SettingView>(
                                                                                   out var settingUi );
                settingView.Init( settingUi );
            } );

            ui.bag_btn.onClick.Set( () =>
            {
                var bagView =
                    Game.Instance.UIControl.OpenPanelView<UI_pack_panel, PackView>(
                                                                                          out var bagUi );
                bagView.InitUI( bagUi );
            } );

            ui.test_dialogue_btn.onClick.Set( () =>
            {
                var dialogueView =
                    Game.Instance.UIControl.OpenPanelView<UI_dialogue, DialogueView>(
                                                                                                out var dialogueUi );
                dialogueView.InitUI( dialogueUi, new List<string>()
                {
                    ClientConfig.GlobalConfig.testDialogueTxt,
                    "哈哈哈哈哈哈哈哈哈，测试数据！！！！！！！！！！！"
                } );
            } );
        }
    }
}