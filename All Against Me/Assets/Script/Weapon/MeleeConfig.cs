using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeConfig : MonoBehaviour
{
    public float vel;
    public float lifeTime;
    public float dano;
    public List<GameObject> markedEnemies;
    // MeleeController meleeSpawn;

    void Awake()
    {
        Invoke("DestroyMelee", lifeTime);
        markedEnemies = new List<GameObject>();
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
        if (col.CompareTag("Enemy") && !markedEnemies.Contains(col.gameObject))
        {
            EnemyStats enemy = col.GetComponent<EnemyStats>(); // Pega os dados de quem colidiu
            enemy.TakeDamage(dano); // faz o inimigo tomar dano
            markedEnemies.Add(col.gameObject); // marca os inimigos que ja foram acertados para não levarem outro hit
            
        }
    }


}
