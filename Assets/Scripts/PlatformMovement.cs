using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public static float levelSpeed = -5f;

    //Rigidbody rb;

    // Update is called once per frame
    void Update()
    {
        //rb.AddForce(new Vector3(0, 0 , levelSpeed) * 10f, ForceMode.Force);
        transform.position += new Vector3(0, 0, levelSpeed) * Time.deltaTime;
    }

    public static void PlatformSpeed()
    {
        PlatformMovement.levelSpeed = -8f;
        Debug.Log("Current level Speed: " + PlatformMovement.levelSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }
    }
}
