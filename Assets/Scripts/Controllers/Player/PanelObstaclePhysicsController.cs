using System;
using DG.Tweening;
using Managers;
using Signals;
using UnityEngine;
using System.Collections;

namespace Controllers.Player
{
    public class PanelObstaclePhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables
       // [SerializeField] private PanelObstacleMovementController movementController;
        [SerializeField] private PanelObstacleManager manager;
       // [SerializeField] private new Collider collider;
       // [SerializeField] private new Rigidbody rigidbody;

       private bool isfailcalled = true;

        #endregion

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("PanelLevelFail"))
            {
                
                
                SoundSignals.Instance.failSound?.Invoke();
                //CoreGameSignals.Instance.onStageAreaEntered?.Invoke();
                InputSignals.Instance.onDisableInput?.Invoke();
                Debug.Log("lose");
                DOTween.Pause("first");
                if (isfailcalled == true)
                {
                    CoreGameSignals.Instance.onLevelFailed?.Invoke();
                    isfailcalled = false;
                }

                DOTween.Pause("third");

            }

            if (other.CompareTag("PanelLevelWin"))
            {
                SoundSignals.Instance.winSound?.Invoke();
                InputSignals.Instance.onDisableInput?.Invoke();
                CoreGameSignals.Instance.onLevelSuccessful?.Invoke();
                DOTween.PauseAll();
               
               Debug.Log("win");
            }
            if (other.CompareTag("PanelLevelPass"))
            {
                SoundSignals.Instance.passSound?.Invoke();
                UISignals.Instance.onSetStageColor?.Invoke(manager.StageID);
                manager.StageID++;
                Debug.Log("pass");
            }
            if (other.CompareTag("MoreLevelSoon"))
            {
                SoundSignals.Instance.winSound?.Invoke();
                CoreGameSignals.Instance.onmoreSoon?.Invoke();
            }
            
        }
        public void OnReset()
        {
        }
    }
}