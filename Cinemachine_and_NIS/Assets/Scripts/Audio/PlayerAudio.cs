using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioClip laser;
    public AudioClip explosion;

    AudioSource audioSource;

    PlayerShooting shooting;
    PlayerCollision collision;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

        shooting = gameObject.GetComponent<PlayerShooting>();
        shooting.OnShoot += ShootSFX;

        collision = gameObject.GetComponent<PlayerCollision>();
        collision.OnDeath += DeathSFX;
    }

    void ShootSFX()
    {
        audioSource.clip = laser;
        audioSource.Play();
    }

    void DeathSFX()
    {
        audioSource.clip = explosion;
        AudioSource.PlayClipAtPoint(explosion, transform.position);
    }
}
