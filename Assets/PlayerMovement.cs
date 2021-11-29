using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    [SerializeField] Rigidbody2D rb;
    Vector2 movement;

    #region Mouse Looking Variables
    [SerializeField] Camera cameraObj;
    Vector3 dir;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //Get the inputs for both Vertical and Horizontal axes and stores them to movement x and y values
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Makes the object face towards the mouse position
        dir = Input.mousePosition - cameraObj.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    private void FixedUpdate()
    {
        //Uses the rigidbody to move the object using the movement vector, movespeed and a fixed amount of time so that it moves smoothly
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
