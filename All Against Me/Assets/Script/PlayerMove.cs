using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float vel;
    Rigidbody2D rb;
    Vector3 moveVector;
    Animator animator;
    SpriteRenderer sprRen;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        moveVector = new Vector3();
        sprRen = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        #region ANIMATION
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            animator.SetLayerWeight(1, 0);
            animator.SetLayerWeight(3, 0);
            animator.SetLayerWeight(2, 1);
            if (Input.GetAxisRaw("Horizontal") == -1)
            {
                sprRen.flipX = true;
            } else { sprRen.flipX = false; }

        }
        else if (Input.GetAxisRaw("Vertical") != 0)
        {
            animator.SetLayerWeight(2, 0);
            if (Input.GetAxisRaw("Vertical") == 1)
            {
                animator.SetLayerWeight(1, 1);
            }
            else { animator.SetLayerWeight(3, 1); }

        }
        else 
        { 
            animator.SetLayerWeight(1, 0);
            animator.SetLayerWeight(2, 0);
            animator.SetLayerWeight(3, 0);
        }
        #endregion

        moveVector.x = Input.GetAxisRaw("Horizontal");
        moveVector.y = Input.GetAxisRaw("Vertical");
        moveVector *= vel;
        rb.velocity = moveVector;
    }
}
