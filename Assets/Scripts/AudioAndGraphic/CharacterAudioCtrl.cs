using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace A2
{
    public class CharacterAudioCtrl : MonoBehaviour
    {
        [System.Serializable]
        public class soundClips
        {
            public AudioClip walkSound;
            public AudioClip runSound;
        }
        public soundClips SoundClips;

        public AudioSource mainAudioSource;

        public Character player;
        
        private void Start () 
        {
            init();
        }

        public void init()
        {
            player.actionRun += Run;
            player.actionMove += Move;

            mainAudioSource.loop = true;
        }

        private void Run(bool isRun)
        {
            if(isRun) RunBegin();
            else RunFinish();
        }

        private void Move(bool isMove)
        {
            if(isMove) MovBegin();
            else MovFinish();
        }

        private void MovBegin()
        {
            mainAudioSource.clip = SoundClips.walkSound;
            mainAudioSource.Play ();
        }

        private void MovFinish()
        {
            mainAudioSource.Pause();
        }

        private void RunBegin()
        {
            mainAudioSource.clip = SoundClips.runSound;
            mainAudioSource.Play ();
        }

        private void RunFinish()
        {
            if(mainAudioSource.clip == SoundClips.runSound)
            {
                mainAudioSource.clip = SoundClips.walkSound;
                mainAudioSource.Play();
            }
        }

    }
}