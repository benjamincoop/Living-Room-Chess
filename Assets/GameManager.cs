using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // The instance of the GameManager class. Accessible to all objects.

    private GameObject _selectedSpace; // Holds the currently-selected Space object.

    public GameObject SelectedSpace
    {
        get
        {
            return _selectedSpace;
        }
        set
        {
            if(_selectedSpace)
            {
                if(value != _selectedSpace)
                {
                    CaptureSpace(_selectedSpace, value);
                }

                UnselectSpace(value);

            } else
            {
                SelectSpace(value);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SelectSpace(GameObject space)
    {
        _selectedSpace = space;
        _selectedSpace.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, (float)0.5);
    }

    private void UnselectSpace(GameObject space)
    {
        _selectedSpace.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
        _selectedSpace = null;
    }

    private void CaptureSpace(GameObject src, GameObject dest)
    {
        dest.GetComponent<SpriteRenderer>().sprite = src.GetComponent<SpriteRenderer>().sprite; // new space takes the sprite of the currently-selected space
        src.GetComponent<SpriteRenderer>().sprite = null;
    }


}
