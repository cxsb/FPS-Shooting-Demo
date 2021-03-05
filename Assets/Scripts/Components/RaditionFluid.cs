using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace A2
{
    public class RaditionFluid : MonoBehaviour
    {
        void OnTriggerStay(Collider collider)
        {
            var hitReciever = collider.gameObject.GetComponent<HitReciever>();
            if(hitReciever!=null)
            {
                hitReciever.RecieveHit(1);
            }
        }
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
