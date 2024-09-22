using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public delegate void PlayerColDelegate();
    public event PlayerColDelegate OnDeath;

    void OnTriggerEnter2D(Collider2D whatIHit)
    {
        if (whatIHit.tag == "Meteor")
        {
            OnDeath?.Invoke();
            GameObject.Find("GameManager").GetComponent<GameManager>().gameOver = true;
            Destroy(whatIHit.gameObject);
            Destroy(this.gameObject);
        }
    }
}
