using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    private IEnumerator coroutine;
    private int currentTime;

    public AudioClip sound; //Squeak sound clip variable
    private AudioSource source { get { return GetComponent<AudioSource>(); } } //Audio source variable to be created in Start()

    public GameObject mole1; //Mole1 variables
    public Transform mole1Up; //Up position
    public Transform mole1Down; //Down position
    private bool MoveMole1Up; //Moving up? (when the mole is the chosen mole)
    private bool MoveMole1Down; //Moving down? (when the mole is the chosen mole)
    private bool mole1Hit; //Hit or not (when the mole is the chosen mole)

    public GameObject mole2; //Mole2 variables (same comments as for Mole1)
    public Transform mole2Up;
    public Transform mole2Down;
    private bool MoveMole2Up;
    private bool MoveMole2Down;
    private bool mole2Hit;

    public GameObject mole3; //Mole3 variables (same comments as for Mole1)
    public Transform mole3Up;
    public Transform mole3Down;
    private bool MoveMole3Up;
    private bool MoveMole3Down;
    private bool mole3Hit;

    public GameObject mole4; //Mole4 variables (same comments as for Mole1)
    public Transform mole4Up;
    public Transform mole4Down;
    private bool MoveMole4Up;
    private bool MoveMole4Down;
    private bool mole4Hit;

    private GameObject[] moles; //Mole array
    private int moleNumber; //Stores number currentMole is in the moles[] array
    public GameObject currentMole; //Stores current mole used in ChooseMole()
        //Initialized as Pipe 1 because CheckHit() needed to start with an object without a collider
    public float moveSpeed; //Stores moveSpeed set in SetSpeed()
    private Transform up; //Stores up position based on currentMole in ChoosePoints()
    private Transform down; //Stores down position based on currentMole in ChoosePoints()
    private int lastMoleNumber = -1; //Stores last mole used based on position in mole[] array in ChooseMole()
    private bool moleHit; //Bool tracking if currentMole has been hit
    public Sprite hitSprite; //Image of hit mole (hit)
    public Sprite notHitSprite; //Image of not hit mole (normal)

    public int currentScore; //Player's current score

    void Start()
    {
        coroutine = Counting(1, 3); //Create countdown every 1 second for 3 seconds
        StartCoroutine(coroutine); //Start count

        moles = GameObject.FindGameObjectsWithTag("mole"); //Populate mole array

        gameObject.AddComponent<AudioSource>(); //Create AudioSource
        source.clip = sound; //Set which sound clip will be played
        source.playOnAwake = false; //AudioSource will not play sound when it is created
    }

    void Update()
    {
        CheckHit(); //Constant call to check if the chosen mole has been hit
        if (MoveMole1Up == true) //Move Mole1 up
        {
            currentMole = mole1;
            up = mole1Up;
            currentMole.transform.position = Vector3.MoveTowards(currentMole.transform.position, up.position, Time.deltaTime * moveSpeed);
            if (moleHit == true)//Stop moving mole upward when hit and change animation
            {
                MoveMole1Up = false; //Stop moving mole up
                MoveMole1Down = true; //Start moving mole down
                currentMole.GetComponent<Image>().sprite = hitSprite;
                UpdateScore();
            }
            else if (Vector3.Distance(up.position, currentMole.transform.position) <= 1) //When reach destination point, switch to move down
            {
                MoveMole1Up = false;
                MoveMole1Down = true;
            }
        }
         if (MoveMole1Down == true) //Move Mole1 down
         {
            down = mole1Down;
            currentMole.transform.position = Vector3.MoveTowards(currentMole.transform.position, down.position, Time.deltaTime * moveSpeed);
            if ((moleHit == true) && (currentMole.GetComponent<Image>().sprite != hitSprite))
            {
                currentMole.GetComponent<Image>().sprite = hitSprite;
                UpdateScore();
            }
            else if (Vector3.Distance(down.position, currentMole.transform.position) <= 1)
            {
                if (moleHit == false)
                {
                    MoveMole1Down = false;
                    EndGame();
                }
                    else if (moleHit == true)
                {
                    MoveMole1Down = false;
                    moleHit = false;
                    currentMole.GetComponent<Image>().sprite = notHitSprite;
                    RunGame();
                }
            }
         }
        if (MoveMole2Up == true) //Move Mole2 up
        {
            currentMole = mole2;
            up = mole2Up;
            currentMole.transform.position = Vector3.MoveTowards(currentMole.transform.position, up.position, Time.deltaTime * moveSpeed);
            if (moleHit == true)//Stop moving mole upward when hit and change animation
            {
                MoveMole2Up = false; //Stop moving mole up
                MoveMole2Down = true; //Start moving mole down
                currentMole.GetComponent<Image>().sprite = hitSprite;
                UpdateScore();
            }
            else if (Vector3.Distance(up.position, currentMole.transform.position) <= 1) //When reach destination point, switch to move down
            {
                MoveMole2Up = false;
                MoveMole2Down = true;
            }
        }
        if (MoveMole2Down == true) //Move Mole2 down
        {
            down = mole2Down;
            currentMole.transform.position = Vector3.MoveTowards(currentMole.transform.position, down.position, Time.deltaTime * moveSpeed);
            if ((moleHit == true) && (currentMole.GetComponent<Image>().sprite != hitSprite))
            {
                currentMole.GetComponent<Image>().sprite = hitSprite;
                UpdateScore();
            }
            else if (Vector3.Distance(down.position, currentMole.transform.position) <= 1)
            {
                if (moleHit == false)
                {
                    MoveMole2Down = false;
                    EndGame();
                }
                else if (moleHit == true)
                {
                    MoveMole2Down = false;
                    moleHit = false;
                    currentMole.GetComponent<Image>().sprite = notHitSprite;
                    RunGame();
                }
            }
        }
        if (MoveMole3Up == true) //Move Mole3 up
        {
            currentMole = mole3;
            up = mole3Up;
            currentMole.transform.position = Vector3.MoveTowards(currentMole.transform.position, up.position, Time.deltaTime * moveSpeed);
            if (moleHit == true)//Stop moving mole upward when hit and change animation
            {
                MoveMole3Up = false; //Stop moving mole up
                MoveMole3Down = true; //Start moving mole down
                currentMole.GetComponent<Image>().sprite = hitSprite;
                UpdateScore();
            }
            else if (Vector3.Distance(up.position, currentMole.transform.position) <= 1) //When reach destination point, switch to move down
            {
                MoveMole3Up = false;
                MoveMole3Down = true;
            }
        }
        if (MoveMole3Down == true) //Move Mole3 down
        {
            down = mole3Down;
            currentMole.transform.position = Vector3.MoveTowards(currentMole.transform.position, down.position, Time.deltaTime * moveSpeed);
            if ((moleHit == true) && (currentMole.GetComponent<Image>().sprite != hitSprite))
            {
                currentMole.GetComponent<Image>().sprite = hitSprite;
                UpdateScore();
            }
            else if (Vector3.Distance(down.position, currentMole.transform.position) <= 1)
            {
                if (moleHit == false)
                {
                    MoveMole3Down = false;
                    EndGame();
                }
                else if (moleHit == true)
                {
                    MoveMole3Down = false;
                    moleHit = false;
                    currentMole.GetComponent<Image>().sprite = notHitSprite;
                    RunGame();
                }
            }
        }

        if (MoveMole4Up == true) //Move Mole4 up
        {
            currentMole = mole4;
            up = mole4Up;
            currentMole.transform.position = Vector3.MoveTowards(currentMole.transform.position, up.position, Time.deltaTime * moveSpeed);
            if (moleHit == true)//Stop moving mole upward when hit and change animation
            {
                MoveMole4Up = false; //Stop moving mole up
                MoveMole4Down = true; //Start moving mole down
                currentMole.GetComponent<Image>().sprite = hitSprite;
                UpdateScore();
            }
            else if (Vector3.Distance(up.position, currentMole.transform.position) <= 1)
            {
                MoveMole4Up = false;
                MoveMole4Down = true;
            }
        }
        if (MoveMole4Down == true) //Move Mole4 down
        {
            down = mole4Down;
            currentMole.transform.position = Vector3.MoveTowards(currentMole.transform.position, down.position, Time.deltaTime * moveSpeed);
            if ((moleHit == true) && (currentMole.GetComponent<Image>().sprite != hitSprite))
            {
                currentMole.GetComponent<Image>().sprite = hitSprite;
                UpdateScore();
            }
            else if (Vector3.Distance(down.position, currentMole.transform.position) <= 1)
            {
                if (moleHit == false)
                {
                    MoveMole1Down = false;
                    EndGame();
                }
                else if (moleHit == true)
                {
                    MoveMole4Down = false;
                    moleHit = false;
                    currentMole.GetComponent<Image>().sprite = notHitSprite;
                    RunGame();
                }
            }
        }
    }

    private IEnumerator Counting(int waitTime, int countTime) //Count function
    {
        currentTime = countTime;
        var tobject = GameObject.Find("Countdown");
        var txt = tobject.GetComponent<Text>(); //Set text changed to "Countdown"'s text
        while (currentTime != 0) //If count isn't zero - reduce count by 1
        {
            txt.text = currentTime.ToString();
            currentTime -= (int)(waitTime); //Decrease countdown by waitTime (1 second)
            yield return new WaitForSeconds(waitTime);
        }
        if (currentTime == 0) //If count is 0 - disable text
        {
            txt.enabled = false;
            RunGame();
        }
    }

    public void RunGame() //Game function
    {
        while (true)
        {
            SetSpeed(); //Set speed that moles move up and down
            ChooseMole(); //Choose which mole moves
            ChoosePoints(); //Choose points corresponding to the mole chosen in ChooseMole()
            break;
        }
    }

    public void SetSpeed() //Increase mole movement speed
    {
        double rate = 1.05; //Rate of increase
        if (moveSpeed <= 200)
        {
            moveSpeed = (float)((int)(moveSpeed * rate));
        }
    }

    public void ChooseMole() //Randomly picks a mole from the mole[] array
    {

        moleNumber = Random.Range(0, (moles.Length));
        if(moleNumber == lastMoleNumber) //Prevent the same mole from being called twice in a row by repeating until a different mole is called
        {
            ChooseMole();
        }
        lastMoleNumber = moleNumber;
        currentMole = moles[moleNumber];
    }

    public void ChoosePoints() //Assign up and down coordinates based on which mole is chosen in ChooseMole()
    {
        if (moleNumber == 0) //Mole1
        {
            up = mole1Up;
            down = mole1Down;
            MoveMole1Up = true;
        }
        else if (moleNumber == 1) //Mole2
        {
            up = mole2Up;
            down = mole2Down;
            MoveMole2Up = true;
        }
        else if (moleNumber ==  2)//Mole3
        {
            up = mole3Up;
            down = mole3Down;
            MoveMole3Up = true;
        }
        else if (moleNumber == 3)//Mole4
        {
            up = mole4Up;
            down = mole4Down;
            MoveMole4Up = true;
        }
    }

    private bool maskHit = false;

    public void CheckHit()
    {
        if (Input.GetMouseButtonDown(0)) //If screen is pressed
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
            if ((hit)) //If screen is pressed on current mole above pipe
            {
                if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
                {
                    if (hit.collider.tag == "mask")
                    {
                        maskHit = true;
                    }
                    else if ((moleHit == false) && (hit.transform.name == currentMole.name))
                    {
                        if(maskHit == false)
                        {
                            source.PlayOneShot(sound); //Play sound once
                            moleHit = true; //Mole is hit
                        }
                    }
                    maskHit = false;
                }
            }
        }
    }

    public void UpdateScore()
    {
        currentScore += 1;
        var tobject = GameObject.Find("Score");
        var txt = tobject.GetComponent<Text>(); //Set text changed to "Countdown"'s text
        txt.text = currentScore.ToString();
    }

    public void EndGame()
    {
        int bestScore = PlayerPrefs.GetInt("Best Score");

        if (bestScore <= currentScore)
        {
            PlayerPrefs.SetInt("Best Score", currentScore);
        }
        PlayerPrefs.SetInt("Score", currentScore);
        SceneManager.LoadScene("_end");
    }
}