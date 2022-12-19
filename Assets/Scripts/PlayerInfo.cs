using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo
{
     public int lifes;
     public double x;
     public double y;
     public double z;
     public double rotate_x;
     public double rotate_y;
     public double rotate_z;
     public bool book;
     public bool boots;
     public bool present;
     public bool food;
     
     public PlayerInfo(int lifes, double x, double y, double z, double rotate_x, double rotate_y, double rotate_z,bool book, bool boots, bool present, bool food)
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
         
     }
}
