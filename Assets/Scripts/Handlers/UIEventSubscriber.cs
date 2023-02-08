using System.Diagnostics;
using Enums;
using Managers;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Handlers
{
    public class UIEventSubscriber : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private UIEventSubscriptionTypes type;
        //[SerializeField] private UILevelTypes levelType;
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
            switch (type)
            {
                case UIEventSubscriptionTypes.OnPlay:
                {
                    button.onClick.AddListener(_manager.Play);
                    break;
                }
                case UIEventSubscriptionTypes.OnNextLevel:
                {
                    button.onClick.AddListener(_manager.NextLevel);
                    break;
                }
                case UIEventSubscriptionTypes.OnRestartLevel:
                {
                    button.onClick.AddListener(_manager.RestartLevel);
                    break;
                }
                case UIEventSubscriptionTypes.OnLevelsPanel:
                {
                    button.onClick.AddListener(_manager.LevelsShow);
                    break;
                }
            }
            
            
            // switch(levelType)
            // {
            //     case UILevelTypes.Level1:
            //     {
            //         button.onClick.AddListener(_manager.Level1);
            //         break;
            //     }
            // }
        }

        private void UnSubscribeEvents()
        {
            switch (type)
            {
                case UIEventSubscriptionTypes.OnPlay:
                {
                    button.onClick.RemoveListener(_manager.Play);
                    break;
                }
                case UIEventSubscriptionTypes.OnNextLevel:
                {
                    button.onClick.RemoveListener(_manager.NextLevel);
                    break;
                }
                case UIEventSubscriptionTypes.OnRestartLevel:
                {
                    button.onClick.RemoveListener(_manager.RestartLevel);
                    break;
                }
                case UIEventSubscriptionTypes.OnLevelsPanel:
                {
                    button.onClick.RemoveListener(_manager.LevelsShow);
                    break;
                }
            }
            // switch(levelType)
            // {
            //     case UILevelTypes.Level1:
            //     {
            //         button.onClick.RemoveListener(_manager.Level1);
            //         break;
            //     }
            // }
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }
    }
}