using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD53.Shared
{
    public class ShouldDestroy : MonoBehaviour
    {
        public void Now()
        {
            Destroy(gameObject);
        }
    }
}
