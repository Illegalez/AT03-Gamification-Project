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

public class WaypointMenu : MonoBehaviour //InteractableObject
{
    [SerializeField] private GameObject waypointMenu;
    [SerializeField] private GameObject waypointKeybind;
    [SerializeField] private MouseLook mouseLook;
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private Transform player;
    [SerializeField] private AudioClip audioClip;

    private ParticleSystem particles;
    private Collider objectCollider;
    private AudioSource audioSource;
    public static bool mouseToggled = false;
    public static GameObject lastWaypoint = null;

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
        waypoints[point].GetComponent<AudioSource>().PlayOneShot(audioClip);
        player.position = waypoints[point].transform.position;
        //lastWaypoint = waypoints[point].gameObject;


        // Fix last point teleported to not showing
        if (!waypointKeybind.activeSelf)
            ToggleMenu();
    }
}
