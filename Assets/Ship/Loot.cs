using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD53.Ship
{
    public class Loot : MonoBehaviour
    {
        public int LootIndex = 1;

        private void OnTriggerEnter(Collider other)
        {
            other.gameObject.GetComponent<Looter>()?.SetLoot(LootIndex);
        }

        private void OnTriggerExit(Collider other)
        {
            other.gameObject.GetComponent<Looter>()?.SetLoot(0);
        }
    }
}
