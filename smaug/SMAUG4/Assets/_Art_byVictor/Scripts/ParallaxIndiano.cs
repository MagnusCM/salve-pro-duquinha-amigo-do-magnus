using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxIndiano : MonoBehaviour
{
    Material mat; 
    float distance;

    [Range(-0.5f, 0.5f)]
    public float speed = 0.2f;
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        distance += Time.deltaTime * speed;
        mat.SetTextureOffset("_MaunTex", Vector2.right * distance);
    }
}
