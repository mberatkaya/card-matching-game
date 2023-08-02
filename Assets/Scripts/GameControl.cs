using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    GameObject SelectedButton;
    GameObject Button›tself;

    int SelectedValue;
    int LevelGoal;
    public int TotalGoal;

    public Sprite defaultSprite;
    public AudioSource[] Sounds;
    public GameObject[] Buttons;
    public GameObject[] LastScenes;
     
    //random
    public GameObject Grid;
    public GameObject CardRepo;
    bool renderStatus;
    int giveNumber;
    int TotalNumber;
    
    //timer
    public float RemainingTime = 120;
    float Minute;
    float Second;
    bool Timer;
    public TextMeshProUGUI Counter;

    void Start()
    {
        SelectedValue = 0;

        Timer = true;

        renderStatus = true;
        giveNumber = 0;
        TotalNumber = CardRepo.transform.childCount;


        StartCoroutine(Pool());
    }

    private void Update()
    {
        if (Timer && RemainingTime > 1)
        {
            RemainingTime -= Time.deltaTime;

            Minute = Mathf.FloorToInt(RemainingTime / 60);
            Second = Mathf.FloorToInt(RemainingTime % 60);

            Counter.text = string.Format("{0:00} : {1:00} ", Minute, Second);
        }

        else
        {
            Timer = false;
            GameOver();
        }
    }
  
    IEnumerator Pool()
    {
        yield return new WaitForSeconds(.1f);
        
        while (renderStatus)
        {
            int randomNum = Random.Range(0, CardRepo.transform.childCount - 1);
            
            if (CardRepo.transform.GetChild(randomNum).gameObject != null)
            {
                CardRepo.transform.GetChild(randomNum).transform.SetParent(Grid.transform);
                giveNumber++;

                if (giveNumber == TotalNumber)
                {
                    renderStatus = false;

                    Destroy(CardRepo.gameObject);
                }
            }
            
        }
    }
    public void Pause()
    {
        LastScenes[2].SetActive(true);

        Time.timeScale = 0;
    }

    public void Continue()
    {
        LastScenes[2].SetActive(false);
        Time.timeScale = 1;
    }
    void GameOver()
    {
        LastScenes[0].SetActive(true);
    }

    void Win()
    {
        LastScenes[1].SetActive(true);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

  
    public void GiveObject(GameObject Card)
    {
        Button›tself = Card;

        Button›tself.GetComponent<Image>().sprite = Button›tself.GetComponentInChildren<SpriteRenderer>().sprite;
        Button›tself.GetComponent<Image>().raycastTarget = false;
        Sounds[0].Play();
    }

    void ButtonSituation(bool situation)
    {
        foreach (var item in Buttons) 
        {
            if (item != null)
            {
                item.GetComponent<Image>().raycastTarget = situation;
            }
        }
    }

    public void ButtonTouch(int Xvalue)
    {
        Kontrol(Xvalue);
    }

    void Kontrol(int Yvalue)
    {
        if (SelectedValue == 0)
        {  
            SelectedValue = Yvalue;
            SelectedButton = Button›tself;
        }

        else
        {
            StartCoroutine(TimeControl(Yvalue));
        }
    }

    IEnumerator TimeControl(int Yvalue)
    {
        ButtonSituation(false);

        yield return new WaitForSeconds(1);

        if (SelectedValue == Yvalue)
        {
            LevelGoal++;

            SelectedButton.GetComponent<Image>().enabled = false;
            Button›tself.GetComponent<Image>().enabled = false;

            SelectedButton.GetComponent<Button>().enabled = false;
            Button›tself.GetComponent <Button>().enabled = false;
            

            SelectedValue = 0;
            SelectedButton = null;
            ButtonSituation(true);

            if (TotalGoal == LevelGoal)
            {
                Win();
            }

        }

        else
        {
            Sounds[1].Play();

            SelectedButton.GetComponent<Image>().sprite = defaultSprite;
            Button›tself.GetComponent<Image>().sprite = defaultSprite;

            SelectedValue = 0;
            SelectedButton = null;
            ButtonSituation(true);
        }
    }
}
