using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A2
{
    public class RigidBullet : MonoBehaviour
    {
        private HitSender hitsSender;
        private Bullet bullet;


        private void OnTriggerEnter(Collider other)
        {
            GameObject _explode = ExplodePool.Instance.explodePool.New();
            Collider[] colliders = Physics.OverlapSphere(transform.position, bullet.range);
            for (int i = 0; i < colliders.Length; i++)
            {
                var hitReciever = colliders[i].gameObject.GetComponent<HitReciever>();
                if(hitReciever != null)
                {
                    hitsSender.DealDamage(hitReciever,colliders[i].gameObject.transform.position,bullet);
                }
            }
            _explode.gameObject.transform.position = transform.position;
            _explode.SetActive(true);
            _explode.GetComponent<Explode>().DestroySelfBegin();
            RigidBulletPool.Instance.rocketPool.Store(this.gameObject);
            gameObject.SetActive(false);
        }

        public void SetHitSender(HitSender hitsSender)
        {
            this.hitsSender = hitsSender;
        }

        public void SetBullet(Bullet bullet)
        {
            this.bullet=bullet;
            StartCoroutine(waitToDie(3));
        }

        IEnumerator waitToDie(float seconds){
            yield return new WaitForSeconds(seconds);
            RigidBulletPool.Instance.rocketPool.Store(this.gameObject);
            gameObject.SetActive(false);
        }

    }
}
