using System;
using Enums;
using Extensions;
using UnityEngine.Events;
namespace Signals
{
    public class SoundSignals : MonoSingleton<SoundSignals>
    {
        public UnityAction backgroundSound = delegate { };
        public UnityAction failSound = delegate { };
        public UnityAction winSound = delegate { };
        public UnityAction passSound = delegate { };
        public UnityAction clickSound = delegate { };
        
    }
}