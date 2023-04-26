using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class NumberCounter : MonoBehaviour {
    public TMP_Text texto;
    private float duracao = 0.5f;

    private int _valorAnterior;

    private Coroutine contadorCoroutine;

    public static void mudaDinheiro(Player player) {
        NumberCounter numberCounter = player.textDinheiro.GetComponent<NumberCounter>();
        numberCounter.updateText(player.dinheiro);
    }

    public void updateText(int novoValor) {
        _valorAnterior = int.Parse(Regex.Replace(texto.text, "[^0-9]", ""));
        if (contadorCoroutine != null) {
            StopCoroutine(contadorCoroutine);
        }

        contadorCoroutine = StartCoroutine(contaValor(novoValor));
    }

    private IEnumerator contaValor(int valor) {
        WaitForSeconds wait = new WaitForSeconds(1f / 60);
        int stepAmout;

        if (valor - _valorAnterior < 0) {
            stepAmout = Mathf.FloorToInt((valor - _valorAnterior) / (60 * duracao));
        } else {
            stepAmout = Mathf.CeilToInt((valor - _valorAnterior) / (60 * duracao));
        }

        if (_valorAnterior < valor) {
            while (_valorAnterior < valor) {
                _valorAnterior += stepAmout;
                if (_valorAnterior > valor) {
                    _valorAnterior = valor;
                }
                texto.SetText("$ " + _valorAnterior.ToString("N0"));
                yield return wait;
            }
        } else {
            while (_valorAnterior > valor) {
                _valorAnterior += stepAmout;
                if (_valorAnterior < valor) {
                    _valorAnterior = valor;
                }
                texto.SetText("$ " + _valorAnterior.ToString("N0"));
                yield return wait;
            }
        }
    }
}
