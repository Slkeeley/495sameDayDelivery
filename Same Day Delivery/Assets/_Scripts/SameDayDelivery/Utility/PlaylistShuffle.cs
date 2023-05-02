using System;
using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace SameDayDelivery.Utility
{

    public class PlaylistShuffle : MonoBehaviour
    {
        public enum PlaylistType
        {
            Shuffle,
            Sequence
        }
        
        public List<AudioClip> playlist = new List<AudioClip>();
        [SerializeField, Tooltip("Shuffle = next track is randomized, Sequence = plays the next track in order.")]
        private PlaylistType _playlistType = PlaylistType.Shuffle;
        [Min(0f)] public float nextTrackDurationMin = 1f;
        [Min(0f)] public float nextTrackDurationMax = 3f;
        [Range(0f, 2f)] public float pitchVariance = 0.1f;
        public float pitchOffset = 0f;

        public bool playOnAwake;

        private AudioSource _source;
        
        [SerializeField] private bool _paused;
        [SerializeField] private float _nextTrackClock;
        [SerializeField] private int _currentTrack;

        private void Awake()
        {
            _paused = true;
            
            _source = GetComponent<AudioSource>();

            if (!playOnAwake) return;

            NextTrack(true);
        }

        public void Play()
        {
            _paused = false;
        }

        public void Pause()
        {
            _paused = true;
        }

        public void NextTrack(bool repeatCurrentTrack = false)
        {
            _paused = false;

            switch (_playlistType)
            {
                case PlaylistType.Shuffle:
                    PlayRandom(repeatCurrentTrack);
                    break;
                case PlaylistType.Sequence:
                    PlayNextSequence(repeatCurrentTrack);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void PlayNextSequence(bool repeatCurrentTrack = false)
        {
            if (playlist.Count <= 0) return;
            if (!repeatCurrentTrack)
            {
                _currentTrack++;
                if (_currentTrack >= playlist.Count) _currentTrack = 0;
            }
            
            _source.clip = playlist[_currentTrack];
            _nextTrackClock = Random.Range(nextTrackDurationMin, nextTrackDurationMax);
            _source.pitch = Mathf.Clamp(1 + pitchOffset + Random.Range(-pitchVariance, pitchVariance), -3, 3);
            _source.Play();
        }

        public void PlayRandom(bool repeatCurrentTrack = false)
        {
            if (playlist.Count <= 0) return;
            if (!repeatCurrentTrack)
            {
                _currentTrack = Random.Range(0, playlist.Count);
            }
            _source.clip = playlist[_currentTrack];
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