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
            legenda.text = "Mais um turno� Pelo menos � melhor do que ficar naquela casa vazia";
            nome.text = "Jer�nimo:";
            StartCoroutine(waiter(5));

        }
        if (legenda.text.Substring(0, 9).Equals("Mais um t") && isFinish)
        {
            isFinish = false;
            legenda.text = "V� at� a sua bancada para esperar seus clientes";
            nome.text = "";

            StartCoroutine(waiter(0));
        }
        if (isPlayerInTable && isFinish && legenda.text.Substring(0, 9).Equals("V� at� a "))
        {
            isFinish = false;
            isPlayerInTable = false;

            nome.text = "R�dio:";
            legenda.text = "Em outras not�cias, recebemos um relato n�o confirmado de um acidente na penitenci�ria da cidade na noite passada";
            StartCoroutine(waiter(5));

        }
        if (legenda.text.Substring(0, 9).Equals("Em outras") && isFinish)
        {   
            isFinish = false;
            isPlayerInTable = false;
            nome.text = "R�dio:";
            legenda.text = "Ainda n�o h� estimativas do n�mero de feridos";

            //TIRAR DAQUI PARA RAPHAEL DEFINIR
            

            StartCoroutine(waiter(3));
            

        }
        if(isFinish && isAgnes && legenda.text.Substring(0, 9).Equals("Ainda n�o"))
        {
            isFinish = false;
            isPlayerInTable = false;

            nome.text = "Agnes:";
            legenda.text = "Noite, Jer�nimo. Come�ou agora?";
            StartCoroutine(waiter(4));

        }
        if (isFinish &&  isAgnes && legenda.text.Substring(0, 9).Equals("Noite, Je"))
        {
            isFinish = false;
            isPlayerInTable = false;

            nome.text = "Jer�nimo:";
            legenda.text = "Pois �. E pelo visto seu turno foi longo hoje";
            StartCoroutine(waiter(4));

        }
        if (isFinish && isAgnes && legenda.text.Substring(0, 9).Equals("Pois �. E"))
        {
            isFinish = false;
            isPlayerInTable = false;

            nome.text = "Agnes:";
            legenda.text = "Ainda bem que voc� t� aberto. N�o tive tempo essa semana pra olhar essas pe�as. ";
            StartCoroutine(waiter(4));

        }
        if (isFinish && isAgnes && legenda.text.Substring(0, 9).Equals("Ainda bem"))
        {
            isFinish = false;
            isPlayerInTable = false;

            nome.text = "Agnes:";
            legenda.text = "T�o imundas, acho que por isso que o computador do Gabriel n�o funciona mais. Pode dar uma olhada a� ?";
            StartCoroutine(waiter(4));

        }
        if (isFinish && isAgnes && legenda.text.Substring(0, 9).Equals("T�o imund"))
        {
            /*isFinish = false;
            isPlayerInTable = false;

            nome.text = "Agnes:";
            legenda.text = "T�o imundas, acho que por isso que o computador do Gabriel n�o funciona mais. Pode dar uma olhada a� ?";
            StartCoroutine(waiter(4));*/

            //A��O LIMPAR PE�AS

        }


        /*Agnes: Noite, Jer�nimo. Come�ou agora? 

Jer�nimo: Pois �. E pelo visto seu turno foi longo hoje. 

Agnes: Nem me fala. 
Ainda bem que voc� t� aberto. N�o tive tempo essa semana pra olhar essas pe�as. 
T�o imundas, acho que por isso que o computador do Gabriel n�o funciona mais. 
Pode dar uma olhada a�? 
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
