using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEditor : MonoBehaviour
{
    public Transform KinectTransform;
    public GameObject EditUI;
    public Camera Camera;
    public GameObject ModelMeshParent;
    public float RotationChange = 1;
    public float TranslationChange = 0.02f;
    public float FOVChange = 0.05f;
    public GameObject VoxelObject;
    public GameObject ParticleObject;

    private int currChild = 0;

    void Start()
    {
        currChild = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            EditUI.SetActive(!EditUI.activeSelf);
        }

        if (EditUI.activeSelf)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                KinectTransform.transform.Rotate(new Vector3(RotationChange, 0, 0));
            }

            if (Input.GetKey(KeyCode.A))
            {
                KinectTransform.transform.Rotate(new Vector3(-RotationChange, 0, 0));
            }

            if (Input.GetKey(KeyCode.W))
            {
                KinectTransform.transform.Translate(new Vector3(0, 0, TranslationChange));
            }

            if (Input.GetKey(KeyCode.S))
            {
                KinectTransform.transform.Translate(new Vector3(0, 0, -TranslationChange));
            }

            if (Input.GetKey(KeyCode.E))
            {
                KinectTransform.transform.Translate(new Vector3(0, TranslationChange, 0));
            }

            if (Input.GetKey(KeyCode.D))
            {
                KinectTransform.transform.Translate(new Vector3(0, -TranslationChange, 0));
            }

            if (Input.GetKey(KeyCode.R))
            {
                Camera.fieldOfView = Camera.fieldOfView + FOVChange;
            }

            if (Input.GetKey(KeyCode.F))
            {
                Camera.fieldOfView = Camera.fieldOfView - FOVChange;
            }

            if (Input.GetKey(KeyCode.R))
            {
                Camera.fieldOfView = Camera.fieldOfView + FOVChange;
            }

            if (Input.GetKey(KeyCode.F))
            {
                Camera.fieldOfView = Camera.fieldOfView - FOVChange;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                ModelMeshParent.transform.GetChild(currChild).gameObject.SetActive(false);
                currChild++;
                currChild %= ModelMeshParent.transform.childCount;
                ModelMeshParent.transform.GetChild(currChild).gameObject.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                bool VoxelOn = VoxelObject.gameObject.activeSelf;
                VoxelObject.gameObject.SetActive(!VoxelOn);
                ParticleObject.gameObject.SetActive(VoxelOn);
            }
        }
    }
}
