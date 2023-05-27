using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR;

public class ChessPieceController : MonoBehaviour
{
    public Rigidbody rb;
    private float gridSize = 3.0f;

    // Update is called once per frame
    void Update()
    {
        rb.transform.position = new Vector3(
            RoundToNearestGrid(rb.transform.position.x),
            RoundToNearestGrid(rb.transform.position.y),
            RoundToNearestGrid(rb.transform.position.z));
    }

    private float RoundToNearestGrid(float pos)
    {
        float xDiff = pos % gridSize;
        pos -= xDiff;
        if (xDiff > (gridSize / 2))
        {
            pos += gridSize;
        }
        return pos;
    }
}
