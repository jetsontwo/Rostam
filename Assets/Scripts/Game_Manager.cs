﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour {

    private float game_multiplier = 0.002f;
    public PlayerShooting player_shoot;
    public Camera_Shake cs;
    public Player_Access pa;
    public Texture2D cursor;
    public GameObject[] spawn_locations;
    public GameObject[] enemies;
    public GameObject enemy_holder;

    void Start()
    {
        StartCoroutine(spawn());
        Cursor.SetCursor(cursor,new Vector2(16, 16), CursorMode.Auto);
        
    }

	// Use this for initialization
	public void Up_the_Ante () {
        cs.shake_mult += game_multiplier / 100;
        var main = player_shoot.explosion_ps.main;
        main.startSizeMultiplier += game_multiplier;
        var main2 = player_shoot.shoot_ps.main;
        main2.startSizeMultiplier += game_multiplier;
    }

    private IEnumerator spawn()
    {
        while(true)
        {
            GameObject g = Instantiate(enemies[Random.Range(0, 3)], spawn_locations[Random.Range(0, 4)].transform.position, Quaternion.identity, enemy_holder.transform);
            g.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
            yield return new WaitForSeconds(Random.Range(0.6f, 1.2f));
        }

    }

}
