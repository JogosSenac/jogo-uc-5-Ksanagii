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
    // Start is called before the first frame update
    void Start()
    {
        pm = FindObjectOfType<PlayerMove>();
        
    }

    // Update is called once per frame
    void Update()
    {
        ChunkChecker();
    }

    void ChunkChecker()
    {
        if (!currentChunk) { return; }
        #region
        // Se eu estiver me movendo para direita
        if (pm.moveVector.x > 0 && pm.moveVector.y == 0) // direita
        {
            // se não existir um objeto do layer terrain numa determinada area
            if (!Physics2D.OverlapCircle(player.transform.position + new Vector3(20, 0, 0), checkerRadius, terrainMask))
            {
                // a variavel que indica que nao tem terrain fica setada para a posicao
                noTerrainPositions = player.transform.position + new Vector3(20, 0, 0);
                SpawnChunk();
            }
        }
        else if (pm.moveVector.x < 0 && pm.moveVector.y == 0) // esquerda
        {
            // se não existir um objeto do layer terrain numa determinada area
            if (!Physics2D.OverlapCircle(player.transform.position + new Vector3(-20, 0, 0), checkerRadius, terrainMask))
            {
                // a variavel que indica que nao tem terrain fica setada para a posicao
                noTerrainPositions = player.transform.position + new Vector3(-20, 0, 0);
                SpawnChunk();
            }
        }
        else if (pm.moveVector.x > 0 && pm.moveVector.y > 0) // direita cima
        {
            // se não existir um objeto do layer terrain numa determinada area
            if (!Physics2D.OverlapCircle(player.transform.position + new Vector3(20, 20, 0), checkerRadius, terrainMask))
            {
                // a variavel que indica que nao tem terrain fica setada para a posicao
                noTerrainPositions = player.transform.position + new Vector3(20, 20, 0);
                SpawnChunk();
            }
        }
        else if (pm.moveVector.x == 0 && pm.moveVector.y > 0) // cima
        {
            // se não existir um objeto do layer terrain numa determinada area
            if (!Physics2D.OverlapCircle(player.transform.position + new Vector3(0, 20, 0), checkerRadius, terrainMask))
            {
                // a variavel que indica que nao tem terrain fica setada para a posicao
                noTerrainPositions = player.transform.position + new Vector3(0, 20, 0);
                SpawnChunk();
            }
        }
        else if (pm.moveVector.x < 0 && pm.moveVector.y > 0) // esquerda cima
        {
            // se não existir um objeto do layer terrain numa determinada area
            if (!Physics2D.OverlapCircle(player.transform.position + new Vector3(-20, 20, 0), checkerRadius, terrainMask))
            {
                // a variavel que indica que nao tem terrain fica setada para a posicao
                noTerrainPositions = player.transform.position + new Vector3(-20, 20, 0);
                SpawnChunk();
            }
        }
        else if (pm.moveVector.x == 0 && pm.moveVector.y < 0) // baixo
        {
            // se não existir um objeto do layer terrain numa determinada area
            if (!Physics2D.OverlapCircle(player.transform.position + new Vector3(0, -20, 0), checkerRadius, terrainMask))
            {
                // a variavel que indica que nao tem terrain fica setada para a posicao
                noTerrainPositions = player.transform.position + new Vector3(0, -20, 0);
                SpawnChunk();
            }
        }
        else if (pm.moveVector.x < 0 && pm.moveVector.y < 0) // esquerda baixo
        {
            // se não existir um objeto do layer terrain numa determinada area
            if (!Physics2D.OverlapCircle(player.transform.position + new Vector3(-20, -20, 0), checkerRadius, terrainMask))
            {
                // a variavel que indica que nao tem terrain fica setada para a posicao
                noTerrainPositions = player.transform.position + new Vector3(-20, -20, 0);
                SpawnChunk();
            }
        }
        else if (pm.moveVector.x > 0 && pm.moveVector.y < 0) // direita baixo
        {
            // se não existir um objeto do layer terrain numa determinada area
            if (!Physics2D.OverlapCircle(player.transform.position + new Vector3(20, -20, 0), checkerRadius, terrainMask))
            {
                // a variavel que indica que nao tem terrain fica setada para a posicao
                noTerrainPositions = player.transform.position + new Vector3(20, -20, 0);
                SpawnChunk();
            }
        }
        #endregion
    }
    void SpawnChunk()
    {
        int random = Random.Range(0, terrainChunks.Count);
        Instantiate(terrainChunks[random], noTerrainPositions, Quaternion.identity);
    }

}
