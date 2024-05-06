using UnityEngine;

public class WaypointMenu : MonoBehaviour
{
    [Tooltip("This is the waypoint menu that will open and close")]
    [SerializeField] private GameObject waypointMenu;
    [Tooltip("This is the waypoint menu keybind that will show when the waypoint menu doesn't")]
    [SerializeField] private GameObject waypointKeybind;
    [Tooltip("Put the player gameobject in here")]
    [SerializeField] private Transform player;
    [Tooltip("Put all the waypoints in the scene in this")]
    [SerializeField] private GameObject[] waypoints;
    [Tooltip("Put the teleport audio clip in here")]
    [SerializeField] private AudioClip audioClip;

    private AudioSource audioSource;
    private Animator animator;

    // Sets the MouseLook to the value of mouseLook
    private MouseLook mouseLook;
    // Sets a static bool to the value of mouseToggled then sets it to false;
    public static bool mouseToggled = false;

    private void Awake()
    {
        // Gets the player 1st child and trys to get the mouse look commponet and sets it to mouseLook
        player.transform.GetChild(0).TryGetComponent<MouseLook>(out mouseLook);
        // Trys to get the Animator of this object and sets it to the value animator
        TryGetComponent<Animator>(out animator);
        // Trys to get the Audio Source of this object and sets it to the value audioSource
        TryGetComponent<AudioSource>(out audioSource);
    }

    private void Update()
    {
        // Check if the WaypointMenu button has been clicked
        if (Input.GetButtonDown("WaypointMenu"))
        {
            // Calls the InvertMouse void
            InvertMouse();
            // Tells the audioSoruce to play a audioClip a single time without setting it the the AudioClip.
            audioSource.PlayOneShot(audioClip);
        }

        // Checks if 1 on the keyboard was pressed
        if (Input.GetKeyDown(KeyCode.Alpha1))
            // Calls TeleportWaypoint() and passes an int to corrospond to the array slot
            TeleportToPoint(0);

        // Checks if 2 on the keyboard was pressed if the one above failed
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            // Calls TeleportWaypoint() and passes an int to corrospond to the array slot
            TeleportToPoint(1);

        // Checks if 3 on the keyboard was pressed if the one above failed
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            // Calls TeleportWaypoint() and passes an int to corrospond to the array slot
            TeleportToPoint(2);

        // Checks if 4 on the keyboard was pressed if the one above failed
        else if (Input.GetKeyDown(KeyCode.Alpha4))
            // Calls TeleportWaypoint() and passes an int to corrospond to the array slot
            TeleportToPoint(3);

        // Checks if 5 on the keyboard was pressed if the one above failed
        else if (Input.GetKeyDown(KeyCode.Alpha5))
            // Calls TeleportWaypoint() and passes an int to corrospond to the array slot
            TeleportToPoint(4);

    }

    // Toggles the mouse lock, and visablity on and off
    private void InvertMouse()
    {
        // Checks if the mouseToggled is false
        if (!mouseToggled)
        {
            // Turns the mouse on
            mouseLook.ToggleMouseLook(false, true);
            // Toggles the menu animation to open
            animator.SetBool("State", true);
        }
        // if the top is true runs this
        else
        {
            // Turns the mouse off
            mouseLook.ToggleMouseLook(true, true);
            // Toggles the menu animation to close
            animator.SetBool("State", false);
        }
        // Sets mouseToggle to the oppiset of what it currently is.
        mouseToggled = !mouseToggled;
    }

    //Teleports the player to the waypoint and passes the point
    public void TeleportToPoint(int point)
    {
        // Gets waypounts element of the value point and calls the NavigationWaypoint then triggers Activate() that
        // teleports the player and activates the current waypoint and disables the waypoing you're going it in the array
        waypoints[point].GetComponent<NavigationWaypoint>().Activate();
        // Check the see if the waypointKeybind isnt active
        if (mouseToggled)
            // Calls the InvertMouse() void
            InvertMouse();
    }
}
