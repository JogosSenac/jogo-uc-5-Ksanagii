using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletConfig : MonoBehaviour
{
    public float vel;
    public int dano;
    public int dirTiro;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(vel * Time.deltaTime, 0), transform );
        Invoke("DestroyBullet", 5.5f);
    }

    void DestroyBullet()
    {
        
        Destroy(this.gameObject);
    }
}
