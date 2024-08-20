using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class GunController : MonoBehaviour
{
    public Camera cam;
    SpriteRenderer sprRenderer;
    public GameObject mira;
    public GameObject tiroPrefab;
    public int velTiro;

    // Start is called before the first frame update
    void Start()
    {
        sprRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition; // Guardando a posicao do mouse em uma variavel
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position); // Guardando a posicao da arma em relacao a camera em uma variavel

        Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y); // Calcula a distancia exata do ponto da arma ate o mouse

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg; // Converte a distancia em angulo

        transform.rotation = Quaternion.Euler(0, 0, angle); // transforma o angulo em Z da rotacao

        sprRenderer.flipY = (mousePos.x < screenPoint.x); // inverte o sprite se o moouse passar do eixo x da arma

        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(tiroPrefab, mira.transform.position, transform.rotation);
        }
        
        
    }
    
}
