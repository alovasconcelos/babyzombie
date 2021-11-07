using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baby : MonoBehaviour
{
    public AudioSource groan;
    public AudioSource jump;
    public float jumpValue;
    

    private Rigidbody2D rigidBody;
    private Animator anim;
    private Renderer rend;

    private bool isJumping = false;
    public float blinkTime;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
        groan.Play();
    }

    IEnumerator Blink()
    {
        for (int i = 0; i < blinkTime; i++)
        {
            rend.enabled = true;
            yield return new WaitForSeconds(0.1f);
            rend.enabled = false;
            yield return new WaitForSeconds(0.1f);
        }
        rend.enabled = true;
    }

    void ZombieControl() 
    { 
        float h = Input.GetAxis("Horizontal");
        
        if (h != 0) {
            // The Baby Zombie is walking
            float g = h > 0 ? 0 : 180;
            transform.rotation = Quaternion.Euler(new Vector3(0, g, 0));
            transform.Translate(new Vector3 (Mathf.Abs(h) * Time.deltaTime, 0, 0));
            
        }
        //StartCoroutine(Blink());
        anim.SetBool("isWalking", h != 0);

        if (!isJumping && Input.GetButtonDown("Jump")) {
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
            jump.Play();
        }
        
    }
}
