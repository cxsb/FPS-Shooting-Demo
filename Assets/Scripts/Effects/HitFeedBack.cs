using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A2
{
    public enum HitFeedBackType
    {            
        None =0,
        Blood = 1,
        Dirt = 2,
        Concrete = 3,
        Metal = 4
    }
    public class HitFeedBack : MonoBehaviour
    {
        public bool isStatic { 
            get
            {
                return gameObject.isStatic;
            }
        }
        public HitFeedBackType feedBackType = HitFeedBackType.None;
        public void Reflect(Vector3 position, Quaternion rotation)
        {
            GameObject bulletHole = null;
            if(feedBackType==HitFeedBackType.Blood)
            {
                bulletHole = EffectPool.Instance.bloodImpactPool.New();
            }
            if(feedBackType==HitFeedBackType.Concrete)
            {
                bulletHole = EffectPool.Instance.concreteImpactPool.New();
            }
            if(feedBackType==HitFeedBackType.Dirt)
            {
                bulletHole = EffectPool.Instance.dirtImpactPool.New();
            }
            if(feedBackType==HitFeedBackType.Metal)
            {
                bulletHole = EffectPool.Instance.metalImpactPool.New();
            }

            if(!isStatic)
            {
                bulletHole.transform.parent = transform;
            }

            bulletHole.gameObject.transform.position = position;
            bulletHole.gameObject.transform.rotation = rotation;
            bulletHole.gameObject.SetActive(true);
            bulletHole.gameObject.GetComponent<ImpactEffect>().DestroySelfBegin();
        }
    }
}
