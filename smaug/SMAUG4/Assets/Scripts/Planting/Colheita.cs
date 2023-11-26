using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colheita : MonoBehaviour
{
    private bool planting = false;
    private static bool hasGot = false;

    void Update()
    {
        if (!hasGot && planting && Input.GetKeyDown(KeyCode.E))
        {
            gameObject.SetActive(false);
            hasGot = true;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            planting = true;
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            planting = false;
        }
    }
}