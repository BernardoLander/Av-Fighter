using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomScript : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public float camSpeed = 1f; // Camera movement speed
    public float camDist = 5f;   // Distance of camera from center
    public Vector3 angles = Vector3.zero; // Camera rotation angles (if needed)
    public Vector2 cameraBuffer = new Vector2(1f, 1f); // Buffer for camera size

    private List<GameObject> players;

    void Start()
    {
        players = new List<GameObject>();
        players.Add(player1);
        players.Add(player2);
    }

    void Update()
    {
        CalculateBounds();
        CalculateCameraPosAndSize();
    }

    void CalculateBounds()
    {
        minX = Mathf.Infinity;
        maxX = -Mathf.Infinity;
        minY = Mathf.Infinity;
        maxY = -Mathf.Infinity;
        minZ = Mathf.Infinity;
        maxZ = -Mathf.Infinity;

        foreach (GameObject player in players)
        {
            Vector3 tempPlayer = player.transform.position;

            // X, Y, and Z Bounds
            if (tempPlayer.x < minX) minX = tempPlayer.x;
            if (tempPlayer.x > maxX) maxX = tempPlayer.x;
            if (tempPlayer.y < minY) minY = tempPlayer.y;
            if (tempPlayer.y > maxY) maxY = tempPlayer.y;
            if (tempPlayer.z < minZ) minZ = tempPlayer.z;
            if (tempPlayer.z > maxZ) maxZ = tempPlayer.z;
        }
    }

    void CalculateCameraPosAndSize()
    {
        Vector3 cameraCenter = Vector3.zero;

        foreach (GameObject player in players)
        {
            cameraCenter += player.transform.position;
        }

        Vector3 finalCameraCenter = cameraCenter / players.Length;

        // Rotates and Positions camera around a point
        Quaternion rot = Quaternion.Euler(angles);
        Vector3 pos = rot * new Vector3(0f, 0f, -camDist) + finalCameraCenter;

        transform.rotation = rot;
        transform.position = Vector3.Lerp(transform.position, pos, camSpeed * Time.deltaTime);

        Vector3 finalLookAt = finalCameraCenter; // Assuming you want camera to look at center

        transform.LookAt(finalLookAt);

        // Size (Orthographic Camera)
        float sizeX = maxX - minX + cameraBuffer.x;
        float sizeY = maxY - minY + cameraBuffer.y;
        float sizeZ = maxZ - minZ + cameraBuffer.z; // Added Z size calculation

        float camSize = Mathf.Max(sizeX, Mathf.Max(sizeY, sizeZ)); // Use max size for all directions

        GetComponent<Camera>().orthographicSize = camSize * 0.5f;
    }
}
