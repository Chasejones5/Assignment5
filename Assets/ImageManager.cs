using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageManager : MonoBehaviour
{
    public Image animalImage;
    private Dictionary<string, Sprite> animalSprites = new Dictionary<string, Sprite>();

    void Start()
    {
        LoadAnimalSprites();
    }

    void LoadAnimalSprites()
    {
        // Load sprites from Resources folder
        LoadSprite("whale");
        LoadSprite("shark");
        LoadSprite("seal");
        LoadSprite("seaturtle");
        LoadSprite("squid");
        LoadSprite("swordfish");
        LoadSprite("plankton");
        LoadSprite("dolphin");
        LoadSprite("jellyfish");
        LoadSprite("octopus");

        // Add code to load other animal sprites here
    }

    void LoadSprite(string spriteName)
    {
        // Load sprite from Resources folder
        Sprite sprite = Resources.Load<Sprite>("Animals/" + spriteName);
        if (sprite != null)
        {
            animalSprites.Add(spriteName, sprite);
            Debug.Log("Loaded sprite: " + spriteName);
        }
        else
        {
            Debug.LogError("Failed to load sprite: " + spriteName);
        }
    }

    public void DisplayAnimalImage(string animalName)
    {
        if (animalSprites.ContainsKey(animalName))
        {
            animalImage.sprite = animalSprites[animalName];
            animalImage.gameObject.SetActive(true);

            Canvas animalImageCanvas = animalImage.GetComponentInParent<Canvas>();
            if (animalImageCanvas != null)
            {
                animalImageCanvas.sortingOrder = 10; // Adjust this value as needed
            }

            // Find the Canvas component of the guessed word text
            GameObject guessedWordTextObject = GameObject.Find("GuessedWordText");
            if (guessedWordTextObject != null)
            {
                Canvas guessedWordCanvas = guessedWordTextObject.GetComponentInParent<Canvas>();
                if (guessedWordCanvas != null)
                {
                    guessedWordCanvas.sortingOrder = 5; // Adjust this value as needed, but make it lower than the animal image's Canvas
                }
            }
        }
    }

    public void HideAnimalImage()
    {
        animalImage.gameObject.SetActive(false);
    }
}