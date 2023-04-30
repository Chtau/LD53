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

        private int parentId;

        private void Awake()
        {
            Destroy(gameObject, lifeTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetInstanceID() == parentId)
                return;
            var life = other.gameObject.GetComponentInParent<Ship.Life>();
            if (life != null)
            {
                life.IncomingHit(damage);
                Destroy(gameObject);
            }
        }

        public void SetParentId(int id)
        {
            parentId = id;
        }
    }
}
