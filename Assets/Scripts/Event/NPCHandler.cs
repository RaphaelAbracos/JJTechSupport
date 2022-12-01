using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCHandler : MonoBehaviour
{

    [SerializeField] private Transform spawnPosition;
    [SerializeField] private GameObject[] prefabs;

    [SerializeField] private GameObject Pc_teste;
    [SerializeField] private GameObject Pc_teste2;
    [SerializeField] private Transform PcPosition;
    [SerializeField] private CheckStatus PlayerComplete;
    GameObject NPC_1;
    GameObject NPC_2;
    int action;
    bool isLoading;
    // Start is called before the first frame update
    void Start()
    {
        action = 0;
        isLoading = false;
        PlayerComplete = FindObjectOfType<CheckStatus>();
        NPC_1 = Instantiate(prefabs[0], spawnPosition.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

        StartCoroutine(Action());
        //if (PlayerComplete.isCompleted && action == 0)
        //{
        //    Pc_teste.SetActive(false);
        //    Destroy(NPC_1);
        //    NPC_2 = Instantiate(prefabs[1], spawnPosition.position, Quaternion.identity);
        //    PlayerComplete.isCompleted = false;
        //    action++;
        //}
        //if (PlayerComplete.isCompleted && action == 1)
        //{
        //    Pc_teste2.SetActive(false);
        //    Destroy(NPC_2);
        //    //NPC_2 = Instantiate(prefabs[1], spawnPosition.position, Quaternion.identity);
        //    PlayerComplete.isCompleted = false;
        //    action++;
        //}
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("NPC") && action == 0)
        {
            Pc_teste.SetActive(true);
        }
        if(other.CompareTag("NPC") && action == 1)
        {
            Pc_teste2.SetActive(true);
            PlayerComplete.ResetProperties();
        }
    }

    void SpawnRandomPrefab()
    {
        Instantiate(prefabs[Random.Range(0, prefabs.Length)], spawnPosition.position, Quaternion.identity);
    }

    IEnumerator Action()
    {
        if (PlayerComplete.isCompleted && action == 0 && !isLoading)
        {
            isLoading = true;
            yield return new WaitForSeconds(5);
            Pc_teste.SetActive(false);
            Destroy(NPC_1);
            NPC_2 = Instantiate(prefabs[1], spawnPosition.position, Quaternion.identity);
            PlayerComplete.isCompleted = false;
            action++;
            isLoading = false;
        }
        if (PlayerComplete.isCompleted && action == 1 && !isLoading)
        {
            isLoading = true;
            yield return new WaitForSeconds(5);
            Pc_teste2.SetActive(false);
            Destroy(NPC_2);
            //NPC_2 = Instantiate(prefabs[1], spawnPosition.position, Quaternion.identity);
            PlayerComplete.isCompleted = false;
            action++;
            isLoading = false;
        }
    }
}
