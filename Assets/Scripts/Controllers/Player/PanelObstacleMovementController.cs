using Data.ValueObjects;
using Keys;
using Managers;
using Sirenix.OdinInspector;
using Unity.Mathematics;
using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

namespace Controllers.Player
{
    public class PanelObstacleMovementController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private PanelObstacleManager manager;
        
        [SerializeField] private new Rigidbody rigidbody;
        [SerializeField] private new Collider collider;
        
        #endregion

        #region Private Variables

        [ShowInInspector] public MovementData _data;
        [SerializeField] private List<DOTweenAnimation> tweenAnimations = new List<DOTweenAnimation>();
        [ShowInInspector] private bool _isReadyToMove, _isReadyToPlay;

        private float _xValue;
        private float2 _clampValues;

        #endregion

        #endregion   
        internal void SetMovementData(MovementData movementData)
        {
            _data = movementData;
        }

        private void FixedUpdate()
        {
            if (!_isReadyToPlay)
            {
               // StopPlayer();
                return;
            }

            if (_isReadyToPlay)
            {
                MovePlayer();
            }
            else
            {
                StopPlayerHorizontaly();
            }
        }
        private void MovePlayer()
        {
            foreach (var animation in tweenAnimations)
            {
                animation.DOPlayById("first");
                animation.DOPlayById("second");
                animation.DOPlayById("third");
               
            }
            
           
        }

        private void StopPlayerHorizontaly()
        {
            
           // rigidbody.velocity = new float3(0, rigidbody.velocity.y, _data.ForwardSpeed);
            rigidbody.angularVelocity = float3.zero;
        }
        
        
        
       

        internal void IsReadyToPlay(bool condition)
        {
            _isReadyToPlay = condition;
        }

        internal void IsReadyToMove(bool condition)
        {
            _isReadyToMove = condition;
        }

        internal void UpdateInputParams(HorizontalnputParams inputParams)
        {
            _xValue = inputParams.HorizontalInputValue;
            _clampValues = new float2(inputParams.HorizontalInputClampNegativeSide,
                inputParams.HorizontalInputClampPositiveSide);
        }

        internal void OnReset()
        {
            
            _isReadyToPlay = false;
            _isReadyToMove = false;
        }
    }
}