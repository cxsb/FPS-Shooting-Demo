using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace A2
{
    public class GunAudioCtrl : MonoBehaviour
    {
        [System.Serializable]
        public class soundClips
        {
            public AudioClip shootSound;
            public AudioClip takeOutSound;
            public AudioClip reloadSoundOutOfAmmo;
            public AudioClip reloadSoundAmmoLeft;
        }
        public soundClips SoundClips;

        public AudioSource gunAudioSource;
        public AudioSource shootAudioSource;

        public Gun gun;
        
        private void Start() 
        {
            init();
        }

        public void init()
        {
            gun.actionShoot += Shoot;
            gun.actionReload += Reload;
        }

        private void Shoot(bool isAim)
        {
            shootAudioSource.clip = SoundClips.shootSound;
            shootAudioSource.Play();
        }

        private void Reload(bool isSingle,bool isEmpty)
        {
            if(!isSingle)
            {
                if(isEmpty)
                {
                    gunAudioSource.clip = SoundClips.reloadSoundOutOfAmmo;
                    gunAudioSource.Play ();
                }
                else
                {
                    gunAudioSource.clip = SoundClips.reloadSoundAmmoLeft;
                    gunAudioSource.Play ();
                }
            }
        }

    }
}