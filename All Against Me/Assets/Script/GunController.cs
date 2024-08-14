using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    SpriteRenderer sprRenderer;
    // Start is called before the first frame update
    void Start()
    {
        sprRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition; // Guardando a posição do mouse em uma variavel
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position); // Guardando a posição da arma em reslação a camera em uma variavel

        Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y); // Calcula a distancia exata do ponto da arma ate o mouse

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg; // Converte a distancia em angulo

        transform.rotation = Quaternion.Euler(0, 0, angle); // transforma o angulo em Z da rotação

        sprRenderer.flipY = (mousePos.x < screenPoint.x); // inverte o sprite se o moouse passar do eixo x da arma
    }
}
