using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnTrigger : MonoBehaviour
{
    private AudioSource audioClip;
    private bool once;

    private void Awake()
    {
        audioClip = GetComponent<AudioSource>();
        once = false;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player") && !once)
        {
            audioClip.Play();
            once = true;
        }
    }
}
