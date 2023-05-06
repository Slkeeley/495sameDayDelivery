using SameDayDelivery.PackageSystem;
using UnityEngine;

namespace _Scripts.SameDayDelivery.Utility
{
    public class AnimationLinker : MonoBehaviour
    {
        [SerializeField]
        private PackagePickup _packagePickupScript;

        public void PickupAnimationCompleted()
        {
            _packagePickupScript.PickupAnimationCompleted();
        }

        public void ThrowPackage()
        {
            _packagePickupScript.ThrowPackage();
            _packagePickupScript.ThrowAnimationCompleted();
        }
    }
}