using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameState : MonoBehaviour
{
    public static GameState Instance { get; private set; }
    public bool playerTurn = true;
    public string enemyDuelPieceName = null;
    private void Awake()
    {
        Instance = this;
    }

    public void setPlayerTurn(bool val) {
        Instance.playerTurn = val;
    }

    public void setEnemyDuelPieceName(string val) {
        Instance.setEnemyDuelPieceName(val);
    }
}
