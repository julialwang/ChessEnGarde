using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{

    public static bool playerTurn;
    // Start is called before the first frame update
    void Start()
    {
        playerTurn = false;
    }
}
