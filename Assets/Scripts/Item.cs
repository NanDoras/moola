using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float roSpeed;

    void Update()
    {
        transform.Rotate(Vector3.up * roSpeed * Time.deltaTime, Space.World);
    }
}
