using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SameDayDelivery.Utility
{
    public class PassiveBobbing : MonoBehaviour
    {
        public float amplitude = 1f;
        public float frequency = 1f;
        public bool outOfSync = true;
        [Header("Random Position Offset")]
        public Vector3 minPos = Vector3.zero;
        public Vector3 maxPos = Vector3.zero;
        private Vector3 _originalPosition;
        private float _offset;
        private Rigidbody _rb;
        [SerializeField]
        private float _updateInterval = 0.005f;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            
            var x = Random.Range(minPos.x, maxPos.x);
            var y = Random.Range(minPos.y, maxPos.y);
            var z = Random.Range(minPos.z, maxPos.z);
            transform.localPosition += new Vector3(x, y, z);
            _originalPosition = transform.localPosition;
            _offset = outOfSync ? Random.Range(1f, 10f) : 1f;

            StartCoroutine(Bobbing());
        }

        private IEnumerator Bobbing()
        {
            // a little redundant, but designed this way for performance efficiency
            if (_rb)
            {
                while (true)
                {
                    if (_rb.useGravity) yield break;
                    transform.localPosition = _originalPosition +
                                              Vector3.up * (amplitude * Mathf.Sin(frequency * Time.time * _offset));
                    yield return new WaitForSeconds(_updateInterval);
                }
            }
            else
            {
                while (true)
                {
                    transform.localPosition = _originalPosition +
                                              Vector3.up * (amplitude * Mathf.Sin(frequency * Time.time * _offset));
                    yield return new WaitForSeconds(_updateInterval);
                }
            }
        }
    }
}