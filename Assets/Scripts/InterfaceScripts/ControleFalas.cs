using System;
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

    public TMPro.TextMeshProUGUI Missao;
    public TMPro.TextMeshProUGUI Missao1;
    public TMPro.TextMeshProUGUI Missao2;

    public string[] stringArray;

    int i = 0;

    public int seg;
    public int min;
    public int hor;

    public bool isFinish = true;
    public bool isPlayerInTable = false;

    public float letterPause;

    public bool isAgnes = false;
    public bool isGaroto = false;
    public bool isAssassino = false;
    public bool isLimpaPecasAcabou = false;
    public bool isColocouRAM = false;
    public bool isMontouPc = false;

    NPCHandler NPCHandler;

    public int vezesLimpa = 0;
    public int vezesMontaRam = 0;
    public int vezesMontaPC= 0;
    void Start()
    {
 
        CronometroText.text = "0";
        StartCoroutine("cronometro");
        legenda.text = "Texto inicial";
        legenda.fontStyle = FontStyles.Bold;
        NPCHandler = FindObjectOfType<NPCHandler>();

        //StartCoroutine(TypeText(0));




    }

    // Update is called once per frame
    void Update()
    {
        if (isMontouPc)
        {
            if (vezesMontaPC <= 0)
            {
                legenda.text = "MontandoPC";
                isFinish = true;
                vezesMontaPC++;
            }


        }

        if (isColocouRAM)
        {
            if (vezesMontaRam <= 0)
            {
                legenda.text = "ColocandoRam";
                isFinish = true;
                vezesMontaRam++;
            }
            
            
        }
        if (isLimpaPecasAcabou)
        {
            if (vezesLimpa <= 0)
            {
                legenda.text = "LimpandoPecas";
                isFinish = true;
                vezesLimpa++;
            }


        }
        if (!legenda.text.Equals(""))
        {
            falas();
        }
       

    }
    IEnumerator waiter(int tempo)
    {

        yield return new WaitForSeconds(tempo);
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


    void falas()
    {
        try
        {
            int tempoPadraoTeste = 1;
            if (legenda.text.Substring(0, 9).Equals("Texto ini") && isFinish)
            {
                isFinish = false;
                legenda.text = "Mais um turno� Pelo menos � melhor do que ficar naquela casa vazia";
                nome.text = "Jer�nimo:";
                nome.color = Color.blue;
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
                nome.color = Color.gray;
                legenda.text = "Em outras not�cias, recebemos um relato n�o confirmado de um acidente na penitenci�ria da cidade na noite passada";
                StartCoroutine(waiter(5));

            }
            if (legenda.text.Substring(0, 9).Equals("Em outras") && isFinish)
            {
                isFinish = false;
                isPlayerInTable = false;
                nome.text = "R�dio:";
                nome.color = Color.gray;
                legenda.text = "Ainda n�o h� estimativas do n�mero de feridos";

                //TIRAR DAQUI PARA RAPHAEL DEFINIR


                StartCoroutine(waiter(2));


            }
            if (isFinish && isAgnes && legenda.text.Substring(0, 9).Equals("Ainda n�o"))
            {
                isFinish = false;

                nome.text = "Agnes:";
                nome.color = Color.yellow;
                nome.color = Color.yellow;
                legenda.text = "Noite, Jer�nimo. Come�ou agora?";
                StartCoroutine(waiter(4));

            }
            if (isFinish && isAgnes && legenda.text.Substring(0, 9).Equals("Noite, Je"))
            {
                isFinish = false;

                nome.text = "Jer�nimo:";
                nome.color = Color.blue;
                legenda.text = "Pois �. E pelo visto seu turno foi longo hoje";
                StartCoroutine(waiter(4));

            }
            if (isFinish && isAgnes && legenda.text.Substring(0, 9).Equals("Pois �. E"))
            {
                isFinish = false;

                nome.text = "Agnes:";
                nome.color = Color.yellow;
                legenda.text = "Ainda bem que voc� t� aberto. N�o tive tempo essa semana pra olhar essas pe�as. ";
                StartCoroutine(waiter(5));

            }
            if (isFinish && isAgnes && legenda.text.Substring(0, 9).Equals("Ainda bem"))
            {
                isFinish = false;

                nome.text = "Agnes:";
                nome.color = Color.yellow;
                legenda.text = "T�o imundas, acho que por isso que o computador do Gabriel n�o funciona mais. Pode dar uma olhada a� ?";
                StartCoroutine(waiter(5));

            }
            if (isFinish && isAgnes && legenda.text.Substring(0, 9).Equals("T�o imund"))
            {
                nome.text = "";
                legenda.text = "";
                NPCHandler.ChamarPecas();
                /*isFinish = false;
                isPlayerInTable = false;

                nome.text = "Agnes:";
                legenda.text = "T�o imundas, acho que por isso que o computador do Gabriel n�o funciona mais. Pode dar uma olhada a� ?";
                StartCoroutine(waiter(4));*/

                //A��O LIMPAR PE�AS
                StartCoroutine(waiter(2));

            }
            //verifica se limpa pecas ja acabou

            if (isLimpaPecasAcabou && isFinish && isAgnes && legenda.text.Substring(0, 9).Equals("LimpandoP"))
            {
                isFinish = false;
                Missao.color = new Color(255, 244, 0, 255);
                nome.text = "Agnes:";
                nome.color = Color.yellow;
                legenda.text = "Voc� viu a not�cia sobre a pris�o? Fiquei horrorizada. Justo hoje tamb�m. ";
                StartCoroutine(waiter(5));
            }

            if (isLimpaPecasAcabou && isFinish && isAgnes && legenda.text.Substring(0, 9).Equals("Voc� viu "))
            {
                isFinish = false;

                nome.text = "Agnes:";
                nome.color = Color.yellow;
                legenda.text = "Eu at� ia na igreja acender uma vela por conta do anivers�rio da morte da Aninha, mas fiquei assustada. Ai, lembro at� hoje quando o pessoal aqui do bairro falou pra mim o que aconteceu. ";
                StartCoroutine(waiter(7));
            }

            if (isLimpaPecasAcabou && isFinish && isAgnes && legenda.text.Substring(0, 9).Equals("Eu at� ia"))
            {
                isFinish = false;

                nome.text = "Agnes:";
                nome.color = Color.yellow;
                legenda.text = "Nem parece que se passaram doze anos, parece que foi ontem. Mas eu vou acender a vela pra ela, nem que seja amanh�. ";
                StartCoroutine(waiter(5));
            }
            if (isLimpaPecasAcabou && isFinish && isAgnes && legenda.text.Substring(0, 9).Equals("Nem parec"))
            {
                isFinish = false;

                nome.text = "Jer�nimo:";
                nome.color = Color.blue;
                legenda.text = "Voc� tem um bom cora��o, Agnes. Pronto, novo em folha. ";

                StartCoroutine(waiter(4));
            }
            //AGNES SAI isAgnes = false; isLimpaPecasAcabou = true;
            if (isFinish && legenda.text.Substring(0, 9).Equals("Voc� tem "))
            {
                isFinish = false;
                NPCHandler.isAgnisleft = true;
                nome.text = "R�dio:";
                nome.color = Color.gray;
                legenda.text = "Acabamos de receber a confirma��o que alguns detentos n�o identificados n�o foram localizados depois do acidente. ";

                StartCoroutine(waiter(5));
            }
            if (isFinish && legenda.text.Substring(0, 9).Equals("Acabamos "))
            {
                isFinish = false;

                nome.text = "R�dio:";
                nome.color = Color.gray;
                legenda.text = "Estamos com uma de nossas rep�rteres no local, e em breve retornaremos com mais not�cias.";

                StartCoroutine(waiter(5));
            }
            if (isFinish && isGaroto && legenda.text.Substring(0, 9).Equals("Estamos c"))
            {
                isFinish = false;

                nome.text = "Morador Novo:";
                nome.color = Color.cyan;
                legenda.text = "Opa, mo�o. Voc� tem RAM a do meu PC queimou";

                StartCoroutine(waiter(4));
            }
            if (isFinish && isGaroto && legenda.text.Substring(0, 9).Equals("Opa, mo�o"))
            {
                isFinish = false;

                nome.text = "Jer�nimo:";
                nome.color = Color.blue;
                legenda.text = "Boa noite, vamos ver";

                StartCoroutine(waiter(2));
            }
            if (isFinish && isGaroto && legenda.text.Substring(0, 9).Equals("Boa noite"))
            {
                nome.text = "";
                legenda.text = "";
                NPCHandler.ChamarRAM();
                /*isFinish = false;
                isPlayerInTable = false;
                
                nome.text = "Agnes:";
                legenda.text = "T�o imundas, acho que por isso que o computador do Gabriel n�o funciona mais. Pode dar uma olhada a� ?";
                StartCoroutine(waiter(4));*/

                //A��O LIMPAR PE�AS
                StartCoroutine(waiter(2));

            }
            if (isFinish && isGaroto && isColocouRAM && legenda.text.Substring(0, 9).Equals("Colocando"))
            {
                isFinish = false;
                Missao1.color = new Color(255, 244, 0, 255);
                nome.text = "Morador Novo:";
                nome.color = Color.cyan;
                legenda.text = "Cara, c� viu a not�cia? Muito doido";

                StartCoroutine(waiter(3));
            }
            if (isFinish && isGaroto && isColocouRAM && legenda.text.Substring(0, 9).Equals("Cara, c� "))
            {
                isFinish = false;

                nome.text = "Morador Novo:";
                nome.color = Color.cyan;
                legenda.text = "Essa cidade t� ficando cada vez melhor. Esses dias tavam me contando de um assassinato que rolou aqui uns anos atr�s. Falaram que a menina ficou cinco dias presa com um cara e acharam ela s� duas semanas depois.";

                StartCoroutine(waiter(8));
            }
            if (isFinish && isGaroto && isColocouRAM && legenda.text.Substring(0, 9).Equals("Essa cida"))
            {
                isFinish = false;

                nome.text = "Morador Novo:";
                nome.color = Color.cyan;
                legenda.text = "Levaram ela do lado da escola, c� acredita? � muita incompet�ncia mesmo, ainda mais quando voc� pensa que�";

                StartCoroutine(waiter(6));
            }
            if (isFinish && isGaroto && isColocouRAM && legenda.text.Substring(0, 9).Equals("Levaram e"))
            {
                isFinish = false;

                nome.text = "Jer�nimo:";
                nome.color = Color.blue;
                legenda.text = "A pe�a t� encaixada. Boa noite pra voc�.";

                StartCoroutine(waiter(4));
            }
            if (isFinish && isGaroto && isColocouRAM && legenda.text.Substring(0, 9).Equals("A pe�a t�"))
            {
                isFinish = false;

                nome.text = "Morador Novo:";
                nome.color = Color.cyan;
                legenda.text = "Nossa, calma cara. Beleza, t� vazando. ";

                StartCoroutine(waiter(4));
            }
            //GAROTO SAI isGaroto = false; isColocouRam = false;

            //ASSASSINO ENTRA E PARADO
            if (isFinish && isAssassino && legenda.text.Substring(0, 9).Equals("Nossa, ca"))
            {
                isFinish = false;

                nome.text = "Homem:";
                nome.color = Color.red;
                legenda.text = "   ...   ";

                StartCoroutine(waiter(3));
            }
            if (isFinish && isAssassino && legenda.text.Substring(0, 9).Equals("   ...   "))
            {
                isFinish = false;

                nome.text = "Jer�nimo:";
                nome.color = Color.blue;
                legenda.text = "Ahn� Boa noite. No que posso ajudar?";

                StartCoroutine(waiter(4));
            }
            if (isFinish && isAssassino && legenda.text.Substring(0, 9).Equals("Ahn� Boa "))
            {
                isFinish = false;

                nome.text = "Homem:";
                nome.color = Color.red;
                legenda.text = "    ...   ";

                StartCoroutine(waiter(2));
            }
            if (isFinish && isAssassino && legenda.text.Substring(0, 9).Equals("    ...  "))
            {
                isFinish = false;

                nome.text = "Homem:";
                nome.color = Color.red;
                legenda.text = "Eu queria que voc� montasse um computador pra mim com o software RBCR nele.";

                StartCoroutine(waiter(4));
            }
            if (isFinish && isAssassino && legenda.text.Substring(0, 9).Equals("Eu queria"))
            {
                isFinish = false;

                nome.text = "Jer�nimo:";
                nome.color = Color.blue;
                legenda.text = "Certo� Tem alguma coisa em mente? ";

                StartCoroutine(waiter(4));
            }
            if (isFinish && isAssassino && legenda.text.Substring(0, 9).Equals("Certo� Te"))
            {
                isFinish = false;

                nome.text = "Homem:";
                nome.color = Color.red;
                legenda.text = "Usa as suas melhores pe�as. Quero ele completamente funcional. ";

                StartCoroutine(waiter(5));
            }
            if (isFinish && isAssassino && legenda.text.Substring(0, 9).Equals("Usa as su"))
            {
                isFinish = false;

                nome.text = "Jer�nimo:";
                nome.color = Color.blue;
                legenda.text = "Ok, s� vai levar um tempo.";

                StartCoroutine(waiter(3));
            }
            if (isFinish && isAssassino && legenda.text.Substring(0, 9).Equals("Ok, s� va"))
            {
                isFinish = false;

                nome.text = "Homem:";
                nome.color = Color.red;
                legenda.text = "Agora eu tenho tempo de sobra.";

                StartCoroutine(waiter(3));
            }
            if (isFinish && isAssassino && legenda.text.Substring(0, 9).Equals("Agora eu "))
            {
                isFinish = false;

                nome.text = "Jer�nimo:";
                nome.color = Color.blue;
                legenda.text = "E vai ser caro. ";

                StartCoroutine(waiter(2));
            }
            if (isFinish && isAssassino && legenda.text.Substring(0, 9).Equals("E vai ser"))
            {
                isFinish = false;

                nome.text = "Homem:";
                nome.color = Color.red;
                legenda.text = "Eu pago. ";

                StartCoroutine(waiter(2));
            }
            //inicia montagem
            if (isFinish && isAssassino && legenda.text.Substring(0, 9).Equals("Eu pago. "))
            {
                isFinish = false;
                nome.text = "";
                legenda.text = "";
                NPCHandler.ChamarPlaca();
                StartCoroutine(waiter(2));
            }

            if (isFinish && isAssassino && isMontouPc && legenda.text.Substring(0, 9).Equals("MontandoP"))
            {
                isFinish = false;
                Missao2.color = new Color(255, 244, 0, 255);
                nome.text = "Homem:";
                nome.color = Color.red;
                legenda.text = "Voc� mora aqui h� bastante tempo?";

                StartCoroutine(waiter(3));
            }
            if (isFinish && isAssassino && isMontouPc && legenda.text.Substring(0, 9).Equals("Voc� mora"))
            {
                isFinish = false;
                nome.text = "Jer�nimo:";
                nome.color = Color.blue;
                legenda.text = "Minha vida toda. ";

                StartCoroutine(waiter(2));
            }
            if (isFinish && isAssassino && isMontouPc && legenda.text.Substring(0, 9).Equals("Minha vid"))
            {
                isFinish = false;
                nome.text = "Homem:";
                nome.color = Color.red;
                legenda.text = "Nunca gostei desse lugar. Qualquer coisinha vira esc�ndalo, todo mundo comenta. As outras cidades que trabalhei eram bem mais discretas. ";

                StartCoroutine(waiter(5));
            }
            if (isFinish && isAssassino && isMontouPc && legenda.text.Substring(0, 9).Equals("Nunca gos"))
            {
                isFinish = false;
                nome.text = "Homem:";
                nome.color = Color.red;
                legenda.text = "Voc� podia fazer qualquer coisa e ser invis�vel. ";

                StartCoroutine(waiter(3));
            }
            if (isFinish && isAssassino && isMontouPc && legenda.text.Substring(0, 9).Equals("Voc� podi"))
            {
                isFinish = false;
                nome.text = "Jer�nimo:";
                nome.color = Color.blue;
                legenda.text = "Eu gosto do pessoal da cidade. S�o pessoas boas. ";

                StartCoroutine(waiter(2));
            }
            if (isFinish && isAssassino && isMontouPc && legenda.text.Substring(0, 9).Equals("Eu gosto "))
            {
                isFinish = false;
                nome.text = "Homem:";
                nome.color = Color.red;
                legenda.text = "Todas elas? At� mesmo escolas que negligenciam sua responsabilidade com as crian�as ? Ou a pol�cia que ignora den�ncias de desaparecimentos? ";

                StartCoroutine(waiter(6));
            }
            if (isFinish && isAssassino && isMontouPc && legenda.text.Substring(0, 9).Equals("Todas ela"))
            {
                isFinish = false;
                isFinish = false;
                nome.text = "Jer�nimo:";
                nome.color = Color.blue;
                legenda.text = "As pessoas que eu conhe�o s�o boas.";

                StartCoroutine(waiter(3));
            }
            if (isFinish && isAssassino && isMontouPc && legenda.text.Substring(0, 9).Equals("As pessoa"))
            {
                isFinish = false;
                nome.text = "Homem:";
                nome.color = Color.red;
                legenda.text = "N�o. O mundo � cheio de monstros, voc� j� deveria saber disso. ";

                StartCoroutine(waiter(3));
            }
            if (isFinish && isAssassino && isMontouPc && legenda.text.Substring(0, 9).Equals("N�o. O mu"))
            {
                isFinish = false;
                nome.text = "Homem:";
                nome.color = Color.red;
                legenda.text = "N�o sei que tipo de sem no��o traria uma crian�a pra esse mundo. Voc� tem filhos, Jer�nimo? ";

                StartCoroutine(waiter(4));
            }
            if (isFinish && isAssassino && isMontouPc && legenda.text.Substring(0, 9).Equals("N�o sei q"))
            {
                isFinish = false;
                nome.text = "Jer�nimo:";
                nome.color = Color.blue;
                legenda.text = "Uma menina.";

                StartCoroutine(waiter(2));
            }
            if (isFinish && isAssassino && isMontouPc && legenda.text.Substring(0, 9).Equals("Uma menin"))
            {
                isFinish = false;
                nome.text = "Homem:";
                nome.color = Color.red;
                legenda.text = "Interessante. Ela gosta de futebol? ";

                StartCoroutine(waiter(3));
            }
            if (isFinish && isAssassino && isMontouPc && legenda.text.Substring(0, 9).Equals("Interessa"))
            {
                isFinish = false;
                nome.text = "Jer�nimo:";
                nome.color = Color.blue;
                legenda.text = "Muito.   ";

                StartCoroutine(waiter(2));
            }
            if (isFinish && isAssassino && isMontouPc && legenda.text.Substring(0, 9).Equals("Muito.   "))
            {
                isFinish = false;
                nome.text = "Homem:";
                nome.color = Color.red;
                legenda.text = "Igualzinha ao pai. Aposto que ela era o tipo de f� que tinha adesivos dos jogadores no caderno da escola.";

                StartCoroutine(waiter(5));
            }
            if (isFinish && isAssassino && isMontouPc && legenda.text.Substring(0, 9).Equals("Igualzinh"))
            {
                isFinish = false;
                nome.text = "R�dio:";
                nome.color = Color.gray;
                legenda.text = "Aten��o. Um detento extremamente perigoso est� � solta na cidade ap�s o acidente na penitenci�ria. ";

                StartCoroutine(waiter(5));
            }
            if (isFinish && isAssassino && isMontouPc && legenda.text.Substring(0, 9).Equals("Aten��o. "))
            {
                isFinish = false;
                nome.text = "R�dio:";
                nome.color = Color.gray;
                legenda.text = "Ele � um homem branco, tem estatura mediana e barba castanha escura. Se ver algu�m assim, contate as autoridades imediatamente e n�o se aproxime.";

                StartCoroutine(waiter(6));
            }
            if (isFinish && isAssassino && isMontouPc && legenda.text.Substring(0, 9).Equals("Ele � um "))
            {
                isFinish = false;
                nome.text = "Jer�nimo:";
                nome.color = Color.blue;
                legenda.text = "   ....  ";

                StartCoroutine(waiter(2));
            }
            if (isFinish && isAssassino && isMontouPc && legenda.text.Substring(0, 9).Equals("   ....  "))
            {
                isFinish = false;
                nome.text = "Homem:";
                nome.color = Color.red;
                legenda.text = "E usava a camisa do time nas aulas de educa��o f�sica. ";

                StartCoroutine(waiter(4));
            }
            if (isFinish && isAssassino && isMontouPc && legenda.text.Substring(0, 9).Equals("E usava a"))
            {
                isFinish = false;
                nome.text = "Jer�nimo:";
                nome.color = Color.blue;
                legenda.text = "Eu� Eu t� quase acabando. ";

                StartCoroutine(waiter(3));
            }
            if (isFinish && isAssassino && isMontouPc && legenda.text.Substring(0, 9).Equals("Eu� Eu t�"))
            {
                isFinish = false;
                nome.text = "Homem: ";
                legenda.text = "Como est� a sua esposa? Faz muito tempo que n�o fala com ela? ";

                StartCoroutine(waiter(4));
            }
            if (isFinish && isAssassino && isMontouPc && legenda.text.Substring(0, 9).Equals("Como est�"))
            {
                isFinish = false;
                nome.text = "Jer�nimo:";
                nome.color = Color.blue;
                legenda.text = "Quem � voc�?";

                StartCoroutine(waiter(3));
            }
            if (isFinish && isAssassino && isMontouPc && legenda.text.Substring(0, 9).Equals("Quem � vo"))
            {
                isFinish = false;
                nome.text = "Homem:";
                nome.color = Color.red;
                legenda.text = "Aposto que ela ficou arrasada quando soube. Ela tinha cara de quem chorava muito. Acho que a Aninha puxou isso dela. ";

                StartCoroutine(waiter(5));
            }
            if (isFinish && isAssassino && isMontouPc && legenda.text.Substring(0, 9).Equals("Aposto qu"))
            {
                isFinish = false;
                nome.text = "Jer�nimo:";
                nome.color = Color.blue;
                legenda.text = "Sai da minha loja ou eu chamo a pol�cia. ";

                StartCoroutine(waiter(3));
            }
            if (isFinish && isAssassino && isMontouPc && legenda.text.Substring(0, 9).Equals("Sai da mi"))
            {
                isFinish = false;
                nome.text = "Homem:";
                nome.color = Color.red;
                legenda.text = "Pena que n�o dei tempo pra ela chorar. Fiquei muitos anos esperando pra terminar o trabalho.";

                StartCoroutine(waiter(4));
            }
            if (isFinish && isAssassino && isMontouPc && legenda.text.Substring(0, 9).Equals("Pena que "))
            {
                isFinish = false;
                nome.text = "Homem:";
                nome.color = Color.red;
                legenda.text = "Agora s� restou voc�. Completamente sozinho.";

                StartCoroutine(waiter(3));
            }
            if (isFinish && isAssassino && isMontouPc && legenda.text.Substring(0, 9).Equals("Agora s� "))
            {
                isFinish = false;
                nome.text = "Homem:";
                nome.color = Color.red;
                legenda.text = "D� oi pra Aninha por mim.";

                StartCoroutine(waiter(3));
                StartCoroutine(NPCHandler.DestroyAssassino());
            }

            //(Jer�nimo morre)
        }
        catch (Exception e)
        {
            
        }

        }


}
