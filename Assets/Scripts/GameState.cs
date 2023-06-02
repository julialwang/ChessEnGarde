using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class GameState : MonoBehaviour
{
    private GameObject[] whitePieces = new GameObject[16];
    public static bool playerTurn = true;
    //public static TMP_Text whiteTime;
    //public static TMP_Text blackTime;
    //public static TMP_Text gameOver;
    //private float white;
    //private float black;


    // Start is called before the first frame update
    void Start()
    {
        //gameOver.gameObject.SetActive(false);
        playerTurn = true;
        whitePieces = GameObject.FindGameObjectsWithTag("White");
        whitePieces = GameObject.FindGameObjectsWithTag("Black");
        //whiteTime = this.transform.FindDeepChild("White").gameObject.GetComponent<TMP_Text>();
        //blackTime = this.transform.FindDeepChild("Black").gameObject.GetComponent<TMP_Text>();
    }

    private void Update()
    {
        if (!playerTurn)
        {
            //float currTime = black += Time.deltaTime;
            //float seconds = Mathf.CeilToInt(currTime % 60);
            //blackTime.text = string.Format("{0:0}", seconds);
            foreach (GameObject piece in whitePieces)
            {
                piece.SetActive(false);
            }
        } else
        {
            //float currTime = white += Time.deltaTime;
            //float seconds = Mathf.CeilToInt(currTime % 60);
            //whiteTime.text = string.Format("{0:0}", seconds);
            foreach (GameObject piece in whitePieces)
            {
                piece.SetActive(true);
            }
        }
    }
}
