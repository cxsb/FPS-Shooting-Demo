using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A2
{
    public class HitReciever : MonoBehaviour
    {
        public HealthState healthState;
        public float ratio = 1;
        public int RecieveHit(int damage)
        {
            int _damage = (int)(ratio * damage);
            if (healthState.health - _damage <= 0)
            {
                int realDamage = healthState.health;
                healthState.health = 0;
                healthState.HealthChange();
                healthState.Death();
                return realDamage;
            }
            else
            {
                healthState.health -= _damage;
                healthState.HealthChange();
                return _damage;
            }
        }

        public int ReverseHealth(int reverse)
        {
            if (healthState.health+reverse>healthState.healthMax)
            {
                int realReverse = healthState.healthMax - healthState.health;
                healthState.health = healthState.healthMax;
                healthState.HealthChange();
                return realReverse;
            }
            else
            {
                healthState.health += reverse;
                healthState.HealthChange();
                return reverse;
            }
        }
    }
}