using UnityEngine;
using TMPro;

public class CollisionBall : MonoBehaviour
{
    private PointsScript pointsScript;
    public GameObject points;
    public TextMeshProUGUI endGame;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Add components PointScript to the private variable above (pointssScript line 6)
        pointsScript = points.GetComponent<PointsScript>();
    }

    // It is called on each frame
    void Update()
    {
        // If the ball falls under the plane we destroy the object
        if (this.transform.position.y <= -2)
        {
            Destroy(this.gameObject);
            // We assign to the text the value for score and level
            endGame.text = "Level: " + pointsScript.level + " | Score: " + pointsScript.score + " - Game Over! Press R to restart.";
        }
    }

    // Trigger events on collision
    void OnTriggerEnter(Collider object_c) // Collider component
    {
        pointsScript.score++;
        // Reduces the number of the skittles
        pointsScript.countobjects--;
        // The skittle disappears
        Destroy(object_c.gameObject);
    }
}
