using System.Collections;
using UnityEngine;

public class MeleeController : MonoBehaviour
{
    bool podeAtacar;
    public GameObject meleePrefab;
    public GameObject miraMelee;
    public float cooldownMeleeDur;


    void Start()
    {
        podeAtacar = true;
    }

    private void FixedUpdate()
    {
        Atacar();
    }

    void Atacar()
    {
        if (Input.GetMouseButton(1) && podeAtacar)
        {
            Instantiate(meleePrefab, miraMelee.transform.position, transform.rotation); // instancio o tiro
            podeAtacar = false; // deixo falso apos atirar
            if (cooldownMeleeDur > 0) { StartCoroutine(Cooldown()); }
        }
    }



    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldownMeleeDur);
        podeAtacar = true;
    }
}
