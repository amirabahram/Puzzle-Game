using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class GameData 
{
    private bool[] candyPuzzlevels;
    private bool[] transportPuzzleLevels;
    private bool[] fruitsPuzzleLevels;

    private int[] candyPuzzlevelsStars;
    private int[] transportPuzzleLevelsStars;
    private int[] fruitsPuzzleLevelsStars;

    private bool isGameStartedForFirstTime;
    private float musicVolume;
    public void SetCandyPuzzleLevels(bool[] candyPuzzleLevels)
    {
        this.candyPuzzlevels = candyPuzzleLevels;
    }
    public bool[] GetCandyPuzzlevels() {  return this.candyPuzzlevels; }
    public void SetTransportPuzzleLevels(bool[] transportPuzzleLevels) { this.transportPuzzleLevels = transportPuzzleLevels;}
    public bool[] GetTransportPuzzleLevels() {  return this.transportPuzzleLevels; }
    public void SetFruitsPuzzleLevels(bool[] fruitsPuzzleLevels) 
    { 
        this.fruitsPuzzleLevels = fruitsPuzzleLevels; 
    }
    public bool[] GetFruitsPuzzleLevels() 
    { 
        return this.fruitsPuzzleLevels;
    }

    public void SetCandyLevelStars(int[] candyLevelStars) { candyPuzzlevelsStars = candyLevelStars;}
    public int[] GetCandyLevelStars() { return  this.candyPuzzlevelsStars;}
    public void SetTransportStars(int[] transportStars) { this.transportPuzzleLevelsStars = transportStars;}
    public int[] GetTransportStars() { return this.transportPuzzleLevelsStars;}
    public void SetFruitsLevelsStars(int[] fruitsLevelsStars) { this.fruitsPuzzleLevelsStars = fruitsLevelsStars;}
    public int[] GetFruitsStars() {  return fruitsPuzzleLevelsStars; }
    public void SetIsTheGameStartedForFirstTime(bool isTheGameStartedForFirstTime)
    {
        this.isGameStartedForFirstTime = isTheGameStartedForFirstTime;
    }
    public bool GetIsGameStartedForFirstTime() { return this.isGameStartedForFirstTime;}
    public void SetMusicVolume(float volume) { this.musicVolume = volume; }
    public float GetMusicVolume() {  return this.musicVolume; }
}
