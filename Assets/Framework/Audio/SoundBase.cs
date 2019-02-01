using UnityEngine;

namespace PlantsVsZombies.Audio
{
    public class SoundBase : MonoBehaviour
    {
        private AudioSource _audioSource;

        private bool _isPlayed;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.playOnAwake = false;
        }

        public void play(AudioClip audioClip, float volume)
        {
            _audioSource.clip = audioClip;

            _isPlayed = true;
            
            _audioSource.Play();
        }

        private void Update()
        {
            if(!_isPlayed) return;
            if(_audioSource.isPlaying) return;
            
//           Core.Instance.get<FactorySound>()
        }
    }
}