using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    EnemyStats enemy;
    SpriteRenderer spr;
    
    Vector2 knockbackVelocity;
    float knockbackDuration;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<EnemyStats>();
        player = FindObjectOfType<PlayerMove>().transform;
        spr = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(knockbackDuration > 0 )
        {
            transform.position += (Vector3)knockbackVelocity * Time.deltaTime;
            knockbackDuration -= Time.deltaTime;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemy.currentMoveSpeed * Time.deltaTime); // move em direcao ao player
        }
        spr.flipX = (transform.position.x > player.transform.position.x); // gira quando passar do pivot do player
    }

    public void Knockback(Vector2 velocity, float duration)
    {
        if (knockbackDuration > 0 ) {return;}

        knockbackVelocity = velocity;
        knockbackDuration = duration;
        
    }
}
