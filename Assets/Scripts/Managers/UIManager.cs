using System;
using Enums;
using Signals;
using UnityEngine;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onLevelInitialize += OnLevelInitialize;
            CoreGameSignals.Instance.OnLevelsPanel += OnLevelsPanel;
            CoreGameSignals.Instance.onLevelSuccessful += OnLevelSuccessful;
            CoreGameSignals.Instance.onLevelFailed += OnLevelFailed;
            CoreGameSignals.Instance.onReset += OnReset;
        }

        private void UnSubscribeEvents()
        {
            CoreGameSignals.Instance.onLevelInitialize -= OnLevelInitialize;
            CoreGameSignals.Instance.OnLevelsPanel -= OnLevelsPanel;
            CoreGameSignals.Instance.onLevelSuccessful -= OnLevelSuccessful;
            CoreGameSignals.Instance.onLevelFailed -= OnLevelFailed;
            CoreGameSignals.Instance.onReset -= OnReset;
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        public void NextLevel()
        {
            CoreGameSignals.Instance.onNextLevel?.Invoke();
            CoreGameSignals.Instance.onReset?.Invoke();
        }

        public void RestartLevel()
        {
            CoreGameSignals.Instance.onRestartLevel?.Invoke();
            CoreGameSignals.Instance.onReset?.Invoke();
        }
        
        public void LevelsShow()
        {
            CoreGameSignals.Instance.OnLevelsPanel?.Invoke();
           // CoreUISignals.Instance.onClosePanel?.Invoke(2);
            CoreUISignals.Instance.onClosePanel?.Invoke(1);
            //CoreGameSignals.Instance.onReset?.Invoke();
        }
        
        public void Level1()
        {
            CoreGameSignals.Instance.onClearActiveLevel?.Invoke();
           // CoreGameSignals.Instance.onReset?.Invoke();
            CoreGameSignals.Instance.onLevelInitialize?.Invoke(0);
           // CoreUISignals.Instance.onCloseAllPanels?.Invoke();
           CoreUISignals.Instance.onClosePanel?.Invoke(2);
            
        }
        public void Level2()
        {
            CoreGameSignals.Instance.onClearActiveLevel?.Invoke();
           // CoreGameSignals.Instance.onReset?.Invoke();
            CoreGameSignals.Instance.onLevelInitialize?.Invoke(1);
           // CoreUISignals.Instance.onCloseAllPanels?.Invoke();
           CoreUISignals.Instance.onClosePanel?.Invoke(2);
            
        }

        public void Play()
        {
            CoreGameSignals.Instance.onPlay?.Invoke();
            CoreUISignals.Instance.onClosePanel?.Invoke(1);
            CameraSignals.Instance.onSetCameraTarget?.Invoke();
        }

        private void OnLevelInitialize(int levelValue)
        {
            CoreUISignals.Instance.onOpenPanel?.Invoke(UIPanelTypes.Level,0);
            CoreUISignals.Instance.onOpenPanel?.Invoke(UIPanelTypes.Start, 1);
            UISignals.Instance.onSetNewLevelValue?.Invoke(levelValue);
        }
        
        private void OnLevelsPanel()
        {
            CoreUISignals.Instance.onOpenPanel?.Invoke(UIPanelTypes.LevelsShow, 2);
        }

        private void OnLevelSuccessful()
        {
            CoreUISignals.Instance.onOpenPanel?.Invoke(UIPanelTypes.Win, 2);
        }

        private void OnLevelFailed()
        {
            CoreUISignals.Instance.onOpenPanel?.Invoke(UIPanelTypes.Fail, 2);
        }

        private void OnReset()
        {
            CoreUISignals.Instance.onCloseAllPanels?.Invoke();
            CoreUISignals.Instance.onOpenPanel?.Invoke(UIPanelTypes.Start, 1);
        }
    }
}