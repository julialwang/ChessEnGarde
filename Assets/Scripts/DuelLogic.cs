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
    private Vector3 direction;
    private TMP_Text Timer;
    private TMP_Text Label;
    private SimpleShoot Gun;
    private int shotsRemaining;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = 3.0f;
        inCountdown = true;
        holstered = false;
        Timer = this.transform.FindDeepChild("TimerText").gameObject.GetComponent<TMP_Text>();
        Label = this.transform.FindDeepChild("TimerLabel").gameObject.GetComponent<TMP_Text>();
        Gun = GameObject.Find("M1911 Handgun_Model").GetComponent<SimpleShoot>();
    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.XR.InputDevice handR = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        handR.TryGetFeatureValue(UnityEngine.XR.CommonUsages.deviceRotation, out Quaternion rotR);
        direction = rotR * Vector3.forward;
        DetermineHolstered();
        ChangeDuelPrompt();
    }

    void DetermineHolstered() {
        if (direction.y >= -1.0f && direction.y < -0.8f) {
            holstered = true;
        } else {
            holstered = false;
        }
    }

    void ChangeDuelPrompt() {
        if (!inCountdown && timeLeft <= 0 && Gun.shotsRemaining <= 0 && Gun.hitObjectTag.Equals("Enemy")) {
            Debug.Log("Enemy killed.");
            Timer.text = " ";
            Label.text = "You killed the enemy!";
        } else if (!inCountdown && timeLeft <= 0 && Gun.shotsRemaining <= 0 && !Gun.hitObjectTag.Equals("Enemy")) {
            Debug.Log("Enemy hit.");
            Timer.text = " ";
            Label.text = "You missed the enemy!";
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
