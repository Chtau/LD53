using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LD53.Ship
{
    public class Life : MonoBehaviour
    {
        public int life = 100;

        public UnityEvent<int, int> LifeChanged;
        public UnityEvent Destroyed;

        private int maxLife = 100;

        private void Awake()
        {
            maxLife = life;
            LifeChanged?.Invoke(life, maxLife);
        }

        public void IncomingHit(int damage)
        {
            life -= damage;
            if (life <= 0)
            {
                Destroyed?.Invoke();
                life = 0;
            }
            LifeChanged?.Invoke(life, maxLife);
            //Debug.Log($"Hit for {damage}, remaining life:{life}");
        }
    }
}
