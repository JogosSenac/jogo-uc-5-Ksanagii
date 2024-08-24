using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public List<GameObject> terrainChunks;
    public GameObject player;
    public float checkerRadius;
    Vector3 noTerrainPositions;
    public LayerMask terrainMask;
    PlayerMove pm;
    public GameObject currentChunk;

    [Header("Optimization")]
    public List<GameObject> spawnedChunks;
    GameObject latestChunk; // vai guardar um ultimo chunk gerado
    public float maxOpDist; // Tem que ser maior e superior ao tamanho do tilemap (tanto em largura quanto altura)
    float OpDist;
    float optimizerCooldown;
    public float optimizerCooldownDur;

    void Start()
    {
        pm = FindObjectOfType<PlayerMove>();
        
    }

    // Update is called once per frame
    void Update()
    {
        ChunkChecker();
        ChunkOptimizer();

    }

    void ChunkChecker()
    {
        if (!currentChunk) { return; }

        #region
        // Se eu estiver me movendo para direita
        if (pm.moveVector.x > 0 && pm.moveVector.y == 0) // direita
        {
            // se não existir um objeto do layer terrain numa determinada area
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Direita").position, checkerRadius, terrainMask))
            {
                // a variavel que indica que nao tem terrain fica setada para a posicao
                noTerrainPositions = currentChunk.transform.Find("Direita").position;
                SpawnChunk();
            }
        }
        else if (pm.moveVector.x < 0 && pm.moveVector.y == 0) // esquerda
        {
            // se não existir um objeto do layer terrain numa determinada area
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Esquerda").position, checkerRadius, terrainMask))
            {
                // a variavel que indica que nao tem terrain fica setada para a posicao
                noTerrainPositions = currentChunk.transform.Find("Esquerda").position;
                SpawnChunk();
            }
        }
        else if (pm.moveVector.x > 0 && pm.moveVector.y > 0) // direita cima
        {
            // se não existir um objeto do layer terrain numa determinada area
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Direita Cima").position, checkerRadius, terrainMask))
            {
                // a variavel que indica que nao tem terrain fica setada para a posicao
                noTerrainPositions = currentChunk.transform.Find("Direita Cima").position;
                SpawnChunk();
            }
        }
        else if (pm.moveVector.x == 0 && pm.moveVector.y > 0) // cima
        {
            // se não existir um objeto do layer terrain numa determinada area
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Cima").position, checkerRadius, terrainMask))
            {
                // a variavel que indica que nao tem terrain fica setada para a posicao
                noTerrainPositions = currentChunk.transform.Find("Cima").position;
                SpawnChunk();
            }
        }
        else if (pm.moveVector.x < 0 && pm.moveVector.y > 0) // esquerda cima
        {
            // se não existir um objeto do layer terrain numa determinada area
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Esquerda Cima").position, checkerRadius, terrainMask))
            {
                // a variavel que indica que nao tem terrain fica setada para a posicao
                noTerrainPositions = currentChunk.transform.Find("Esquerda Cima").position;
                SpawnChunk();
            }
        }
        else if (pm.moveVector.x == 0 && pm.moveVector.y < 0) // baixo
        {
            // se não existir um objeto do layer terrain numa determinada area
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Baixo").position, checkerRadius, terrainMask))
            {
                // a variavel que indica que nao tem terrain fica setada para a posicao
                noTerrainPositions = currentChunk.transform.Find("Baixo").position;
                SpawnChunk();
            }
        }
        else if (pm.moveVector.x < 0 && pm.moveVector.y < 0) // esquerda baixo
        {
            // se não existir um objeto do layer terrain numa determinada area
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Esquerda Baixo").position, checkerRadius, terrainMask))
            {
                // a variavel que indica que nao tem terrain fica setada para a posicao
                noTerrainPositions = currentChunk.transform.Find("Esquerda Baixo").position;
                SpawnChunk();
            }
        }
        else if (pm.moveVector.x > 0 && pm.moveVector.y < 0) // direita baixo
        {
            // se não existir um objeto do layer terrain numa determinada area
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Direita Baixo").position, checkerRadius, terrainMask))
            {
                // a variavel que indica que nao tem terrain fica setada para a posicao
                noTerrainPositions = currentChunk.transform.Find("Direita Baixo").position;
                SpawnChunk();
            }
        }
        #endregion
    }

    void SpawnChunk()
    {
        int random = Random.Range(0, terrainChunks.Count);
        latestChunk = Instantiate(terrainChunks[random], noTerrainPositions, Quaternion.identity);
        spawnedChunks.Add(latestChunk);
    }

    void ChunkOptimizer()
    {
        optimizerCooldown -= Time.deltaTime;
        if(optimizerCooldown <= 0f)
        {
            optimizerCooldown = optimizerCooldownDur;
        }
        else
        {
            return;
        }

        foreach (var chunk in spawnedChunks)
        {
            OpDist = Vector3.Distance(player.transform.position, chunk.transform.position); // distancia entre o player e o chunk antigo
            /* verificacao simplificada
            if (OpDist > maxOpDist)
            {
                chunk.SetActive(false);
            }
            else
            {
                chunk.SetActive(true);
            }
            */

            chunk.SetActive(OpDist <= maxOpDist); // se a distancia for maior que a distancia maxima, ele desativa
        }
    }
}
