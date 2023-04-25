using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DiceSwipeControl : MonoBehaviour {

    public GameObject diceObject;
    public bool rola = false;

    private Dice dice;
    private Vector3 initPos;
    public int valor;

    void Start() {
        initPos = diceObject.transform.position;
        dice = new Dice(diceObject);
    }

    void Update() {
        if (rola) {
            valor = 0;
            rola = false;
            diceObject.transform.position = initPos;
            diceObject.GetComponent<Rigidbody>().useGravity = true;
            diceObject.SetActive(true);
            rodar();
            StartCoroutine(getDiceCount(dice));
        }
    }

    void rodar() {
        diceObject.transform.rotation = Quaternion.Euler(Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180));
        diceObject.GetComponent<Rigidbody>().isKinematic = false;
        diceObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * Random.Range(1200.0f, 2500.0f));
        var v3 = new Vector3(Random.Range(-500.0f, 500.0f), Random.Range(-500.0f, 50.0f), Random.Range(-500, 500));
        diceObject.GetComponent<Rigidbody>().AddTorque(v3);
    }


    IEnumerator getDiceCount(Dice dice) {
        yield return new WaitForSeconds(1.0f);
        while (dice.gameObject.GetComponent<Rigidbody>().velocity.magnitude > 0.05f) {
            yield return 0;
        }

        valor = dice.GetDiceCount();
        dice.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }

}
