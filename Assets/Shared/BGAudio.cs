using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD53.Shared
{
    public class BGAudio : MonoBehaviour
    {
        private AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.ignoreListenerPause = true;
            audioSource.ignoreListenerVolume = true;
        }
    }
}
