using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CPUPieceController : MonoBehaviour
{
    private GameObject[] objs;
    private int moveNum;
    public float speed = 3f;

    private void Start()
    {
        moveNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameState.playerTurn)
        {
            if (moveNum == 0)
            {
                StartCoroutine(RandomDelay());
                GameObject pawn = GameObject.Find("BlackAPawn");
                pawn.transform.position = new Vector3(
                    pawn.transform.position.x - 3f,
                    pawn.transform.position.y,
                    pawn.transform.position.z);
            } else if (moveNum == 1)
            {
                StartCoroutine(RandomDelay());
                GameObject pawn = GameObject.Find("BlackGPawn");
                pawn.transform.position = new Vector3(
                    pawn.transform.position.x - 3f,
                    pawn.transform.position.y,
                    pawn.transform.position.z);
            } else if (moveNum == 2)
            {
                StartCoroutine(RandomDelay());
                GameObject knight = GameObject.Find("BlackKingKnight");
                knight.transform.position = new Vector3(
                    knight.transform.position.x - 3f,
                    knight.transform.position.y,
                    knight.transform.position.z + 3f);
            } else if (moveNum == 3)
            {
                StartCoroutine(RandomDelay());
                GameObject knight = GameObject.Find("BlackHPawn");
                knight.transform.position = new Vector3(
                    knight.transform.position.x - 6f,
                    knight.transform.position.y,
                    knight.transform.position.z);
            }
            else if (moveNum == 4)
            {
                StartCoroutine(RandomDelay());
                GameObject knight = GameObject.Find("BlackQueenRook");
                knight.transform.position = new Vector3(
                    knight.transform.position.x - 6f,
                    knight.transform.position.y,
                    knight.transform.position.z);
            }
            else if (moveNum == 5)
            {
                StartCoroutine(RandomDelay());
                GameObject knight = GameObject.Find("BlackQueenBishop");
                knight.transform.position = new Vector3(
                    knight.transform.position.x - 3f,
                    knight.transform.position.y,
                    knight.transform.position.z + 3f);
            }
            else
            {
                //GameState.gameOver = this.transform.FindDeepChild("Game Over").gameObject.GetComponent<TMP_Text>();
                //GameState.gameOver.gameObject.SetActive(true);
                Debug.Log("gameover");
            }
            moveNum++;
            GameState.playerTurn = true;
        }
    }
    // idk if this does anything

    private IEnumerator RandomDelay()
    {
        yield return new WaitForSeconds(Random.Range(2.0f, 3.0f));
    }


}
