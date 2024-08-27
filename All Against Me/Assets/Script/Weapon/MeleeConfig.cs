using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeConfig : MonoBehaviour
{
    public float vel;
    public float lifeTime;
    public float dano;
    // MeleeController meleeSpawn;

    void Awake()
    {
        Invoke("DestroyMelee", lifeTime);
        // meleeSpawn = FindObjectOfType<MeleeController>();
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Translate(new Vector3(vel * Time.deltaTime, 0), transform);
        // transform.position = meleeSpawn.miraMelee.transform.position;
        // transform.rotation = meleeSpawn.miraMelee.transform.rotation;

    }

    void DestroyMelee()
    {
        Destroy(this.gameObject);
    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            EnemyStats enemy = col.GetComponent<EnemyStats>(); // Pega os dados de quem colidiu
            enemy.TakeDamage(dano); // faz o inimigo tomar dano

        }
    }


}
