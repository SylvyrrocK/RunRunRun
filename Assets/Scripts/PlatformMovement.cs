using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] public static float levelSpeed = -2f;

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, levelSpeed) * Time.deltaTime;
    }

    public static void PlatformSpeed()
    {
        PlatformMovement.levelSpeed = -6f;
        Debug.Log(PlatformMovement.levelSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }
    }
}
