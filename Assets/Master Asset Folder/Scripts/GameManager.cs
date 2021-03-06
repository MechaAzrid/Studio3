﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Added for Saving
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameManager : MonoBehaviour
{
    [Header("Game Variables")]
    public static GameManager instance = null; // allows for this object to become static in awake
    public PauseManager PM;
    public float foodPercentage; // what the average health vs unhealthy food stat is
    public string savedScene;
    public bool loadingScene;
    StreamWriter debugFile;
    public int shiftNumber;

    public string master = "Master_Scene"; 

    [Header("Player Variables")]
    public float playerGold; // how much gold the player has

    public float rent;
    public float petrol;

    [Header("Shift Variables")]
    public float shiftTime;
    public float maxShiftTime;
    public bool shiftStarted;
    public bool shiftFinished;
    public List<Meal> menu = new List<Meal>();
    public int customersServed;
    public float earnedGold;

    [Header("Prototyping")]
    public bool prototyping;

    // PRIVATE VARIABLES
    public CustomerManager CM; // links to customer manager
<<<<<<< HEAD
    private DebugMenu DB;
=======
    //private DebugMenu DB;

    public AudioSource AudioGM;
    public AudioClip mainmusic;

>>>>>>> Millie

    void Awake()
    {

        if (instance == null) // Check if instance already exists
        {
            instance = this; // this is instance
        }

        else if (instance != this) //If instance already exists
        {
            Destroy(gameObject); // destroys this 
        }

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == master)
        {
<<<<<<< HEAD

=======
            CM = GameObject.Find("_CustomerManager").GetComponent<CustomerManager>(); // links the game manager to customer manager
            PM = CM.GetComponent<PauseManager>();
           // DB = CM.GetComponent<DebugMenu>();
>>>>>>> Millie
        }

        else
        {
            CM = null;
            PM = null;
           // DB = null;
        }



    }

    void Start()
    {
        foodPercentage = 0; // resets the percentage

    
      

    }

    void Update()
    {
        if (shiftStarted) // checks to see if the shift has started.
        {
            shiftTime += Time.deltaTime; // increases time every second 

            if (shiftTime >= maxShiftTime) // checks to see if the shift time is equal or greater than the max amount of time per shift
            {
                if (shiftFinished == false) // prevents end shift from being called a lot....
                {
                    EndShift(); // runs end of shift
                }
            }
        }

        if (playerGold <= 0)
        {
            if (shiftFinished == false) // prevents end shift from being called a lot....
            {
                EndShift(); // runs end of shift
            }
        }

    }

    public void AddMeal(Meal meal)
    {
        menu.Add(meal);
    }

    public void ResetShift()
    {
        shiftStarted = false;
        playerGold = 200;
        shiftTime = 0;
        shiftNumber = 0;
        CM.infoBubble.SetActive(false);
    }

    public void UpdateHealthMeter() // Responsible for Updated the Overall Health Meter
    {
        float healthValue = 0; // used to calculate the health value

        if (CM.customersCompleted.Count >= 2)
        {

            foreach (GameObject order in CM.customersCompleted) // for each customer that has been completed it grabs the health value of the meal and adds it
            {
                // Grabbing Customer and Meal
                Customer completedCustomer = order.GetComponent<Customer>(); // link to the customer
                Meal meal = completedCustomer.customer.chosenMeal; // link to the chosen meal

                healthValue += meal.mealHealth; // adds meal health value 
            }

            foodPercentage = foodPercentage + healthValue / CM.customersCompleted.Count; // divides the health value by the number of completed customers to calculate the average



            // if (CM.customersCompleted.Count >= 1)
            foreach (GameObject gameObject in CM.customersCompleted)
            {
                DestroyObject(gameObject);
            }

            CM.customersCompleted.Clear(); 
        }

    }

    // Saving Variables
    public void SaveGame()
    {
        ClearSave();
        // savedScene = SceneManager.GetActiveScene().name;
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savegame1.dat");

        print("Creating Save");

        PlayerData data = new PlayerData();

        // Create a new variable for each thing that needs to be saved!
        data.playerGold = playerGold;
        data.foodPercentage = foodPercentage;

        
        data.savedScene = savedScene;

        bf.Serialize(file, data);
        file.Close();

        print("Saved!");
    }

    // Saving Variables
    public void SaveQuit()
    {
        ClearSave();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savegame1.dat");

        print("Creating Save");

        PlayerData data = new PlayerData();

        // Create a new variable for each thing that needs to be saved!
        data.playerGold = playerGold;
        data.foodPercentage = foodPercentage;


        data.savedScene = savedScene;

        bf.Serialize(file, data);
        file.Close();

        print("Saved!");

        Application.Quit();
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/savegame1.dat"))
        {
            print("Save Game Exists!"); 

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savegame1.dat", FileMode.Open);

            PlayerData data = (PlayerData)bf.Deserialize(file);

            print("Opening Save");

            playerGold = data.playerGold; 
            foodPercentage = data.foodPercentage;
            savedScene = data.savedScene;

            print("Save Loaded!");

        }

        /* AUTOSAVE LOAD
        else if (File.Exists(Application.persistentDataPath + "/save.autosave"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/save.autosave", FileMode.Open);

            PlayerData data = (PlayerData)bf.Deserialize(file);

            playerGold = data.playerGold;
            foodPercentage = data.foodPercentage;
            savedScene = data.savedScene;

            if (savedScene == master)
            {
                LoadScene(master);
                savedScene = null; 
            }
        }
        */
    }

    public void ClearSave()
    {
        if (File.Exists(Application.persistentDataPath + "/savegame1.dat"))
        {
            print("Save File Located!");
            File.Delete(Application.persistentDataPath + "/savegame1.dat");
            print("Save File Deleted :(");
        }
    }

    public void LoadScene(string scene) // Used to Load Scenes
    {
        StopCoroutine(LoadingScene(scene));
        StartCoroutine(LoadingScene(scene));
    }

    public IEnumerator LoadingScene(string scene)
    {
        if (loadingScene == true)
        {
            yield break;
        }

        loadingScene = true;

        if (shiftFinished == true)
        {
            if (CM != null)
            {
                CM.endShiftUI.SetActive(true);
                // Play sound here for end of shift
                yield return new WaitForSeconds(2f);
            }
        }

        if (shiftStarted)
        {
            ResetShift();
        }

        float fadeTime = GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);

        CM = null;
        PM = null;
        //DB = null;

        SceneManager.LoadScene(scene); // Loads the designated Scene

        if (scene == master) // Checks to see if the master scene is loaded, if so, enables all customer interaction prototype scripts
        {
<<<<<<< HEAD
            print("master scene loaded");
=======
            // Enables All Customer Interaction Scripts
            CM = GameObject.Find("_CustomerManager").GetComponent<CustomerManager>(); // links the game manager to customer manager
            PM = CM.GetComponent<PauseManager>();
            // DB = CM.GetComponent<DebugMenu>();
>>>>>>> Millie

            // Enables the Start of a Shift
            //StartShift();
        }

        else
        {
            CM = null;
            PM = null;
            //DB = null;
        }

        loadingScene = false;
    }


    public void StartShift()
    {
		//if (menu.Count > 0) {
		//	CM.menu.Clear();
		//}

		shiftFinished = false;
        shiftStarted = true;
<<<<<<< HEAD

        foreach (Meal meal in menu)
        {
            print(meal.mealName);
=======
        shiftNumber++;

        foreach (Meal meal in menu)
        {
            CM.menu.Add(meal);
>>>>>>> Millie
        }

    }

    public void EndShift()
    {
        print("End shift triggered");
        shiftStarted = false;
        shiftFinished = true;
        shiftTime = 0;

        CM.infoBubble.SetActive(false);

        playerGold -= petrol;
        playerGold -= rent;

		playerGold = Mathf.Clamp (playerGold, 0, 9000);

        shiftTime = 0;

        UpdateHealthMeter();
        

        LoadScene("End Of Shift");
      
    }

} 

[Serializable]
class PlayerData
{
    public float playerGold;
    public float foodPercentage;
    public string savedScene;
}