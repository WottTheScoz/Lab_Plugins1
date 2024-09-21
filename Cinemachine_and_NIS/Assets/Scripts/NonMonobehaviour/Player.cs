using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    // Movement info
    public float speed {get; private set;} = 6f;
    public float hScreenLimit {get; private set;}  = 10f;
    public float vScreenLimit {get; private set;} = 6f;

    // Attack info
    public float fireCooldown {get; private set;} = 0.5f;
}
