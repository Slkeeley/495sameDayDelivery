using UnityEngine;

namespace SameDayDelivery.Utility
{
    [RequireComponent(typeof(Animator))]
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

        public void ToggleBool(string name)
        {
            if (!_animator) return;
            
            _animator.SetBool(name, !_animator.GetBool(name));
        }
    }
}