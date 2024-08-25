using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletConfig : MonoBehaviour
{
    public float vel;
    public float dano;
    [Header("Quantos inimigos pode perfurar")]
    public int pierce; // quatiedade de inimigos que pode perfurar

    private void Awake()
    {
        Invoke("DestroyBullet", 0.9f);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(vel * Time.deltaTime, 0), transform); // segue em linha reta
        
    }

    void DestroyBullet()
    {
        Destroy(this.gameObject);
    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            EnemyStats enemy = col.GetComponent<EnemyStats>(); // Pega os dados de quem colidiu
            enemy.TakeDamage(dano); // faz o inimigo tomar dano
            ReducePierce();
        }
    }

    void ReducePierce() // reduz quantiedade de inimigos que pode perfurar
    {
        pierce--;
        if (pierce <= 0)
        {
            DestroyBullet(); // destroy bala apos acabar todas perfuração
            
        }
    }
}
