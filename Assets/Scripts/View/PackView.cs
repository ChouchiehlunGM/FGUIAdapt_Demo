using ConceptDemo.Scripts;
using ui.Demo;
using UnityEngine;

namespace View
{
    public class PackView:MonoBehaviour
    {
        private UI_pack_panel _ui;
        
        public void InitUI( UI_pack_panel ui )
        {
            this._ui = ui;
            InitView();
        }

        private void InitView()
        {
            _ui.pack_bag.close_btn.onClick.Set( () =>
            {
                _ui.pack_bag.sign_out.Play( () =>
                {
                    Game.Instance.UIControl.ClosePanelView<UI_pack_panel>();
                } );
            } );
        }
    }
}