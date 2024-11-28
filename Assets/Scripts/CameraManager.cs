using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform camera1Transform;
    public Transform player1Transform;
    public Transform player2Transform;

    public float Yoffset = 2f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float MidpointX = (player1Transform.position.x + player2Transform.position.x) / 2;
        float MidpointY = (player1Transform.position.y + player2Transform.position.y) / 2;

        //Yoffset = Yoffset - MidpointX;


        camera1Transform.SetPositionAndRotation(new Vector3(MidpointX, MidpointY + Yoffset, -10f), new Quaternion(0f, 0f, 0f, 0f));

        float DistanceX = Mathf.Pow(player1Transform.position.x - player2Transform.position.x, 2);
        float DistanceY = Mathf.Pow(player1Transform.position.y - player2Transform.position.y, 2);

        float CameraSize = MathF.Sqrt(DistanceX + DistanceY);
        if (CameraSize >= 7f)
        {
            CameraSize = CameraSize / 2;

            GetComponent<Camera>().orthographicSize = GetComponent<Camera>().orthographicSize = CameraSize;
        }
        

    }
}
