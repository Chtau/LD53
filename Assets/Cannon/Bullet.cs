using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD53.Cannon
{
    public class Bullet : MonoBehaviour
    {
        [Tooltip("Time till the projectile will be destroyed if it doesnt hit something.")]
        public float lifeTime = 5f;
        [Tooltip("Damage which will be applied to the \"Life\" component.")]
        public int damage = 10;

        private void Awake()
        {
            Destroy(gameObject, lifeTime);
        }

        private void OnCollisionEnter(Collision collision)
        {
            collision.gameObject.GetComponentInParent<Ship.Life>()?.IncomingHit(damage);
            Destroy(gameObject);
        }
    }
}
