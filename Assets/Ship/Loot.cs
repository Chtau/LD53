using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD53.Ship
{
    public class Loot : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            other.gameObject.GetComponent<Looter>()?.SetLoot(1);
        }

        private void OnTriggerExit(Collider other)
        {
            other.gameObject.GetComponent<Looter>()?.SetLoot(0);
        }
    }
}
