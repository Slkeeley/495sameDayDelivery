using UnityEngine;

namespace SameDayDelivery.Utility
{
    public class AnimatorUnityEventHandler : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void SetBoolOn(string boolName)
        {
            if (!_animator) return;

            _animator.SetBool(boolName, true);
        }

        public void SetBoolOff(string boolName)
        {
            if (!_animator) return;

            _animator.SetBool(boolName, false);
        }
    }
}