using System.Collections.Generic;
using UnityEngine;

public class DropRateManage : MonoBehaviour
{

    [System.Serializable] public class Drops
    {
        public string name;
        public GameObject item;
        public float dropRate;
    }

    public List<Drops> drops;

    void OnDestroy()
    {
        float randomNumber = Random.Range(0f, 100f); // numero aleatorio de 0 a 100
        List<Drops> possibleDrops = new List<Drops>(); // totais de itens que podem cair

        foreach(Drops rate in drops)
        {
            if(randomNumber <= rate.dropRate) // se for menor que a chance de cair, ele dropa o item
            {
                possibleDrops.Add(rate);
            }
            if (possibleDrops.Count > 0) // se for maior que
            {
                Drops drops = possibleDrops[Random.Range(0, possibleDrops.Count)]; // seleciona um dos itens
                Instantiate(drops.item, transform.position, Quaternion.identity); // dropa ele
                
            }
        }
    }

}
