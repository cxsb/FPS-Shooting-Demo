using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace A2
{
    public class GunEffectCtrl : MonoBehaviour
    {
        public ParticleSystem muzzleParticles;
	    public ParticleSystem sparkParticles;
        public Light sparkLight;

        public Gun gun;

        private void Start() 
        {
            init();
        }

        public void init()
        {
            gun.actionShoot += Shoot;
        }
        
        private void Shoot(bool isAim)
        {
            muzzleParticles.Emit(1);
            sparkParticles.Emit(UnityEngine.Random.Range (3, 6));
            StartCoroutine(coroutineSparkLight());
        }

        IEnumerator coroutineSparkLight()
        {
            sparkLight.enabled = true;
            yield return new WaitForSeconds(0.01f);
            sparkLight.enabled = false;
        }
      
    }
}