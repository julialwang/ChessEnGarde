using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class ChessPieceController : MonoBehaviour
{
    public Rigidbody rb;
    public static bool whiteMove = true;
    public static GameObject enemy;
    public string nextScene;

    // Update is called once per frame
    void Update()
    {
        rb.transform.position = new Vector3(
            RoundX(rb.transform.position.x),
            rb.transform.position.y,
            RoundZ(rb.transform.position.z));
    }

    private float RoundX(float pos)
    {
        if (pos <= -9.5)
        {
            return -11;
        } else if (pos <= -6.5 && pos > -9.5)
        {
            return -8;
        } else if (pos <= -3.5 && pos > -6.5)
        {
            return -5;
        } else if (pos <= -0.5 && pos > -3.5)
        {
            return -2;
        } else if (pos <= 2.5 && pos > -0.5)
        {
            return 1;
        } else if (pos <= 5.5 && pos > 2.5)
        {
            return 4;
        } else if (pos <= 8.5 && pos > 5.5)
        {
            return 7;
        }
        return 10;
    }

    private float RoundZ(float pos)
    {
        if (pos <= -9)
        {
            return -10.5f;
        }
        else if (pos <= -6 && pos > -9)
        {
            return -7.5f;
        }
        else if (pos <= -3 && pos > -6)
        {
            return -4.5f;
        }
        else if (pos <= 0 && pos > -3)
        {
            return -1.5f;
        }
        else if (pos <= 3 && pos > 0)
        {
            return 1.5f;
        }
        else if (pos <= 6 && pos > 3)
        {
            return 4.5f;
        }
        else if (pos <= 9 && pos > 6)
        {
            return 7.5f;
        }
        return 10.5f;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Black"))
        {
            enemy = other.gameObject;
            SceneManager.LoadScene(nextScene);
            if (DuelLogic.enemyHit)
            {
                Destroy(enemy);
            }
        }
    }
}
