using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Vector3 movedelta;
    public Rigidbody2D rb;
    public float movespeed;
    public int deathcount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movedelta.x = Input.GetAxisRaw("Horizontal");
        movedelta.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
            transform.Translate(movedelta.x * movespeed * Time.deltaTime, 0, 0);
            transform.Translate(0, movedelta.y * movespeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        deathcount++;
        Debug.Log(deathcount);
    }
}
