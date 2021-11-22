using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSMoving : MonoBehaviour
{

    Rigidbody2D rigidbody2D;
    [SerializeField] float speed = 5;
    [SerializeField] float hold = 5;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {


        //Moving spaceship follow arrow key
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody2D.AddForce(new Vector2(-1 * speed, 0));
            //transform.position += new Vector3(-1 * speed * Time.deltaTime, 0, 0);
        }else if(Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody2D.AddForce(new Vector2(1 * speed, 0));
            //transform.position += new Vector3(1 * speed * Time.deltaTime, 0, 0);
        }else if(Input.GetKey(KeyCode.UpArrow))
        {
            rigidbody2D.AddForce(new Vector2(0, 1 * speed));
            //transform.position += new Vector3(0, 1 * speed * Time.deltaTime, 0);
        }else if(Input.GetKey(KeyCode.DownArrow))
        {
            rigidbody2D.AddForce(new Vector2(0, -1 * speed));
            //transform.position += new Vector3(0, -1 * speed * Time.deltaTime, 0);
        }
    }
}
