using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;    // para poder utilizar arquivos

/// <summary>
/// Classe para carregar dados de um arquivo -> eventualmente generalizar para poder operar com os dados gerais e especificos.
/// </summary>
public class LoadData : MonoBehaviour
{
    /// <summary>
    /// Ui Principal
    /// </summary>
    public GameObject UIprincipal; 
    private GameObject UIINST;
    private List<string> listaStrings;
    private List<Button> listaBtns;
    private List<GameObject> listaDADOS;
    /// <summary>
    /// string com o cabeçalho dos dados básicos
    /// </summary>
    public const string strCab = "Nº,Nome,Idade,Sexo,Experiência,T. Museu,T. Química,+";
    /// <summary>
    /// Prefab da UI com os dados extras
    /// </summary>
    public GameObject UIextra;
    /// <summary>
    ///  Texto cabeçalho
    /// </summary>
    public TMP_Text cabecalho;
    /// <summary>
    ///  interface que irá apresentar os dados já coletados 
    /// </summary>
    public GameObject UIDadosGerais;
    /// <summary>
    /// propriedade para exibir que não existem entradas ainda
    /// </summary>
    public TMP_Text noDataText;
    ///  <summary>
    ///  Dados que serão coletados 
    /// </summary>
    public GameObject contentView;
    /// <summary>
    /// preview dados
    /// </summary>
        public GameObject dadosPrefab;
    /// <summary>
    /// Método para exibir os dados. Invocar quando o o botão específico for acionado
    /// </summary>
    private const string fileNameGeral    = "/dadosGerais.csv"; // nome do arquivo
    private const string fileNameTutorial = "/dadosTutorial.csv"; // nome do arquivo
    private const string fileNameObras = "/dadosObras.csv"; // nome do arquivo
    private bool estado = false; 
    public void Start()
    {
        noDataText.gameObject.SetActive(false);
        listaBtns = new List<Button>();
        listaStrings = new List<string>();
        listaDADOS = new List<GameObject>();
    }
    public void BtnExibirDados() {
        UIprincipal.SetActive(false);
        UIDadosGerais.SetActive(true);
        StreamReader leitor; //leitor do arquivo caso já tenha sido criado 
        string diretorio = Application.dataPath + fileNameGeral;
        int count = 0;
        string line; // linha lida
        char tokenIdent = ',';
        if (File.Exists(diretorio))
        { //se existe o arquivo
            noDataText.gameObject.SetActive(false);
            leitor = new StreamReader(diretorio);
            while ((line = leitor.ReadLine()) != null)
            {

                listaStrings.Add(line);
                string[] colunas = line.Split(tokenIdent);
                if (count == 0) // se linha zero carrego o cabeçalho 
                {
                    colunas = strCab.Split(tokenIdent);
                    cabecalho.SetText("");
                    for (int i = 0; i < 8; i++)
                    {
                        if (i != 1)
                            cabecalho.SetText(cabecalho.text + colunas[i] + " | ");
                    }
                }
                else
                {
                    GameObject playerData = GameObject.Instantiate(dadosPrefab);
                    listaDADOS.Add(playerData);
                    listaBtns.Add(playerData.GetComponentInChildren<Button>());
                    playerData.transform.SetParent(contentView.transform);
                    playerData.transform.localScale = new Vector3(1, 1, 1);
                    playerData.transform.localPosition = Vector3.zero;
                    TMP_Text[] tmpAux = playerData.GetComponentsInChildren<TMP_Text>();

                    for (int i = 0; i < 8; i++)
                    {
                        if (i != 1 && i != 5)
                        {

                            if (i < 1)
                            {
                                tmpAux[i].SetText("");
                                tmpAux[i].SetText(tmpAux[i].text + colunas[i]);
                            }
                            else if (i > 1 && i < 5)
                            {

                                tmpAux[i - 1].SetText("");
                                tmpAux[i - 1].SetText(tmpAux[i - 1].text + colunas[i]);
                            }
                            else
                            {
                                tmpAux[i - 2].SetText("");
                                tmpAux[i - 2].SetText(tmpAux[i - 2].text + colunas[i]);
                            }
                        }
                    }
                }
                count++;

            }
            leitor.Close();
            // verifica se existe o arquivo com os dados gerais 
            // se existir carregar o cabeçalho 
            // carregar os dados enquando não chegar o EOF.
            UIDadosGerais.SetActive(true); // pensar como criar as listas como filhos do content da UI
            for(int i=0; i <listaBtns.Count; i++)
            {
                int posIndex = i;  // para fugir do problema do closure problem.
                                   // tenho que usar um pouco de ponteiros tambem
                listaBtns[posIndex].onClick.AddListener(() => AbriUIExtra(posIndex));
            }
        }
        else {
            noDataText.gameObject.SetActive(true);
        }
        UIDadosGerais.GetComponentInChildren<Button>().onClick.AddListener(() => BtnVoltar());
    }
    /// <summary>
    /// Abre uma url especifica fornecida pelo parametro url
    /// </summary>
    /// <param name="url"></param> url que deve ser aberta
    public void OpenUrlFor(string url)
    {
        Application.OpenURL(url);
    }
    /// <summary>
    /// Fecha a UI dos dados gerais 
    /// </summary>
    public void BtnVoltar() {
        
        foreach(GameObject dado in listaDADOS)
        {
            Destroy(dado);
        }
        UIDadosGerais.SetActive(false);
        UIprincipal.SetActive(true);

        //efeito sonoro é adicionado pelo ambiente.
    }
    private void AbriUIExtra(int indice)
    {
        // MUITO IMPORTANTE Estou preenchendo os campos de acordo com a ordem dentro do prefab. Sim essa prática é muito hard coded. Mas fiquei
        // com bastante dúvida em como fazer isso de forma mais elegante, uma vez que poderia procurar pelo nome, o que não iria melhorar muito.
        // Continuaria extramamente dependente da forma como estruturei o prefab. Enfim, toda essa parte pode ser considerada como um extra,
        // todavia deve existir uma forma muito mais elegante e melhor de implementar isso. Porém ...
        // RESUMINDO: OLHA PARA UI ANTES DE ALTERAR AQUI E VICE-VERSA, sim é uma m ...

        UIINST = GameObject.Instantiate(UIextra, new Vector3(UIDadosGerais.transform.position.x, UIDadosGerais.transform.position.y, UIDadosGerais.transform.position.z), UIDadosGerais.transform.rotation);
        UIDadosGerais.SetActive(false);
        string[] dadosGerais = listaStrings[indice + 1].Split(','); // o mais 1 é para dispensar o cabeçalho
        UIINST.GetComponentInChildren<Button>().onClick.AddListener(() => FecharUIExtra());
        Toggle[] togglesArr = UIINST.GetComponentsInChildren<Toggle>();
        Image[] panelArr = UIINST.GetComponentsInChildren<Image>();
        panelArr[1].GetComponentInChildren<TMP_Text>().text = dadosGerais[0];
        panelArr[2].GetComponentInChildren<TMP_Text>().text = dadosGerais[1];
        // leiutra de arquivo para as obras/toggles 
        List<string> dadosTut = ArquivoParaLista(fileNameTutorial);
        int indiceTut = -1;
        string[] infoTut = { "", "" }; // inicialização só para evitar erro.
        if (dadosTut.Count != 0)
        {
            for (int i = 0; i < dadosTut.Count; i++)
            {
                string[] dividida = dadosTut[i].Split(',');
                if (dividida[0].Equals(dadosGerais[0]))
                {
                    indiceTut = i;
                    infoTut = dividida;
                    break;
                }
            }
        }
        if (indiceTut == -1)
        {
            togglesArr[0].isOn = false;
            panelArr[3].GetComponentInChildren<TMP_Text>().text = "--/--";
            panelArr[4].GetComponentInChildren<TMP_Text>().text = "-/-";
        }
        else
        {
            togglesArr[0].isOn = true;
            panelArr[3].GetComponentInChildren<TMP_Text>().text =  infoTut[infoTut.Length - 1]; // preciso ver o formato que está e fazer uns parseInt provavelmente
            panelArr[4].GetComponentInChildren<TMP_Text>().text = infoTut[infoTut.Length - 2]; // -1 pois array inicia em 0 e outro -1 pois tempo total
        }
        // Verifica se interagiu com o laçador/ pulpito do laçador 
        
        // estou com o indice fixo aqui ...
        List<string> dadosObras = ArquivoParaLista(fileNameObras);
        string[] infoLinhas = { "", "" }; // inicialização só para evitar erro.
        bool encontrouObras= false;
        foreach (string linha in dadosObras)
        {
            string[] dividida = linha.Split(',');
            if (dividida[0].Equals(dadosGerais[0]))
            {
                infoLinhas = dividida;
                encontrouObras = true;
                break; // sai do loop pois achie oque queria
            }
        }
        togglesArr[1].isOn = dadosGerais[8].Equals("T") ? true : false; // sim esta na ordem dos elementos dentro da ui. Novamente, poderia ter feito isso de uma for,ma mais elegante, está muito hard coded 
        Debug.Log(dadosGerais[8].Equals("T") ? true : false);
        if (encontrouObras)
        {// estou com o indice fixo aqui ... HARDCODED novamente mas como é uma função extra ....
            togglesArr[2].isOn = infoLinhas[7].Equals("T") ? true : false; // busto FIXO
            togglesArr[3].isOn = infoLinhas[8].Equals("T") ? true : false; // medalha FIXA
            togglesArr[4].isOn = infoLinhas[1].Equals("T") ? true : false; // bento 
            togglesArr[5].isOn = infoLinhas[2].Equals("T") ? true : false;
            togglesArr[6].isOn = infoLinhas[3].Equals("T") ? true : false;
            togglesArr[7].isOn = infoLinhas[4].Equals("T") ? true : false;// o resto segue a ordem alfabética
            togglesArr[8].isOn = infoLinhas[5].Equals("T") ? true : false;
            togglesArr[9].isOn = infoLinhas[6].Equals("T") ? true : false; // vaso 
        }
        else
        {
            for(int i = 2; i < 10; i++)
            {
                togglesArr[i].isOn = false;
            }
        }
        
    }

    private void FecharUIExtra() {
        UIDadosGerais.SetActive(true);
        Destroy(UIINST);

    }

    private  List<string> ArquivoParaLista(string fileName)
    {
        List<string> arquivoPorLinha = new List<string>();
        StreamReader leitor; //leitor do arquivo caso já tenha sido criado 
        string diretorio = Application.dataPath + fileName;
        string line;
        if (File.Exists(diretorio)) // sempre irá existir a menos que tenha sido deletado de propósito ... ou não tenhamos nenhum dado (no caso das obras).  
                                    // se não tiver nenhum dado, nem deveria ser possível chegar até aqui ...
                                    // no caso do tutorial pode não existir...
        { //se existe o arquivo
            leitor = new StreamReader(diretorio);
            while ((line = leitor.ReadLine()) != null)
            {
                arquivoPorLinha.Add(line);
            }
        }
        return arquivoPorLinha;
    }

}
