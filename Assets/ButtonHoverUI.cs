using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonHoverUI : MonoBehaviour
{
    public GameObject[] buttons;
    public GameObject arrowPrefab;
    private GameObject[] arrows;
    private int selectedButtonIndex = 0;
    private GameObject leftArrow;
    private GameObject rightArrow;

    private void Awake()
    {
        // Instancier les fl�ches gauche et droite
        leftArrow = Instantiate(arrowPrefab, buttons[0].transform.parent);
        rightArrow = Instantiate(arrowPrefab, buttons[0].transform.parent);

        // Initialiser la position des fl�ches
        SetArrowPositions();

        // Initialiser la couleur du texte des boutons
        SetButtonTextColor();
    }

    private void Update()
    {
        // S�lectionner le bouton suivant avec la fl�che vers le bas
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (selectedButtonIndex < buttons.Length - 1)
            {
                selectedButtonIndex++;
                SetArrowPositions();
                SetButtonTextColor();
            }
        }

        // S�lectionner le bouton pr�c�dent avec la fl�che vers le haut
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (selectedButtonIndex > 0)
            {
                selectedButtonIndex--;
                SetArrowPositions();
                SetButtonTextColor();
            }
        }
    }

    public void SetSelectedButton(int index)
    {
        selectedButtonIndex = index;
        SetArrowPositions();
        SetButtonTextColor();
    }

    private void SetArrowPositions()
    {
        // Convertir la position du bouton s�lectionn� en position de l'�cran
        Vector3 screenPos = Camera.main.WorldToScreenPoint(buttons[selectedButtonIndex].transform.position);

        // Calculer la position des fl�ches � partir de la position de l'�cran
        Vector3 leftArrowPos = new Vector3(screenPos.x - 50f, screenPos.y, screenPos.z);
        Vector3 rightArrowPos = new Vector3(screenPos.x + 50f, screenPos.y, screenPos.z);

        // Convertir la position des fl�ches en position du monde
        leftArrow.transform.position = Camera.main.ScreenToWorldPoint(leftArrowPos);
        rightArrow.transform.position = Camera.main.ScreenToWorldPoint(rightArrowPos);
    }

    private void SetButtonTextColor()
    {
        // R�initialiser la couleur du texte des boutons
        foreach (GameObject button in buttons)
        {
            TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.fontSharedMaterial = buttonText.fontMaterial;
            buttonText.fontMaterial.SetFloat("_OutlineWidth", 0f);
        }

        // Rendre le texte du bouton s�lectionn� brillant
        TextMeshProUGUI selectedButtonText = buttons[selectedButtonIndex].GetComponentInChildren<TextMeshProUGUI>();
        selectedButtonText.fontSharedMaterial = selectedButtonText.fontSharedMaterial;
        selectedButtonText.fontMaterial.SetFloat("_OutlineWidth", 0.1f);
    }
}
