using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerColorSwitch : MonoBehaviour
{
    public Material material1; // The first material to use
    public Material material2; // The second material to use
    public float materialSwitchInterval = 10f; // The time interval between material switches
    public GameObject hammer1; // The first hammer game object
    public GameObject hammer2; // The second hammer game object

    private Material currentMaterial1; // The current material in use
    private Material currentMaterial2;
    private string hammer1Tag;
    private string hammer2Tag;

    private Coroutine materialSwitchCoroutine; // The coroutine for switching materials

    void Start()
    {
        // Set the current material to material1
        currentMaterial1 = material1;
        currentMaterial2 = material2;

        // Start the coroutine for switching materials
        materialSwitchCoroutine = StartCoroutine(SwitchMaterials());
    }

    IEnumerator SwitchMaterials()
    {
        while (true)
        {
            // Wait for the specified time interval
            yield return new WaitForSeconds(materialSwitchInterval);

            // Switch the current material
            if (currentMaterial1 == material1)
            {
                currentMaterial1 = material2;
                currentMaterial2 = material1;
                hammer1Tag = "Green";
                hammer2Tag = "Red";

            }
            else
            {
                currentMaterial1 = material1;
                currentMaterial2 = material2;
                hammer1Tag = "Red";
                hammer2Tag = "Green";
            }

            // Update the materials of the hammers
            hammer1.GetComponent<MeshRenderer>().material = currentMaterial1;
            hammer2.GetComponent<MeshRenderer>().material = currentMaterial2;
            hammer1.gameObject.tag = hammer1Tag;
            hammer2 .gameObject.tag = hammer2Tag;

        }
    }
}
