using UnityEngine;
using TMPro;

public class PointsScript : MonoBehaviour
{
    public int countobjects = 0;
    public GameObject mypoints; // skittle
    public Transform parent; // parent object
    public int score = 0;
    public int level = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI levelText;
    // Create the array that contains teh skittle colors
    private Color[] colours = { Color.cornflowerBlue, Color.lawnGreen, Color.red, Color.violet };

    // Update is called once per frame
    void Update()
    {
        if (score == 7)
        {
            level++;
            score = 0;
            levelText.text = "Level: " + level;
        }
        // if the number of skittles is less than 5 (1 hit or game just starts)
        if (countobjects < 5)
        {
            // we create a possible position for the skittle where the X and Z axes are randomized while the value of Y is fixed.
            Vector3 randomXZ = new Vector3(
                Random.Range(-5.9f, 5.9f),
                10f, // start above the plane
                Random.Range(-3.0f, 3.0f)
            );
            // It creates invisable laser beam from a point in a direction
            Ray ray = new Ray(parent.TransformPoint(randomXZ), -parent.up);
            RaycastHit hit;

            // The laser beam checks what is hit and where.
            if (Physics.Raycast(ray, out hit))
            {
                GameObject skittle = Instantiate(mypoints, hit.point, Quaternion.identity);
                // Sets the skittle as a child of the plane
                skittle.transform.SetParent(parent, true);
                // Create new skittle
                countobjects += 1;
                // Add the material to the skittle
                skittle.GetComponent<MeshRenderer>().material.color = colours[Random.Range(0, 3)];
                // Create the logic that makes sure the skittle is on the plane and visible to the user
                if (skittle.transform.position.y < 0.05 || skittle.transform.position.y >= 1.7f)
                {
                    Destroy(skittle);
                    countobjects--;
                }
            }
            // Display on the screen the current number of skittles hit (1 skittle = 1 score)
            scoreText.text = "Score: " + score;
        }

    }
}
