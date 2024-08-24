using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropRandomizer : MonoBehaviour
{
    [SerializeField] private List<GameObject> propsSpawnPoints;
    [SerializeField] private List<GameObject> propsPrefabs;

    void Start()
    {
        SpawnProps();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnProps()
    {
        foreach (GameObject prop in propsSpawnPoints)
        {
            int rand = Random.Range(0, propsSpawnPoints.Count); // cria uma variavel local random ate o numero maximos de spawnpoints
            GameObject propObject = Instantiate(propsPrefabs[rand], prop.transform.position, Quaternion.identity); // instancia um prop na posicao do spawnPoints
            propObject.transform.parent = prop.transform;
        }
    }
}
