using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A2
{
    [System.Serializable]
    public class Bullet : ICloneable<Bullet>
    {
        public float range;
        public int damageTemp;
        public int difShield;
        public int difFlesh;
        public int difArmor;

        public Bullet(float range, int damageTemp, int difShield, int difFlesh, int difArmor)
        {
            this.range = range;
            this.damageTemp = damageTemp;
            this.difShield = difShield;
            this.difFlesh = difFlesh;
            this.difArmor = difArmor;
        }

        public Bullet Critical(float criticalDamage)
        {
            return new Bullet(range, (int)(damageTemp * criticalDamage), difShield, difFlesh, difArmor);
        }

        public Bullet Clone()
        {
            return new Bullet(range, damageTemp, difShield, difFlesh, difArmor);
        }
    }

    public class HitSender : MonoBehaviour
    {
        public void DealDamage(HitReciever hitReciever, Vector3 hitPos, Bullet Bullet)
        {
            if(hitReciever!=null)
            {
                int trueDamage=hitReciever.RecieveHit(Bullet.damageTemp);
            }
        }
    }
}
