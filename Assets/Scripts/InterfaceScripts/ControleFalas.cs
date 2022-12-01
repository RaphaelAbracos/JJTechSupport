using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class ControleFalas : MonoBehaviour
{
    public TMPro.TextMeshProUGUI legenda;
    public TMPro.TextMeshProUGUI nome;
    public TMPro.TextMeshProUGUI CronometroText;
    public string[] stringArray;

    int i = 0;

    public int seg;
    public int min;
    public int hor;

    public string textoLegenda;
    public bool isFinish = true;
    public bool isPlayerInTable = false;

    public float letterPause;

    public bool isAgnes = false;
    void Start()
    {
 
        CronometroText.text = "0";
        StartCoroutine("cronometro");
        legenda.text = "Texto inicial";
        legenda.fontStyle = FontStyles.Bold;
        
        //StartCoroutine(TypeText(0));




    }

    // Update is called once per frame
    void Update()
    {
        if (legenda.text.Substring(0, 9).Equals("Texto ini") && isFinish)
        {
            isFinish = false;
            legenda.text = "Mais um turno… Pelo menos é melhor do que ficar naquela casa vazia";
            nome.text = "Jerônimo:";
            StartCoroutine(waiter(5));

        }
        if (legenda.text.Substring(0, 9).Equals("Mais um t") && isFinish)
        {
            isFinish = false;
            legenda.text = "Vá até a sua bancada para esperar seus clientes";
            nome.text = "";

            StartCoroutine(waiter(0));
        }
        if (isPlayerInTable && isFinish && legenda.text.Substring(0, 9).Equals("Vá até a "))
        {
            isFinish = false;
            isPlayerInTable = false;

            nome.text = "Rádio:";
            legenda.text = "Em outras notícias, recebemos um relato não confirmado de um acidente na penitenciária da cidade na noite passada";
            StartCoroutine(waiter(5));

        }
        if (legenda.text.Substring(0, 9).Equals("Em outras") && isFinish)
        {   
            isFinish = false;
            isPlayerInTable = false;
            nome.text = "Rádio:";
            legenda.text = "Ainda não há estimativas do número de feridos";

            //TIRAR DAQUI PARA RAPHAEL DEFINIR
            

            StartCoroutine(waiter(3));
            

        }
        if(isFinish && isAgnes && legenda.text.Substring(0, 9).Equals("Ainda não"))
        {
            isFinish = false;
            isPlayerInTable = false;

            nome.text = "Agnes:";
            legenda.text = "Noite, Jerônimo. Começou agora?";
            StartCoroutine(waiter(4));

        }
        if (isFinish &&  isAgnes && legenda.text.Substring(0, 9).Equals("Noite, Je"))
        {
            isFinish = false;
            isPlayerInTable = false;

            nome.text = "Jerônimo:";
            legenda.text = "Pois é. E pelo visto seu turno foi longo hoje";
            StartCoroutine(waiter(4));

        }
        if (isFinish && isAgnes && legenda.text.Substring(0, 9).Equals("Pois é. E"))
        {
            isFinish = false;
            isPlayerInTable = false;

            nome.text = "Agnes:";
            legenda.text = "Ainda bem que você tá aberto. Não tive tempo essa semana pra olhar essas peças. ";
            StartCoroutine(waiter(4));

        }
        if (isFinish && isAgnes && legenda.text.Substring(0, 9).Equals("Ainda bem"))
        {
            isFinish = false;
            isPlayerInTable = false;

            nome.text = "Agnes:";
            legenda.text = "Tão imundas, acho que por isso que o computador do Gabriel não funciona mais. Pode dar uma olhada aí ?";
            StartCoroutine(waiter(4));

        }
        if (isFinish && isAgnes && legenda.text.Substring(0, 9).Equals("Tão imund"))
        {
            /*isFinish = false;
            isPlayerInTable = false;

            nome.text = "Agnes:";
            legenda.text = "Tão imundas, acho que por isso que o computador do Gabriel não funciona mais. Pode dar uma olhada aí ?";
            StartCoroutine(waiter(4));*/

            //AÇÃO LIMPAR PEÇAS

        }


        /*Agnes: Noite, Jerônimo. Começou agora? 

Jerônimo: Pois é. E pelo visto seu turno foi longo hoje. 

Agnes: Nem me fala. 
Ainda bem que você tá aberto. Não tive tempo essa semana pra olhar essas peças. 
Tão imundas, acho que por isso que o computador do Gabriel não funciona mais. 
Pode dar uma olhada aí? 
*/

    }
    IEnumerator waiter(int tempo)
    {

        yield return new WaitForSeconds(tempo);
        isFinish = true;

    }
    IEnumerator TypeText(int tempo)
    {
        yield return new WaitForSeconds(tempo);
        foreach (char letter in textoLegenda.ToCharArray())
            {

                yield return new WaitForSeconds(letterPause);
                legenda.text += letter;
                yield return 0;
                isFinish = false;
            }

        isFinish = true;
    }


    // Start is called before the first frame update

    IEnumerator cronometro()
    {
        yield return new WaitForSeconds(1);
        seg += 1;
        if (seg == 60)
        {
            seg = 0;
            min += 1;
            if (min == 60)
            {
                min = 0;
                hor += 1;
            }
        }

        string s = seg.ToString();
        if (seg < 10) { s = "0" + seg.ToString(); }


        string m = min.ToString();
        if (min < 10) { m = "0" + min.ToString(); }
        string h = hor.ToString();
        if (hor < 10) { h = "0" + hor.ToString(); }

        CronometroText.text = h + ":" + m + ":" + s;

        StartCoroutine("cronometro");
    }





}
