using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD53.Cannon
{
    public class Move : MonoBehaviour
    {
        public float speed = 10.0f;

        private void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            float up = Input.GetKey("e") ? 1 : (Input.GetKey("q") ? -1 : 0);

            Vector3 movement = new Vector3(horizontal, up, vertical);
            transform.Translate(movement * speed * Time.deltaTime);
        }
    }
}
