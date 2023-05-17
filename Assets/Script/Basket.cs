using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
	[Header("Set Dynamically")]
	public Text scoreGT;
    // Start is called before the first frame update
    void Start()
    {

	GameObject scoreGO = GameObject.Find("ScoreCounter");
//get the text component
scoreGT = scoreGO.GetComponent<Text>();
//Set the score to zero
scoreGT.text = "0";
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;

mousePos2D.z = -Camera.main.transform.position.z;

Vector3 mousePos3D = Camera.main.ScreenToWorldPoint (mousePos2D);

//move the x position of the basket based on mouse

Vector3 pos = this.transform.position;
pos.x = mousePos3D.x;
this.transform.position = pos;


    }
	//When we hit an Apple
	void OnCollisionEnter(Collision coll) 
{
GameObject collidedWith = coll.gameObject;
if (collidedWith.CompareTag ("Apple")) {
print("AppleCollided");
Destroy(collidedWith);
}

//Convert the score from String to int
int score = int.Parse(scoreGT.text);
//Add 100 points
score += 100;
//convert the score back to a String
scoreGT.text = score.ToString();

}



}
