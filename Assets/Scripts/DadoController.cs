using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public class DadoController : MonoBehaviour {

    public DiceSwipeControl rolarDado1;
    public DiceSwipeControl rolarDado2;

    public GameObject botao;

    public Text texto;

    Color colorOutLine;

    public void rodou() {
        botao.SetActive(false);

        rolarDado1.rola = true;
        rolarDado2.rola = true;
        StartCoroutine(Waiter());
    }

    IEnumerator Waiter() {
        yield return new WaitForSeconds(1);
        while (true) {
            if (rolarDado1.valor > 0 && rolarDado2.valor > 0) {
                break;
            } else {
                yield return 0;
            }
        }

        int numero1 = rolarDado1.valor;
        int numero2 = rolarDado2.valor;

        texto.gameObject.SetActive(true);

        texto.text = (numero1 + numero2) + "";

        // Pega a casa onde ira cair para mostrar o Outline
        Player player = Variaveis.getPlayerJogando();
        int casaPlayer = player.casa;

        casaPlayer += (numero1 + numero2);
        if (casaPlayer > 31) {
            casaPlayer = casaPlayer - 32;
        }

        Variaveis.mostraOutlineRolagem = true;
        GameObject casa = GameObject.Find("Casa " + casaPlayer);

        StartCoroutine(PiscadorCasa(casa));
        StartCoroutine(Andador((numero1 + numero2)));
    }

    IEnumerator PiscadorCasa(GameObject casa) {
        Outline outline = null;

        if (casa.GetComponent<Outline>() != null) {
            outline = casa.GetComponent<Outline>();
        } else {
            outline = casa.AddComponent<Outline>();
        }
        ColorUtility.TryParseHtmlString("#FF8A00", out colorOutLine);
        casa.GetComponent<Outline>().OutlineColor = colorOutLine;
        casa.GetComponent<Outline>().OutlineWidth = 10.0f;
        outline.enabled = true;

        yield return new WaitForSeconds(1);
        while (Variaveis.mostraOutlineRolagem) {
            yield return 0;
        }

        outline.enabled = false;

        Destroy(casa.GetComponent<Outline>());
    }

    IEnumerator Andador(int numero) {
        yield return new WaitForSeconds(1);
        Player player = Variaveis.getPlayerJogando();
        Component[] cop = player.playerObject.GetComponents<PlayerController>();
        ((PlayerController)cop[0]).move(numero);
    }
}
