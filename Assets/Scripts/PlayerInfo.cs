using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo
{
     public int lifes;
     public float x;
     public float y;
     public float z;
     public float rotate_x;
     public float rotate_y;
     public float rotate_z;
     public bool book;
     public bool boots;
     public bool present;
     public bool food;
     public bool met_gopnik;
     public bool met_babka;

    public PlayerInfo(int lifes, float x, float y, float z, float rotate_x, float rotate_y, float rotate_z,bool book, bool boots, bool present, bool food, bool met_babka, bool met_gopnik)
     {
         this.lifes=lifes;
         this.x=x;
         this.y=y;
         this.z=z;
         this.rotate_x=rotate_x;
         this.rotate_y=rotate_y;
         this.rotate_z=rotate_z;
         this.book=book;
         this.boots=boots;
         this.food=food;
         this.present=present;
         this.met_babka = met_babka;
         this.met_gopnik = met_gopnik;
    }
}
