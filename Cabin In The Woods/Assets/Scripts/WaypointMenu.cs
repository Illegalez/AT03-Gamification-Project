using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using static UnityEngine.ParticleSystem;

public class WaypointMenu : MonoBehaviour
{
    [SerializeField] private GameObject waypointMenu;
    [SerializeField] private GameObject waypointKeybind;
    [SerializeField] private MouseLook mouseLook;
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private Transform player;
    [SerializeField] private AudioClip audioClip;
    public static bool mouseToggled = false;

    private void Start()
    {
        waypointMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetButtonDown("WaypointMenu"))
            ToggleMenu();
        if (Input.GetKeyDown(KeyCode.Alpha1))
            TeleportToPoint(0);
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            TeleportToPoint(1);
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            TeleportToPoint(2);
        else if (Input.GetKeyDown(KeyCode.Alpha4))
            TeleportToPoint(3);
        else if (Input.GetKeyDown(KeyCode.Alpha5))
            TeleportToPoint(4);
    }

    private void ToggleMenu()
    {
        waypointMenu.SetActive(!waypointMenu.activeSelf);
        waypointKeybind.SetActive(!waypointKeybind.activeSelf);
        ToggleMouse();
    }

    private void ToggleMouse()
    {
        if (!mouseToggled)
        {
            mouseLook.ToggleMouseLook(false, true);
            //Debug.Log("Toggled Mouse off");
        }
        else
        {
            mouseLook.ToggleMouseLook(true, true);
            //Debug.Log("Toggled Mouse on");
        }

        mouseToggled = !mouseToggled;

        //Debug.Log($"Mouse state {mouseToggled}");
    }

    public void TeleportToPoint(int point)
    {
        waypoints[point].GetComponent<AudioSource>().PlayOneShot(audioClip);
        player.position = waypoints[point].transform.position;

        // Fix last point teleported to not showing

        ToggleMenu();
    }
}
