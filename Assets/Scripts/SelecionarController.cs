using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelecionarController : MonoBehaviour {
    private Transform highlight;
    private List<Transform> selection = new List<Transform>();
    private RaycastHit raycastHit;

    private Transform ultimoSelecionado;

    void Update() {
        // Highlight
        if (highlight != null) {
            highlight.gameObject.GetComponent<Outline>().enabled = false;
            highlight = null;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out raycastHit) && !(ultimoSelecionado != null && ultimoSelecionado == raycastHit.transform)) {

            if (ultimoSelecionado != null) {
                ultimoSelecionado = null;
            }

            highlight = raycastHit.transform;
            if (highlight.CompareTag("Casa") && !selection.Contains(highlight)) {
                if (highlight.gameObject.GetComponent<Outline>() != null) {
                    highlight.gameObject.GetComponent<Outline>().enabled = true;
                } else {
                    Outline outline = highlight.gameObject.AddComponent<Outline>();
                    outline.enabled = true;
                    highlight.gameObject.GetComponent<Outline>().OutlineColor = Color.red;
                    highlight.gameObject.GetComponent<Outline>().OutlineWidth = 7.0f;
                }
            } else {
                highlight = null;
            }
        }

        // Selection
        if (Variaveis.permiteSelecionarCasas && Input.GetMouseButtonDown(0)) {
            if (raycastHit.transform.CompareTag("Casa") && !selection.Contains(raycastHit.transform)) {
                Transform selecionado = raycastHit.transform;
                selecionado.gameObject.GetComponent<Outline>().enabled = true;
                selection.Add(selecionado);
            } else {
                Transform selecionado = raycastHit.transform;
                selection.Remove(selecionado);
                selecionado.gameObject.GetComponent<Outline>().enabled = false;
                ultimoSelecionado = selecionado;
            }

            highlight = null;
        }
    }

}
