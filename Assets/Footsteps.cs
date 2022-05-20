using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioClip[] foostepsOnGrass;
    public AudioClip[] foostepsOnStone;
    public AudioClip[] foostepsOnWood;

    public string material;

    public FirstPersonMovement character;
    public GroundCheck groundCheck;
    public float velocityThreshold = .01f;
    Vector2 lastCharacterPosition;

    Vector2 CurrentCharacterPosition => new Vector2(character.transform.position.x, character.transform.position.z);


    void Reset()
    {
        // Setup stuff.
        character = GetComponentInParent<FirstPersonMovement>();
        groundCheck = (transform.parent ?? transform).GetComponentInChildren<GroundCheck>();
    }

    void FixedUpdate()
    {
        // Play moving audio if the character is moving and on the ground.
        float velocity = Vector3.Distance(CurrentCharacterPosition, lastCharacterPosition);
        if (velocity >= velocityThreshold && groundCheck && groundCheck.isGrounded)
        {
            PlayFootstepSound();
        }

        // Remember lastCharacterPosition.
        lastCharacterPosition = CurrentCharacterPosition;
    }

    void PlayFootstepSound()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.volume = Random.Range(0.9f, 1.0f);
        audioSource.pitch = Random.Range(0.9f, 1.1f);

        switch (material)
        {
            case "Grass":
                if (foostepsOnGrass.Length > 0 && !audioSource.isPlaying)
                    audioSource.PlayOneShot(foostepsOnGrass[Random.Range(0, foostepsOnGrass.Length)]);
                break;

            case "Stone":
                if (foostepsOnStone.Length > 0 && !audioSource.isPlaying)
                    audioSource.PlayOneShot(foostepsOnStone[Random.Range(0, foostepsOnStone.Length)]);
                break;

            case "Wood":
                if (foostepsOnWood.Length > 0 && !audioSource.isPlaying)
                    audioSource.PlayOneShot(foostepsOnWood[Random.Range(0, foostepsOnWood.Length)]);
                break;

            default:
                break;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Grass":
            case "Stone":
            case "Wood":
                material = collision.gameObject.tag;
                break;

            default:
                break;
        }
    }

    private void Awake()
    {
        int test;
    }
}
