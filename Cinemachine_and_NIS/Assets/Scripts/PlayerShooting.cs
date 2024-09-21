using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject laserPrefab;

    int timerCondition;

    PlayerInputReader input;

    Player playerInfo = new Player();
    Timer cooldownTimer = new Timer();

    // Start is called before the first frame update
    void Start()
    {
        // Subscribes shooting to PlayerInputReader
        input = gameObject.GetComponent<PlayerInputReader>();
        input.OnShoot += Shooting;
    }

    // Update is called once per frame
    void Update()
    {
        // Increments the cooldown timer
        // Cooldown time is determined by playerInfo
        timerCondition = cooldownTimer.DiscreteTimer(playerInfo.fireCooldown);
    }

    void Shooting()
    {
        // Shoots if cooldown timer is complete
        if(timerCondition == 0)
        {
            Instantiate(laserPrefab, transform.position + Vector3.up, Quaternion.identity);
            cooldownTimer.TurnTimerOn(true);
        }
    }
}
