using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPlacing : MonoBehaviour
{
    private bool isMoving;

    void Start()
    {
       
        isMoving = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (isMoving) 
        {
            Vector3 mousePosition;
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            this.gameObject.transform.localPosition = new Vector3(mousePosition.x, mousePosition.y, 0);
        }

       
      
      
    }

    private void OnMouseUp()
    {
        isMoving = false;

    }

    private void OnMouseDrag()
    {
        isMoving = true;

        
    }
}

