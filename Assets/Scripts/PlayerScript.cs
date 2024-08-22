using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float speed;
    SpriteRenderer sr;
    float x;
    float maxX = 4.7f;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        if((x>0 && transform.position.x<maxX) || (x<0 && transform.position.x > -maxX))
        {
            transform.Translate(x, 0.0f, 0.0f);
        }
        
    }
}
