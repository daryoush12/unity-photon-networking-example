using Photon.Pun;
using UnityEngine;

public class CameraManager : MonoBehaviourPun
{
    [SerializeField] private GameObject _camera = null;
    [SerializeField] private GameObject _CinemachineBrain = null;

    // Update is called once per frame
    private void Update()
    {
        if (!photonView.IsMine)
        {
            if (_camera != null && _CinemachineBrain != null)
            {
                _camera.SetActive(false);
                _CinemachineBrain.SetActive(false);
            }
        }
    }
}