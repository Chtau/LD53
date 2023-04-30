using LD53.Cannon;
using LD53.Ship;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LD53.Drones
{
    public class AreaTrigger : MonoBehaviour
    {
        public UnityEvent<GameObject> targetEnter;
        public UnityEvent targetClear;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<Looter>())
            {
                targetEnter?.Invoke(other.gameObject);
                return;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.GetComponent<Looter>())
            {
                targetClear?.Invoke();
            }
        }
    }
}
