using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD53.Ship
{
    public class Loot : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            // TODO: add a timer for looting
            other.gameObject.GetComponent<Looter>()?.SetLoot(1);
        }
    }
}
