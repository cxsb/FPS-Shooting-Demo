using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A2
{
    public class RigidBulletPool : SingletonMono<RigidBulletPool>
    {
        public ObjPool<GameObject> rocketPool = new ObjPool<GameObject>(1);
        public GameObject rocketPrefab;

        void Start()
        {
            rocketPool.init += NewRocket;
            rocketPool.reset += ResetRocket;
        }

        private GameObject NewRocket()
        {
            //刷火箭
            GameObject obj = Instantiate(rocketPrefab,transform);
            return obj;
        }

        private void ResetRocket(GameObject obj)
        {
            obj.GetComponent<Rigidbody>().velocity=Vector3.zero;
        }
    }
}
