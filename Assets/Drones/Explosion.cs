using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD53.Drones
{
    public class Explosion : MonoBehaviour
    {
        public AudioSource audioSource;

        [Tooltip("Damage which will be applied to the \"Life\" component.")]
        public int damage = 25;

        private void OnCollisionEnter(Collision collision)
        {
            if (transform.GetChild(0).gameObject.activeSelf)
            {
                collision.gameObject.GetComponentInParent<Ship.Life>()?.IncomingHit(damage);
                transform.GetChild(0).gameObject.SetActive(false);
                audioSource.Play();
                Destroy(gameObject, 5f);
            }
        }
    }
}
