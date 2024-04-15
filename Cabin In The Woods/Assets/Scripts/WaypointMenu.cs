using UnityEngine;

public class WaypointMenu : MonoBehaviour //InteractableObject
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

    //private ParticleSystem particles;
    //private Collider objectCollider;
    //private AudioSource audioSource;

    // Sets the MouseLook to the value of mouseLook
    private MouseLook mouseLook;
    // Sets a static bool to the value of mouseToggled then sets it to false;
    public static bool mouseToggled = false;
    //public static GameObject lastWaypoint = null;

    private void Awake()
    {
        // Gets the player 1st child and trys to get the mouse look commponet and sets it to mouseLook
        player.transform.GetChild(0).TryGetComponent<MouseLook>(out mouseLook);
    }
    private void Start()
    {
        // Turns the waypoint menu off on start
        waypointMenu.SetActive(false);
    }

    private void Update()
    {
        // Check if the WaypointMenu button has been clicked
        if (Input.GetButtonDown("WaypointMenu"))
            // Calls the ToggleMenu void
            ToggleMenu();

        // Checks if 1 on the keyboard was pressed
        if (Input.GetKeyDown(KeyCode.Alpha1))
            // Calls the TeleportPoint void and passes 0 through it
            TeleportToPoint(0);
        // Checks if 2 on the keyboard was pressed if the one above failed
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            // Calls the TeleportPoint void and passes 1 through it
            TeleportToPoint(1);
        // Checks if 3 on the keyboard was pressed if the one above failed
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            // Calls the TeleportPoint void and passes 2 through it
            TeleportToPoint(2);
        // Checks if 4 on the keyboard was pressed if the one above failed
        else if (Input.GetKeyDown(KeyCode.Alpha4))
            // Calls the TeleportPoint void and passes 3 through it
            TeleportToPoint(3);
        // Checks if 5 on the keyboard was pressed if the one above failed
        else if (Input.GetKeyDown(KeyCode.Alpha5))
            // Calls the TeleportPoint void and passes 4 through it
            TeleportToPoint(4);
    }

    // Toggles the menu on and off when the fucntion is called.
    private void ToggleMenu()
    {
        // Sets the waypointMenu active state to the oppiset of what it is currently
        waypointMenu.SetActive(!waypointMenu.activeSelf);
        // Sets the waypointKeybind active state to the oppiset of what it is currently
        waypointKeybind.SetActive(!waypointKeybind.activeSelf);
        // Calls the ToggleMouse function
        ToggleMouse();
    }

    // Toggles the mouse lock, and visablity on and off
    private void ToggleMouse()
    {
        // Checks if the mouseToggled is false
        if (!mouseToggled)
        {
            // Turns the mouse off and
            mouseLook.ToggleMouseLook(false, true);
            //Debug.Log("Toggled Mouse off");
        }
        // if the top is true runs this
        else
        {
            mouseLook.ToggleMouseLook(true, true);
            //Debug.Log("Toggled Mouse on");
        }

        // Sets mouseToggle to the oppiset of what it currently is.
        mouseToggled = !mouseToggled;

        //Debug.Log($"Mouse state {mouseToggled}");
    }

    //public override bool Activate()
    //{
    //    if (Interaction.Instance.CurrentWaypoint != this)
    //    {
    //        if (Interaction.Instance.CurrentWaypoint != null)
    //        {
    //            Interaction.Instance.CurrentWaypoint.Deactivate();
    //        }
    //        Interaction.Instance.CurrentWaypoint = NavigationWaypoint;
    //        Interaction.Instance.transform.parent.position = transform.position;
    //        if (objectCollider != null)
    //        {
    //            objectCollider.enabled = false;
    //        }
    //        if (particles != null)
    //        {
    //            particles.Stop();
    //        }
    //        if (audioSource != null && audioClip != null)
    //        {
    //            audioSource.PlayOneShot(audioClip);
    //        }
    //        return true;
    //    }
    //    return false;
    //}

    //public override bool Deactivate()
    //{
    //    if (Interaction.Instance.CurrentWaypoint == this)
    //    {
    //        if (Interaction.Instance.CurrentTooltip != null)
    //        {
    //            Interaction.Instance.CurrentTooltip.Deactivate();
    //        }
    //        Interaction.Instance.CurrentWaypoint = null;
    //        if (objectCollider != null)
    //        {
    //            objectCollider.enabled = true;
    //        }
    //        if (particles != null)
    //        {
    //            particles.Play();
    //        }
    //        return true;
    //    }
    //    return false;
    //}

    //Teleports the player to the waypoint and passes the point
    public void TeleportToPoint(int point)
    {
        //if (lastWaypoint != null)
        //{
        //    particles = lastWaypoint.GetComponentInChildren<ParticleSystem>();
        //    lastWaypoint.TryGetComponent<AudioSource>(out audioSource);
        //    lastWaypoint.TryGetComponent<Collider>(out objectCollider);

        //    if (objectCollider != null)
        //    {
        //        objectCollider.enabled = true;
        //        Debug.Log($"Enabling the collider on {lastWaypoint.gameObject.name}");
        //    }
        //    if (particles != null)
        //    {
        //        particles.Play();
        //        Debug.Log($"Enabling the partical on {lastWaypoint.gameObject.name}");
        //    }
        //    if (audioSource != null && audioClip != null)
        //    {
        //        audioSource.PlayOneShot(audioClip);
        //        Debug.Log($"Playing the audio on {lastWaypoint.gameObject.name}");
        //    }
        //}
        
        // Gets the waypoints and sets the array point to the value called "point" of the current waypoint then gets the
        // audio source compement and plays the audioClip through the audio source without assigning it to the compoment
        waypoints[point].GetComponent<AudioSource>().PlayOneShot(audioClip);
        // Sets the players position to current waypoints position
        player.position = waypoints[point].transform.position;
        //lastWaypoint = waypoints[point].gameObject;

        // Check the see if the waypointKeybind isnt active
        if (!waypointKeybind.activeSelf)
            // Calls the ToggleMenu() void
            ToggleMenu();
    }
}
