using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace A2
{
    public class ImpactEffect : MonoBehaviour
    {
        public HitFeedBackType feedBackType;
        [Header("Impact Despawn Timer")]
        //How long before the impact is destroyed
        public float despawnTime = 3.0f;

        [Header("Audio")]
        public AudioClip[] impactSounds;
        public AudioSource audioSource;

	    public void DestroySelfBegin()
        {
            audioSource.clip = impactSounds
            [Random.Range(0, impactSounds.Length)];
            //Play the random impact sound
            audioSource.Play();
            StartCoroutine(coroutineDisappear(despawnTime));
        }

        IEnumerator coroutineDisappear(float seconds){
            yield return new WaitForSeconds(seconds);
            if(feedBackType == HitFeedBackType.Concrete) EffectPool.Instance.concreteImpactPool.Store(this.gameObject);
            if(feedBackType == HitFeedBackType.Dirt) EffectPool.Instance.dirtImpactPool.Store(this.gameObject);
            if(feedBackType == HitFeedBackType.Metal) EffectPool.Instance.metalImpactPool.Store(this.gameObject);
            if(feedBackType == HitFeedBackType.Blood) EffectPool.Instance.bloodImpactPool.Store(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }
}