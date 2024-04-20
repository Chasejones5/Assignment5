using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public GameObject letter;
    public GameObject cen;
    public TMP_Text funFactText;
    public GameObject nextRoundButton;
    public GameObject quitGameButton;
    private string[] wordsToGuess = { "whale", "shark", "octopus", "dolphin", "seal", "swordfish", "seaturtle", "squid", "jellyfish", "plankton" };
    private string wordToGuess = "";
    private int lengthOfWordToGuess;
    char[] lettersToGuess;
    bool[] lettersGuessed;
    private int nbAttempts, maxNbAttempts;
    public TMP_Text remainingAttemptsText;
    int score = 0;
    public ImageManager imageManager;

    Dictionary<string, string> funFacts = new Dictionary<string, string>
    {
        {"whale", "Whales are the largest animals on Earth."},
        {"shark", "Sharks have been around for more than 400 million years."},
        {"octopus", "Octopi have three hearts."},
        {"dolphin", "Dolphins are known for their intelligence and playful behavior."},
        {"seal", "Seals can stay underwater for up to two hours."},
        {"swordfish", "Swordfish are known for their long, flat bill-like snout."},
        {"seaturtle", "Sea turtles can live for more than 100 years."},
        {"squid", "Squids have the largest eyes of any animal."},
        {"jellyfish", "Jellyfish have no brain, blood, or heart."},
        {"plankton", "Plankton are the foundation of the marine food web."}
    };

    // Start is called before the first frame update
    void Start()
    {
        imageManager.HideAnimalImage();
        cen = GameObject.Find("centerOfScreen");
        InitGame();
        Debug.Log("GameManager.Start() - InitGame() called successfully");
        InitLetters();
        Debug.Log("GameManager.Start() - InitLetters() called successfully");
        nbAttempts = 0;
        maxNbAttempts = 10;
        updateNbAttempts();
        updateScore();
        nextRoundButton.SetActive(false);
        quitGameButton.SetActive(true);
        LoadHighScores();
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        

    }

    // Update is called once per frame
    void Update()
    {
        //CheckKeyboard();
        checkKeyboard2();
    }
    void InitLetters()
    {
        Debug.Log("GameManager.InitLetters() - Start");

        int nbLetters = lengthOfWordToGuess;

        GameObject[] existingLetters = GameObject.FindGameObjectsWithTag("Letter");
        Debug.Log("GameManager.InitLetters() - Number of existing letters: " + existingLetters.Length);
        foreach (GameObject letter in existingLetters)
        {
            Destroy(letter);
        }

        for (int i = 0; i < nbLetters; i++)
        {
            Vector3 newPosition;
            newPosition = new Vector3(cen.transform.position.x + ((i - nbLetters / 2.0f) * 100), cen.transform.position.y, cen.transform.position.z);
            GameObject l = (GameObject)Instantiate(letter, newPosition, Quaternion.identity);
            l.name = "letter" + (i + 1);
            l.tag = "Letter";
            l.transform.SetParent(GameObject.Find("Canvas").transform);
        }
        Debug.Log("GameManager.InitLetters() - End");
    }

    void InitGame()
    {
        // Load the current score from PlayerPrefs
        score = PlayerPrefs.GetInt("score", 0);

        int randomNumber = Random.Range(0, wordsToGuess.Length);
        wordToGuess = wordsToGuess[randomNumber];
        lengthOfWordToGuess = wordToGuess.Length;
        wordToGuess = wordToGuess.ToUpper();
        maxNbAttempts = wordsToGuess.Length * 2;
        lettersToGuess = new char[lengthOfWordToGuess];
        lettersGuessed = new bool[lengthOfWordToGuess];
        lettersToGuess = wordToGuess.ToCharArray();
    }

    void CheckKeyboard()
    {
        bool incorrectGuess = true;

        if (Input.GetKeyDown(KeyCode.A))
        {
            for (int i = 0; i < lengthOfWordToGuess; i++)
            {
                if (!lettersGuessed[i])
                {
                    if (lettersToGuess[i] == 'A')
                    {
                        lettersGuessed[i] = true;
                        GameObject.Find("letter" + (i + 1)).GetComponent<TextMeshProUGUI>().text = "A";
                        incorrectGuess = false;
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            for (int i = 0; i < lengthOfWordToGuess; i++)
            {
                if (!lettersGuessed[i])
                {
                    if (lettersToGuess[i] == 'B')
                    {
                        lettersGuessed[i] = true;
                        GameObject.Find("letter" + (i + 1)).GetComponent<TextMeshProUGUI>().text = "B";
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            for (int i = 0; i < lengthOfWordToGuess; i++)
            {
                if (!lettersGuessed[i])
                {
                    if (lettersToGuess[i] == 'C')
                    {
                        lettersGuessed[i] = true;
                        GameObject.Find("letter" + (i + 1)).GetComponent<TextMeshProUGUI>().text = "C";
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            for (int i = 0; i < lengthOfWordToGuess; i++)
            {
                if (!lettersGuessed[i])
                {
                    if (lettersToGuess[i] == 'D')
                    {
                        lettersGuessed[i] = true;
                        GameObject.Find("letter" + (i + 1)).GetComponent<TextMeshProUGUI>().text = "D";
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            for (int i = 0; i < lengthOfWordToGuess; i++)
            {
                if (!lettersGuessed[i])
                {
                    if (lettersToGuess[i] == 'E')
                    {
                        lettersGuessed[i] = true;
                        GameObject.Find("letter" + (i + 1)).GetComponent<TextMeshProUGUI>().text = "E";
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            for (int i = 0; i < lengthOfWordToGuess; i++)
            {
                if (!lettersGuessed[i])
                {
                    if (lettersToGuess[i] == 'F')
                    {
                        lettersGuessed[i] = true;
                        GameObject.Find("letter" + (i + 1)).GetComponent<TextMeshProUGUI>().text = "F";
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            for (int i = 0; i < lengthOfWordToGuess; i++)
            {
                if (!lettersGuessed[i])
                {
                    if (lettersToGuess[i] == 'G')
                    {
                        lettersGuessed[i] = true;
                        GameObject.Find("letter" + (i + 1)).GetComponent<TextMeshProUGUI>().text = "G";
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            for (int i = 0; i < lengthOfWordToGuess; i++)
            {
                if (!lettersGuessed[i])
                {
                    if (lettersToGuess[i] == 'H')
                    {
                        lettersGuessed[i] = true;
                        GameObject.Find("letter" + (i + 1)).GetComponent<TextMeshProUGUI>().text = "H";
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            for (int i = 0; i < lengthOfWordToGuess; i++)
            {
                if (!lettersGuessed[i])
                {
                    if (lettersToGuess[i] == 'I')
                    {
                        lettersGuessed[i] = true;
                        GameObject.Find("letter" + (i + 1)).GetComponent<TextMeshProUGUI>().text = "I";
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            for (int i = 0; i < lengthOfWordToGuess; i++)
            {
                if (!lettersGuessed[i])
                {
                    if (lettersToGuess[i] == 'J')
                    {
                        lettersGuessed[i] = true;
                        GameObject.Find("letter" + (i + 1)).GetComponent<TextMeshProUGUI>().text = "J";
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            for (int i = 0; i < lengthOfWordToGuess; i++)
            {
                if (!lettersGuessed[i])
                {
                    if (lettersToGuess[i] == 'K')
                    {
                        lettersGuessed[i] = true;
                        GameObject.Find("letter" + (i + 1)).GetComponent<TextMeshProUGUI>().text = "K";
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            for (int i = 0; i < lengthOfWordToGuess; i++)
            {
                if (!lettersGuessed[i])
                {
                    if (lettersToGuess[i] == 'L')
                    {
                        lettersGuessed[i] = true;
                        GameObject.Find("letter" + (i + 1)).GetComponent<TextMeshProUGUI>().text = "L";
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            for (int i = 0; i < lengthOfWordToGuess; i++)
            {
                if (!lettersGuessed[i])
                {
                    if (lettersToGuess[i] == 'M')
                    {
                        lettersGuessed[i] = true;
                        GameObject.Find("letter" + (i + 1)).GetComponent<TextMeshProUGUI>().text = "M";
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            for (int i = 0; i < lengthOfWordToGuess; i++)
            {
                if (!lettersGuessed[i])
                {
                    if (lettersToGuess[i] == 'N')
                    {
                        lettersGuessed[i] = true;
                        GameObject.Find("letter" + (i + 1)).GetComponent<TextMeshProUGUI>().text = "N";
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            for (int i = 0; i < lengthOfWordToGuess; i++)
            {
                if (!lettersGuessed[i])
                {
                    if (lettersToGuess[i] == 'O')
                    {
                        lettersGuessed[i] = true;
                        GameObject.Find("letter" + (i + 1)).GetComponent<TextMeshProUGUI>().text = "O";
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            for (int i = 0; i < lengthOfWordToGuess; i++)
            {
                if (!lettersGuessed[i])
                {
                    if (lettersToGuess[i] == 'P')
                    {
                        lettersGuessed[i] = true;
                        GameObject.Find("letter" + (i + 1)).GetComponent<TextMeshProUGUI>().text = "P";
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            for (int i = 0; i < lengthOfWordToGuess; i++)
            {
                if (!lettersGuessed[i])
                {
                    if (lettersToGuess[i] == 'Q')
                    {
                        lettersGuessed[i] = true;
                        GameObject.Find("letter" + (i + 1)).GetComponent<TextMeshProUGUI>().text = "Q";
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            for (int i = 0; i < lengthOfWordToGuess; i++)
            {
                if (!lettersGuessed[i])
                {
                    if (lettersToGuess[i] == 'R')
                    {
                        lettersGuessed[i] = true;
                        GameObject.Find("letter" + (i + 1)).GetComponent<TextMeshProUGUI>().text = "R";
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            for (int i = 0; i < lengthOfWordToGuess; i++)
            {
                if (!lettersGuessed[i])
                {
                    if (lettersToGuess[i] == 'S')
                    {
                        lettersGuessed[i] = true;
                        GameObject.Find("letter" + (i + 1)).GetComponent<TextMeshProUGUI>().text = "S";
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            for (int i = 0; i < lengthOfWordToGuess; i++)
            {
                if (!lettersGuessed[i])
                {
                    if (lettersToGuess[i] == 'T')
                    {
                        lettersGuessed[i] = true;
                        GameObject.Find("letter" + (i + 1)).GetComponent<TextMeshProUGUI>().text = "T";
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            for (int i = 0; i < lengthOfWordToGuess; i++)
            {
                if (!lettersGuessed[i])
                {
                    if (lettersToGuess[i] == 'U')
                    {
                        lettersGuessed[i] = true;
                        GameObject.Find("letter" + (i + 1)).GetComponent<TextMeshProUGUI>().text = "U";
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            for (int i = 0; i < lengthOfWordToGuess; i++)
            {
                if (!lettersGuessed[i])
                {
                    if (lettersToGuess[i] == 'V')
                    {
                        lettersGuessed[i] = true;
                        GameObject.Find("letter" + (i + 1)).GetComponent<TextMeshProUGUI>().text = "V";
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            for (int i = 0; i < lengthOfWordToGuess; i++)
            {
                if (!lettersGuessed[i])
                {
                    if (lettersToGuess[i] == 'W')
                    {
                        lettersGuessed[i] = true;
                        GameObject.Find("letter" + (i + 1)).GetComponent<TextMeshProUGUI>().text = "W";
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            for (int i = 0; i < lengthOfWordToGuess; i++)
            {
                if (!lettersGuessed[i])
                {
                    if (lettersToGuess[i] == 'X')
                    {
                        lettersGuessed[i] = true;
                        GameObject.Find("letter" + (i + 1)).GetComponent<TextMeshProUGUI>().text = "X";
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            for (int i = 0; i < lengthOfWordToGuess; i++)
            {
                if (!lettersGuessed[i])
                {
                    if (lettersToGuess[i] == 'Y')
                    {
                        lettersGuessed[i] = true;
                        GameObject.Find("letter" + (i + 1)).GetComponent<TextMeshProUGUI>().text = "Y";
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            for (int i = 0; i < lengthOfWordToGuess; i++)
            {
                if (!lettersGuessed[i])
                {
                    if (lettersToGuess[i] == 'Z')
                    {
                        lettersGuessed[i] = true;
                        GameObject.Find("letter" + (i + 1)).GetComponent<TextMeshProUGUI>().text = "Z";
                    }
                }
            }
        }
        if (incorrectGuess)
        {
            nbAttempts++;
            remainingAttemptsText.text = "Remaining Attempts: " + (maxNbAttempts - nbAttempts);
        }

        if (nbAttempts > maxNbAttempts)
        {
            SceneManager.LoadScene("wordGameEnd");
        }

    }
    void checkKeyboard2()
    {
        if (Input.anyKeyDown)
        {
            char letterPressed = Input.inputString.ToCharArray()[0];
            int letterPressedAsInt = System.Convert.ToInt32(letterPressed);

            if (letterPressedAsInt >= 97 && letterPressed <= 122)
            {
                nbAttempts++;
                updateNbAttempts();

                if (nbAttempts > maxNbAttempts)
                {
                    SceneManager.LoadScene("wordGameEnd");
                }

                bool letterFound = false;
                for (int i = 0; i < lengthOfWordToGuess; i++)
                {
                    if (!lettersGuessed[i])
                    {
                        letterPressed = System.Char.ToUpper(letterPressed);

                        if (lettersToGuess[i] == letterPressed)
                        {
                            lettersGuessed[i] = true;
                            GameObject.Find("letter" + (i + 1)).GetComponent<TextMeshProUGUI>().text = letterPressed.ToString();
                            letterFound = true;
                        }
                    }
                }

                if (letterFound)
                {
                    score = PlayerPrefs.GetInt("score");
                    score++;
                    PlayerPrefs.SetInt("score", score);
                    updateScore();

                    // Check if the current score is higher than the high score
                    int highScore = HighScoreManager.GetHighScore();
                    if (score > highScore)
                    {
                        // If so, update the high score
                        HighScoreManager.UpdateHighScore(score);
                        Debug.Log("New High Score: " + score);
                    }
                }
            }
        }

        UpdateButtonVisibility(); // Move this line outside the loop
    }

    public void NextRound()
    {
        InitGame();
        InitLetters();
        nextRoundButton.SetActive(false);
        funFactText.text = "";
        nbAttempts = 0;
        updateNbAttempts();
        UpdateButtonVisibility();
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("wordGameFinish");
    }
    void updateNbAttempts()
    {
        GameObject.Find("nbAttempts").GetComponent<TextMeshProUGUI>().text = nbAttempts + "/" + maxNbAttempts;
    }

    void updateScore()
    {
        GameObject.Find("scoreUI").GetComponent<TextMeshProUGUI>().text = "Score: " + score;
    }
    void LoadHighScores()
    {
        int highScore = HighScoreManager.GetHighScore();
        UpdateHighScoreUI(highScore);
    }

    void UpdateHighScoreUI(int highScore)
    {
        TMP_Text highScoreText = GameObject.Find("HighScoreText").GetComponent<TMP_Text>();
        highScoreText.text = "High Score: " + highScore;
    }
    public void UpdateScore(int amount)
    {
        // Update current score
        score = PlayerPrefs.GetInt("score", 0);
        score += amount;
        PlayerPrefs.SetInt("score", score);

        // Update the UI to display the current score
        updateScore();

        // Check if the current score is higher than the high score
        int highScore = HighScoreManager.GetHighScore();
        if (score > highScore)
        {
            // If so, update the high score
            HighScoreManager.UpdateHighScore(score);
            Debug.Log("New High Score: " + score);
        }
    }
    public void ShowHighScoreScene()
    {
        // Load the high score scene
        SceneManager.LoadScene("wordGameScores");
    }
    public void UpdateButtonVisibility()
    {
        if (nextRoundButton != null)
        {
            nextRoundButton.SetActive(true);
        }
        bool wordGuessed = true;
        for (int i = 0; i < lengthOfWordToGuess; i++)
        {
            if (!lettersGuessed[i])
            {
                wordGuessed = false;
                break;
            }
        }

        if (wordGuessed)
        {
            
            if (funFacts.ContainsKey(wordToGuess.ToLower()))
            {
                if (funFactText != null)
                {
                    funFactText.text = "Fun Fact: " + funFacts[wordToGuess.ToLower()];
                }
                
            }
            else
            {
                if (funFactText != null)
                {
                    funFactText.text = "No fun fact available for this word.";
                }
                
            }
            if (funFactText != null)
            {
                imageManager.DisplayAnimalImage(wordToGuess.ToLower());
                nextRoundButton.SetActive(true);
            }
            
        }
        else
        {
            imageManager.HideAnimalImage();
            nextRoundButton.SetActive(false);
        }
    }

}