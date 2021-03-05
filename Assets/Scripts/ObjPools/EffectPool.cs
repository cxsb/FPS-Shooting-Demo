using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A2
{
    public class EffectPool : SingletonMono<EffectPool>
    {
        public ObjPool<GameObject> bloodImpactPool = new ObjPool<GameObject>(1);
        public ObjPool<GameObject> dirtImpactPool = new ObjPool<GameObject>(1);
        public ObjPool<GameObject> concreteImpactPool = new ObjPool<GameObject>(1);
        public ObjPool<GameObject> metalImpactPool = new ObjPool<GameObject>(1);
        public GameObject bloodImpactPrefab;
        public GameObject dirtImpactPrefab;
        public GameObject concreteImpactPrefab;
        public GameObject metalImpactPrefab;

        void Start()
        {
            bloodImpactPool.init += NewBloodImpact;
            bloodImpactPool.reset += ResetBloodImpact;
            dirtImpactPool.init += NewDirtImpact;
            dirtImpactPool.reset += ResetDirtImpact;
            concreteImpactPool.init += NewConcreteImpact;
            concreteImpactPool.reset += ResetConcreteImpact;
            metalImpactPool.init += NewMetalImpact;
            metalImpactPool.reset += ResetMetalImpact;
        }

        private GameObject NewBloodImpact()
        {
            GameObject obj = Instantiate(bloodImpactPrefab,transform);
            return obj;
        }

        private void ResetBloodImpact(GameObject obj)
        {
            
        }

        private GameObject NewDirtImpact()
        {
            GameObject obj = Instantiate(dirtImpactPrefab,transform);
            return obj;
        }

        private void ResetDirtImpact(GameObject obj)
        {
            
        }

        private GameObject NewConcreteImpact()
        {
            GameObject obj = Instantiate(concreteImpactPrefab,transform);
            return obj;
        }

        private void ResetConcreteImpact(GameObject obj)
        {
            
        }

        private GameObject NewMetalImpact()
        {
            GameObject obj = Instantiate(metalImpactPrefab,transform);
            return obj;
        }

        private void ResetMetalImpact(GameObject obj)
        {
            
        }
    }
}

