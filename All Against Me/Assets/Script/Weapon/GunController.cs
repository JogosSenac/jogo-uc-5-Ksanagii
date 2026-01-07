using System.Collections;
using UnityEngine;

public class GunController : MonoBehaviour
{
    SpriteRenderer sprRenderer;
    public GameObject mira;
    public GameObject tiroPrefab;
    protected bool podeAtirar;
    public float fireRate;

    void Start()
    {
        sprRenderer = GetComponent<SpriteRenderer>();
        podeAtirar = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        #region Rotacao da Arma
        Vector3 mousePos = Input.mousePosition; // Guardando a posicao do mouse em uma variavel
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position); // Guardando a posicao da arma em relacao a camera em uma variavel

        Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y); // Calcula a distancia exata do ponto da arma ate o mouse

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg; // Converte a distancia em angulo

        transform.rotation = Quaternion.Euler(0, 0, angle); // transforma o angulo em Z da rotacao

        sprRenderer.flipY = (mousePos.x < screenPoint.x); // inverte o sprite se o moouse passar do eixo x da arma
        #endregion 
        /*
        if (mousePos.x < screenPoint.x) { 
            mira.transform.rotation = Quaternion.Euler(0, 0, -90);
        }else{mira.transform.rotation = Quaternion.Euler(0, 0, 0);} 
        */
    }

    private void FixedUpdate()
    {
        Atirar();
    }

    void Atirar()
    {
        
        if (Input.GetMouseButton(0) && podeAtirar)
        {
            Instantiate(tiroPrefab, mira.transform.position, transform.rotation); // instancio o tiro
            podeAtirar = false; // deixo falso apos atirar
            if (fireRate > 0) { StartCoroutine(FireRate()); } // carrego o delay de firerate
        }
    }

    IEnumerator FireRate()
    {
        yield return new WaitForSeconds(fireRate);
        podeAtirar = true;
    }
}
