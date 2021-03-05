using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace A2
{
    public class PlayerHealthBar : MonoBehaviour
    {
        public Transform healthBar;
        public HitReciever hitReciever;
        // Start is called before the first frame update
        void Start()
        {
            Transform bar=healthBar.Find("Fill Area").Find("Fill");
            bar.gameObject.GetComponent<Image>().color = new Color(0.2f, 1f, 0.2f, 1f);
            hitReciever.healthState.actionHealthChange += UpdateHealthBar;
            UpdateHealthBar();
        }

        // Update is called once per frame
        void UpdateHealthBar()
        {
            healthBar.gameObject.GetComponent<Slider>().value = hitReciever.healthState.health/(float)hitReciever.healthState.healthMax;
        }
    }
}