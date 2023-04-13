using System;
using Controllers.Pool;
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

       

        #endregion

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("PanelLevelFail"))
            {
                
                
               
                //CoreGameSignals.Instance.onStageAreaEntered?.Invoke();
                InputSignals.Instance.onDisableInput?.Invoke();
                Debug.Log("lose");
                DOTween.Pause("first");
                CoreGameSignals.Instance.onLevelFailed?.Invoke();
                DOTween.Pause("third");

            }

            if (other.CompareTag("PanelLevelWin"))
            {
                InputSignals.Instance.onDisableInput?.Invoke();
                CoreGameSignals.Instance.onLevelSuccessful?.Invoke();
                DOTween.PauseAll();
               
               Debug.Log("win");
            }
            if (other.CompareTag("PanelLevelPass"))
            {
                UISignals.Instance.onSetStageColor?.Invoke(manager.StageID);
                manager.StageID++;
                Debug.Log("pass");
            }
            
        }
        public void OnReset()
        {
        }
    }
}