using UnityEngine;
using UnityEngine.SceneManagement;

public class ExperienceGem : MonoBehaviour, ICollectible
{
    //Transform player;
    public int experienceGranted;
    public bool activeMag;
    PlayerStats player;

    public void Collect()
    {

        player.IncreaseExp(experienceGranted);
        Destroy(this.gameObject);

    }

    void Awake()
    {
        player = FindObjectOfType<PlayerStats>();
        activeMag = false;
    }
    public void Update()
    {
        if (activeMag)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 5f * Time.deltaTime);
        }
        if(SceneManager.GetActiveScene().name == "Menu")
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            Collect();
        }
    }
}
