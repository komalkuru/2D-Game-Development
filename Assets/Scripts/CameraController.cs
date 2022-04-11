using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject targetPlayer;
    void Update()
    {
        transform.position = new Vector3(targetPlayer.transform.position.x, targetPlayer.transform.position.y, transform.position.z);
    }
}
