using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    public float speed = 100;
    public GameObject pelletPrefab;
    public float cooldown = 0.1f;
    public bool isOnCooldown = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float direction = Input.GetAxisRaw("Horizontal") * speed * Time.fixedDeltaTime;

        if (Input.GetKey(KeyCode.Space))
        {
            if (!isOnCooldown)
            {
                StartCoroutine(SpawnPellet());
            }
        }

        gameObject.GetComponent<Rigidbody2D>().MovePosition(gameObject.transform.position + new Vector3(direction, 0, 0));
    }

    IEnumerator SpawnPellet()
    {
        isOnCooldown = true;
        Instantiate(pelletPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
        yield return new WaitForSecondsRealtime(cooldown);
        isOnCooldown = false;
    }
}
