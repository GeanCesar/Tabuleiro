using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CompraController : MonoBehaviour {

    Renderer rend;
    public Material[] materials;
    public Transform box;
    public CanvasGroup background;

    public GameObject painelCompra;

    public GameObject botaoRodar;
    public Text textoResultado;

    public TMP_Text textCidade;
    public TMP_Text textCompra;
    public TMP_Text textAluguel;
    public TMP_Text textRecompra;

    private Player playerAtual;
    private Cidade cidadeAtual;


    public void mostrarCompra(Cidade cidade, Player player) {
        playerAtual = player;
        cidadeAtual = cidade;
        if (cidade.tipoCidade == TipoCidade.CIDADE) {
            textCidade.text = cidade.nomeCidade;
            textCompra.text = "$" + cidade.valorCompra;
            textAluguel.text = "$" + cidade.valorAluguel;
            textRecompra.text = "$" + cidade.valorRecompra;
            painelCompra.SetActive(true);
            OnEnable();
        } else {
            liberaRodar();
        }
    }

    public void liberaRodar() {
        textoResultado.gameObject.SetActive(false);
        botaoRodar.SetActive(true);
    }

    private void OnEnable() {
        background.alpha = 0;
        background.LeanAlpha(1, 0.4f);
        box.localPosition = new Vector2(0, -Screen.height);
        box.LeanMoveLocalY(0, 0.4f).setEaseOutExpo().delay = 0.1f;
    }

    public void CloseDialog() {
        background.LeanAlpha(0, 0.3f);
        box.LeanMoveLocalY(-Screen.height, 0.3f).setEaseInExpo().setOnComplete(OnComplete);
        liberaRodar();
    }

    public void cancelar() {
        CloseDialog();
    }

    void OnComplete() {
        painelCompra.SetActive(false);
    }

    public void comprar() {
        rend = cidadeAtual.gameObject.GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = materials[playerAtual.id - 1];
        CloseDialog();

        if (cidadeAtual.dono != null) {
            cidadeAtual.dono.dinheiro = cidadeAtual.dono.dinheiro + cidadeAtual.valorRecompra;
            playerAtual.dinheiro = playerAtual.dinheiro - cidadeAtual.valorRecompra;
        } else {
            playerAtual.dinheiro = playerAtual.dinheiro - cidadeAtual.valorCompra;
        }

        cidadeAtual.dono = playerAtual;
        TMP_Text valorCasa = GameObject.Find("Valor Casa " + cidadeAtual.id).GetComponent<TMP_Text>();
        valorCasa.text = "$ " + cidadeAtual.valorAluguel;
    }
}
