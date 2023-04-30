using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace LD53.Cannon
{
    public class Shoot : MonoBehaviour
    {
        public Transform spawnPoint;
        public Bullet prefab;
        [Tooltip("Projectile speed")]
        public float speed = 10f;
        [Tooltip("Input to be used with this shooting skill.")]
        public string buttonName = "Fire1";

        private void Update()
        {
            if (Input.GetButtonDown(buttonName))
            {
                Bullet bullet = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation, transform);
                bullet.SetParentId(gameObject.GetInstanceID());
                bullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * speed;
            }
        }
    }
}
