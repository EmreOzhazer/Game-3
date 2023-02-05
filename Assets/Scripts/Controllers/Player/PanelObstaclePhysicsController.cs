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

        [SerializeField] private PanelObstacleManager manager;
        [SerializeField] private new Collider collider;
        [SerializeField] private new Rigidbody rigidbody;
        


        #endregion

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("PanelLevelFail"))
            {
               // manager.ForceCommand.Execute();
                CoreGameSignals.Instance.onStageAreaEntered?.Invoke();
                InputSignals.Instance.onDisableInput?.Invoke();
                Debug.Log("lose");
                CoreGameSignals.Instance.onLevelFailed?.Invoke();
    
            }

            if (other.CompareTag("PanelLevelWin"))
            {
                CoreGameSignals.Instance.onLevelSuccessful?.Invoke();
                manager.StageID++;
                Debug.Log("win");
            }
            
        }
        public void OnReset()
        {
        }
    }
}