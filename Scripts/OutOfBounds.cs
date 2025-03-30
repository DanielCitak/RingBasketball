using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    [SerializeField] float maxRight;
    [SerializeField] float maxTop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > maxTop)
        {
            Destroy(gameObject);
        }
        if (transform.position.y < -maxTop)
        {
            Destroy(gameObject);
        }
        if (transform.position.x > maxRight)
        {
            Destroy(gameObject);
        }
        if (transform.position.y < -maxRight)
        {
            Destroy(gameObject);
        }
    }
}
