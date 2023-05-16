using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/**
 * This component represents the ability to move objects around with WSAD keys.
 */
public class SuperPower : MonoBehaviour
{
    [SerializeField] InputAction objectMoveAction;
    [SerializeField] float speed = 3.5f;

    // Start is called before the first frame update
    private void OnEnable()
    {
        objectMoveAction.Enable();
    }
    private void OnDisable()
    {
        objectMoveAction.Disable();
    }
    void OnValidate()
    {
        // Provide default bindings for the input actions.
        // Based on answer by DMGregory: https://gamedev.stackexchange.com/a/205345/18261
        if (objectMoveAction == null)
            objectMoveAction = new InputAction(type: InputActionType.Button);
        if (objectMoveAction.bindings.Count == 0)
            objectMoveAction.AddCompositeBinding("2DVector")
                .With("Up", "<Keyboard>/W")
                .With("Down", "<Keyboard>/S")
                .With("Left", "<Keyboard>/D")
                .With("Right", "<Keyboard>/A");
    }
    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitData;
        Physics.Raycast(ray, out hitData);
        GameObject hitObject = hitData.transform.gameObject;
        // Debug.Log("Tag: " + hitObject.tag + " Name: " + hitObject.name);
        if (hitObject.tag != "Terrain")
        {
            Vector3 movement = objectMoveAction.ReadValue<Vector2>();
            Vector3 velocity = new Vector3(0, 0, 0);
            velocity.x = movement.x * speed;
            velocity.z = movement.y * speed;
            hitObject.transform.Translate(velocity * speed * Time.deltaTime);
        }
    }
}
