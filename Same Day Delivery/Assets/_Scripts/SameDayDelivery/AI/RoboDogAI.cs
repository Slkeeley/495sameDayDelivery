using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SameDayDelivery.AI
{
    public class RoboDogAI : MonoBehaviour
    {
        [SerializeField]
        private int _bodyIdleAnimations = 2;
        [SerializeField]
        private int _headIdleAnimations = 2;
        [SerializeField]
        private float _responseTime = 0.15f;

        [SerializeField]
        private Transform _player;
        
        private Animator _animator;
        
        private static readonly int BodyIdleAnim = Animator.StringToHash("BodyIdle");
        private static readonly int HeadIdleAnim = Animator.StringToHash("HeadIdle");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            EstablishPlayer();
            StartCoroutine(Think());
        }

        private IEnumerator Think()
        {
            while (true)
            {
                yield return new WaitForSeconds(_responseTime);
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
            _animator.SetInteger(HeadIdleAnim, Random.Range(0, _bodyIdleAnimations));
        }
    }
}