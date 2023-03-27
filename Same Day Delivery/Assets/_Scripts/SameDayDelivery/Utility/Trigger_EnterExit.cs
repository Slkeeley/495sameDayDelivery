using UnityEngine;
using UnityEngine.Events;

namespace SameDayDelivery.Utility
{

    [RequireComponent(typeof(Collider))]
    public class Trigger_EnterExit : MonoBehaviour
    {

        [SerializeField, Tooltip("Will only trigger if the object that collides with this trigger, has this tag")]
        private string triggerTag = "Player";

        [SerializeField, Tooltip("Trigger the On Enter actions only once.")]
        private bool triggerEnterOnlyOnce;

        [SerializeField, Tooltip("Trigger the On Exit actions only once.")]
        private bool triggerExitOnlyOnce;
        
        [Space, SerializeField, Tooltip("Actions that will be performed when an object with trigger tag enters the trigger " +
                                 "collider on this object.")]
        private UnityEvent onEnter;

        [SerializeField, Tooltip("Actions that will be performed when an object with trigger tag exits the trigger " +
                                 "collider on this object.")]
        private UnityEvent onExit;

        private bool _enterTriggered;
        private bool _exitTriggered;

        /// <summary>
        /// Method <c>OnTriggerEnter</c> Executes onEnter actions if the object with triggerTag enters the
        /// trigger collider on this object. 
        /// </summary>
        /// <param name="other">The collider of the object that touched this trigger</param>
        private void OnTriggerEnter(Collider other)
        {
            if (triggerEnterOnlyOnce && _enterTriggered) return;

            if (!other.CompareTag(triggerTag)) return;

            onEnter?.Invoke();

            if (triggerEnterOnlyOnce)
                _enterTriggered = true;
        }

        /// <summary>
        /// Method <c>OnTriggerEnter</c> Executes onEnter actions if the object with triggerTag exits the
        /// trigger collider on this object. 
        /// </summary>
        /// <param name="other">The collider of the object that touched this trigger</param>
        private void OnTriggerExit(Collider other)
        {
            if (triggerExitOnlyOnce && _exitTriggered) return;

            if (!other.CompareTag(triggerTag)) return;

            onExit?.Invoke();

            if (triggerExitOnlyOnce)
                _exitTriggered = true;
        }
    }

}