using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player {

    public int id;
    public int dinheiro;
    public int casa = 0;
    public string cor;
    public bool jogando = true;
    public bool adicionaDinheiro = true;
    public GameObject playerObject;
    public TMP_Text textDinheiro;
}
