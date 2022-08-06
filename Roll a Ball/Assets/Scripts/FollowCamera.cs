using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform player;

    //public Transform player_2;
    //public Transform player_3;
    private Vector3 offset = new Vector3(0, 1, -5);

    void Update()
    {
        transform.position = player.position + offset;
    }
}
