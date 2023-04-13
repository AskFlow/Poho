using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Checkpoint : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private InputActionAsset inputActions;

    public float fillSpeed = 0.5f; // Vitesse de remplissage du slider
    public float fillAmount = 0f; // Quantité de remplissage actuelle du slider
    public float fillMax = 2f; // Quantité maximale de remplissage du slider

    public Image slider;
    public GameObject interactionUI;
    public KeyCode interactKey = KeyCode.E;

    private bool isInRange = false;
    private bool isFilling = false;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        inputActions.Enable();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
            interactionUI.SetActive(true);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
            interactionUI.SetActive(false);
            ResetSlider();
        }
    }

    private void Update()
    {
        if (isInRange)
        {
            if (inputActions.FindAction("Use").IsPressed())
            {
                isFilling = true;
            }

            if (!inputActions.FindAction("Use").IsPressed())
            {
                isFilling = false;
                ResetSlider();
            }

            if (isFilling && fillAmount < fillMax)
            {
                fillAmount += fillSpeed * Time.deltaTime;
                slider.fillAmount = fillAmount / fillMax;
            }

            if (fillAmount >= fillMax)
            {
                // Si le slider est rempli à sa valeur maximale, prenez le checkpoint
                TakeCheckpoint();
                ResetSlider();
            }
        }
    }

    private void TakeCheckpoint()
    {
        // Code pour prendre le checkpoint
        gameManager.lastCheckPointPos = transform.position;

        interactionUI.SetActive(false);
    }

    private void ResetSlider()
    {
        fillAmount = 0f;
        slider.fillAmount = 0f;
    }
}
