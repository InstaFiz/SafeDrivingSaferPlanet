using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset = new Vector3(0, 1, 0);

    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}