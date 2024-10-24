using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] public static float levelSpeed = -5f;

    // Update is called once per frame
    void Update()
    {
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
