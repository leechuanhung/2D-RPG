using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Character : MonoBehaviour
{

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public float Speed = 4f;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

   
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Speed * Time.deltaTime);
        }
    }

}
