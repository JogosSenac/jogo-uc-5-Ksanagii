using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float vel;
    Rigidbody2D rb;
    Vector3 moveVector;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        moveVector = new Vector3();
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveVector.x = Input.GetAxisRaw("Horizontal");
        moveVector.y = Input.GetAxisRaw("Vertical");
        moveVector *= vel;
        rb.velocity = moveVector;
    }
}
