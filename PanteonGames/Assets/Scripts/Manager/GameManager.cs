using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public List<Transform> players;
    public static GameManager instance;
    
    

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (UIManager.instance.isGameStart && !UIManager.instance.isPlayerFinishedGame)
        {
            Insertionsort(players);
        }
        
    }
    public void Insertionsort(List<Transform> input)
    {
        for (int i = 1; i < input.Count; i++)
        {
            Transform temp = input[i];
            int j;
            for (j = i-1; j>=0 &&  input[j].position.z >temp.position.z; j--)
            {
                input[j + 1] = input[j];
            }
            input[j + 1] = temp;
        }
    }
    

    
}
