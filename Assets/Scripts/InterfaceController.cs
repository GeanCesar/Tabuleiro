using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InterfaceController : MonoBehaviour {
    public Player player;
    public TMP_Text textDinheiro1;
    public TMP_Text textDinheiro2;
    public TMP_Text textDinheiro3;
    public TMP_Text textDinheiro4;

    void Start() {
        player = Variaveis.getPlayerJogando();
    }

    void Update() {
        textDinheiro1.text = "$ " + Variaveis.getPlayer(1).dinheiro;
        textDinheiro2.text = "$ " + Variaveis.getPlayer(2).dinheiro;
        textDinheiro3.text = "$ " + Variaveis.getPlayer(3).dinheiro;
        textDinheiro4.text = "$ " + Variaveis.getPlayer(4).dinheiro;
    }
}
