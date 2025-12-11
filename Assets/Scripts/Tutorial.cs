using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public Canvas daCanvas;
    public Text daText;
    public Text gameplayText;
    public int curPage;
    public bool finished;
    public bool won;
    public bool offroad;

    // Start is called before the first frame update
    void Start()
    {
        curPage = 0;
        finished = false;
        won = false;
        offroad = false;
        gameplayText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        switch (curPage)
        {
            case 0:
                daText.text = "Welcome to Safe Driving, Safer Planet! In this game, you assume the role of a carpool host in order to reduce CO2 emissions.";
                break;
            case 1:
                daText.text = "Use the arrow keys to move. Pick up the passengers around town.";
                break;
            case 2:
                daText.text = "Keep an eye on your gas! Pick up gas cans around town to fill your gas up.";
                break;
            case 3:
                daText.text = "One more thing: please stay on the road. Good luck!";
                break;
            case 4:
                finished = true;
                daCanvas.enabled = false;
                gameplayText.enabled = true;
                break;
            case 5:
                finished = false;
                daCanvas.enabled = true;
                gameplayText.enabled = false;
                if (offroad)
                    daText.text = "Hey! Stay on the gosh darn road!";
                else if (won)
                    daText.text = "Nice! You brought all passengers to their destination and reduced CO2 emissions by only using one car. Click the button to play again!";
                else
                    daText.text = "You ran out of gas. Remember to keep an eye out for gas cans! Click the button to play again";
                break;
            case 6:
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                break;
        }
    }

    public void Increment()
    {
        curPage++;
    }
}
