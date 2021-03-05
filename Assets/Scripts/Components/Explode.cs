using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A2
{
    public class Explode : MonoBehaviour
    {
        [Header("Customizable Options")]
        //How long before the explosion prefab is destroyed
        public float despawnTime = 3.0f;
        //How long the light flash is visible
        public float lightDuration = 0.02f;
        [Header("Light")]
        public Light lightFlash;

        [Header("Audio")]
        public AudioClip[] explosionSounds;
        public AudioSource audioSource;

        private IEnumerator LightFlash () {
            //Show the light
            lightFlash.GetComponent<Light>().enabled = true;
            //Wait for set amount of time
            yield return new WaitForSeconds (lightDuration);
            //Hide the light
            lightFlash.GetComponent<Light>().enabled = false;
        }

        public void DestroySelfBegin()
        {
            //Get a random impact sound from the array
            audioSource.clip = explosionSounds
            [Random.Range(0, explosionSounds.Length)];
            //Play the random explosion sound
            audioSource.Play();
            StartCoroutine(coroutineExplode(despawnTime));
            StartCoroutine(LightFlash());
        }

        IEnumerator coroutineExplode(float seconds){
            yield return new WaitForSeconds(seconds);
            ExplodePool.Instance.explodePool.Store(this.gameObject);
            this.gameObject.SetActive(false);
        }
        
    }
}