using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public List<GameObject> terrainChunks;
    public GameObject player;
    public float checkerRadius;
    Vector3 noTerraiPositions;
    public LayerMask terrainMask;
    PlayerMove pm;
    // Start is called before the first frame update
    void Start()
    {
        pm = FindObjectOfType<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
