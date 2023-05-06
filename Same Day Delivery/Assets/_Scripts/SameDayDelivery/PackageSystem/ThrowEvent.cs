using UnityEngine;
using UnityEngine.Events;

namespace SameDayDelivery.Utility
{
    public class ThrowEvent : MonoBehaviour
    {
        public UnityEvent onThrow;

        public void Throw()
        {
            onThrow?.Invoke();
        }
    }
}