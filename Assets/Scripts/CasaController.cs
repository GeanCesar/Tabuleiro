using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CasaController : MonoBehaviour {

    Player jogador;
    public int casa;

    public CompraController compraController;
    public GameObject casaObject;

    int playersParados = 0;

    void Start() {

    }

    void Update() {

    }

    void OnCollisionEnter(Collision collision) {
        jogador = Variaveis.getPlayerJogando();
        if (collision.gameObject.tag == "Player") {
            if (collision.gameObject == Variaveis.getPlayer(collision.gameObject).playerObject
                && Variaveis.getPlayer(collision.gameObject).adicionaDinheiro) {
                Variaveis.getPlayer(collision.gameObject).dinheiro += Variaveis.valorAAdicionar;
                Variaveis.getPlayer(collision.gameObject).adicionaDinheiro = false;
            }
        }
        playersParados++;

        processaCompra();

        if (playersParados == Variaveis.quantidadePlayers) {
            Variaveis.iniciou = true;
            Variaveis.valorAAdicionar = 300;
        }
    }

    void processaCompra() {
        if (Variaveis.getCidade(casa).dono != null && Variaveis.getCidade(casa).dono != jogador) {
            jogador.dinheiro -= Variaveis.getCidade(casa).valorAluguel;
            Variaveis.getCidade(casa).dono.dinheiro += Variaveis.getCidade(casa).valorAluguel;
            if (Variaveis.getCidade(casa).valorRecompra < jogador.dinheiro) {
                compraController.mostrarCompra(Variaveis.getCidade(casa), jogador);
            } else {
                compraController.liberaRodar();
            }

        } else {
            compraController.mostrarCompra(Variaveis.getCidade(casa), jogador);
        }

        if (Variaveis.iniciou) {
            Variaveis.proximoJogador();
        }
    }
}
