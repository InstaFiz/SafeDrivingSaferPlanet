using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColliderAndInfo : MonoBehaviour
{
    private float gasSupply;
    private int curPassengers;
    private int maxPassengers;

    public Text daText;
    public GameObject tutorial;
    public Tutorial tutorialScript;

    public ArrowLook arrow;

    // Start is called before the first frame update
    void Start()
    {
        gasSupply = 200;
        curPassengers = 0;
        maxPassengers = 5;

        tutorialScript = tutorial.GetComponent<Tutorial>();
    }

    // Update is called once per frame
    void Update()
    {
        if (curPassengers >= maxPassengers)
            daText.text = "Gas supply: " + Mathf.CeilToInt(gasSupply) + "\nYou have all passengers!\nTake them to the road in the corner\nthat leaves town.";
        else
            daText.text = "Gas supply: " + Mathf.CeilToInt(gasSupply) + "\nPassengers: " + curPassengers + "/" + maxPassengers;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            gasSupply -= 10 * Time.deltaTime;
            gasSupply = Mathf.Max(0, gasSupply);
        }

        if (gasSupply <= 0 && tutorialScript.finished)
        {
            tutorialScript.Increment();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Gas"))
        {
            Destroy(other.gameObject);
            gasSupply += 50;
        }

        if (other.gameObject.CompareTag("Blockade"))
        {
            Destroy(other.gameObject);
            tutorialScript.offroad = true;
            tutorialScript.Increment();
        }

        if (other.gameObject.CompareTag("Passenger"))
        {
            arrow.CollectPassenger(other.transform);
            Destroy(other.gameObject);
            curPassengers++;
        }

        if (other.gameObject.CompareTag("Win") && curPassengers >= maxPassengers)
        {
            Destroy(other.gameObject);
            tutorialScript.won = true;
            tutorialScript.Increment();
        }
    }
}