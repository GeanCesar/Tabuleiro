using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    Player player;

    public GameObject playerObject;
    public TMP_Text textDinheiro;


    void Start() {
        player = Variaveis.getPlayer(int.Parse(playerObject.name.Substring(7, 1)));
        player.playerObject = playerObject;
        player.textDinheiro = textDinheiro;
    }

    void Update() { }

    public void move(int casas) {
        StartCoroutine(Waiter(casas));
    }

    void OnCollisionEnter(Collision collision) {

    }

    IEnumerator Waiter(int casas) {
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        for (int i = 0; i < casas; i++) {
            player = Variaveis.getPlayerJogando();
            player.casa += 1;
            if (player.casa > 31) {
                player.casa = player.casa - 32;
                player.adicionaDinheiro = true;
            }

            GameObject c = GameObject.Find("Casa " + player.casa);
            Vector3 vector3 = c.transform.position;
            vector3.y = vector3.y + 2;

            if (player.id == 1) {
                vector3.z = vector3.z + 1;
                vector3.x = vector3.x - 1;
            } else if (player.id == 2) {
                vector3.z = vector3.z + 1;
                vector3.x = vector3.x + 1;
            } else if (player.id == 3) {
                vector3.z = vector3.z - 1;
                vector3.x = vector3.x - 1;
            } else if (player.id == 4) {
                vector3.z = vector3.z - 1;
                vector3.x = vector3.x + 1;
            }

            gameObject.transform.position = vector3;
            gameObject.transform.eulerAngles = new Vector3(
                0,
                0,
                0
            );
            yield return new WaitForSeconds(0.1f);
        }
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        Variaveis.mostraOutlineRolagem = false;
    }

}
