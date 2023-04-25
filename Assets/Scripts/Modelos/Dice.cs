using UnityEngine;
using System.Collections;
public class Dice : MonoBehaviour {

    public GameObject gameObject;

    private int diceCount;

    internal Vector3 initPos;

    public Dice(GameObject gameObject) {
        this.gameObject = gameObject;
    }

    void Start() {
        GetComponent<Rigidbody>().solverIterations = 250;
        initPos = transform.position;
    }

    void OnEnable() {
        initPos = transform.position;
    }

    public int GetDiceCount() {
        diceCount = 0;
        regularDiceCount();
        return diceCount;
    }

    void regularDiceCount() {
        if (Vector3.Dot(gameObject.transform.forward, Vector3.up) > 0.6f)
            diceCount = 5;
        if (Vector3.Dot(-gameObject.transform.forward, Vector3.up) > 0.6f)
            diceCount = 2;
        if (Vector3.Dot(gameObject.transform.up, Vector3.up) > 0.6f)
            diceCount = 3;
        if (Vector3.Dot(-gameObject.transform.up, Vector3.up) > 0.6f)
            diceCount = 4;
        if (Vector3.Dot(gameObject.transform.right, Vector3.up) > 0.6f)
            diceCount = 6;
        if (Vector3.Dot(-gameObject.transform.right, Vector3.up) > 0.6f)
            diceCount = 1;
    }

}
