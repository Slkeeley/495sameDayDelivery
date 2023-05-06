using UnityEngine;
using UnityEngine.Events;

namespace SameDayDelivery.Utility
{
    public class StepEvent : MonoBehaviour
    {
        public UnityEvent onStep;

        public void Step()
        {
            onStep?.Invoke();
        }
    }
}