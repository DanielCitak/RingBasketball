using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 mouseOffset;
    Vector3 throwDir;
    Vector3 oldMousePos;
    bool isCrashed;
    float throwSpeed = 3000.0f;
    private Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
       
    }
    private Vector3 MousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {
        mouseOffset = gameObject.transform.position - MousePos();
        StopCoroutine(OldMousePos());
        StartCoroutine(OldMousePos());

    }
    private void OnMouseDrag()
    {
        if (!isCrashed)
        {

            transform.position = MousePos() + mouseOffset;
        }
        
        rb.velocity = Vector3.zero;
        
        
        

    }
    private void OnMouseUp()
    {
       
        throwDir = MousePos()- oldMousePos;
        rb.AddForce(throwDir * throwSpeed);

    }
    IEnumerator OldMousePos()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.01f);           
            oldMousePos = MousePos();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        isCrashed = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        isCrashed = false;
    }
    
  
}
