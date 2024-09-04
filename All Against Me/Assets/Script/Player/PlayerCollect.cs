using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    PlayerStats player;
    CircleCollider2D magnetArea;
    void Start()
    {
        //target = null;
        player = GetComponentInParent<PlayerStats>();
        magnetArea = GetComponent<CircleCollider2D>();
    }
    void Update()
    {
        magnetArea.radius = player.currentMagnet;
        //if(target != null)
        //{
            //target.transform.position = Vector2.MoveTowards(target.transform.position, transform.position, pullingSpeed * Time.deltaTime);
        //}
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Checa se o object que colidiu tem a interface de coletaveis
        if(col.gameObject.TryGetComponent(out ICollectible collectible))
        {
            //Rigidbody2D rb = col.gameObject.GetComponent<Rigidbody2D>(); // pega o rigidbody do coletavel
            //Vector2 forceDirection = (transform.position - col.transform.position).normalized; // direcao em que tem que ir o orb
            //rb.AddForce(forceDirection * pullingSpeed); // adiciono a forca na direcao

            //target = col.gameObject;

            // chama o metodo de coletar
            // collectible.Collect();

            ExperienceGem gem = col.gameObject.GetComponent<ExperienceGem>();
            gem.activeMag = true;
        }
    }
    /*
    public GameObject target;
    public float pullSpeed;
    void Update()
    {
        if (target)
            Magn();
    }
    void Magn()
    {
        Rigidbody2D rgb = GetComponent<Rigidbody2D>();
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, pullSpeed * Time.deltaTime);
    }

    colision.GetComponent<Magnete>().target = gameObject;
    collision.GetComponent<Magnete>().pullSpeed = pullSpeed; */
}
