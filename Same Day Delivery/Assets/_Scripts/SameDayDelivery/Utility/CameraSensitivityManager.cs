using System;
using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace SameDayDelivery.Utility
{
    [RequireComponent(typeof(CinemachineFreeLook))]
    public class CameraSensitivityManager : MonoBehaviour
    {
        [Header("Slider")]
        [SerializeField]
        private Slider _cameraSensitivitySlider;

        [SerializeField, Tooltip("How far the slider goes negatively and positively, where 0 is the default " +
                                 "settings, and it goes up to Slider Scale and down to negative Slider Scale.")]
        private float _sliderScale = 100f;

        [Header("X-Axis")]
        [SerializeField]
        private float _xModMin = 100f;
        [SerializeField]
        private float _xModMax = 250f;
        [SerializeField]
        private float _xModStart = 225f;
        
        [Header("Y-Axis")]
        [SerializeField]
        private float _yModMin = 4f;
        [SerializeField]
        private float _yModMax = 20f;
        [SerializeField]
        private float _yModStart = 12f;

        [SerializeField]
        private CinemachineFreeLook _freeLookCam;

        private void Awake()
        {
            _freeLookCam = GetComponent<CinemachineFreeLook>();
        }

        private void Start()
        {
            _cameraSensitivitySlider.minValue = -_sliderScale;
            _cameraSensitivitySlider.maxValue = _sliderScale;
            _cameraSensitivitySlider.value = 0f;
            
            UpdateSensitivity(0f);
        }

        public void UpdateSensitivity(float modifierValue)
        {
            float xAdjustedValue = 0f;
            float yAdjustedValue = 0f;
            float sliderPercent = 0f;
            
            if (modifierValue < 0f)
            {
                sliderPercent = Mathf.InverseLerp(-_sliderScale, 0f, modifierValue);
                
                xAdjustedValue = Mathf.Lerp(_xModMin, _xModStart, sliderPercent);
                yAdjustedValue = Mathf.Lerp(_yModMin, _yModStart, sliderPercent);
            }
            else
            {
                sliderPercent = Mathf.InverseLerp(0f, _sliderScale, modifierValue);
                
                xAdjustedValue = Mathf.Lerp(_xModStart, _xModMax, sliderPercent);
                yAdjustedValue = Mathf.Lerp(_yModStart, _yModMax, sliderPercent);
            }

            _freeLookCam.m_XAxis.m_MaxSpeed = xAdjustedValue;
            _freeLookCam.m_YAxis.m_MaxSpeed = yAdjustedValue;
        }
    }
}