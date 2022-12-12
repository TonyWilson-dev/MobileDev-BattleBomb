using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPlacing : MonoBehaviour
{
    private Vector2 startingPosition;
    private bool isMoving = false;

    void Start()
    {
        Debug.Log("starting");
    }
    // Update is called once per frame
    void Update()
    {
        if (isMoving) 
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            this.gameObject.transform.localPosition = new Vector3(mousePos.x, mousePos.y, 0);
        }

        if (Input.GetMouseButtonDown(0)) 
        { 
            Debug.Log("mouse down ");

            //setting vector 3 to world point of mouse position
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            Debug.Log(mousePos); 
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            Debug.Log(mousePos);
            isMoving = true;

        }
        else
        {
            isMoving = false;
        }
    }
}

