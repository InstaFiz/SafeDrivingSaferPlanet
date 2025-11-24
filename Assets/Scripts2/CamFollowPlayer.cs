using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    public Transform player;

    private Vector3 offset = new Vector3(0, 2, -6);

    void LateUpdate()
    {
        transform.position = player.TransformPoint(offset);
        transform.LookAt(player);
    }
}