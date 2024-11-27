using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform player1Transform;
    public Transform player2Transform;
    float playerMidpoint = 14f;
    float playerOrigin = 14f;
    float maxSize = 7.5f;


    // Start is called before the first frame update
    void Start()
    {
        Camera camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Transform bigger = player2Transform;
        Transform smaller = player1Transform;

        if (player1Transform.position.x > player2Transform.position.x)
        {
            bigger = player1Transform;
            smaller = player2Transform;
        }
        playerMidpoint = bigger.position.x - smaller.position.x;
        if (GetComponent<Camera>().orthographicSize <= maxSize) 
        {
            if (playerMidpoint > playerOrigin)
            {
                GetComponent<Transform>().set(playerMidpoint);
                GetComponent<Camera>().orthographicSize = GetComponent<Camera>().orthographicSize + (playerMidpoint - playerOrigin);
                playerMidpoint = bigger.position.x - smaller.position.x;
            }
            
        }
        else if (GetComponent<Camera>().orthographicSize >= 5f)
        {
            if (playerMidpoint < playerOrigin)
            {
                GetComponent<Camera>().orthographicSize = GetComponent<Camera>().orthographicSize - (playerOrigin - playerMidpoint);
                playerMidpoint = bigger.position.x - smaller.position.x;
            }

        }
    }
}
