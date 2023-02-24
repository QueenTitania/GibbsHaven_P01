using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float gridScale = 10f;
    [SerializeField] private GameObject stonePrefab;
    [SerializeField] private GameObject goban;
    [SerializeField] GameObject canvas;

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
            player.transform.position = touchPositionAction.ReadValue<Vector2>();
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
            Vector2 gridSnap = new Vector2(Mathf.Round(currentPos.x / gridScale) * gridScale,
                                         Mathf.Round(currentPos.y / gridScale) * gridScale);
            GameObject instance = Instantiate(stonePrefab, canvas.transform);
            instance.transform.position = gridSnap;
        }


        player.SetActive(false);
        //Vector2 position = touchPositionAction.ReadValue<Vector2>();
        //player.transform.position = position;
    }


}
