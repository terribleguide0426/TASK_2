﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace GADE_POE
{
    [Serializable]
    class FactoryBuilding : Building
    {
      
        private int units;

        public int Units
        {
            get { return units; }
            set { units = value; }
        }
        private int rateProduction;

        public int RateProduction
        {
            get { return rateProduction; }
            set { rateProduction = value; }
        }
        private Direction spawnpt;

        public Direction SpawnPt
        {
            get { return spawnpt; }
            set { spawnpt = value; }
        }



        public int Xpos
        {
            get { return X_position; }
            set { X_position = value; }
        }
        public int Ypos
        {
            get { return Y_position; }
            set { Y_position = value; }
        }
        public int health
        {
            get { return Health; }
            set { Health = value; }
        }

        public int Fact
        {
            get { return Faction; }
            set { Faction = value; }
        }
        public string Pic
        {
            get { return Image; }
            set { Image = value; }
        }

        public FactoryBuilding(int X_position, int Y_position, int Health, int Faction, string image,int units, int rateProduction, Direction spawnpt)
        {
            //VALUES ALLOCATED
            Xpos = X_position;
            Ypos = Y_position;
            health = Health;
            Fact = Faction;
            Pic = Image;
            RateProduction = rateProduction;
            Units = units;
            SpawnPt = spawnpt;
        }
        public override bool isDestoryed()
        {
            //CHECKS HEALTH
            if (Health < 1)
            {
                return true;
            }
            else

                return false;
        }
        public override string ToString()
        {
            return "m";
        }
        public Unit SpawnUnits(int maxX,int maxY)
        {
            //SPAWNING OF UNITS
            Random r = new Random();
            MeleeUnits m = new MeleeUnits("Tank", r.Next(0, maxX), r.Next(0, maxY), r.Next(5, 10) * 10, r.Next(5, 20), 1, 1, i % 2, "DirtGround.jpg");
            m.Xpos = X_position;
            Ypos = Y_position;
            health = Health;
            Fact = Faction;
            Pic = Image;
            RateProduction = rateProduction;
            Units = units;
            SpawnPt = spawnpt;
            return m;

        }
        public override void Save()
        {

        }
    }
}
