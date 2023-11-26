using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingGold : MonoBehaviour
{
    [SerializeField] private int coins;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            coins++;
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
        }
        
    }

}
