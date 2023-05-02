using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace SameDayDelivery.AI
{
    public class RoboDogAI : MonoBehaviour
    {
        [SerializeField]
        private int _bodyIdleAnimations = 2;
        [SerializeField]
        private int _headIdleAnimations = 2;
        [SerializeField, Tooltip("How long to wait between thought cycles.")]
        private float _responseTime = 0.15f;
        [SerializeField, Tooltip("How many units away does the dog spot the player, and begin chasing Sheldon.")]
        private float _aggroRange = 15f;
        [SerializeField, Tooltip("")]
        private float speed = 8f;
        [FormerlySerializedAs("ActivateRobotAIAtStart")]
        [SerializeField, Tooltip("")]
        private bool _activateRobotAIAtStart = true;

        [SerializeField]
        private Transform _player;
        
        private Animator _animator;
        
        private static readonly int BodyIdleAnim = Animator.StringToHash("BodyIdle");
        private static readonly int HeadIdleAnim = Animator.StringToHash("HeadIdle");
        private float _distanceFromPlayer;
        private Rigidbody _rb;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _rb = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            if (_activateRobotAIAtStart)
                ActivateAI();
        }

        private void ActivateAI()
        {
            EstablishPlayer();
            StartCoroutine(Think());
        }

        private IEnumerator Think()
        {
            while (true)
            {
                yield return new WaitForSeconds(_responseTime);

                Vector3 pos = transform.position;
                Vector3 playerPos = _player.position;

                pos.y = 0f;
                playerPos.y = 0f;
                
                _distanceFromPlayer = Vector3.Distance(pos, playerPos);

                if (_distanceFromPlayer <= _aggroRange)
                {
                    Vector3 direction = (playerPos - pos).normalized;
                    transform.forward = direction;
                    _rb.velocity = direction * speed;
                }
            }
        }

        private void EstablishPlayer()
        {
            if (_player) return;
            GameObject playerGo = GameObject.FindWithTag("Player");
            if (playerGo)
                _player = playerGo.transform;
        }

        public void ChooseRandomIdleBody()
        {
            _animator.SetInteger(BodyIdleAnim, Random.Range(0, _bodyIdleAnimations));
        }

        public void ChooseRandomIdleHead()
        {
            _animator.SetInteger(HeadIdleAnim, Random.Range(0, _headIdleAnimations));
        }
    }
}