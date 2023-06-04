using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class DuelLogic : MonoBehaviour
{
    private bool inCountdown;
    private bool holstered;
    private float timeLeft;
    private Vector3 directionR;
    private Vector3 directionL;
    private TMP_Text Timer;
    private TMP_Text Label;
    private SimpleShoot Gun;
    private int shotsRemaining;
    public string nextScene;

    public bool shotsFired;
    public static bool enemyHit;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = 3.0f;
        inCountdown = true;
        holstered = false;
        shotsFired = false;
        enemyHit = false;
        Timer = this.transform.FindDeepChild("TimerText").gameObject.GetComponent<TMP_Text>();
        Label = this.transform.FindDeepChild("TimerLabel").gameObject.GetComponent<TMP_Text>();
        Gun = GameObject.Find("M1911 Handgun_Model").GetComponent<SimpleShoot>();
    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.XR.InputDevice handR = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        UnityEngine.XR.InputDevice handL = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        handR.TryGetFeatureValue(UnityEngine.XR.CommonUsages.deviceRotation, out Quaternion rotR);
        handL.TryGetFeatureValue(UnityEngine.XR.CommonUsages.deviceRotation, out Quaternion rotL);
        handR.TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out bool rightGripPressed);
        handL.TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out bool leftGripPressed);
        directionR = rotR * Vector3.forward;
        directionL = rotL * Vector3.forward;
        DetermineHolstered(leftGripPressed, rightGripPressed);
        ChangeDuelPrompt();
    }

    void DetermineHolstered(bool leftHeld, bool rightHeld) {
        if ((directionL.y >= -1.0f && directionL.y < -0.8f && leftHeld) || 
            (directionR.y >= -1.0f && directionR.y < -0.8f && rightHeld)) {
            holstered = true;
        } else {
            holstered = false;
        }
    }

    void FinishDuel() {
        SceneManager.LoadScene(nextScene);
    }

    void ChangeDuelPrompt() {
        if (!inCountdown && timeLeft <= 0 && Gun.shotsRemaining <= 0 && Gun.hitObjectTag.Equals("Enemy")) {
            Debug.Log("Enemy killed.");
            Timer.text = " ";
            Label.text = "You killed the enemy!";
            shotsFired = true;
            enemyHit = true;
            Invoke("FinishDuel", 1.5f);
        } else if (!inCountdown && timeLeft <= 0 && Gun.shotsRemaining <= 0 && !Gun.hitObjectTag.Equals("Enemy")) {
            Debug.Log("Enemy hit.");
            Timer.text = " ";
            Label.text = "You missed the enemy!";
            shotsFired = true;
            enemyHit = false;
        } else if (inCountdown && holstered && timeLeft <= 0 && Gun.shotsRemaining > 0) {
            Debug.Log("Waiting for shot.");
            inCountdown = false;
            Timer.text = string.Format("{0:0}", 0);
            Label.text = "SHOOT!";
            timeLeft = 0f;
        } else if (inCountdown && timeLeft > 0f && holstered && Gun.shotsRemaining > 0) {
            Debug.Log("Counting down.");
            Label.text = "Counting down...";
            timeLeft -= Time.deltaTime;
            float seconds = Mathf.CeilToInt(timeLeft % 60);
            Timer.text = string.Format("{0:0}", seconds);
        } else if (inCountdown && !holstered) {
            Debug.Log("Resetting countdown.");
            ResetCountdown();
        }
    }

    public void AllowCountdown()
    {
        inCountdown = true;
    }

    public void ResetCountdown()
    {
        timeLeft = 3.0f;
        holstered = false;
        Label.text = "Please holster your weapon.";
    }
}

public static class TransformDeepChildExtension
 {
     //Breadth-first search
     public static Transform FindDeepChild(this Transform aParent, string aName)
     {
         Queue<Transform> queue = new Queue<Transform>();
         queue.Enqueue(aParent);
         while (queue.Count > 0)
         {
             var c = queue.Dequeue();
             if (c.name == aName)
                 return c;
             foreach(Transform t in c)
                 queue.Enqueue(t);
         }
         return null;
     }    
 }
