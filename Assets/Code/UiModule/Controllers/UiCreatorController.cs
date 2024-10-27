using System;
using System.Collections.Generic;
using Code.UiModule.Configs;
using Code.UiModule.Enums;
using Code.UiModule.Views;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Code.UiModule.Controllers
{
    public class UiCreatorController
    {
        private readonly UiRoot _uiRoot;
        private readonly UiHudConfig _uiHudConfig;
        private readonly UiWindowConfig _uiWindowConfig;
        private readonly UiPopupConfig _uiPopupConfig;
        private readonly Dictionary<Type, GuiComponent> _uiInstancesByType;
    
        public UiCreatorController(
            UiRoot uiRoot, 
            UiHudConfig uiHudConfig, 
            UiWindowConfig uiWindowConfig, 
            UiPopupConfig uiPopupConfig)
        {
            _uiRoot = uiRoot;
            _uiHudConfig = uiHudConfig;
            _uiWindowConfig = uiWindowConfig;
            _uiPopupConfig = uiPopupConfig;
            _uiInstancesByType = new Dictionary<Type, GuiComponent>();
        }
    
        public T Open<T>(UiType uiType) where T : GuiComponent
        {
            T templateGui;
            RectTransform parent;
            
            switch (uiType)
            {
                case UiType.Hud:
                    templateGui = GetGuiComponent<T>(_uiHudConfig.Huds);
                    parent = _uiRoot.HudCanvas;
                    break;
                case UiType.Windows:
                    templateGui = GetGuiComponent<T>(_uiWindowConfig.Windows);
                    parent = _uiRoot.WindowCanvas;
                    break;
                case UiType.Popup:
                    templateGui = GetGuiComponent<T>(_uiPopupConfig.Popups);
                    parent = _uiRoot.PopupCanvas;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(uiType), uiType, null);
            }

            var instanceGui = Object.Instantiate(templateGui, parent);
            _uiInstancesByType.Add(typeof(T), instanceGui);

            return instanceGui;
        }

        public void Close<T>() where T : GuiComponent
        {
            if (!_uiInstancesByType.TryGetValue(typeof(T), out var instance))
            {
                return;
            }
            
            _uiInstancesByType.Remove(typeof(T));
            Object.Destroy(instance.gameObject);
        }
        
        private T GetGuiComponent<T>(IEnumerable<GuiComponent> guiComponents) where T : GuiComponent
        {
            foreach (var hud in guiComponents)
            {
                if (hud.GetType() != typeof(T))
                {
                    continue;
                }

                return (T)hud;
            }

            return null;
        }
    }
}