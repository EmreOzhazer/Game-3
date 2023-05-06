using Signals;
using UnityEngine;

namespace Managers
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioSource[] _audioSource;
        private void OnEnable() => SubscribeEvents();
        
        private void SubscribeEvents()
        {
            SoundSignals.Instance.backgroundSound += BgSound;
            SoundSignals.Instance.winSound += WinSound;
            SoundSignals.Instance.failSound += FailSound;
            SoundSignals.Instance.passSound += PassSound;
            SoundSignals.Instance.clickSound += ClickSound;
        }

        private void UnsubscribeEvents()
        { 
            SoundSignals.Instance.backgroundSound -= BgSound;
           SoundSignals.Instance.winSound -= WinSound;
           SoundSignals.Instance.failSound -= FailSound;
           SoundSignals.Instance.passSound -= PassSound;
           SoundSignals.Instance.clickSound -= ClickSound;
        }

        private void OnDisable() => UnsubscribeEvents();

        private void BgSound()
        {
            _audioSource[0].Play();
        }
        private void WinSound()
        {
            _audioSource[1].Play();
        }
        private void FailSound()
        {
            _audioSource[2].Play();
        }
        private void PassSound()
        {
            _audioSource[3].Play();
        }
        private void ClickSound()
        {
            _audioSource[4].Play();
        }
    }
}