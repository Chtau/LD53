using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD53.Shared
{
    public class ShouldDestroy : MonoBehaviour
    {
        public AudioSource audioSource;

        public void Now()
        {
            transform.GetChild(0).gameObject.SetActive(false);
            audioSource.Play();
            Destroy(gameObject, 5f);
        }
    }
}
