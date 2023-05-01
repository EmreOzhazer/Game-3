using System.Collections.Generic;
using System.Collections;
using DG.Tweening;
using Managers;
using Signals;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

namespace Controllers.UI
{
    public class LevelPanelController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables
        
        [SerializeField] private List<TextMeshProUGUI> levelTexts = new List<TextMeshProUGUI>();
        [Space] [SerializeField] private List<Image> stageImages = new List<Image>();
        [SerializeField] private List<GameObject> startingImages = new List<GameObject>();
        #endregion

        #endregion

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            UISignals.Instance.onSetNewLevelValue += OnSetNewLevelValue;
            UISignals.Instance.onSetStageColor += OnSetStageColor;
            UISignals.Instance.onCountdownStart += onCountdownStart;
        }

        private void UnSubscribeEvents()
        {
            UISignals.Instance.onSetNewLevelValue -= OnSetNewLevelValue;
            UISignals.Instance.onSetStageColor -= OnSetStageColor;
            UISignals.Instance.onCountdownStart -= onCountdownStart;
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }
        

        private void  onCountdownStart()
        {
            StartCoroutine(countdownImages());
            IEnumerator  countdownImages()
            {
                // startingImages[imagevalue].DOPlay();
                startingImages[0].SetActive(true);
                
                yield return new WaitForSeconds (1f);
            
                startingImages[0].SetActive(false);
                startingImages[1].SetActive(true);
                
                yield return new WaitForSeconds (1f);
                
                startingImages[1].SetActive(false);
                CoreGameSignals.Instance.onPlay?.Invoke();
            }
            
           
        }
       
        
       
        
        
        
        private void OnSetNewLevelValue(int levelValue)
        {
            if (levelValue <= 0) levelValue = 1;
           
            levelTexts[0].text = levelValue.ToString();
           
            var value = ++levelValue;
            levelTexts[1].text = value.ToString();
           
        }

        [Button("OnSetStageColor")]
        private void OnSetStageColor(int stageValue)
        {
            stageImages[stageValue].DOColor(Color.red, .35f).SetEase(Ease.Linear);
        }
    }
}