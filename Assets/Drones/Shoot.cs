using LD53.Cannon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD53.Drones
{
    public class Shoot : MonoBehaviour
    {
        public AudioSource audioSource;
        public Transform spawnPoint;
        public Bullet prefab;
        [Tooltip("Projectile speed")]
        public float speed = 10f;

        private GameObject target;
        private float time;

        private void Update()
        {
            if (target != null && transform.GetChild(0).gameObject.activeSelf)
            {
                time += Time.deltaTime;
                if (time % 60 > 1)
                {
                    Bullet bullet = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation, transform);
                    bullet.SetParentId(gameObject.GetInstanceID());
                    bullet.GetComponent<Rigidbody>().velocity = (target.transform.position - spawnPoint.position).normalized * speed;
                    audioSource.Play();
                    time = 0;
                }
            }
        }

        public void InRange(GameObject obj)
        {
            target = obj;
        }

        public void Clear()
        {
            target = null;
        }
    }
}
