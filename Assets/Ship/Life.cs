using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD53.Ship
{
    public class Life : MonoBehaviour
    {
        public int life = 100;

        public void IncomingHit(int damage)
        {
            life -= damage;
            if (life <= 0)
            {
                Destroy(gameObject);
            }
            Debug.Log($"Hit for {damage}, remaining life:{life}");
        }
    }
}
