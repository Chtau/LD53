using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD53.Ship
{
    public class Looter : MonoBehaviour
    {
        public void SetLoot(int loot)
        {
            Debug.Log($"Looted: {loot}");
        }
    }
}
