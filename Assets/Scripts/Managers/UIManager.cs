using System;
using Enums;
using Signals;
using UnityEngine;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        #region Serialized Variables

        [SerializeField] private LevelManager levelManager;
        

        #endregion
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
            levelManager.levelID++;
            CoreGameSignals.Instance.onClearActiveLevel?.Invoke();
            CoreGameSignals.Instance.onLevelInitialize?.Invoke(levelManager.levelID++);
            
            CoreUISignals.Instance.onClosePanel?.Invoke(1);
            CoreUISignals.Instance.onClosePanel?.Invoke(2);
            UISignals.Instance.onCountdownStart?.Invoke();
            
            
            // CoreGameSignals.Instance.onNextLevel?.Invoke();
            // CoreGameSignals.Instance.onReset?.Invoke();
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
           
        }
        
        public void Level1()
        {
            CoreGameSignals.Instance.onClearActiveLevel?.Invoke();
            CoreGameSignals.Instance.onLevelInitialize?.Invoke(0);
            
            CoreUISignals.Instance.onClosePanel?.Invoke(1);
            CoreUISignals.Instance.onClosePanel?.Invoke(2);
            UISignals.Instance.onCountdownStart?.Invoke();
            levelManager.levelID = 0;
            
        }
        public void Level2()
        {           

            CoreGameSignals.Instance.onClearActiveLevel?.Invoke();
            CoreGameSignals.Instance.onLevelInitialize?.Invoke(1);
            
            CoreUISignals.Instance.onClosePanel?.Invoke(1);
            CoreUISignals.Instance.onClosePanel?.Invoke(2);
            UISignals.Instance.onSetNewLevelValue?.Invoke(2);
            UISignals.Instance.onCountdownStart?.Invoke();
            
            levelManager.levelID = 1;

        }

        public void Play()
        {
            CoreGameSignals.Instance.onPlay?.Invoke();
            CoreUISignals.Instance.onClosePanel?.Invoke(1);
            CameraSignals.Instance.onSetCameraTarget?.Invoke();

        }
        //next levele bastıktan sonra level biri ibtirip yeniden geçersn level sayısı artmaya devam ediyor
        // next levelde uı daki sayılar değişmiyor sadece level panlini açınca çalışıyor 
        //yukardaki paneli tümden kaldırılabilinir.
        private void OnLevelInitialize(int levelValue)
        {
            CoreUISignals.Instance.onOpenPanel?.Invoke(UIPanelTypes.Level,0);
            CoreUISignals.Instance.onOpenPanel?.Invoke(UIPanelTypes.Start, 1);
            UISignals.Instance.onSetNewLevelValue?.Invoke(levelManager.levelID);
            
            
            
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