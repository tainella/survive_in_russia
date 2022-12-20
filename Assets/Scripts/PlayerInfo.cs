using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo
{
    public int lifes;
    public float x;
    public float y;
    public float z;
    public float rotateX;
    public float rotateY;
    public float rotateZ;
    public bool book;
    public bool boots;
    public bool present;
    public bool food;
    public bool metGopnik;
    public bool metGranny;

    public PlayerInfo(int lifes, float x, float y, float z, float rotateX, float rotateY, float rotateZ, bool book, bool boots, bool present, bool food, bool metGranny, bool metGopnik)
    {
        this.lifes = lifes;
        this.x = x;
        this.y = y;
        this.z = z;
        this.rotateX = rotateX;
        this.rotateY = rotateY;
        this.rotateZ = rotateZ;
        this.book = book;
        this.boots = boots;
        this.food = food;
        this.present = present;
        this.metGranny = metGranny;
        this.metGopnik = metGopnik;
    }
}
