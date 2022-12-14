using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{

    [SerializeField, Range(0, 10)] private float bombForce;
    [SerializeField, Range(0, 2)] private float minimumFiringDistance;
    [SerializeField, Range(2, 5)] private float maximumFiringDistance;

    private bool isAiming = false, isFiring = false;
    private Vector3 startPosition;
    private float aimingDistance;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = this.gameObject.transform.position;
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void OnMouseUp()
    {
        isAiming = false;

        if (aimingDistance < minimumFiringDistance)
        {
            this.gameObject.transform.position = startPosition;
        }
        else
        {
            firing();
        }
    }

    private void firing()
    {
        isAiming = false;
        isFiring = true;
        Debug.Log("Firing!");
        Vector2 aimingVector;
        aimingVector = new Vector2(startPosition.x - gameObject.transform.position.x, startPosition.y - gameObject.transform.position.y);

        Debug.Log(aimingVector);

        rb.AddForce(aimingVector * bombForce, ForceMode2D.Impulse);
    }

    private void OnMouseDrag()
    {
        if (!isFiring)
        {
            isAiming = true;
            aimingDistance = Vector3.Distance(startPosition, transform.position);
            if (aimingDistance > maximumFiringDistance)
            {
                firing();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isAiming)
        {
            Vector3 mousePosition;
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            this.gameObject.transform.localPosition = new Vector3(mousePosition.x, mousePosition.y, 0);
        }
    }
}
