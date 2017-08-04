using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelContainer : MonoBehaviour {
    private int level = 1;
	// Use this for initialization
	public int GetLevel()
    {
        return level;
    }
    public void IncrementLevel()
    {
        level++;
    }
}
