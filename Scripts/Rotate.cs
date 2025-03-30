using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Mathematics;

public class Rotate : MonoBehaviour
{
    float randomRotX;
    float randomRotY;
    float randomRotZ;
    // Start is called before the first frame update
    void Start()
    {
        randomRotX = UnityEngine.Random.Range(-100.0f, 100f);
        randomRotY = UnityEngine.Random.Range(-100.0f, 100f);
        randomRotZ = UnityEngine.Random.Range(-100.0f, 100f);
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Rotate(randomRotX* Time.deltaTime, randomRotY * Time.deltaTime, randomRotZ * Time.deltaTime);
        
    }
}
