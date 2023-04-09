using System;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Controllers.Player
{
    public class GuyMovementConstrainController : MonoBehaviour
    {
        // #region Private Variables
        //
        // [ShowInInspector] private Vector2 yCons;
        // [ShowInInspector] private Vector2 xCons;
        // private Vector2 _positon;
        //
        // #endregion
        
        public float xRangemax;
        public float xRangemin;
        // public float yRangemax;
        // public float yRangemin;
        
        private void Update()
        {
            if (transform.position.x > xRangemax )
            {
                transform.position = new Vector3(xRangemax, transform.position.y, transform.position.z);
            }
            else if ( transform.position.x < xRangemin)
            {
                transform.position = new Vector3(xRangemin, transform.position.y, transform.position.z);
            }   

            // else if (transform.position.x > yRangemax )
            // {
            //     transform.position = new Vector3(transform.position.x, yRangemax, transform.position.z);
            // }
            // else   transform.position = new Vector3(transform.position.x, yRangemin, transform.position.z);
            // {
            //    
            // }   
        }
    }
}