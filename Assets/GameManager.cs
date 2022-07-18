using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ApiReturnData
{
    public string data;

    public static ApiReturnData CreateFromJSON(string json)
    {
        return JsonUtility.FromJson<ApiReturnData>(json);
    }
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // The instance of the GameManager class. Accessible to all objects.

    private GameObject _selectedSpace; // Holds the currently-selected Space given by the server
    private string _lastMove; // Holds the source destination Space names of the last move the server recieved

    private const float API_UPDATE_DELAY = 0.5f; // The rate at which the server is queried for updates
    private float _elapsedTime = 0.0f; // Tracks time elapsed since last server update

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= API_UPDATE_DELAY)
        {
            StartCoroutine(GetSelectedFromServer());
            StartCoroutine(GetLastMoveFromServer());
            _elapsedTime = 0.0f;
        }
    }

    /// <summary>
    /// Called from within the client to update the currently selected Space and synchronize the server
    /// </summary>
    /// <param name="space"></param>
    public void SelectSpace(GameObject space)
    {
        if(_selectedSpace)
        {
            _selectedSpace.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
            StartCoroutine(SendMoveToServer(_selectedSpace.name+","+space.name));
            UpdateMove(_selectedSpace, space);
        } else if(space.GetComponent<SpriteRenderer>().sprite)
        {
            UpdateSelected(space);
            StartCoroutine(SendSelectedToServer(space.name));
        }
    }

    /// <summary>
    /// Handles a change in Space selection, either from the server or the client 
    /// </summary>
    /// <param name="selected"></param>
    void UpdateSelected(GameObject selected)
    {
        if (_selectedSpace)
        {
            _selectedSpace.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
        }

        _selectedSpace = selected;
        _selectedSpace.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, (float)0.5);
    }

    void UpdateMove(GameObject src, GameObject dest)
    {
        dest.GetComponent<SpriteRenderer>().sprite = src.GetComponent<SpriteRenderer>().sprite; // new space takes the sprite of the currently-selected space
        src.GetComponent<SpriteRenderer>().sprite = null;
        _selectedSpace = null;
    }

    /// <summary>
    /// Returns the currently-selected Space from the server API, represented as a GameObject name
    /// </summary>
    /// <returns></returns>
    IEnumerator GetSelectedFromServer()
    {
        UnityWebRequest request = UnityWebRequest.Get("/api/get_selected");
        yield return request.SendWebRequest();

        if(request.result == UnityWebRequest.Result.Success)
        {
            string name = ApiReturnData.CreateFromJSON(request.downloadHandler.text).data;

            if (name != "" && (_selectedSpace == null || name != _selectedSpace.name))
            {
                UpdateSelected(GameObject.Find(name));
            }
        }
    }

    /// <summary>
    /// Calls the server API method to update the currently selected Space
    /// </summary>
    /// <param name="selected"></param>
    /// <returns></returns>
    IEnumerator SendSelectedToServer(string selected)
    {
        UnityWebRequest request = UnityWebRequest.Get("/api/send_selected?selected=" + selected);
        yield return request.SendWebRequest();
    }

    /// <summary>
    /// Calls the server API method to update the last move played
    /// </summary>
    /// <param name="selected"></param>
    /// <returns></returns>
    IEnumerator GetLastMoveFromServer()
    {
        UnityWebRequest request = UnityWebRequest.Get("/api/get_move");
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string move = ApiReturnData.CreateFromJSON(request.downloadHandler.text).data;

            if (move != "" && (_lastMove == null || move != _lastMove))
            {
                _lastMove = move;
                UpdateMove(_selectedSpace, GameObject.Find(move.Split(",")[1]));
            }
        }
    }

    /// <summary>
    /// Calls the server API method to update the latest move
    /// </summary>
    /// <param name="selected"></param>
    /// <returns></returns>
    IEnumerator SendMoveToServer(string move)
    {
        UnityWebRequest request = UnityWebRequest.Get("/api/send_move?move=" + move);
        yield return request.SendWebRequest();
    }
}
