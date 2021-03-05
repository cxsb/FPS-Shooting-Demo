using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A2
{
    public class CasingPool : SingletonMono<CasingPool>
    {
        public ObjPool<GameObject> rifleCasingPool = new ObjPool<GameObject>(1);
        public GameObject rifleCasingPrefab;

        void Start()
        {
            rifleCasingPool.init += NewRifleCasing;
            rifleCasingPool.reset += ResetRifleCasing;
        }

        private GameObject NewRifleCasing()
        {
            GameObject obj = Instantiate(rifleCasingPrefab,transform);
            return obj;
        }

        private void ResetRifleCasing(GameObject obj)
        {
            
        }
    }
}
