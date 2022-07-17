using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var spaces = GameObject.FindGameObjectsWithTag("Space");
        foreach(GameObject space in spaces)
        {
            switch(space.name)
            {
                // white pieces
                case "a1":
                    space.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("white_rook");
                    break;
                case "b1":
                    space.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("white_knight");
                    break;
                case "c1":
                    space.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("white_bishop");
                    break;
                case "d1":
                    space.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("white_queen");
                    break;
                case "e1":
                    space.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("white_king");
                    break;
                case "f1":
                    space.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("white_bishop");
                    break;
                case "g1":
                    space.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("white_knight");
                    break;
                case "h1":
                    space.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("white_rook");
                    break;
                case "a2":
                    space.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("white_pawn");
                    break;
                case "b2":
                    space.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("white_pawn");
                    break;
                case "c2":
                    space.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("white_pawn");
                    break;
                case "d2":
                    space.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("white_pawn");
                    break;
                case "e2":
                    space.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("white_pawn");
                    break;
                case "f2":
                    space.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("white_pawn");
                    break;
                case "g2":
                    space.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("white_pawn");
                    break;
                case "h2":
                    space.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("white_pawn");
                    break;
                // black pieces
                case "a7":
                    space.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("black_pawn");
                    break;
                case "b7":
                    space.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("black_pawn");
                    break;
                case "c7":
                    space.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("black_pawn");
                    break;
                case "d7":
                    space.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("black_pawn");
                    break;
                case "e7":
                    space.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("black_pawn");
                    break;
                case "f7":
                    space.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("black_pawn");
                    break;
                case "g7":
                    space.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("black_pawn");
                    break;
                case "h7":
                    space.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("black_pawn");
                    break;
                case "a8":
                    space.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("black_rook");
                    break;
                case "b8":
                    space.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("black_knight");
                    break;
                case "c8":
                    space.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("black_bishop");
                    break;
                case "d8":
                    space.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("black_queen");
                    break;
                case "e8":
                    space.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("black_king");
                    break;
                case "f8":
                    space.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("black_bishop");
                    break;
                case "g8":
                    space.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("black_knight");
                    break;
                case "h8":
                    space.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("black_rook");
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
