using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickButton : MonoBehaviour {                                      
	/// <summary>
	/// Script que contem todas as interações do pulpito do Laçador
	/// Contém n métodos públicos para cada interação que ocorre no pulpito
	/// </summary>
	// Script para gerenciar o comportamento dos botões.
	public Image ltextButton;                   // Botão de texto do Laçador.
	public Image lpicButton;                    // Botão de fotos do Laçador.
	public Image lvideoButton;                  // Botão de vídeo do Laçador.
	public GameObject ltextNext;                // Botão de passar o texto do Laçador.
	public GameObject ltextPrevious;            // Botão de voltar o texto do Laçador.
	public GameObject lpicNext;                 // Botão de passar a foto do Laçador.
	public GameObject lpicPrevious;             // Botão de voltar a foto do Laçador.
	public GameObject ltextPanel;               // Painel do texto do Laçador.
	public Text linfoText;                      // Texto do Laçador. 
	public Text lnumText;                       // Número da página do texto do Laçador.
	public Image lpicPanel;                     // Painel de fotos do Laçador.
	public Sprite lpic1, lpic2, lpic3, lpic4;   // Fotos do Laçador.
	public GameObject lvideoPlayer;             // Player de vídeo do Laçador.
	public Camera eyeCamera;                    // Olhos do avatar (câmera). 
	private Vector3 ltargetPosition;            // Posiçao na qual o painel do texto deve apontar. 
	private int lpanelPage;                     // Página do texto.
	private bool ltextSelected;                 // Seleção do texto.
	private bool lpicSelected;                  // Seleção de fotos.
	private bool lvideoSelected;                // Seleção de Vídeo.
	private bool pressMoment;                   // Momento em que o usuário pressiona o botão. 
    private AudioSource audio;					// Fonte de Audio
    public AudioClip clip;						// Clipe de Audio

    // Use this for initialization
    void Start () {
        // Inicialização dos parâmetros.
        audio = GetComponent<AudioSource>();
        ltextSelected = false;
		lpicSelected = false;
		lvideoSelected = false;
		lpanelPage = 1;
		linfoText.enabled = false;
		lnumText.enabled = false;
		lvideoPlayer.SetActive (false);
		ltextNext.SetActive (false);
		ltextPrevious.SetActive (false);
		lpicNext.SetActive (false);
		lpicPrevious.SetActive (false);
		ltextPanel.transform.localScale = new Vector3 (0, 0.5f, 0);
		lpicPanel.color = new Color32 (255, 255, 255, 0);
		pressMoment = false; 
       // Debug.Log("inicialização btn ok ");
	}
		
	// Update is called once per frame
	/// <summary>
	/// Monitora os botoes;
	/// </summary>
	void Update () {
		// Rotaciona o texto para ficar sempre de frente para o usuário.
		ltargetPosition = new Vector3 (eyeCamera.transform.position.x, ltextPanel.transform.position.y, eyeCamera.transform.position.z);
		ltextPanel.transform.LookAt (ltargetPosition);
		ltextPanel.transform.Rotate (0, 180.0f, 0);

		// Se o botão do texto for apertado, aumenta gradativamente o tamanho do painel do texto, primero na horizontal, depois na vertical.
		if (ltextSelected && lpicPanel.color.a <= 0) {
			// Primeiro, aumenta gradativamente a escala do painel do texto em x até atingir 1.  
			if (ltextPanel.transform.localScale.x < 0.99) {
				ltextPanel.transform.localScale += new Vector3 (0.05f, 0, 0);
			} 
			// Depois, aumenta gradativamente a escala do painel do texto em y até atingir 1.  
			else if (ltextPanel.transform.localScale.y < 0.99) {
				ltextPanel.transform.localScale += new Vector3 (0, 0.025f, 0);
			}
			// Finalmente, deixa o texto visível no painel.
			else if (pressMoment) {
				linfoText.enabled = true;
				lnumText.enabled = true;
				linfoText.text = "A Estátua do Laçador é um monumento histórico de Porto Alegre que representa o gaúcho pilchado (em trajes típicos). A obra é de autoria do escultor gaúcho Antônio Caringi (1905-1981) que venceu diversos concursos e produziu diversos monumentos, em geral, ligados à história e à cultura gaúcha.";
				lnumText.text = "1/7";
				pressMoment = false;
			}
		}

		// Se o botão do texto for "desapertado" ou outro botão for apertado, diminui gradativamente o tamanho do painel do texto, primero na verical, depois na horizontal.
		if (!ltextSelected) {
			// Primeiro, deixa o texto invisível.
			linfoText.text = "";
			lnumText.text = "";
		
			// Depois, diminui gradativamente a escala do painel do texto em y até atingir 0.05.  
			if (ltextPanel.transform.localScale.y > 0.05) {
				ltextPanel.transform.localScale -= new Vector3 (0, 0.05f, 0);
			} 
			// Finalmente, diminui gradativamente a escala do painel do texto em x até atingir 0.
			else if (ltextPanel.transform.localScale.x > 0) {
				ltextPanel.transform.localScale -= new Vector3 (0.05f, 0, 0);
			} 
		}

		// Se o botão da foto for apertado, aumenta o alpha gradativamente do painel da foto. 
		if (lpicSelected && ltextPanel.transform.localScale.x <= 0) {
			if (lpicPanel.color.a < 1) {
				lpicPanel.color += new Color32 (255, 255, 255, 15);
			} 
		}

		// Se o botão da foto for "desapertado" ou outro botão for apertado, diminui o alpha gradativamente do painel da foto. 
		if (!lpicSelected) {
			if (lpicPanel.color.a > 0) {
				lpicPanel.color -= new Color32 (0, 0, 0, 15);
			}  
		}
	}
	/// <summary>
	/// Função chamada quando o botão do texto é apertado.
	/// </summary>
	public void TextButtonClicked () {
		lvideoPlayer.SetActive (false);
		ltextSelected = !ltextSelected;
		lpicSelected = false;
		lvideoSelected = false;
		lpicNext.SetActive (false);
		lpicPrevious.SetActive (false);
		lpicButton.color = new Color32 (255, 255, 255, 200);
		lvideoButton.color = new Color32 (255, 255, 255, 200);


		if (ltextSelected == true) {
			pressMoment = true;
			lpanelPage = 1;
			ltextNext.SetActive (true);
			ltextPrevious.SetActive (false);
			ltextButton.color = new Color32 (255, 111, 0, 200);
		}
		else {
			ltextNext.SetActive (false);
			ltextPrevious.SetActive (false);
			ltextButton.color = new Color32 (255, 255, 255, 200);
		}	
	}

	/// <summary>
	///  Função chamada quando o botão da foto é apertado.
	/// </summary>
	public void PicButtonClicked () {
        Debug.Log("btn apertado = ok");
		lvideoPlayer.SetActive (false);
		lpicSelected = !lpicSelected;
		ltextSelected = false;
		lvideoSelected = false;
		ltextNext.SetActive (false);
		ltextPrevious.SetActive (false);
		ltextButton.color = new Color32 (255, 255, 255, 200);
		lvideoButton.color = new Color32 (255, 255, 255, 200);

		if (lpicSelected == true) {
			lpicPanel.sprite = lpic1;
			lpanelPage = 1;
			lpicNext.SetActive (true);
			lpicPrevious.SetActive (false);
			lpicButton.color = new Color32 (255, 111, 0, 200);
		}
		else {
			lpicNext.SetActive (false);
			lpicPrevious.SetActive (false);
			lpicButton.color = new Color32 (255, 255, 255, 200);
		}	
	}

	/// <summary>
	/// Função chamada quando o botão do vídeo é apertado.
	/// </summary>
	public void VideoButtonClicked () {
        Debug.Log("btn video = ok");
        lvideoSelected = !lvideoSelected;
		ltextSelected = false;
		lpicSelected = false;
		ltextNext.SetActive (false);
		ltextPrevious.SetActive (false);
		lpicNext.SetActive (false);
		lpicPrevious.SetActive (false);
		ltextButton.color = new Color32 (255, 255, 255, 200);
		lpicButton.color = new Color32 (255, 255, 255, 200);

		if (lvideoSelected == true) {
			lvideoButton.color = new Color32 (255, 111, 0, 200);
			lvideoPlayer.SetActive (true);
		}
		else {
			lvideoButton.color = new Color32 (255, 255, 255, 200);
			lvideoPlayer.SetActive (false);
		}	
	}



    public void imgOrgBtbs() // o que raios faz essa função ? provavelmente serve para rordenar, verificar se existe um caso que chame ela dentro do btn pul´p
    {
       if  (lpanelPage == 4) { 
            lpicNext.SetActive(false);
            audio.PlayOneShot(clip);
        }
       else if (lpanelPage == 1)
        {
            lpicPrevious.SetActive(false);
            audio.PlayOneShot(clip);
        }
        else
        {
            lpicNext.SetActive(true);
            lpicPrevious.SetActive(true);

        }
    }

    public void txtOrgBtbs()
    {
        if (lpanelPage == 7)
        {
            ltextNext.SetActive(false);
           
            audio.PlayOneShot(clip);
        }
        else if (lpanelPage == 1)
        {
            ltextPrevious.SetActive(false);
            audio.PlayOneShot(clip);
        }
        else
        {
            ltextPrevious.SetActive(true);
            ltextNext.SetActive(true);
        }
    }
	/// <summary>
	/// Função chamada quando o botão de avançar texto é apertado.
	/// </summary>
	public void TextNextButtonClicked () {
        //Debug.Log("btn texto proximo = ok");
        if (lpanelPage < 7) {
			lpanelPage += 1;
		}

		switch (lpanelPage) {
			case 2:
				linfoText.text = "A obra “O Laçador” foi criada em gesso, em 1954, como resultado de um concurso vencido por Caringi para executar uma escultura que identificasse o homem riograndense na Exposição do IV Centenário de Fundação de São Paulo. Como modelo de indumentária, o artista utilizou Paixão Côrtes, um dos fundadores do Movimento Tradicionalista Gaúcho. Em 1958, a escultura foi adquirida pela Prefeitura Municipal de Porto Alegre e foi, então, a partir da matriz em gesso, fundida em bronze e transportada para ser instalada sobre um pedestal no antigo Largo do Bombeiro. Em 2007, em função da construção do Viaduto Leonel Brizola, a estátua foi transferida para o Sítio do Laçador, em frente ao primeiro terminal do Aeroporto Internacional Salgado Filho, onde permanece nos dias atuais.";
				lnumText.text = "2/7";
                break;
			case 3:
				linfoText.text = "Em 1992, a Câmara Municipal de Porto Alegre aprovou a Lei Complementar nº 279, instituindo, oficialmente, o Monumento do Laçador como símbolo oficial da cidade. Em 2008, a Lei Estadual nº 12.992, declara a Estátua do Laçador integrante do patrimônio histórico e cultural e escultura-símbolo do Estado do Rio Grande do Sul.";
				lnumText.text = "3/7";
				break;
			case 4:
				linfoText.text = "A digitalização 3D da Estátua do Laçador foi realizada em 10 de agosto de 2011 e contou com o apoio da Coordenação da Memória Cultural, órgão da Secretaria da Cultura de Porto Alegre. Devido à altura da estátua (4,4 m), do pedestal (2,2 m) e da coxilha do Sítio do Laçador (5 m), além da distância imposta pela mureta que circunda a coxilha, fez-se necessário um caminhão-cesto com braço telescópico de 25 m, permitindo posicionar o scanner 3D a cerca de 1 m da estátua. Em 07 de setembro de 2011, foi realizada uma nova etapa de digitalização, com o uso de um tripé, visando complementar a parte inferior da estátua. Ao todo, foram 12 horas de aquisição, gerando 207 nuvens de pontos (resultado de 207 digitalizações), capturando cerca de 30 milhões de pontos.";
				lnumText.text = "4/7";
				break;
			case 5:
				linfoText.text = "Após a filtragem dos dados, cerca de 6,5 milhões pontos foram unidos três a três e convertidos em uma malha com 13 milhões de triângulos. Para manipulação dos arquivos no hardware disponível em 2011, a malha original foi reduzida para 7 milhões de triângulos, resultando em uma resolução (espaçamento entre os pontos dos vértices) de 3,8 mm. Infelizmente, o laço original da estátua em bronze foi furtado. Para evitar novos furtos, foi confeccionado um novo laço em aço que recebeu o devido acabamento para imitar o bronze. A partir dos dados da digitalização, o novo laço foi modelado no software 3D Studio Max e agregado ao modelo 3D. A digitalização foi realizada sem captura de cores. No modelo disponível online, foram aplicados mapas de texturas imitando o bronze e a coloração da superfície estátua, apenas para efeito de visualização.";
				lnumText.text = "5/7";
				break;
			case 6:
				linfoText.text = "O modelo 3D original permite realizar medições na estátua de dimensões totais de aproximadamente 2,0 x 1,2 x 4,4 m (largura x profundidade x altura). Por exemplo, o corpo masculino sobre a base de bronze possui altura de 4,1 m e largura entre ombros de 1,2 m. Na lateral da base, ao lado do pé esquerdo, é possível observar a assinatura do artista e o ano da obra, com inscrição em baixo relevo “A. Caringi” e logo abaixo “1954”. A partir do modelo 3D também é possível observar a obra por diferentes ângulos, difíceis de se conseguir na estátua original. Por exemplo, pode ser percebido o cuidado de Caringi com a perspectiva do ponto de vista do observador. O artista aumentou a parte superior do corpo da escultura, uma vez que esta deve ser vista de baixo para cima e sobre o seu pedestal.";
				lnumText.text = "6/7";
				break;
			case 7:
				linfoText.text = "Cabe ainda salientar que o modelo 3D virtual, bem como um protótipo em escala reduzida da Estátua do Laçador foram disponibilizados à Coordenação da Memória Cultural de Porto Alegre, com a qual estabeleceu-se importante parceria para a continuidade e o desdobramento de pesquisas referentes à preservação do patrimônio histórico e cultural da cidade.";
				lnumText.text = "7/7";
                break;
		}
	}
	/// <summary>
	/// Função chamada quando o botão de voltar texto é apertado.
	/// </summary>
	public void TextPreviousButtonClicked () {
		if (lpanelPage > 1) {
			lpanelPage -= 1;
		}

		switch (lpanelPage) {
			case 6:
				linfoText.text = "O modelo 3D original permite realizar medições na estátua de dimensões totais de aproximadamente 2,0 x 1,2 x 4,4 m (largura x profundidade x altura). Por exemplo, o corpo masculino sobre a base de bronze possui altura de 4,1 m e largura entre ombros de 1,2 m. Na lateral da base, ao lado do pé esquerdo, é possível observar a assinatura do artista e o ano da obra, com inscrição em baixo relevo “A. Caringi” e logo abaixo “1954”. A partir do modelo 3D também é possível observar a obra por diferentes ângulos, difíceis de se conseguir na estátua original. Por exemplo, pode ser percebido o cuidado de Caringi com a perspectiva do ponto de vista do observador. O artista aumentou a parte superior do corpo da escultura, uma vez que esta deve ser vista de baixo para cima e sobre o seu pedestal.";
				lnumText.text = "6/7";
                break;
			case 5:
				linfoText.text = "Após a filtragem dos dados, cerca de 6,5 milhões pontos foram unidos três a três e convertidos em uma malha com 13 milhões de triângulos. Para manipulação dos arquivos no hardware disponível em 2011, a malha original foi reduzida para 7 milhões de triângulos, resultando em uma resolução (espaçamento entre os pontos dos vértices) de 3,8 mm. Infelizmente, o laço original da estátua em bronze foi furtado. Para evitar novos furtos, foi confeccionado um novo laço em aço que recebeu o devido acabamento para imitar o bronze. A partir dos dados da digitalização, o novo laço foi modelado no software 3D Studio Max e agregado ao modelo 3D. A digitalização foi realizada sem captura de cores. No modelo disponível online, foram aplicados mapas de texturas imitando o bronze e a coloração da superfície estátua, apenas para efeito de visualização.";
				lnumText.text = "5/7";	
				break;
			case 4:
				linfoText.text = "A digitalização 3D da Estátua do Laçador foi realizada em 10 de agosto de 2011 e contou com o apoio da Coordenação da Memória Cultural, órgão da Secretaria da Cultura de Porto Alegre. Devido à altura da estátua (4,4 m), do pedestal (2,2 m) e da coxilha do Sítio do Laçador (5 m), além da distância imposta pela mureta que circunda a coxilha, fez-se necessário um caminhão-cesto com braço telescópico de 25 m, permitindo posicionar o scanner 3D a cerca de 1 m da estátua. Em 07 de setembro de 2011, foi realizada uma nova etapa de digitalização, com o uso de um tripé, visando complementar a parte inferior da estátua. Ao todo, foram 12 horas de aquisição, gerando 207 nuvens de pontos (resultado de 207 digitalizações), capturando cerca de 30 milhões de pontos.";
				lnumText.text = "4/7";	
				break;
			case 3:
				linfoText.text = "Em 1992, a Câmara Municipal de Porto Alegre aprovou a Lei Complementar nº 279, instituindo, oficialmente, o Monumento do Laçador como símbolo oficial da cidade. Em 2008, a Lei Estadual nº 12.992, declara a Estátua do Laçador integrante do patrimônio histórico e cultural e escultura-símbolo do Estado do Rio Grande do Sul.";
				lnumText.text = "3/7";	
				break;
			case 2:
				linfoText.text = "A obra “O Laçador” foi criada em gesso, em 1954, como resultado de um concurso vencido por Caringi para executar uma escultura que identificasse o homem riograndense na Exposição do IV Centenário de Fundação de São Paulo. Como modelo de indumentária, o artista utilizou Paixão Côrtes, um dos fundadores do Movimento Tradicionalista Gaúcho. Em 1958, a escultura foi adquirida pela Prefeitura Municipal de Porto Alegre e foi, então, a partir da matriz em gesso, fundida em bronze e transportada para ser instalada sobre um pedestal no antigo Largo do Bombeiro. Em 2007, em função da construção do Viaduto Leonel Brizola, a estátua foi transferida para o Sítio do Laçador, em frente ao primeiro terminal do Aeroporto Internacional Salgado Filho, onde permanece nos dias atuais.";
				lnumText.text = "2/7";
                break;
			case 1:
				linfoText.text = "A Estátua do Laçador é um monumento histórico de Porto Alegre que representa o gaúcho pilchado (em trajes típicos). A obra é de autoria do escultor gaúcho Antônio Caringi (1905-1981) que venceu diversos concursos e produziu diversos monumentos, em geral, ligados à história e à cultura gaúcha.";
				lnumText.text = "1/7";
				break;
		}
	}
	/// <summary>
	/// Função chamada quando o botão de avançar foto é apertado.
	/// </summary>
	public void PicNextButtonClicked () {
		if (lpanelPage < 4) {
			lpanelPage += 1;
		}

		switch (lpanelPage) {
			case 2:
				lpicPanel.sprite = lpic2;
                break;
			case 3:
				lpicPanel.sprite = lpic3;
				break;
			case 4:
				lpicPanel.sprite = lpic4;
				break;
		}
	}

	/// <summary>
	/// Função chamada quando o botão de voltar foto é apertado.
	/// </summary> 
	public void PicPreviousButtonClicked () {
		if (lpanelPage > 1) {
			lpanelPage -= 1;
		}

		switch (lpanelPage) {
			case 3:
				lpicPanel.sprite = lpic3;
                break;
			case 2:
				lpicPanel.sprite = lpic2;
				break;
			case 1:
				lpicPanel.sprite = lpic1;
                break;
		}
	}
}