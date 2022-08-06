using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorItem : MonoBehaviour
{
    private float rotateSpeed = -50;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }
}
