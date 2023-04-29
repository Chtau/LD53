using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD53.Cannon
{
    public class Shoot : MonoBehaviour
    {
        public Transform spawnPoint;
        public GameObject prefab;
        [Tooltip("Projectile speed")]
        public float speed = 10f;
        [Tooltip("Input to be used with this shooting skill.")]
        public string buttonName = "Fire1";

        private void Update()
        {
            if (Input.GetButtonDown(buttonName))
            {
                var bullet = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
                bullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * speed;
            }
        }
    }
}
