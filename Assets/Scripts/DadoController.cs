using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DadoController : MonoBehaviour {

    public DiceSwipeControl rolarDado1;
    public DiceSwipeControl rolarDado2;

    public GameObject botao;

    public Text texto;

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

        StartCoroutine(Andador((numero1 + numero2)));
    }

    IEnumerator Andador(int numero) {
        yield return new WaitForSeconds(1);
        Player player = Variaveis.getPlayerJogando();
        Component[] cop = player.playerObject.GetComponents<PlayerController>();
        ((PlayerController)cop[0]).move(numero);
    }
}
