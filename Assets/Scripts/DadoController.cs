using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DadoController : MonoBehaviour {

    public GameObject botao;

    public Text texto;

    public void rodou() {
        botao.SetActive(false);

        int numero1 = UnityEngine.Random.Range(1, 7);
        int numero2 = UnityEngine.Random.Range(1, 7);

        texto.gameObject.SetActive(true);

        texto.text = (numero1 + numero2) + "";

        StartCoroutine(Waiter((numero1 + numero2)));
    }

    IEnumerator Waiter(int numero) {
        yield return new WaitForSeconds(1);
        Player player = Variaveis.getPlayerJogando();
        Component[] cop = player.playerObject.GetComponents<PlayerController>();
        ((PlayerController)cop[0]).move(numero);
    }
}
