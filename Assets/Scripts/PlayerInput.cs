using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    public float speed = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float direction = Input.GetAxisRaw("Horizontal") * speed * Time.fixedDeltaTime;

        gameObject.GetComponent<Rigidbody2D>().MovePosition(gameObject.transform.position + new Vector3(direction, 0, 0));

    }
}
