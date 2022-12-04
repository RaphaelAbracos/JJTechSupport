using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCHandler : MonoBehaviour
{

    [SerializeField] private Transform spawnPosition;
    [SerializeField] private GameObject[] prefabs;

    [SerializeField] private GameObject Pc_teste;
    [SerializeField] private GameObject Pc_teste2;
    [SerializeField] private GameObject Pecas;
    [SerializeField] private Transform PcPosition;
    [SerializeField] private GameObject buttonInstall;
    public GameOverScreen gameOverScreen;
    private CheckStatus PlayerComplete;
    private ControleFalas controleFalas;
    GameObject NPC_1;
    GameObject NPC_2;
    GameObject NPC_3;
    public bool isAgnisleft;
    int action;
    bool isLoading;
    bool isStart = true;
    // Start is called before the first frame update
    void Start()
    {
        isAgnisleft = false;
        action = 0;
        isLoading = false;
        PlayerComplete = FindObjectOfType<CheckStatus>();
        controleFalas = FindObjectOfType<ControleFalas>();
        //NPC_1 = Instantiate(prefabs[0], spawnPosition.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

        StartCoroutine(Action());
        StartCoroutine(StartScene());
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("NPC") && action == 0 && controleFalas.isFinish)
        {
            //Pecas.SetActive(true);
            controleFalas.isAgnes = true;
            //Pc_teste.SetActive(true);

        }
        if (other.CompareTag("NPC") && action == 1 && controleFalas.isFinish)
        {
            //Pc_teste.SetActive(true);
            controleFalas.isGaroto = true;
        }
        if (other.CompareTag("NPC") && action == 2 && controleFalas.isFinish)
        {
            //Pc_teste2.SetActive(true);
            //PlayerComplete.ResetProperties();
            controleFalas.isAssassino = true;
        }
    }
    

    public void ChamarPecas()
    {
        Pecas.SetActive(true);
    }

    public void ChamarRAM()
    {
       Pc_teste.SetActive(true);
    }

    public void ChamarPlaca()
    {
        Pc_teste2.SetActive(true);
        PlayerComplete.ResetProperties();
    }

    void SpawnRandomPrefab()
    {
        Instantiate(prefabs[Random.Range(0, prefabs.Length)], spawnPosition.position, Quaternion.identity);
    }

    IEnumerator Action()
    {

        if (PlayerComplete.isPecasCompleted && action == 0 && !isLoading && controleFalas.isFinish)
        {
            isLoading = true;
            controleFalas.isLimpaPecasAcabou = true;
            yield return new WaitForSeconds(21);
            Pecas.SetActive(false);
            Destroy(NPC_1);
            NPC_2 = Instantiate(prefabs[1], spawnPosition.position, Quaternion.identity);
            PlayerComplete.isCompleted = false;
            isLoading = false;
            action++;
        }

        if (PlayerComplete.isCompleted && action == 1 && !isLoading && controleFalas.isFinish)
        {
            isLoading = true;
            controleFalas.isColocouRAM = true;
            yield return new WaitForSeconds(25);
            Pc_teste.SetActive(false);
            Destroy(NPC_2);
            NPC_3 = Instantiate(prefabs[2], spawnPosition.position, Quaternion.identity);
            PlayerComplete.isCompleted = false;
            action++;
            isLoading = false;
        }
        if (PlayerComplete.isCompleted && action == 2 && !isLoading && controleFalas.isFinish)
        {
            bool isInstall = buttonInstall.GetComponentInChildren<InstallProgram>().isInstalou;
            if (isInstall)
            {
                controleFalas.isMontouPc = true;
                isLoading = true;
            }
        }
    }

    IEnumerator StartScene()
    {
        if (controleFalas.isPlayerInTable && isStart && controleFalas.isFinish)
        {
            isStart = false;
            yield return new WaitForSeconds(10);
            NPC_1 = Instantiate(prefabs[0], spawnPosition.position, Quaternion.identity);
            yield return new WaitForSeconds(3);
        }
    }

    public IEnumerator DestroyAssassino()
    {
        yield return new WaitForSeconds(5);
        Pc_teste2.SetActive(false);
        gameOverScreen.Setup();
        PlayerComplete.isCompleted = false;
        action++;
        isLoading = false;
    }
}
