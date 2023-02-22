using Cinemachine;
using UnityEngine;

namespace SameDayDelivery.Utility
{
    public class CinemachineShake : MonoBehaviour
    {
        [HideInInspector]
        public static CinemachineShake Instance { get; private set; }
        
        private CinemachineFreeLook _freeLookCam;
        private CinemachineBasicMultiChannelPerlin _multiChannel;
        private float _shakeTimer;
        private float _shakeTimeOriginal;
        private float _amplitude;
        private float _frequency;

        private CinemachineBasicMultiChannelPerlin _perlinRig0;
        private CinemachineBasicMultiChannelPerlin _perlinRig1;
        private CinemachineBasicMultiChannelPerlin _perlinRig2;
        private bool _impulseShaking;

        private void Awake()
        {
            Instance = this;
            _freeLookCam = GetComponent<CinemachineFreeLook>();
            _perlinRig0 = _freeLookCam.GetRig(0).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            _perlinRig1 = _freeLookCam.GetRig(1).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            _perlinRig2 = _freeLookCam.GetRig(2).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }
        
        public void ShakeCamera(float intensity, float frequency, float time)
        {
            _amplitude = intensity;
            _frequency = frequency;
            _shakeTimeOriginal = _shakeTimer = time;
            
            _perlinRig0.m_FrequencyGain = _frequency;
            _perlinRig1.m_FrequencyGain = _frequency;
            _perlinRig2.m_FrequencyGain = _frequency;
            
            _impulseShaking = true;
        }
        
        public void ShakeCamera(float intensity, float frequency)
        {
            _amplitude = intensity;
            _frequency = frequency;
            
            _perlinRig0.m_FrequencyGain = frequency;
            _perlinRig1.m_FrequencyGain = frequency;
            _perlinRig2.m_FrequencyGain = frequency;
            
            _perlinRig0.m_AmplitudeGain = intensity;
            _perlinRig1.m_AmplitudeGain = intensity;
            _perlinRig2.m_AmplitudeGain = intensity;
            
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
            _perlinRig0.m_AmplitudeGain = Mathf.Lerp(_amplitude, 0f, percentElapsed);
            _perlinRig1.m_AmplitudeGain = Mathf.Lerp(_amplitude, 0f, percentElapsed);
            _perlinRig2.m_AmplitudeGain = Mathf.Lerp(_amplitude, 0f, percentElapsed);
        }

        public void StopCameraShake(bool graduallyStop)
        {
            _perlinRig0.m_AmplitudeGain = 0f;
            _perlinRig1.m_AmplitudeGain = 0f;
            _perlinRig2.m_AmplitudeGain = 0f;

            _perlinRig0.m_FrequencyGain = 0f;
            _perlinRig1.m_FrequencyGain = 0f;
            _perlinRig2.m_FrequencyGain = 0f;

            _impulseShaking = graduallyStop;
        }

        public void StopCameraShake()
        {
            _perlinRig0.m_AmplitudeGain = 0f;
            _perlinRig1.m_AmplitudeGain = 0f;
            _perlinRig2.m_AmplitudeGain = 0f;

            _perlinRig0.m_FrequencyGain = 0f;
            _perlinRig1.m_FrequencyGain = 0f;
            _perlinRig2.m_FrequencyGain = 0f;

            _impulseShaking = false;
        }
    }
}