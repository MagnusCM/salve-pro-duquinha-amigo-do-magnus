using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitCollector : MonoBehaviour
{
    private bool pit = false;
    private static bool hasGot = false;

    void Update()
    {
        if (!hasGot && pit && Input.GetKeyDown(KeyCode.E))
        {
            
            hasGot = true;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            pit = true;
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            pit = false;
        }
    }
}
