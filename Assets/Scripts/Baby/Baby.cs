using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baby : MonoBehaviour
{
    public AudioSource groan;
    private Rigidbody2D rigidBody;
    public float jumpValue;
    private bool isJumping = false;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        groan.Play();
    }

    void ZombieControl() 
    { 
        float h = Input.GetAxis("Horizontal");
        
        if (h != 0) {
            float g = h > 0 ? 0 : 180;
            transform.rotation = Quaternion.Euler(new Vector3(0, g, 0));
            transform.Translate(new Vector3 (Mathf.Abs(h) * Time.deltaTime, 0, 0));
        }
        if(!isJumping && Input.GetButtonDown("Jump")) {
            Jump();
        }
    }

    void Update()
    {
        
    }

    void FixedUpdate() 
    {
        ZombieControl();
        
    }

    void Jump() {
        rigidBody.AddForce(new Vector2(0f, jumpValue), ForceMode2D.Impulse);    
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer == 3) {
            isJumping = false;
        }
    }
    
    void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.layer == 3) {
            isJumping = true;
        }
        
    }
}
