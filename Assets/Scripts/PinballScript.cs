using UnityEngine;
// We manage the restart of the game
using UnityEngine.SceneManagement;

public class PinballScript : MonoBehaviour
{
    // Plane moving speed
    public float speed = 8f;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown("left shift") || Input.GetKeyDown("right shift"))
        {
            speed = 16f;
        }
        if (Input.GetKeyUp("left shift") || Input.GetKeyUp("right shift"))
        {
            speed = 8f;
        }
        // Player may choose the up arrow or letter w to list the plane towards the left side
        // In the case of a multiplayer, both players can control the game with one or the other option.
        if (Input.GetKey("up") || Input.GetKey("w"))
        {
            transform.Rotate(new Vector3(1, 0, 0) * Time.deltaTime * speed);
        }
        if (Input.GetKey("down") || Input.GetKey("s"))
        {
            transform.Rotate(new Vector3(-1, 0, 0) * Time.deltaTime * speed);
        }
        if (Input.GetKey("left") || Input.GetKey("a"))
        {
            transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * speed);
        }
        if (Input.GetKey("right") || Input.GetKey("d"))
        {
            transform.Rotate(new Vector3(0, 0, -1) * Time.deltaTime * speed);
        }
        // Restart the game
        if (Input.GetKey("r"))
        {
            // Get active scene takes the current scene and re-execute the current scene.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        // Exit the game - (especially helpful once the game is exported)
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
