using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class PuzzleGameSaver : MonoBehaviour
{
    private GameData gameData;
    public bool[] candyPuzzlevels;
    public bool[] transportPuzzleLevels;
    public bool[] fruitsPuzzleLevels;

    public int[] candyPuzzlevelsStars;
    public int[] transportPuzzleLevelsStars;
    public int[] fruitsPuzzleLevelsStars;
    private bool IsGameStartedForFirstTime;
    public  float musicVolume;
    private void Awake()
    {
        InitializeGame();
    }
    void InitializeGame()
    {
        LoadGameData();
        if (gameData != null)
        {
            IsGameStartedForFirstTime = gameData.GetIsGameStartedForFirstTime();

        }
        else
        {
            IsGameStartedForFirstTime = true;
        }
        if (IsGameStartedForFirstTime)
        {
            IsGameStartedForFirstTime = false;
            musicVolume = 0f;
            candyPuzzlevels = new bool[5];
            transportPuzzleLevels = new bool[5];
            fruitsPuzzleLevels = new bool[5];
            candyPuzzlevels[0] = true;
            transportPuzzleLevels[0] = true;
            fruitsPuzzleLevels[0] = true;
            for(int i = 1; i < candyPuzzlevels.Length; i++) {
                candyPuzzlevels[i]= false;
                transportPuzzleLevels[i] = false;
                fruitsPuzzleLevels[i] = false;
            }
            candyPuzzlevelsStars = new int[5];
            transportPuzzleLevelsStars = new int[5];
            fruitsPuzzleLevelsStars = new int[5];
            for(int i = 0;i<candyPuzzlevelsStars.Length; i++)
            {
                candyPuzzlevelsStars[i] = 0;
                transportPuzzleLevelsStars[i] = 0;
                fruitsPuzzleLevelsStars[i] = 0;
            }
            gameData = new GameData();
            gameData.SetCandyPuzzleLevels(candyPuzzlevels);
            gameData.SetTransportPuzzleLevels(transportPuzzleLevels);
            gameData.SetFruitsPuzzleLevels(fruitsPuzzleLevels);
            gameData.SetCandyLevelStars(candyPuzzlevelsStars);
            gameData.SetTransportStars(transportPuzzleLevelsStars);
            gameData.SetFruitsLevelsStars(fruitsPuzzleLevelsStars);
            gameData.SetIsTheGameStartedForFirstTime(IsGameStartedForFirstTime);
            gameData.SetMusicVolume(musicVolume);
            SaveGameData();
            LoadGameData();
        }
    }
    public void SaveGameData()
    {
        FileStream file = null;
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            file = File.Create(Application.persistentDataPath + "/GameData.dat");
            if(gameData !=  null)
            {
                gameData.SetCandyPuzzleLevels(candyPuzzlevels);
                gameData.SetTransportPuzzleLevels(transportPuzzleLevels);
                gameData.SetFruitsPuzzleLevels(fruitsPuzzleLevels);
                gameData.SetCandyLevelStars(candyPuzzlevelsStars);
                gameData.SetTransportStars(transportPuzzleLevelsStars);
                gameData.SetFruitsLevelsStars(fruitsPuzzleLevelsStars); 
                gameData.SetMusicVolume(musicVolume);
                gameData.SetIsTheGameStartedForFirstTime(IsGameStartedForFirstTime);
                bf.Serialize(file,gameData);

            }
        }
        catch(Exception e)
        {

        }
        finally
        {
            if(file != null)
            {
                file.Close();
            }
        }
    }
    void LoadGameData()
    {
        FileStream file = null;
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            file = File.Open(Application.persistentDataPath + "/GameData.dat",FileMode.Open);
            gameData = (GameData)bf.Deserialize(file);
            if(gameData != null)
            {
                candyPuzzlevels = gameData.GetCandyPuzzlevels();
                transportPuzzleLevels = gameData.GetTransportPuzzleLevels();
                fruitsPuzzleLevels = gameData.GetFruitsPuzzleLevels();
                candyPuzzlevelsStars = gameData.GetCandyLevelStars();
                transportPuzzleLevelsStars = gameData.GetTransportStars();
                fruitsPuzzleLevelsStars = gameData.GetFruitsStars();
                musicVolume = gameData.GetMusicVolume();
                IsGameStartedForFirstTime = gameData.GetIsGameStartedForFirstTime();

               
            }
        }
        catch(Exception e)
        {

        }
        finally { if(file != null) {  file.Close(); } }

    }
    public void Save(int level,string selectedPuzzle,int stars)
    {
        int unlockNextLevel = -1;
        switch (selectedPuzzle)
        {
            case "Candy Button":
                unlockNextLevel = level + 1;
                candyPuzzlevelsStars[level-1] = stars;
                if (level <= candyPuzzlevels.Length)
                {
                    candyPuzzlevels[level] = true;
                }
                break;
            case "Transport Button":
                unlockNextLevel = level + 1;
                transportPuzzleLevelsStars[level-1] = stars;
                if (level <= transportPuzzleLevels.Length)
                {
                    transportPuzzleLevels[level] = true;
                }
                break;
            case "Fruit Button":
                unlockNextLevel = level + 1;
                fruitsPuzzleLevelsStars[level-1] = stars;
                if (level <= fruitsPuzzleLevels.Length)
                {
                    fruitsPuzzleLevels[level] = true;
                }
                break;
        }
    }
}
