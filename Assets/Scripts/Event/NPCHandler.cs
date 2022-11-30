using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCHandler : MonoBehaviour
{

    [SerializeField] private Transform spawnPosition;
    [SerializeField] private GameObject[] prefabs;

    [SerializeField] private GameObject Pc_teste;
    [SerializeField] private Transform PcPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("x"))
        {
            SpawnRandomPrefab();
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("NPC"))
        {
            Instantiate(Pc_teste, PcPosition, true);
        }
    }

    void SpawnRandomPrefab()
    {
        Instantiate(prefabs[Random.Range(0, prefabs.Length)], spawnPosition.position, Quaternion.identity);
    }
}
