using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstallProgram : MonoBehaviour
{
    [SerializeField]
    private GameObject instalador;
    [SerializeField]
    private GameObject instalando;
    [SerializeField]
    private GameObject botaoInstalar;
    [SerializeField]
    private GameObject botaoInstalarInstalador;
    [SerializeField]
    private GameObject botaoCancelar;
    [SerializeField]
    private GameObject botaoCancelar2;
    [SerializeField]
    private GameObject complete;

    public  bool isInstalou = false;

    public void chamarInstaladorButton()
    {
        StartCoroutine(chamarInstalador());
    }
    public void chamarCancelarInstalacao()
    {
        StartCoroutine(cancelarInstalacao());
    }
    public void chamarInstalandoPanel()
    {
        StartCoroutine(chamarInstalando());
    }
    public IEnumerator chamarInstalador()
    {
        yield return new WaitForSeconds(1f);
        instalador.SetActive(true);
        botaoInstalarInstalador.SetActive(true);
        botaoCancelar.SetActive(true);
        botaoCancelar2.SetActive(true);
        botaoInstalar.SetActive(false);
        isInstalou = false;
    }
    public IEnumerator chamarInstalando()
    {
        yield return new WaitForSeconds(2f);
        instalando.SetActive(true);
        instalador.SetActive(false);
        botaoCancelar.SetActive(true);
        isInstalou = false;
        StartCoroutine(chamarComplete());

    }

    public IEnumerator chamarComplete()
    {
        yield return new WaitForSeconds(5f);
        instalando.SetActive(false);
        complete.SetActive(true);
        isInstalou = true;
    }

    public IEnumerator cancelarInstalacao()
    {
        yield return new WaitForSeconds(1f);
        instalador.SetActive(false);
        instalando.SetActive(false);
        botaoInstalarInstalador.SetActive(false);
        botaoCancelar.SetActive(false);
        botaoCancelar2.SetActive(false);
        botaoInstalar.SetActive(true);
        complete.SetActive(false);

    }


}
