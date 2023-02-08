using System.Diagnostics;
using Enums;
using Managers;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Handlers
{
    public class UILevelSubscriber: MonoBehaviour
    {
         #region Self Variables

        #region Serialized Variables

       
        [SerializeField] private UILevelTypes levelType;
        [SerializeField] private Button button;

        #endregion

        #region Private Variables

        [ShowInInspector] private UIManager _manager;

        #endregion

        #endregion

        private void Awake()
        {
            FindReferences();
        }

        private void FindReferences()
        {
            _manager = FindObjectOfType<UIManager>();
        }

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            switch(levelType)
            {
                case UILevelTypes.Level1:
                {
                    button.onClick.AddListener(_manager.Level1);
                    break;
                }
                case UILevelTypes.Level2:
                {
                    button.onClick.AddListener(_manager.Level2);
                    break;
                }
            }
        }

        private void UnSubscribeEvents()
        {
            switch(levelType)
            {
                case UILevelTypes.Level1:
                {
                    button.onClick.RemoveListener(_manager.Level1);
                    break;
                }
                case UILevelTypes.Level2:
                {
                    button.onClick.RemoveListener(_manager.Level2);
                    break;
                }
            }
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }
    }
}
