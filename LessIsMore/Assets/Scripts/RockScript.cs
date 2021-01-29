using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScript : MonoBehaviour
{
    private AudioSource hitAudio;

    private void Awake()
    {
        hitAudio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            this.gameObject.tag = "Untagged";
            hitAudio.Play();
        }
        if(collision.gameObject.CompareTag("Player") && this.gameObject.CompareTag("Ground"))
        {
            hitAudio.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Death"))
        {
            Destroy(this.gameObject);
        }
    }
}
