using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpin : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f;

    // Update is called once per frame
    void Update()
    {
        //Rotation
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}
