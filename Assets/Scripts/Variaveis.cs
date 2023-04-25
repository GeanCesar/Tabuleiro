using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Variaveis {

    private static List<Player> players = new List<Player>();
    private static List<Cidade> cidades = new List<Cidade>();

    public static bool permiteSelecionarCasas = true;
    public static bool iniciou = false;
    public static int quantidadePlayers = 4;
    public static int valorAAdicionar = 2000;
    public static bool mostraOutlineRolagem = false;

    static Variaveis() {
        montaJogadores();
        montaCidades();
    }

    static void montaCidades() {
        Cidade cidade = new Cidade(0, 0, 0, "Inicio", TipoCidade.INICIO, GameObject.Find("Casa 0"));
        Cidade cidade1 = new Cidade(1, 100, 80, "Granada", TipoCidade.CIDADE, GameObject.Find("Casa 1"));
        Cidade cidade2 = new Cidade(2, 120, 90, "Sevilha", TipoCidade.CIDADE, GameObject.Find("Casa 2"));
        Cidade cidade3 = new Cidade(3, 140, 100, "Madrid", TipoCidade.CIDADE, GameObject.Find("Casa 3"));
        Cidade cidade4 = new Cidade(4, 160, 110, "Bali", TipoCidade.CIDADE, GameObject.Find("Casa 4"));
        Cidade cidade5 = new Cidade(5, 180, 120, "Hong Kong", TipoCidade.CIDADE, GameObject.Find("Casa 5"));
        Cidade cidade6 = new Cidade(6, 200, 130, "Pequim", TipoCidade.CIDADE, GameObject.Find("Casa 6"));
        Cidade cidade7 = new Cidade(7, 220, 140, "Xangai", TipoCidade.CIDADE, GameObject.Find("Casa 7"));
        Cidade cidade8 = new Cidade(8, 240, 0, "Ilha perdida", TipoCidade.ILHA, GameObject.Find("Casa 8"));
        Cidade cidade9 = new Cidade(9, 260, 160, "Veneza", TipoCidade.CIDADE, GameObject.Find("Casa 9"));
        Cidade cidade10 = new Cidade(10, 280, 170, "Milão", TipoCidade.CIDADE, GameObject.Find("Casa 10"));
        Cidade cidade11 = new Cidade(11, 300, 180, "Roma", TipoCidade.CIDADE, GameObject.Find("Casa 11"));
        Cidade cidade12 = new Cidade(12, 0, 0, "Sorte", TipoCidade.SORTE, GameObject.Find("Casa 12"));
        Cidade cidade13 = new Cidade(13, 340, 190, "Hamburgo", TipoCidade.CIDADE, GameObject.Find("Casa 13"));
        Cidade cidade14 = new Cidade(14, 360, 200, "Chipre", TipoCidade.CIDADE, GameObject.Find("Casa 14"));
        Cidade cidade15 = new Cidade(15, 380, 210, "Berlim", TipoCidade.CIDADE, GameObject.Find("Casa 15"));
        Cidade cidade16 = new Cidade(16, 0, 0, "Copa do mundo", TipoCidade.COPA, GameObject.Find("Casa 16"));
        Cidade cidade17 = new Cidade(17, 420, 220, "Londres", TipoCidade.CIDADE, GameObject.Find("Casa 17"));
        Cidade cidade18 = new Cidade(18, 440, 230, "Dubai", TipoCidade.CIDADE, GameObject.Find("Casa 18"));
        Cidade cidade19 = new Cidade(19, 460, 240, "Sydney", TipoCidade.CIDADE, GameObject.Find("Casa 19"));
        Cidade cidade20 = new Cidade(20, 0, 0, "Sorte", TipoCidade.SORTE, GameObject.Find("Casa 20"));
        Cidade cidade21 = new Cidade(21, 500, 250, "Chicago", TipoCidade.CIDADE, GameObject.Find("Casa 21"));
        Cidade cidade22 = new Cidade(22, 540, 260, "Las vegas", TipoCidade.CIDADE, GameObject.Find("Casa 22"));
        Cidade cidade23 = new Cidade(23, 560, 270, "Nova iorque", TipoCidade.CIDADE, GameObject.Find("Casa 23"));
        Cidade cidade24 = new Cidade(24, 0, 0, "Volta ao mundo", TipoCidade.VIAGEM, GameObject.Find("Casa 24"));
        Cidade cidade25 = new Cidade(25, 600, 280, "Nice", TipoCidade.CIDADE, GameObject.Find("Casa 25"));
        Cidade cidade26 = new Cidade(26, 620, 290, "Lion", TipoCidade.CIDADE, GameObject.Find("Casa 26"));
        Cidade cidade27 = new Cidade(27, 640, 300, "Paris", TipoCidade.CIDADE, GameObject.Find("Casa 27"));
        Cidade cidade28 = new Cidade(28, 0, 0, "Sorte", TipoCidade.SORTE, GameObject.Find("Casa 28"));
        Cidade cidade29 = new Cidade(29, 680, 350, "São Paulo", TipoCidade.CIDADE, GameObject.Find("Casa 29"));
        Cidade cidade30 = new Cidade(30, 0, 0, "Impostos", TipoCidade.IMPOSTO, GameObject.Find("Casa 30"));
        Cidade cidade31 = new Cidade(31, 540, 380, "Rio de Janeiro", TipoCidade.CIDADE, GameObject.Find("Casa 31"));


        cidades.Add(cidade);
        cidades.Add(cidade1);
        cidades.Add(cidade2);
        cidades.Add(cidade3);
        cidades.Add(cidade4);
        cidades.Add(cidade5);
        cidades.Add(cidade6);
        cidades.Add(cidade7);
        cidades.Add(cidade8);
        cidades.Add(cidade9);
        cidades.Add(cidade10);
        cidades.Add(cidade11);
        cidades.Add(cidade12);
        cidades.Add(cidade13);
        cidades.Add(cidade14);
        cidades.Add(cidade15);
        cidades.Add(cidade16);
        cidades.Add(cidade17);
        cidades.Add(cidade18);
        cidades.Add(cidade19);
        cidades.Add(cidade20);
        cidades.Add(cidade21);
        cidades.Add(cidade22);
        cidades.Add(cidade23);
        cidades.Add(cidade24);
        cidades.Add(cidade25);
        cidades.Add(cidade26);
        cidades.Add(cidade27);
        cidades.Add(cidade28);
        cidades.Add(cidade29);
        cidades.Add(cidade30);
        cidades.Add(cidade31);
    }

    static void montaJogadores() {
        Player player1 = new Player();
        Player player2 = new Player();
        Player player3 = new Player();
        Player player4 = new Player();

        player1.cor = "Vermelho";
        player2.cor = "Amarelo";
        player3.cor = "Azul";
        player4.cor = "Verde";

        player1.jogando = true;
        player2.jogando = false;
        player3.jogando = false;
        player4.jogando = false;

        player1.id = 1;
        player2.id = 2;
        player3.id = 3;
        player4.id = 4;

        player1.playerObject = GameObject.Find("Player 1");
        player2.playerObject = GameObject.Find("Player 2");
        player4.playerObject = GameObject.Find("Player 3");
        player3.playerObject = GameObject.Find("Player 4");

        players.Add(player1);
        players.Add(player2);
        players.Add(player3);
        players.Add(player4);
    }

    public static Player getPlayerJogando() {
        foreach (Player p in players) {
            if (p.jogando) {
                return p;
            }
        };
        return null;
    }

    public static Player getPlayer(int id) {
        foreach (Player p in players) {
            if (p.id == id) {
                return p;
            }
        };
        return null;
    }

    public static Player getPlayer(GameObject gameObject) {
        foreach (Player p in players) {
            if (p.playerObject == gameObject) {
                return p;
            }
        };
        return null;
    }

    public static void proximoJogador() {
        Player playerAtual = getPlayerJogando();
        playerAtual.jogando = false;
        int idAtual = playerAtual.id;
        int idAJogar = 0;
        if (idAtual == 4) {
            idAJogar = 1;
        } else {
            idAJogar = idAtual + 1;
        }
        foreach (Player p in players) {
            if (p.id == idAJogar) {
                p.jogando = true;
            }
        }
    }

    public static Cidade getCidade(int id) {
        foreach (Cidade c in cidades) {
            if (c.id == id) {
                return c;
            }
        };
        return null;
    }
}
