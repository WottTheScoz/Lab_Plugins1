using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MeteorEffects : MonoBehaviour
{
    public float shakeIntensity = 5f;
    public float shakeDuration = 0.01f;

    bool startTimer;

    int shakeTimerStatus;

    GameObject vCameraObj;

    Meteor meteorCollision;
    CinemachineVirtualCamera cinemachine;
    CinemachineBasicMultiChannelPerlin cmMCP;

    Timer shakeTimer = new Timer();

    // Start is called before the first frame update
    void Start()
    {
        vCameraObj = GameObject.FindWithTag("VirtualCamera");
        cinemachine = vCameraObj.GetComponent<CinemachineVirtualCamera>();
        cmMCP = cinemachine.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        meteorCollision = gameObject.GetComponent<Meteor>();
        meteorCollision.OnDeath += ShakeCamera;
    }

    // Update is called once per frame
    void Update()
    {
        shakeTimerStatus = shakeTimer.LoopingTimer(shakeDuration);
        if(shakeTimerStatus == 0)
        {
            cmMCP.m_AmplitudeGain = 0f;
            shakeTimer.TurnTimerOn(false);
        }
    }

    void ShakeCamera()
    {
        cmMCP.m_AmplitudeGain = shakeIntensity;

        shakeTimer.ResetTimer();
        shakeTimer.TurnTimerOn(true);
    }
}
