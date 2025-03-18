using UnityEngine;

public class FPSInput : MonoBehaviour
{
    public float speed = 3.0f;
    public float gravity = -9.8f;

    //Variable that references the charcter controller
    private CharacterController charController;

    public const float _baseSpeed = 3f;

    void OnEnable()
    {
        Messenger<float>.AddListener(GameEvents.SPEED_CHANGED, OnSpeedChanged);
    }

    private void OnDisable()
    {
        Messenger<float>.RemoveListener(GameEvents.SPEED_CHANGED, OnSpeedChanged);
    }
    private void OnSpeedChanged(float value)
    {
        speed = _baseSpeed * value;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Gets the character controller component from the game object
        charController = GetComponent<CharacterController>();
    }


    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed /** Time.deltaTime*/;
        float deltaZ = Input.GetAxis("Vertical") * speed /** Time.deltaTime*/;

        //transform.Translate(deltaX, 0, deltaZ);

        //Uses the character controller to move the player instead of the transform
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);

        //Ensures the player doesnt move too fast
        movement = Vector3.ClampMagnitude(movement, speed);

        //Apply gravity
        movement.y = gravity;

        //Speed * Time = Distance so we multiply by Time.deltaTime to move a certain amount within one frame
        movement *= Time.deltaTime;

        //Transforms movement from local to global coordinates
        movement = transform.TransformDirection(movement);

        //Move the character controller using the Move() method
        charController.Move(movement);
    }
}
