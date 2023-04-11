using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace SameDayDelivery.Utility
{
    public class AudioManager : MonoBehaviour
    {
        public AudioMixerGroup masterMixerGroup;
        public AudioMixerGroup musicMixerGroup;
        public AudioMixerGroup sfxMixerGroup;
        public AudioMixerGroup voiceMixerGroup;
        public AudioMixerGroup ambienceMixerGroup;

        public Slider masterVolumeSlider;
        public Slider musicVolumeSlider;
        public Slider sfxVolumeSlider;
        public Slider voiceVolumeSlider;
        public Slider ambienceVolumeSlider;

        [SerializeField, Tooltip("The range the sliders use.")]
        private float slideVolumeScale = 50f;

        [SerializeField, Tooltip("The value the sliders should start at.")]
        private float _startingSliderValue = 0f;

        private float _originalVolumeMaster;
        private float _originalVolumeMusic;
        private float _originalVolumeSFX;
        private float _originalVolumeVoice;
        private float _originalVolumeAmbience;

        private const string masterParam = "MasterVolume";
        private const string musicParam = "MusicVolume";
        private const string sfxParam = "SFXVolume";
        private const string voiceParam = "VoiceVolume";
        private const string ambienceParam = "AmbienceVolume";
        
        private const float audioDBMin = -80f;
        private const float audioDBMax = 20f;
        
        private void Start()
        {
            masterMixerGroup.audioMixer.GetFloat(masterParam, out _originalVolumeMaster);
            musicMixerGroup.audioMixer.GetFloat(musicParam, out _originalVolumeMusic);
            sfxMixerGroup.audioMixer.GetFloat(sfxParam, out _originalVolumeSFX);
            voiceMixerGroup.audioMixer.GetFloat(voiceParam, out _originalVolumeVoice);
            ambienceMixerGroup.audioMixer.GetFloat(ambienceParam, out _originalVolumeAmbience);

            masterVolumeSlider.minValue = 0f;
            masterVolumeSlider.maxValue = 100f;
            
            musicVolumeSlider.minValue = -slideVolumeScale;
            musicVolumeSlider.maxValue = slideVolumeScale;
            
            sfxVolumeSlider.minValue = -slideVolumeScale;
            sfxVolumeSlider.maxValue = slideVolumeScale;
            
            voiceVolumeSlider.minValue = -slideVolumeScale;
            voiceVolumeSlider.maxValue = slideVolumeScale;
            
            ambienceVolumeSlider.minValue = -slideVolumeScale;
            ambienceVolumeSlider.maxValue = slideVolumeScale;
            
            masterVolumeSlider.value = 100f;
            musicVolumeSlider.value = Mathf.Clamp(_startingSliderValue, -slideVolumeScale, slideVolumeScale);
            sfxVolumeSlider.value = Mathf.Clamp(_startingSliderValue, -slideVolumeScale, slideVolumeScale);
            voiceVolumeSlider.value = Mathf.Clamp(_startingSliderValue, -slideVolumeScale, slideVolumeScale);
            ambienceVolumeSlider.value = Mathf.Clamp(_startingSliderValue, -slideVolumeScale, slideVolumeScale);

            UpdateMasterVolume(100f);
            UpdateMusicVolume(musicVolumeSlider.value);
            UpdateSFXVolume(sfxVolumeSlider.value);
            UpdateVoiceVolume(voiceVolumeSlider.value);
            UpdateAmbienceVolume(ambienceVolumeSlider.value);
            
        }

        public void UpdateMasterVolume(float sliderVolume)
        {
            float dbPercent = Mathf.InverseLerp(0f, 100f, sliderVolume);
            float mixerValue = Mathf.Lerp(audioDBMin, 0f, dbPercent);
            masterMixerGroup.audioMixer.SetFloat(masterParam, mixerValue);
        }

        public void UpdateMusicVolume(float sliderVolume)
        {
            float dbPercent = 0f;
            float mixerValue = 0f;
            if (sliderVolume < 0f)
            {
                dbPercent = Mathf.InverseLerp(-slideVolumeScale, 0f, sliderVolume);
                mixerValue = Mathf.Lerp(audioDBMin, _originalVolumeMusic, dbPercent);
            }
            else
            {
                dbPercent = Mathf.InverseLerp(0f, slideVolumeScale, sliderVolume);
                mixerValue = Mathf.Lerp(_originalVolumeMusic, audioDBMax, dbPercent);
            }
            
            musicMixerGroup.audioMixer.SetFloat(musicParam, mixerValue);
        }

        public void UpdateSFXVolume(float sliderVolume)
        {
            float dbPercent = 0f;
            float mixerValue = 0f;
            if (sliderVolume < 0f)
            {
                dbPercent = Mathf.InverseLerp(-slideVolumeScale, 0f, sliderVolume);
                mixerValue = Mathf.Lerp(audioDBMin, _originalVolumeSFX, dbPercent);
            }
            else
            {
                dbPercent = Mathf.InverseLerp(0f, slideVolumeScale, sliderVolume);
                mixerValue = Mathf.Lerp(_originalVolumeSFX, audioDBMax, dbPercent);
            }
            sfxMixerGroup.audioMixer.SetFloat(sfxParam, mixerValue);
        }

        public void UpdateVoiceVolume(float sliderVolume)
        {
            float dbPercent = 0f;
            float mixerValue = 0f;
            if (sliderVolume < 0f)
            {
                dbPercent = Mathf.InverseLerp(-slideVolumeScale, 0f, sliderVolume);
                mixerValue = Mathf.Lerp(audioDBMin, _originalVolumeVoice, dbPercent);
            }
            else
            {
                dbPercent = Mathf.InverseLerp(0f, slideVolumeScale, sliderVolume);
                mixerValue = Mathf.Lerp(_originalVolumeVoice, audioDBMax, dbPercent);
            }
            voiceMixerGroup.audioMixer.SetFloat(voiceParam, mixerValue);
        }

        public void UpdateAmbienceVolume(float sliderVolume)
        {
            float dbPercent = 0f;
            float mixerValue = 0f;
            if (sliderVolume < 0f)
            {
                dbPercent = Mathf.InverseLerp(-slideVolumeScale, 0f, sliderVolume);
                mixerValue = Mathf.Lerp(audioDBMin, _originalVolumeAmbience, dbPercent);
            }
            else
            {
                dbPercent = Mathf.InverseLerp(0f, slideVolumeScale, sliderVolume);
                mixerValue = Mathf.Lerp(_originalVolumeAmbience, audioDBMax, dbPercent);
            }
            ambienceMixerGroup.audioMixer.SetFloat(ambienceParam, mixerValue);
        }
    }
}