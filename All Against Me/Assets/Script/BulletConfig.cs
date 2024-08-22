using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletConfig : MonoBehaviour
{
    public float vel;
    public int dano;

    private void Awake()
    {
        Invoke("DestroyBullet", 0.8f);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(vel * Time.deltaTime, 0), transform );
        
    }

    void DestroyBullet()
    {
        
        Destroy(this.gameObject);
    }
}
