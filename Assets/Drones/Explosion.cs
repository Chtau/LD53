using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD53.Drones
{
    public class Explosion : MonoBehaviour
    {
        [Tooltip("Damage which will be applied to the \"Life\" component.")]
        public int damage = 25;

        private void OnCollisionEnter(Collision collision)
        {
            collision.gameObject.GetComponentInParent<Ship.Life>()?.IncomingHit(damage);
            Destroy(gameObject);
        }
    }
}
