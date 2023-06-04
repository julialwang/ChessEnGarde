using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    private string enemyName;

    // [Header("Prefab Refrences")]
    public GameObject pawnPrefab;
    public GameObject rookPrefab;
    public GameObject knightPrefab;
    public GameObject bishopPrefab;
    public GameObject queenPrefab;
    public GameObject kingPrefab;

    [SerializeField] private Transform enemyLocation;

    // Start is called before the first frame update
    void Start()
    {
        enemyName = "";
        if (enemyLocation == null) {
            enemyLocation = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameState.currentEnemyName.Equals(enemyName)) {
            enemyName = GameState.currentEnemyName;
            InstantiatePiece();
        }
    }

    void InstantiatePiece() {
        GameObject tempPrefab;
        if (enemyName.Contains("Pawn")) {
            Debug.Log("INSTANTIATING PAWN");
            tempPrefab = (GameObject) Instantiate(
                pawnPrefab,
                enemyLocation.position,
                enemyLocation.rotation);
            tempPrefab.tag = "Enemy";
        } else if (enemyName.Contains("Rook")) {
            Debug.Log("INSTANTIATING ROOK");
            tempPrefab = (GameObject) Instantiate(
                rookPrefab,
                enemyLocation.position,
                enemyLocation.rotation);
            tempPrefab.tag = "Enemy";
        } else if (enemyName.Contains("Knight")) {
            Debug.Log("INSTANTIATING KNIGHT");
            tempPrefab = (GameObject) Instantiate(
                knightPrefab,
                enemyLocation.position,
                enemyLocation.rotation);
            tempPrefab.tag = "Enemy";
        } else if (enemyName.Contains("Bishop")) {
            Debug.Log("INSTANTIATING BISHOP");
            tempPrefab = (GameObject) Instantiate(
                bishopPrefab,
                enemyLocation.position,
                enemyLocation.rotation);
            tempPrefab.tag = "Enemy";
        } else if (enemyName.Contains("Queen")) {
            Debug.Log("INSTANTIATING QUEEN");
            tempPrefab = (GameObject) Instantiate(
                queenPrefab,
                enemyLocation.position,
                enemyLocation.rotation);
            tempPrefab.tag = "Enemy";
        } else if (enemyName.Contains("King")) {  // should never happen because of how chess works
            Debug.Log("INSTANTIATING KING");
            tempPrefab = (GameObject) Instantiate(
                kingPrefab,
                enemyLocation.position,
                enemyLocation.rotation);
            tempPrefab.tag = "Enemy";
        }
    }
}
