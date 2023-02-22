using UnityEngine;

namespace SameDayDelivery.Utility
{
    public class DeathClock : MonoBehaviour
    {
        public bool destroy;
        public float timeUntilDeath = 1f;
        private float _timer;

        private void Awake()
        {
            _timer = timeUntilDeath;
        }

        private void Update()
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0f)
                Death();
        }

        private void Death()
        {
            if (destroy)
                Destroy(gameObject);
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}