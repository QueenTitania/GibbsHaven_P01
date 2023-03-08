using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchManager : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] public GameObject player1Cursor;
    [SerializeField] public GameObject player2Cursor;
    //[SerializeField] private float gridScale = 10f;
    [SerializeField] private GameObject stonePrefab1;
    [SerializeField] private GameObject stonePrefab2;
    [SerializeField] private GameObject goban;
    [SerializeField] GameObject placedStones;
    private GameObject[] gridSpaces;
    public float gridDist;
    public float nearestDist = 10000;
    public GameObject nearestGrid;
    private int nearestIndex;

    [SerializeField] float xMin = 0;
    [SerializeField] float xMax = 0;
    [SerializeField] float yMin = 0;
    [SerializeField] float yMax = 0;

    private PlayerInput playerInput;

    private InputAction touchPositionAction;
    private InputAction touchPressAction;

    private Coroutine coroutine;

    private void Awake()
    {
        gridSpaces = GameObject.FindGameObjectsWithTag("GridSpace");
        nearestGrid = FindNearestGrid(player.transform.position);
        //nearestDist = Vector2.Distance(player.transform.position, nearestGrid.transform.position);

        playerInput = GetComponent<PlayerInput>();
        touchPressAction = playerInput.actions.FindAction("TouchPress");
        touchPositionAction = playerInput.actions.FindAction("TouchPosition");
    }

    private void OnEnable()
    {
        touchPressAction.performed += TouchPressed;
        touchPressAction.canceled += TouchDone;
    }

    private void OnDisable()
    {
        touchPressAction.performed -= TouchPressed;
        touchPressAction.canceled -= TouchDone;
    }

    private void TouchPressed(InputAction.CallbackContext context)
    {
        Vector2 currentPos = touchPositionAction.ReadValue<Vector2>();
        if ((currentPos.x < xMax && currentPos.x > xMin) && (currentPos.y > yMin && currentPos.y < yMax))
        {
            player.SetActive(true);
            coroutine = StartCoroutine(TrackFinger());
        }
        //Vector2 position = touchPositionAction.ReadValue<Vector2>();
        //player.transform.position = position;
    }

    private IEnumerator TrackFinger()
    {
        while(true)
        {
            Vector2 currentPos = touchPositionAction.ReadValue<Vector2>();
            //Vector2 gridSnap = new Vector2(Mathf.Round(currentPos.x / gridScale) * gridScale, Mathf.Round(currentPos.y / gridScale) * gridScale);
           // player.transform.position = currentPos;
            if(FindNearestGrid(currentPos) != null)
                player.transform.position = FindNearestGrid(currentPos).transform.position;
            yield return null;
        }
    }

    private void TouchDone(InputAction.CallbackContext context)
    {
        
        Vector2 currentPos = touchPositionAction.ReadValue<Vector2>();

        if ((currentPos.x < xMax && currentPos.x > xMin) && (currentPos.y > yMin && currentPos.y < yMax))
        {
            if(coroutine != null)
                StopCoroutine(coroutine);
            //Vector2 gridSnap = new Vector2(Mathf.Round(currentPos.x / gridScale) * gridScale, Mathf.Round(currentPos.y / gridScale) * gridScale);
            //GameObject instance = Instantiate(stonePrefab, placedStones.transform);
            GameObject nearestGrid = FindNearestGrid(currentPos);
            
            player.transform.position = nearestGrid.transform.position;
            //PlacePlayer1Stone();
        }

        
        
        //Vector2 position = touchPositionAction.ReadValue<Vector2>();
        //player.transform.position = position;
    }


    private GameObject FindNearestGrid(Vector2 currentPos)
    {
        nearestDist = 10000;
        for(int i=0; i < gridSpaces.Length; i++)
        {
            gridDist = Vector2.Distance(currentPos, gridSpaces[i].transform.position);
            //Debug.Log(nearestDist);

            if(gridDist < nearestDist)
            {
                if (gridSpaces[i].GetComponent<GridStatus>().hasStone == false)
                {
                    nearestGrid = gridSpaces[i];
                    nearestDist = gridDist;
                    nearestIndex = i;
                }
                
            }
        }

        return nearestGrid;
    }

    public void PlacePlayer1Stone()
    {
        if(player.activeSelf == true)
        {
            GameObject instance = Instantiate(stonePrefab1, placedStones.transform);
            instance.transform.position = player.transform.position;
            gridSpaces[nearestIndex].GetComponent<GridStatus>().hasStone = true;
        }
        
        player.SetActive(false);
    }

    public void PlacePlayer2Stone()
    {
        if(player.activeSelf == true)
        {
            GameObject instance = Instantiate(stonePrefab2, placedStones.transform);
            instance.transform.position = player.transform.position;
            gridSpaces[nearestIndex].GetComponent<GridStatus>().hasStone = true;
        }
        
        player.SetActive(false);
    }

}
