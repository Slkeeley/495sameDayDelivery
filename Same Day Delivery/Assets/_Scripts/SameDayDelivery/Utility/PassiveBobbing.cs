﻿using UnityEngine;

namespace SameDayDelivery.Utility
{
    public class PassiveBobbing : MonoBehaviour
    {
        public float amplitude = 1f;
        public float frequency = 1f;
        public bool outOfSync = true;
        [Header("Random Position Offset")]
        public Vector3 minPos = new Vector3(-1, -1, -1);
        public Vector3 maxPos = new Vector3(1, 1, 1);
        private Vector3 _originalPosition;
        private float _offset;

        private void Awake()
        {
            var x = Random.Range(minPos.x, maxPos.x);
            var y = Random.Range(minPos.y, maxPos.y);
            var z = Random.Range(minPos.z, maxPos.z);
            transform.localPosition += new Vector3(x, y, z);
            _originalPosition = transform.localPosition;
            _offset = outOfSync ? Random.Range(1f, 10f) : 1f;
        }

        private void Update()
        {
            transform.localPosition = _originalPosition + Vector3.up * (amplitude * Mathf.Sin(frequency * Time.time * _offset));
        }
    }
}