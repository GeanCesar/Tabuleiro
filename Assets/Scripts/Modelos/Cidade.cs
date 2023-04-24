using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cidade {

    public Cidade() { }

    public Cidade(int id, int compra, int aluguel, string nome, TipoCidade tipoCidade, GameObject gameObject) {
        this.id = id;
        this.nomeCidade = nome;
        this.valorAluguel = aluguel;
        this.valorCompra = compra;
        this.valorRecompra = (int)(compra + (compra * 0.20f));
        this.tipoCidade = tipoCidade;
        this.gameObject = gameObject;
    }

    public int id;
    public int valorCompra;
    public int valorRecompra;
    public int valorAluguel;
    public string nomeCidade;
    public TipoCidade tipoCidade;
    public GameObject gameObject;
    public Player dono;
}
