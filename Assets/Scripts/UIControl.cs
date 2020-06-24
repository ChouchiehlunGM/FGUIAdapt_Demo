using System;
using System.Collections.Generic;
using System.Linq;
using FairyGUI;
using UI;
using ui.Demo;
using UnityEngine;
using View;

public class UIControl
{
    public static float offsetx;

    public enum UILayer
    {
        BgLayer,
        PanelLayer,
        HudLayer,
        TipLayer
    }

    private BGLayer _bgLayer;
    private PanelLayer _panelLayer;
    private HUDLayer _hudLayer;
    private TipLayer _tipLayer;
    protected Dictionary<Type, GComponent> panelViewCache;
    protected Dictionary<Type, GComponent> hudViewCache;

    public UIControl()
    {
        InitUI();
    }

    private void InitUI()
    {
        // 初始化字体
        UIConfig.defaultFont = "Fonts/4082_方正粗圆_GBK";

        GRoot.inst.SetContentScaleFactor( Config.ClientConfig.GlobalConfig.designResolutionX, Config.ClientConfig.GlobalConfig.designResolutionY, UIContentScaler.ScreenMatchMode.MatchWidthOrHeight );
        StageCamera.main.depth = 3;
        StageCamera.main.nearClipPlane = 0;
        var position = StageCamera.main.gameObject.transform.position;
        StageCamera.main.gameObject.transform.position = new Vector3( position.x, position.y, -15 );


        UIPackage.AddPackage( $"UI/Demo" );
        DemoBinder.BindAll();

        // 初始化适配参数
        // IPhoneXAdapter.Update();
        InitLayers();
        InitHUD(); // HUD先用ugui
        // InputListener.Init();

#if ENGINE_TEST
            var allCamera = Gaming.MainCamera.gameObject.GetComponentsInChildren<Camera>();
            foreach (var camera in allCamera)
            {
                camera.useTrickOcclusionCulling = camera.useTrickCullingByPortalBlock = false;
            }

            StageCamera.main.useTrickOcclusionCulling = StageCamera.main.useTrickCullingByPortalBlock = false;
            Gaming.MainCamera.useTrickOcclusionCulling = Gaming.MainCamera.useTrickCullingByPortalBlock = true;
#endif

    }

    private void InitLayers()
    {
        panelViewCache = new Dictionary<Type, GComponent>();
        hudViewCache = new Dictionary<Type, GComponent>();
        if( _bgLayer == null && _panelLayer == null && _tipLayer == null && _hudLayer == null )
        {
            _bgLayer = AddToRoot( GRoot.inst, BGLayer.CreateInstance() ) as BGLayer;
            _hudLayer = AddToRoot( GRoot.inst, HUDLayer.CreateInstance() ) as HUDLayer;
            _panelLayer = AddToRoot( GRoot.inst, PanelLayer.CreateInstance() ) as PanelLayer;
            _tipLayer = AddToRoot( GRoot.inst, TipLayer.CreateInstance() ) as TipLayer;
        }
    }

    public TipLayer TipLayer => _tipLayer;

    private static GComponent AddToRoot( GComponent root, GComponent ui, bool isFullScreenUI = true)
    {
        if( isFullScreenUI )
        {
            // 需要对iPhoneX适配 && 当前是iPhoneX 才会调整UI的位置和尺寸
            if(IphoneXAdapter.IsPhoneX )
            {
                offsetx = IphoneXAdapter.lastSafeAreaAnchorMin.x * Config.ClientConfig.GlobalConfig.designResolutionX;
                var offsety = IphoneXAdapter.lastSafeAreaAnchorMin.y * Config.ClientConfig.GlobalConfig.designResolutionY;

                // offsetx = SafeAreaPanel.lastSafeAreaAnchorMin.x * designWidth;
                // var offsety = SafeAreaPanel.lastSafeAreaAnchorMin.y * designHeight;
                
                var tw = root.width - offsetx * 2;
                var th = root.height - offsety;
                
                Debug.Log( $"groot width: {GRoot.inst.width} " +
                           $"groot.height: {GRoot.inst.height}  " +
                           $"lastSafeAreaAnchorMin: {SafeAreaPanel.lastSafeAreaAnchorMin} " +
                           $"适配 ipx offsetx: {offsetx} , offsety: {offsety}, tw: {tw}， th：{th}" );

                ui.SetSize( tw, th );
                ui.SetXY( offsetx, 0 );
            }
            else
            {
                ui.SetSize( root.width, root.height );
            }

            ui.AddRelation( root, RelationType.Size );
        }

        ui.visible = true;
        if( root.GetChildren().Any( o => o == ui ) ) return ui;
        root.AddChild( ui );
        return ui;
    }


    private void InitHUD()
    {
        var hudView = OpenHUDView<UI_hud, HUDView>( out var hudUi );
        hudView.InitUI( hudUi );
    }

    protected V OpenView <T, V>( UILayer layer, out T compInstance ) where T : GComponent where V : MonoBehaviour
    {
        if( typeof( T ).GetMethod( "CreateInstance" )?.Invoke( null, null ) is GComponent component )
        {
            var view = component.displayObject.gameObject.AddComponent<V>();
            compInstance = (T)component;
            switch( layer )
            {
                case UILayer.HudLayer:
                    if( !hudViewCache.ContainsKey( typeof( T ) ) )
                    {
                        hudViewCache.Add( typeof( T ), component );
                    }

                    AddToRoot( _hudLayer, component );

                    break;
                case UILayer.PanelLayer:
                    if( !panelViewCache.ContainsKey( typeof( T ) ) )
                    {
                        panelViewCache.Add( typeof( T ), component );
                    }

                    AddToRoot( _panelLayer, component );
                    _hudLayer.visible = false;
                    break;
            }

            return view;
        }

        compInstance = null;
        return null;
    }

    public V OpenHUDView <T, V>( out T uiInstance ) where T : GComponent where V : MonoBehaviour
    {
        return OpenView<T, V>( UILayer.HudLayer, out uiInstance );
    }

    public V OpenPanelView <T, V>( out T uiInstance ) where T : GComponent where V : MonoBehaviour
    {
        return OpenView<T, V>( UILayer.PanelLayer, out uiInstance );
    }

    public bool ClosePanelView <T>() where T : GComponent
    {
        if( panelViewCache.TryGetValue( typeof( T ), out var ui ) )
        {
            ui.RemoveFromParent();
            panelViewCache.Remove( typeof( T ) );
            ui.Dispose();
            if( panelViewCache.Count == 0 )
            {
                _hudLayer.visible = true;
            }

            return true;

        }

        Debug.LogError( $"panelLayer 没有缓存{typeof( T )}" );
        return false;
    }
}