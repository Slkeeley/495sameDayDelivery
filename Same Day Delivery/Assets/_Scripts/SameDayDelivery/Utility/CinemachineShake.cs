using System;
using System.Collections;
using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

namespace SameDayDelivery.Utility
{
    public class CinemachineShake : MonoBehaviour
    {
        public static CinemachineShake Instance { get; private set; }
        
        [SerializeField]
        private CinemachineFreeLook _freeLookCam;
        private CinemachineBasicMultiChannelPerlin _multiChannel;
        private float _shakeTimer;
        private float _shakeTimeOriginal;
        private float _amplitude;
        private float _frequency;

        private CinemachineBasicMultiChannelPerlin _perlineRig0;
        private CinemachineBasicMultiChannelPerlin _perlineRig1;
        private CinemachineBasicMultiChannelPerlin _perlineRig2;
        private bool _impulseShaking;

        private void Awake()
        {
            Instance = this;
            _freeLookCam = GetComponent<CinemachineFreeLook>();
            _perlineRig0 = _freeLookCam.GetRig(0).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            _perlineRig1 = _freeLookCam.GetRig(1).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            _perlineRig2 = _freeLookCam.GetRig(2).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }
        
        public void ShakeCamera(float intensity, float frequency, float time)
        {
            _amplitude = intensity;
            _frequency = frequency;
            _shakeTimeOriginal = _shakeTimer = time;
            
            _perlineRig0.m_FrequencyGain = _frequency;
            _perlineRig1.m_FrequencyGain = _frequency;
            _perlineRig2.m_FrequencyGain = _frequency;
            
            _impulseShaking = true;
        }
        
        public void ShakeCamera(float intensity, float frequency)
        {
            _amplitude = intensity;
            _frequency = frequency;
            
            _perlineRig0.m_FrequencyGain = frequency;
            _perlineRig1.m_FrequencyGain = frequency;
            _perlineRig2.m_FrequencyGain = frequency;
            
            _perlineRig0.m_AmplitudeGain = intensity;
            _perlineRig1.m_AmplitudeGain = intensity;
            _perlineRig2.m_AmplitudeGain = intensity;
            
            _impulseShaking = false;
        }

        private void Update()
        {
            if (!_impulseShaking) return;
            
            if (_shakeTimer <= 0)
            {
                StopCameraShake();

                return;
            }

            _shakeTimer -= Time.deltaTime;
            
            var percentElapsed = Mathf.InverseLerp(_shakeTimeOriginal, 0f, _shakeTimer);
            _perlineRig0.m_AmplitudeGain = Mathf.Lerp(_amplitude, 0f, percentElapsed);
            _perlineRig1.m_AmplitudeGain = Mathf.Lerp(_amplitude, 0f, percentElapsed);
            _perlineRig2.m_AmplitudeGain = Mathf.Lerp(_amplitude, 0f, percentElapsed);
        }

        public void StopCameraShake(bool graduallyStop)
        {
            _perlineRig0.m_AmplitudeGain = 0f;
            _perlineRig1.m_AmplitudeGain = 0f;
            _perlineRig2.m_AmplitudeGain = 0f;

            _perlineRig0.m_FrequencyGain = 0f;
            _perlineRig1.m_FrequencyGain = 0f;
            _perlineRig2.m_FrequencyGain = 0f;

            _impulseShaking = graduallyStop;
        }

        public void StopCameraShake()
        {
            _perlineRig0.m_AmplitudeGain = 0f;
            _perlineRig1.m_AmplitudeGain = 0f;
            _perlineRig2.m_AmplitudeGain = 0f;

            _perlineRig0.m_FrequencyGain = 0f;
            _perlineRig1.m_FrequencyGain = 0f;
            _perlineRig2.m_FrequencyGain = 0f;

            _impulseShaking = false;
        }
    }
}