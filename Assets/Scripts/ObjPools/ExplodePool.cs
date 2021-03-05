using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A2
{
    public class ExplodePool : SingletonMono<ExplodePool>
    {
        public ObjPool<GameObject> explodePool = new ObjPool<GameObject>(1);
        public GameObject explodePrefab;

        void Start()
        {
            explodePool.init += NewExplode;
            explodePool.reset += ResetExplode;
        }

        private GameObject NewExplode()
        {
            //刷爆炸
            GameObject obj = Instantiate(explodePrefab,transform);
            return obj;
        }

        private void ResetExplode(GameObject obj)
        {
            //obj.GetComponent<Rigidbody>().velocity=Vector3.zero;
        }
    }
}
