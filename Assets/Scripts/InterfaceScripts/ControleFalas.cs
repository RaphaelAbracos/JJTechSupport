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
                legenda.text = "Mais um turno… Pelo menos é melhor do que ficar naquela casa vazia";
                nome.text = "Jerônimo:";
                nome.color = Color.blue;
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
                nome.color = Color.gray;
                legenda.text = "Em outras notícias, recebemos um relato não confirmado de um acidente na penitenciária da cidade na noite passada";
                StartCoroutine(waiter(5));

            }
            if (legenda.text.Substring(0, 9).Equals("Em outras") && isFinish)
            {
                isFinish = false;
                isPlayerInTable = false;
                nome.text = "Rádio:";
                nome.color = Color.gray;
                legenda.text = "Ainda não há estimativas do número de feridos";

                //TIRAR DAQUI PARA RAPHAEL DEFINIR


                StartCoroutine(waiter(2));


            }
            if (isFinish && isAgnes && legenda.text.Substring(0, 9).Equals("Ainda não"))
            {
                isFinish = false;

                nome.text = "Agnes:";
                nome.color = Color.yellow;
                nome.color = Color.yellow;
                legenda.text = "Noite, Jerônimo. Começou agora?";
                StartCoroutine(waiter(4));

            }
            if (isFinish && isAgnes && legenda.text.Substring(0, 9).Equals("Noite, Je"))
            {
                isFinish = false;

                nome.text = "Jerônimo:";
                nome.color = Color.blue;
                legenda.text = "Pois é. E pelo visto seu turno foi longo hoje";
                StartCoroutine(waiter(4));

            }
            if (isFinish && isAgnes && legenda.text.Substring(0, 9).Equals("Pois é. E"))
            {
                isFinish = false;

                nome.text = "Agnes:";
                nome.color = Color.yellow;
                legenda.text = "Ainda bem que você tá aberto. Não tive tempo essa semana pra olhar essas peças. ";
                StartCoroutine(waiter(5));

            }
            if (isFinish && isAgnes && legenda.text.Substring(0, 9).Equals("Ainda bem"))
            {
                isFinish = false;

                nome.text = "Agnes:";
                nome.color = Color.yellow;
                legenda.text = "Tão imundas, acho que por isso que o computador do Gabriel não funciona mais. Pode dar uma olhada aí ?";
                StartCoroutine(waiter(5));

            }
            if (isFinish && isAgnes && legenda.text.Substring(0, 9).Equals("Tão imund"))
            {
                nome.text = "";
                legenda.text = "";
                NPCHandler.ChamarPecas();
                /*isFinish = false;
                isPlayerInTable = false;

                nome.text = "Agnes:";
                legenda.text = "Tão imundas, acho que por isso que o computador do Gabriel não funciona mais. Pode dar uma olhada aí ?";
                StartCoroutine(waiter(4));*/

                //AÇÃO LIMPAR PEÇAS
                StartCoroutine(waiter(2));

            }
            //verifica se limpa pecas ja acabou

            if (isLimpaPecasAcabou && isFinish && isAgnes && legenda.text.Substring(0, 9).Equals("LimpandoP"))
            {
                isFinish = false;
                Missao.color = new Color(255, 244, 0, 255);
                nome.text = "Agnes:";
                nome.color = Color.yellow;
                legenda.text = "Você viu a notícia sobre a prisão? Fiquei horrorizada. Justo hoje também. ";
                StartCoroutine(waiter(5));
            }

            if (isLimpaPecasAcabou && isFinish && isAgnes && legenda.text.Substring(0, 9).Equals("Você viu "))
            {
                isFinish = false;

                nome.text = "Agnes:";
                nome.color = Color.yellow;
                legenda.text = "Eu até ia na igreja acender uma vela por conta do aniversário da morte da Aninha, mas fiquei assustada. Ai, lembro até hoje quando o pessoal aqui do bairro falou pra mim o que aconteceu. ";
                StartCoroutine(waiter(7));
            }

            if (isLimpaPecasAcabou && isFinish && isAgnes && legenda.text.Substring(0, 9).Equals("Eu até ia"))
            {
                isFinish = false;

                nome.text = "Agnes:";
                nome.color = Color.yellow;
                legenda.text = "Nem parece que se passaram doze anos, parece que foi ontem. Mas eu vou acender a vela pra ela, nem que seja amanhã. ";
                StartCoroutine(waiter(5));
            }
            if (isLimpaPecasAcabou && isFinish && isAgnes && legenda.text.Substring(0, 9).Equals("Nem parec"))
            {
                isFinish = false;

                nome.text = "Jerônimo:";
                nome.color = Color.blue;
                legenda.text = "Você tem um bom coração, Agnes. Pronto, novo em folha. ";

                StartCoroutine(waiter(4));
            }
            //AGNES SAI isAgnes = false; isLimpaPecasAcabou = true;
            if (isFinish && legenda.text.Substring(0, 9).Equals("Você tem "))
            {
                isFinish = false;
                NPCHandler.isAgnisleft = true;
                nome.text = "Rádio:";
                nome.color = Color.gray;
                legenda.text = "Acabamos de receber a confirmação que alguns detentos não identificados não foram localizados depois do acidente. ";

                StartCoroutine(waiter(5));
            }
            if (isFinish && legenda.text.Substring(0, 9).Equals("Acabamos "))
            {
                isFinish = false;

                nome.text = "Rádio:";
                nome.color = Color.gray;
                legenda.text = "Estamos com uma de nossas repórteres no local, e em breve retornaremos com mais notícias.";

                StartCoroutine(waiter(5));
            }
            if (isFinish && isGaroto && legenda.text.Substring(0, 9).Equals("Estamos c"))
            {
                isFinish = false;

                nome.text = "Morador Novo:";
                nome.color = Color.cyan;
                legenda.text = "Opa, moço. Você tem RAM a do meu PC queimou";

                StartCoroutine(waiter(4));
            }
            if (isFinish && isGaroto && legenda.text.Substring(0, 9).Equals("Opa, moço"))
            {
                isFinish = false;

                nome.text = "Jerônimo:";
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
                legenda.text = "Tão imundas, acho que por isso que o computador do Gabriel não funciona mais. Pode dar uma olhada aí ?";
                StartCoroutine(waiter(4));*/

                //AÇÃO LIMPAR PEÇAS
                StartCoroutine(waiter(2));

            }
            if (isFinish && isGaroto && isColocouRAM && legenda.text.Substring(0, 9).Equals("Colocando"))
            {
                isFinish = false;
                Missao1.color = new Color(255, 244, 0, 255);
                nome.text = "Morador Novo:";
                nome.color = Color.cyan;
                legenda.text = "Cara, cê viu a notícia? Muito doido";

                StartCoroutine(waiter(3));
            }
            if (isFinish && isGaroto && isColocouRAM && legenda.text.Substring(0, 9).Equals("Cara, cê "))
            {
                isFinish = false;

                nome.text = "Morador Novo:";
                nome.color = Color.cyan;
                legenda.text = "Essa cidade tá ficando cada vez melhor. Esses dias tavam me contando de um assassinato que rolou aqui uns anos atrás. Falaram que a menina ficou cinco dias presa com um cara e acharam ela só duas semanas depois.";

                StartCoroutine(waiter(8));
            }
            if (isFinish && isGaroto && isColocouRAM && legenda.text.Substring(0, 9).Equals("Essa cida"))
            {
                isFinish = false;

                nome.text = "Morador Novo:";
                nome.color = Color.cyan;
                legenda.text = "Levaram ela do lado da escola, cê acredita? É muita incompetência mesmo, ainda mais quando você pensa que…";

                StartCoroutine(waiter(6));
            }
            if (isFinish && isGaroto && isColocouRAM && legenda.text.Substring(0, 9).Equals("Levaram e"))
            {
                isFinish = false;

                nome.text = "Jerônimo:";
                nome.color = Color.blue;
                legenda.text = "A peça tá encaixada. Boa noite pra você.";

                StartCoroutine(waiter(4));
            }
            if (isFinish && isGaroto && isColocouRAM && legenda.text.Substring(0, 9).Equals("A peça tá"))
            {
                isFinish = false;

                nome.text = "Morador Novo:";
                nome.color = Color.cyan;
                legenda.text = "Nossa, calma cara. Beleza, tô vazando. ";

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

                nome.text = "Jerônimo:";
                nome.color = Color.blue;
                legenda.text = "Ahn… Boa noite. No que posso ajudar?";

                StartCoroutine(waiter(4));
            }
            if (isFinish && isAssassino && legenda.text.Substring(0, 9).Equals("Ahn… Boa "))
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
                legenda.text = "Eu queria que você montasse um computador pra mim com o software RBCR nele.";

                StartCoroutine(waiter(4));
            }
            if (isFinish && isAssassino && legenda.text.Substring(0, 9).Equals("Eu queria"))
            {
                isFinish = false;

                nome.text = "Jerônimo:";
                nome.color = Color.blue;
                legenda.text = "Certo… Tem alguma coisa em mente? ";

                StartCoroutine(waiter(4));
            }
            if (isFinish && isAssassino && legenda.text.Substring(0, 9).Equals("Certo… Te"))
            {
                isFinish = false;

                nome.text = "Homem:";
                nome.color = Color.red;
                legenda.text = "Usa as suas melhores peças. Quero ele completamente funcional. ";

                StartCoroutine(waiter(5));
            }
            if (isFinish && isAssassino && legenda.text.Substring(0, 9).Equals("Usa as su"))
            {
                isFinish = false;

                nome.text = "Jerônimo:";
                nome.color = Color.blue;
                legenda.text = "Ok, só vai levar um tempo.";

                StartCoroutine(waiter(3));
            }
            if (isFinish && isAssassino && legenda.text.Substring(0, 9).Equals("Ok, só va"))
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

                nome.text = "Jerônimo:";
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
                legenda.text = "Você mora aqui há bastante tempo?";

                StartCoroutine(waiter(3));
            }
            if (isFinish && isAssassino && isMontouPc && legenda.text.Substring(0, 9).Equals("Você mora"))
            {
                isFinish = false;
                nome.text = "Jerônimo:";
                nome.color = Color.blue;
                legenda.text = "Minha vida toda. ";

                StartCoroutine(waiter(2));
            }
            if (isFinish && isAssassino && isMontouPc && legenda.text.Substring(0, 9).Equals("Minha vid"))
            {
                isFinish = false;
                nome.text = "Homem:";
                nome.color = Color.red;
                legenda.text = "Nunca gostei desse lugar. Qualquer coisinha vira escândalo, todo mundo comenta. As outras cidades que trabalhei eram bem mais discretas. ";

                StartCoroutine(waiter(5));
            }
            if (isFinish && isAssassino && isMontouPc && legenda.text.Substring(0, 9).Equals("Nunca gos"))
            {
                isFinish = false;
                nome.text = "Homem:";
                nome.color = Color.red;
                legenda.text = "Você podia fazer qualquer coisa e ser invisível. ";

                StartCoroutine(waiter(3));
            }
            if (isFinish && isAssassino && isMontouPc && legenda.text.Substring(0, 9).Equals("Você podi"))
            {
                isFinish = false;
                nome.text = "Jerônimo:";
                nome.color = Color.blue;
                legenda.text = "Eu gosto do pessoal da cidade. São pessoas boas. ";

                StartCoroutine(waiter(2));
            }
            if (isFinish && isAssassino && isMontouPc && legenda.text.Substring(0, 9).Equals("Eu gosto "))
            {
                isFinish = false;
                nome.text = "Homem:";
                nome.color = Color.red;
                legenda.text = "Todas elas? Até mesmo escolas que negligenciam sua responsabilidade com as crianças ? Ou a polícia que ignora denúncias de desaparecimentos? ";

                StartCoroutine(waiter(6));
            }
            if (isFinish && isAssassino && isMontouPc && legenda.text.Substring(0, 9).Equals("Todas ela"))
            {
                isFinish = false;
                isFinish = false;
                nome.text = "Jerônimo:";
                nome.color = Color.blue;
                legenda.text = "As pessoas que eu conheço são boas.";

                StartCoroutine(waiter(3));
            }
            if (isFinish && isAssassino && isMontouPc && legenda.text.Substring(0, 9).Equals("As pessoa"))
            {
                isFinish = false;
                nome.text = "Homem:";
                nome.color = Color.red;
                legenda.text = "Não. O mundo é cheio de monstros, você já deveria saber disso. ";

                StartCoroutine(waiter(3));
            }
            if (isFinish && isAssassino && isMontouPc && legenda.text.Substring(0, 9).Equals("Não. O mu"))
            {
                isFinish = false;
                nome.text = "Homem:";
                nome.color = Color.red;
                legenda.text = "Não sei que tipo de sem noção traria uma criança pra esse mundo. Você tem filhos, Jerônimo? ";

                StartCoroutine(waiter(4));
            }
            if (isFinish && isAssassino && isMontouPc && legenda.text.Substring(0, 9).Equals("Não sei q"))
            {
                isFinish = false;
                nome.text = "Jerônimo:";
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
                nome.text = "Jerônimo:";
                nome.color = Color.blue;
                legenda.text = "Muito.   ";

                StartCoroutine(waiter(2));
            }
            if (isFinish && isAssassino && isMontouPc && legenda.text.Substring(0, 9).Equals("Muito.   "))
            {
                isFinish = false;
                nome.text = "Homem:";
                nome.color = Color.red;
                legenda.text = "Igualzinha ao pai. Aposto que ela era o tipo de fã que tinha adesivos dos jogadores no caderno da escola.";

                StartCoroutine(waiter(5));
            }
            if (isFinish && isAssassino && isMontouPc && legenda.text.Substring(0, 9).Equals("Igualzinh"))
            {
                isFinish = false;
                nome.text = "Rádio:";
                nome.color = Color.gray;
                legenda.text = "Atenção. Um detento extremamente perigoso está à solta na cidade após o acidente na penitenciária. ";

                StartCoroutine(waiter(5));
            }
            if (isFinish && isAssassino && isMontouPc && legenda.text.Substring(0, 9).Equals("Atenção. "))
            {
                isFinish = false;
                nome.text = "Rádio:";
                nome.color = Color.gray;
                legenda.text = "Ele é um homem branco, tem estatura mediana e barba castanha escura. Se ver alguém assim, contate as autoridades imediatamente e não se aproxime.";

                StartCoroutine(waiter(6));
            }
            if (isFinish && isAssassino && isMontouPc && legenda.text.Substring(0, 9).Equals("Ele é um "))
            {
                isFinish = false;
                nome.text = "Jerônimo:";
                nome.color = Color.blue;
                legenda.text = "   ....  ";

                StartCoroutine(waiter(2));
            }
            if (isFinish && isAssassino && isMontouPc && legenda.text.Substring(0, 9).Equals("   ....  "))
            {
                isFinish = false;
                nome.text = "Homem:";
                nome.color = Color.red;
                legenda.text = "E usava a camisa do time nas aulas de educação física. ";

                StartCoroutine(waiter(4));
            }
            if (isFinish && isAssassino && isMontouPc && legenda.text.Substring(0, 9).Equals("E usava a"))
            {
                isFinish = false;
                nome.text = "Jerônimo:";
                nome.color = Color.blue;
                legenda.text = "Eu… Eu tô quase acabando. ";

                StartCoroutine(waiter(3));
            }
            if (isFinish && isAssassino && isMontouPc && legenda.text.Substring(0, 9).Equals("Eu… Eu tô"))
            {
                isFinish = false;
                nome.text = "Homem: ";
                legenda.text = "Como está a sua esposa? Faz muito tempo que não fala com ela? ";

                StartCoroutine(waiter(4));
            }
            if (isFinish && isAssassino && isMontouPc && legenda.text.Substring(0, 9).Equals("Como está"))
            {
                isFinish = false;
                nome.text = "Jerônimo:";
                nome.color = Color.blue;
                legenda.text = "Quem é você?";

                StartCoroutine(waiter(3));
            }
            if (isFinish && isAssassino && isMontouPc && legenda.text.Substring(0, 9).Equals("Quem é vo"))
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
                nome.text = "Jerônimo:";
                nome.color = Color.blue;
                legenda.text = "Sai da minha loja ou eu chamo a polícia. ";

                StartCoroutine(waiter(3));
            }
            if (isFinish && isAssassino && isMontouPc && legenda.text.Substring(0, 9).Equals("Sai da mi"))
            {
                isFinish = false;
                nome.text = "Homem:";
                nome.color = Color.red;
                legenda.text = "Pena que não dei tempo pra ela chorar. Fiquei muitos anos esperando pra terminar o trabalho.";

                StartCoroutine(waiter(4));
            }
            if (isFinish && isAssassino && isMontouPc && legenda.text.Substring(0, 9).Equals("Pena que "))
            {
                isFinish = false;
                nome.text = "Homem:";
                nome.color = Color.red;
                legenda.text = "Agora só restou você. Completamente sozinho.";

                StartCoroutine(waiter(3));
            }
            if (isFinish && isAssassino && isMontouPc && legenda.text.Substring(0, 9).Equals("Agora só "))
            {
                isFinish = false;
                nome.text = "Homem:";
                nome.color = Color.red;
                legenda.text = "Dá oi pra Aninha por mim.";

                StartCoroutine(waiter(3));
                StartCoroutine(NPCHandler.DestroyAssassino());
            }

            //(Jerônimo morre)
        }
        catch (Exception e)
        {
            
        }

        }


}
