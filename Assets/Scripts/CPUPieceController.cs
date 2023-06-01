using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUPieceController : MonoBehaviour
{
    private GameObject[] objs;
    private int moveNum;

    private void Start()
    {
        moveNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!ChessPieceController.whiteMove)
        {
            if (moveNum == 0)
            {
                GameObject pawn = GameObject.Find("PAWN");
                pawn.transform.position = new Vector3(
                    1f,
                    pawn.transform.position.y,
                    pawn.transform.position.z);
            } else if (moveNum == 1)
            {
                GameObject pawn = GameObject.Find("PAWN2");
                pawn.transform.position = new Vector3(
                    4f,
                    pawn.transform.position.y,
                    pawn.transform.position.z);
            } else if (moveNum == 2)
            {
                GameObject knight = GameObject.Find("KNIGHT");
                knight.transform.position = new Vector3(
                    4f,
                    knight.transform.position.y,
                    -4.5f);
            } else if (moveNum == 3)
            {
                GameObject bishop = GameObject.Find("BISHOP");
                bishop.transform.position = new Vector3(
                    1f,
                    bishop.transform.position.y,
                    4.5f);
            } else
            {
                Debug.Log("GAME OVER");
            }
            moveNum++;
            ChessPieceController.whiteMove = true;
        }
    }


}
