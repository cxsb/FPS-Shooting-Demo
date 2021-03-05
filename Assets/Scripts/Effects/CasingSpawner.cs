using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A2
{
    public class CasingSpawner : MonoBehaviour
    {
        public Transform spawnPoint;
        public Gun gun;

        void Start()
        {
            gun.actionShoot += Shoot;
        }
        
        private void Shoot(bool isAim)
        {
            GameObject casing = CasingPool.Instance.rifleCasingPool.New();
            casing.SetActive(true);
            casing.transform.position = spawnPoint.position;
            casing.transform.rotation = spawnPoint.rotation;
            casing.GetComponent<Casing>().PopOut(spawnPoint);
        }
    }
}
