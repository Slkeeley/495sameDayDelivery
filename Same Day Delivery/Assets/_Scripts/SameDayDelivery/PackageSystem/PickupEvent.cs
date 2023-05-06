using UnityEngine;
using UnityEngine.Events;

namespace SameDayDelivery.PackageSystem
{
    public class PickupEvent : MonoBehaviour
    {
        public UnityEvent onPickup;

        public void Pickup()
        {
            onPickup?.Invoke();
        }
    }
}