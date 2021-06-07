using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Movement : MonoBehaviour
{
    /* General Movement variables */
    [SerializeField] private string horizontalInputEntry;
    [SerializeField] private string verticalInputEntry;

    [SerializeField] private float playerSpeed;
    [SerializeField] private float sprintMultiplier;
    [SerializeField] private KeyCode sprintKey;
    private CharacterController charController;

    /* Jump variables */
    [SerializeField] private AnimationCurve jumpFallOff;
    [SerializeField] private float jumpMultiplier;
    [SerializeField] private KeyCode jumpKey;
    private bool currentlyJumping;

    /* Victory boolean(could be moved somewhere more appropriate) */
    [SerializeField] private bool victoryScreen;

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Animal")
        {
            victoryScreen = true;
            SceneManager.LoadScene("VictoryScene");
        }
    }

    private void Awake()
    {
        horizontalInputEntry = "Horizontal";
        verticalInputEntry = "Vertical";
        playerSpeed = 6.0f;
        sprintMultiplier = 2.0f;
        charController = GetComponent<CharacterController>();
        jumpMultiplier = 10.0f;
        victoryScreen = false;
    }

    private void Update()
    {
        GeneralMovement();
    }

    private void GeneralMovement()
    {
        float horizontalInput = Input.GetAxis(horizontalInputEntry) * playerSpeed;
        float verticalInput = Input.GetAxis(verticalInputEntry) * playerSpeed;

        if (Input.GetKey(sprintKey))
            sprintMultiplier = 2.0f;
        else
            sprintMultiplier = 1.0f;

        Vector3 forwardMovement = transform.forward * verticalInput * sprintMultiplier;
        Vector3 rightMovement = transform.right * horizontalInput * sprintMultiplier;

        charController.SimpleMove(forwardMovement + rightMovement);

        JumpInput();
    }

    private void JumpInput()
    {
        if(Input.GetKeyDown(jumpKey) && !currentlyJumping)
        {
            currentlyJumping = true;
            StartCoroutine(JumpEvent());
        }
    }

    private IEnumerator JumpEvent()
    {
        charController.slopeLimit = 90.0f;
        float timeInAir = 0.0f;

        do
        {
            float jumpForce = jumpFallOff.Evaluate(timeInAir);
            charController.Move(Vector3.up * jumpForce * jumpMultiplier * Time.deltaTime);
            timeInAir += Time.deltaTime;
            yield return null;
        } while (!charController.isGrounded && charController.collisionFlags != CollisionFlags.Above);

        charController.slopeLimit = 45.0f;

        currentlyJumping = false;
    }
}
