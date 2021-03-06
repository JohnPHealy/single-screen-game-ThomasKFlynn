using UnityEngine;
using System.Collections;

public class MagnifyingGlassScript : MonoBehaviour
{
    private Camera magnifyCamera;
    private LineRenderer LeftBorder, RightBorder, TopBorder, BottomBorder; // Reference for lines of magnify glass borders
    private float MGOX, MG0Y; // Magnify Glass Origin X and Y position
    private float MGWidth = Screen.width / 4f, MGHeight = Screen.width / 4f; // Magnify glass width and height
    private Vector3 mousePos;

    public float hSliderValueR = 0.0F;
    public float hSliderValueG = 0.0F;
    public float hSliderValueB = 0.0F;
    public float hSliderValueA = 0.0F;

    void Start()
    {
        Cursor.visible = false;
        createMagnifyGlass();
    }
    void Update()
    {
        // Following lines set the camera's pixelRect and camera position at mouse position
        magnifyCamera.pixelRect = new Rect(Input.mousePosition.x - MGWidth / 2.0f, Input.mousePosition.y - MGHeight / 2.0f, MGWidth, MGHeight);
        mousePos = getWorldPosition(Input.mousePosition);
        magnifyCamera.transform.position = mousePos;
        mousePos.z = Camera.main.nearClipPlane;
    }

    // Following method creates MagnifyGlass
    private void createMagnifyGlass()
    {
        GameObject camera = new GameObject("MagnifyCamera");
        MGOX = Screen.width / 2f - MGWidth / 5f;
        MG0Y = Screen.height / 2f - MGHeight / 5f;
        magnifyCamera = camera.AddComponent<Camera>();
        magnifyCamera.pixelRect = new Rect(MGOX, MG0Y, MGWidth, MGHeight);
        magnifyCamera.transform.position = new Vector3(0, 0, 0);
        if (Camera.main.orthographic)
        {
            magnifyCamera.orthographic = true;
            magnifyCamera.orthographicSize = Camera.main.orthographicSize / 5.0f;//+ 1.0f;
            
        }
        else
        {
            magnifyCamera.orthographic = false;
            magnifyCamera.fieldOfView = Camera.main.fieldOfView / 10.0f;//3.0f;
        }

    }

    // Following method sets border of MagnifyGlass


    // Following method calculates world's point from screen point as per camera's projection type
    public Vector3 getWorldPosition(Vector3 screenPos)
    {
        Vector3 worldPos;
        if (Camera.main.orthographic)
        {
            worldPos = Camera.main.ScreenToWorldPoint(screenPos);
            worldPos.z = Camera.main.transform.position.z;
        }
        else
        {
            worldPos = Camera.main.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, Camera.main.transform.position.z));
            worldPos.x *= -1;
            worldPos.y *= -1;
        }
        return worldPos;
    }
}