using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace A2
{
    public class GunAnimCtrl : MonoBehaviour
    {
        public Character character;
        public Gun gun;
        
        public Animator gunAnim;

        private void Start() 
        {
            init();
        }

        public void init()
        {
            character.actionRun += Run;
            character.actionMove += Move;

            gun.actionShoot += Shoot;
            gun.actionReload += Reload;
            gun.actionAim += Aim;
        }

        private void Shoot(bool isAim)
        {
            if(isAim) gunAnim.Play ("Aim Fire", 0, 0f);
            else gunAnim.Play ("Fire", 0, 0f);
        }

        private void Reload(bool isSingle, bool isUniqueMode)
        {
            if(isSingle)
            {
                if(isUniqueMode)
                {
                    gunAnim.Play ("Reload Open", 0, 0f);
                }
                else
                {
                    gunAnim.Play ("Insert Bullet 2", 0, 0f);
                }
            }
            else
            {
                if(isUniqueMode)
                {
                    gunAnim.Play ("Reload Out Of Ammo", 0, 0f);
                }
                else
                {
                    gunAnim.Play ("Reload Ammo Left", 0, 0f);
                }
            }
        }


        private void SingleReload(bool isFirstBullet)
        {
            if(isFirstBullet)
            {
                gunAnim.Play ("Reload Open", 0, 0f);
            }
            else
            {
                gunAnim.Play ("Insert Bullet 2", 0, 0f);
            }
        }

        private void Run(bool isRun)
        {
            if(isRun)
            {
                gunAnim.SetBool ("Aim", false);
                gunAnim.SetBool ("Run", true);
            }
            else gunAnim.SetBool ("Run", false);
        }

        private void Move(bool isMove)
        {
            if(isMove) gunAnim.SetBool ("Walk", true);
            else gunAnim.SetBool ("Walk", false);
        }

        private void Aim(bool isAim)
        {
            if(isAim) gunAnim.SetBool ("Aim", true);
            else gunAnim.SetBool ("Aim", false);
        }
    }
}