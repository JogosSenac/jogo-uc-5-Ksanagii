using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkTrigger : MonoBehaviour
{
    MapController mc;
    public GameObject targetMap;
    void Start()
    {
        mc = FindObjectOfType<MapController>();
    }

    private void OnTriggerStay2D(Collider2D col) 
    {
        if (col.CompareTag("Player")) // se o player estiver colidindo
        {
            mc.currentChunk = targetMap; // currentchunk � o tile map desse codigo
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.CompareTag("Player")) // se saiu da colis�o
        {
            if( mc.currentChunk == targetMap) 
            {
                mc.currentChunk = null; // currrentchunk � null
            }
        }
    }
}
