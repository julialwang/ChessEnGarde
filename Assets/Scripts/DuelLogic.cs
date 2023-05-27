using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class DuelLogic : MonoBehaviour
{
    private bool gunHeld;
    private bool inCountdown;
    private float timeLeft;

    public Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        gunHeld = false;
        inCountdown = false;
        timeLeft = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.XR.InputDevice handR = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        handR.TryGetFeatureValue(UnityEngine.XR.CommonUsages.deviceRotation, out Quaternion rotR);
        Vector3 direction = rotR * Vector3.forward;
        // Debug.Log("rotR: " + rotR);  // about positive pi/4 is when controller is facing downward!
        if (gunHeld && !inCountdown) {
            Debug.Log("DIRECTION: " + direction);
        } else if (gunHeld) {
            timeLeft -= Time.deltaTime;
            Debug.Log("TIME LEFT: " + timeLeft);
        }
    }

    void ResetCountdown()
    {
        // reset variables for the update to begin checking again
        // display help text to instruct user how to start the duel
    }
}
