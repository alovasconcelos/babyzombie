using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baby : MonoBehaviour
{
    public AudioSource groan;

    void Start()
    {
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
    }

    void Update()
    {
        
    }

    void FixedUpdate() 
    {
        ZombieControl();
        
    }
    
}
