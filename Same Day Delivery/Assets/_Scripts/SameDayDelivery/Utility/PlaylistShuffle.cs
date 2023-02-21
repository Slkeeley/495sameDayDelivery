using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace SameDayDelivery.Utility
{

    public class PlaylistShuffle : MonoBehaviour
    {
        public List<AudioClip> playlist = new List<AudioClip>();
        [Min(0f)] public float nextTrackDurationMin = 1f;
        [Min(0f)] public float nextTrackDurationMax = 3f;
        [Range(0f, 2f)] public float pitchVariance = 0.1f;
        public float pitchOffset = 0f;

        public bool playOnAwake;

        private AudioSource _source;
        
        [SerializeField] private bool _paused;
        [SerializeField] private float _nextTrackClock;

        private void Awake()
        {
            _paused = true;
            
            _source = GetComponent<AudioSource>();

            if (!playOnAwake) return;

            _paused = false;
            
            _nextTrackClock = Random.Range(nextTrackDurationMin, nextTrackDurationMax);
        }

        public void Play()
        {
            _paused = false;
        }

        public void Pause()
        {
            _paused = true;
        }

        public void NextTrack()
        {
            _paused = false;
            
            PlayRandom();
        }

        public void PlayRandom()
        {
            if (playlist.Count <= 0) return;
            int r = Random.Range(0, playlist.Count);
            _source.clip = playlist[r];
            _nextTrackClock = Random.Range(nextTrackDurationMin, nextTrackDurationMax);
            _source.pitch = Mathf.Clamp(1 + pitchOffset + Random.Range(-pitchVariance, pitchVariance), -3, 3);
            _source.Play();
        }

        public void TogglePause()
        {
            _paused = !_paused;
        }

        private void Update()
        {
            if (_paused) return;
            
            if (_source.isPlaying) return;

            if (_nextTrackClock > 0)
            {
                _nextTrackClock -= Time.deltaTime;
                return;
            }

            NextTrack();
        }
    }

}