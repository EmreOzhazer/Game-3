using System;
using Controllers.Pool;
using DG.Tweening;
using Managers;
using Signals;
using UnityEngine;
using System.Collections;
namespace Controllers.Player
{
    public class PlayerPhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private PlayerManager manager;
        [SerializeField] private new Collider collider;
        [SerializeField] private new Rigidbody rigidbody;
        [SerializeField] public PlayerMovementController playerMovementController;

        
        #endregion

        #endregion
       // public SliderBar _sliderBar;
        public bool minigamestarted;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("StageArea"))
            {
                manager.ForceCommand.Execute();
                CoreGameSignals.Instance.onStageAreaEntered?.Invoke();
                InputSignals.Instance.onDisableInput?.Invoke();

                DOVirtual.DelayedCall(3, () =>
                {
                    var result = other.transform.parent.GetComponentInChildren<PoolController>()
                        .TakeStageResult(manager.StageID);
                    if (result)
                    {
                        CoreGameSignals.Instance.onStageAreaSuccessful?.Invoke(manager.StageID);
                        UISignals.Instance.onSetStageColor?.Invoke(manager.StageID);
                        InputSignals.Instance.onEnableInput?.Invoke();
                        manager.StageID++;
                    }
                    else CoreGameSignals.Instance.onLevelFailed?.Invoke();
                });
                return;
            }

            if (other.CompareTag("Finish"))
            {
                minigamestarted = true;
                playerMovementController._data.ForwardSpeed = 30f;
                Debug.Log("minigamestarted");
                Debug.Log(playerMovementController._data.ForwardSpeed);
                
                //StartCoroutine(ExampleCoroutine());
            }
           
        }

        private void Update()
        {   //Debug.Log(playerMovementController._data.ForwardSpeed);
            
            if (minigamestarted == true)
            {
                playerMovementController._data.ForwardSpeed -= Time.deltaTime*2;
               // _sliderBar._bar.value -= Time.deltaTime*10;
            }
            // bar azalması ve hız azalması olayını senkronize yap.
            // if (_sliderBar._bar.value <= 0)
            // {
            //     playerMovementController.StopPlayer();
            //     CoreGameSignals.Instance.onLevelSuccessful?.Invoke();
            // }
            

        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            var transform1 = manager.transform;
            var position = transform1.position;
            Gizmos.DrawSphere(new Vector3(position.x, position.y - 1.2f, position.z + 1f), 1.65f);
        }

        public void OnReset()
        {
        }
    }
}