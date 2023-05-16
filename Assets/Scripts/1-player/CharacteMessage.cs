using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
/**
 * This component represents a text feild that appears if the player is in range of another character and presses E.
 */
public class CharacteMessage : MonoBehaviour
{

    [SerializeField] private CharacterController playerController;
    [SerializeField] private float heyDistance = 5f;
    [SerializeField] private Text text;
    [SerializeField] InputAction heyAction;
    private void OnEnable()
    {
        heyAction.Enable();
    }
    private void OnDisable()
    {
        heyAction.Disable();
    }
    private void Update()
    {
        RaycastHit hit;
        CharacterController charContr = GetComponent<CharacterController>();
        float dist = Vector3.Distance(charContr.transform.position, playerController.transform.position);
        float heyKey = heyAction.ReadValue<float>();

        if (dist <= heyDistance)
        {
            if (heyKey == 1)
            {
                bool active = text.gameObject.activeSelf;
                text.gameObject.SetActive(!active);
            }
        }
        else
        {
            text.gameObject.SetActive(false);
        }
    }
}
