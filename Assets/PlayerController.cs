using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public float moveSpeed;
    public float turnSpeed;
    public Text mouseText;
    public Text playerText;
    private Rigidbody rb;

    private Vector3 inputMovement;
	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update ()
    {
        //inputMovement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //float diagonalFactor = Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") != 0 ? diagonalFactor = 1f / Mathf.Sqrt(2.0f) : 1;
        //transform.Translate(inputMovement * Time.deltaTime * moveSpeed * diagonalFactor, Space.World);
        //transform.Rotate(new Vector3(0, 10) * Time.deltaTime * turnSpeed);
        mouseText.text = "Mouse Pos: " + Input.mousePosition.ToString();
        playerText.text = "Player Pos: " + transform.position.ToString();
    }

    void FixedUpdate()
    {
        Quaternion rotation = rb.rotation;
        rotation[0] = 0;
        rotation[2] = 0;
        rb.rotation = rotation;
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * moveSpeed);        
    }
}
