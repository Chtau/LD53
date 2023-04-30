using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD53.Drones
{
    public class MoveTo : MonoBehaviour
    {
        public float speed = 1f;

        private GameObject target;

        private void Update()
        {
            if (target)
            {
                // follow the player
                // try to shoot the player
                transform.LookAt(target.transform);
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
        }

        public void Target(GameObject obj)
        {
            target = obj;
        }

        public void Clear()
        {
            // wait or go back to the start position?
            target = null;
        }
    }
}
