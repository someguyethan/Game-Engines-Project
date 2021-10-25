using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public PlaceTile placer;
    public Button ball;
    public Button laser;
    public Button jumpPad;
    public Button door;
    public Button ground;
    public Button destroy;

    private void Update()
    {
        ball.onClick.AddListener(BallButton);
        laser.onClick.AddListener(LaserButton);
        jumpPad.onClick.AddListener(JumpPadButton);
        door.onClick.AddListener(DoorButton);
        ground.onClick.AddListener(TileButton);
        destroy.onClick.AddListener(DestroyButton);
    }
    void BallButton()
    {
        placer.doTile = false;
        placer.SetCurrent(placer.ballPrefab, placer.ballPrefab_preview);
    }
    void LaserButton()
    {
        placer.doTile = false;
        placer.SetCurrent(placer.laserPrefab, placer.laserPrefab_preview);
    }
    void JumpPadButton()
    {
        placer.doTile = false;
        placer.SetCurrent(placer.jumpPadPrefab, placer.jumpPadPrefab_preview);
    }
    void DoorButton()
    {
        placer.doTile = false;
        placer.SetCurrent(placer.doorPrefab, placer.doorPrefab_preview);
    }
    void TileButton()
    {
        placer.doTile = true;
    }
    void DestroyButton()
    {
        placer.doDestroy = !placer.doDestroy;
    }
}
