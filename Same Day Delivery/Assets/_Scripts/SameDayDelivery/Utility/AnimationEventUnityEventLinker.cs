using UnityEngine;
using UnityEngine.Events;

namespace SameDayDelivery.Utility
{
    public class AnimationEventUnityEventLinker : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent OnAnimationEvent;

        public void InvokeUnityEvent()
        {
            OnAnimationEvent?.Invoke();
        }
    }
}