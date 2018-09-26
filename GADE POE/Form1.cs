using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace GADE_POE
{
    [Serializable]
    public partial class Form1 : Form
    {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
      
        int Turn = 0;
        Random r = new Random();

        Map map = new Map(20, 20, 20, 10);
        ResourceBuilding br;
        const int spacing = 20;
        const int Size = 20;
        public Form1()
        {
            InitializeComponent();
        }
        //Map mapForm = new Map();
     
        private void Form1_Load(object sender, EventArgs e)
            {
            //Button start = new Button();
            //Button stop = new Button();

            //start.Location = new Point(650, 350);
            //start.Size = new Size(100, 100);
            //start.Text = "start";
            //this.Controls.Add(start);
            //start.Click += new EventHandler(Button_Click);

            //stop.Location = new Point(650, 450);
            //stop.Size = new Size(100, 100);
            //stop.Text = "stop";
            //this.Controls.Add(stop);
            //stop.Click += new EventHandler(Button2_Click);
            //mapForm.CreatingMap(this);
            //    mapForm.SpawnUnits(this);
           


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          
            UpdateMap();
            DisplayMap();
            textBox1.Text = (++Turn).ToString();
        }

        

        public void Button_Click(object sender, EventArgs args)
        {
            //timer1.Start();
        }
        public void Button2_Click(object sender, EventArgs args)
        {
            //timer1.Stop();
        }
        private void DisplayMap()
        {
            //SPAWNING OF UNITS AND CREATING THE PICTURE BOXES AS WELL AS THE CLICK EVENTS
            //ALSO CREATES THE BUILDINGS SEPERATE TO THE UNITS
            groupBox1.Controls.Clear();
            foreach (Unit u in map.Units)
            {
                if (u != null)
                {
                    if (u.GetType() == typeof(MeleeUnits))
                    {

                        int start_x = 20;
                        int start_Y = 20;
                        start_x = groupBox1.Location.X;
                        start_Y = groupBox1.Location.Y;
                        MeleeUnits m = (MeleeUnits)u;
                        PictureBox Pbox = new PictureBox();

                        Pbox.Size = new Size(Size, Size);
                        Pbox.Location = new Point(start_x + (m.Xpos * Size), start_Y + (m.Ypos * Size));
                        Pbox.SizeMode = PictureBoxSizeMode.Zoom;
                        Pbox.ImageLocation = "DirtGround.jpg";

                        if (m.Fact == 1)
                        {

                            Pbox.ImageLocation = "Tank.png";

                        }
                        else
                        {

                            Pbox.ImageLocation = "Tank1.png";
                        }
                        if (m.isDead())
                        {
                            Pbox.ImageLocation = "DirtGround.jpg";
                        }
                        groupBox1.Controls.Add(Pbox);
                        Pbox.Click += new EventHandler(Picture_Click);
                    }
                }
                  

            }
            foreach (Unit u in map.Units)
            {
                if (u != null)
                {
                    if (u.GetType() == typeof(RangedUnits))
                    {
                        int start_x = 20;
                        int start_Y = 20;
                        start_x = groupBox1.Location.X;
                        start_Y = groupBox1.Location.Y;
                        RangedUnits m = (RangedUnits)u;
                        PictureBox Pbox = new PictureBox();

                        Pbox.Size = new Size(Size, Size);
                        Pbox.Location = new Point(start_x + (m.Xpos * Size), start_Y + (m.Ypos * Size));
                        Pbox.SizeMode = PictureBoxSizeMode.Zoom;
                        Pbox.ImageLocation = "DirtGround.jpg";

                        if (m.Fact == 1)
                        {

                            Pbox.ImageLocation = "Ranged.png";

                        }
                        else
                        {

                            Pbox.ImageLocation = "Ranged1.png";
                        }
                        if (m.isDead())
                        {
                            Pbox.ImageLocation = "DirtGround.jpg";
                        }
                        groupBox1.Controls.Add(Pbox);
                        Pbox.Click += new EventHandler(Picture_Click);
                    }
                }
                   

            }
            foreach (Building b in map.Buildings)
            {
                if (b.GetType() == typeof(ResourceBuilding))
                {
                    int start_x = 20;
                    int start_Y = 20;
                    start_x = groupBox1.Location.X;
                    start_Y = groupBox1.Location.Y;
                    ResourceBuilding B1 = (ResourceBuilding)b;
                    PictureBox Pbox = new PictureBox();

                    Pbox.Size = new Size(Size, Size);
                    Pbox.Location = new Point(start_x + (B1.Xpos * Size), start_Y + (B1.Ypos * Size));
                    Pbox.SizeMode = PictureBoxSizeMode.Zoom;
                    Pbox.ImageLocation = "DirtGround.jpg";

                    if (B1.Fact == 1)
                    {

                        Pbox.ImageLocation = "building.png";

                    }
                    else
                    {

                        Pbox.ImageLocation = "building1.png";
                    }
                    if (B1.isDestoryed())
                    {
                        Pbox.ImageLocation = "DirtGround.jpg";
                    }
                    groupBox1.Controls.Add(Pbox);
                    Pbox.Click += new EventHandler(Picture_Click1);
                }

            }
            foreach (Building b in map.Buildings)
            {
                if (b.GetType() == typeof(FactoryBuilding))
                {


                    int start_x = 20;
                    int start_Y = 20;
                    start_x = groupBox1.Location.X;
                    start_Y = groupBox1.Location.Y;
                    FactoryBuilding B1 = (FactoryBuilding)b;
                    PictureBox Pbox = new PictureBox();

                    //if (b == null)
                    //{

                    //}

                    Pbox.Size = new Size(Size, Size);
                    Pbox.Location = new Point(start_x + (B1.Xpos * Size), start_Y + (B1.Ypos * Size));
                    Pbox.SizeMode = PictureBoxSizeMode.Zoom;
                    Pbox.ImageLocation = "DirtGround.jpg";

                    if (B1.Fact == 1)
                    {

                        Pbox.ImageLocation = "building.png";

                    }
                    else
                    {

                        Pbox.ImageLocation = "building1.png";
                    }
                    if (B1.isDestoryed())
                    {
                        Pbox.ImageLocation = "DirtGround.jpg";
                    }
                    groupBox1.Controls.Add(Pbox);
                    Pbox.Click += new EventHandler(Picture_Click);
                }

            }
        }
        private void UpdateMap()
        {
          //MOVEMNET AND COMBAT IS DONE HERE
          //RESOURCE GEN AND DEATH CHECKS ARE ASLO DONE HERE
            foreach (Unit u in map.Units)
            {
                if( u != null)
                {
                    if (u.GetType() == typeof(MeleeUnits))
                    {
                        MeleeUnits m = (MeleeUnits)u;

                        if (m.health < 25)
                        {
                            switch (r.Next(0, 4))
                            {
                                case 0: ((MeleeUnits)u).NewMovePos(Direction.Nort); break;
                                case 1: ((MeleeUnits)u).NewMovePos(Direction.East); break;
                                case 2: ((MeleeUnits)u).NewMovePos(Direction.South); break;
                                case 3: ((MeleeUnits)u).NewMovePos(Direction.West); break;

                            }
                        }
                        else
                        {
                            bool inCombat = false;
                            foreach (Unit e in map.Units)
                            {

                                if (u.AttackRange(e))
                                {
                                    u.Combat(e);
                                    inCombat = true;
                                }
                            }
                            if (!inCombat)
                            {
                                Unit c = u.UnitDistance(map.Units);
                                m.NewMovePos(m.Directionto(c));
                            }

                        }

                    }
                }
               

            }
            foreach (Unit u in map.Units)
            {
                if (u != null)
                {
                    if (u.GetType() == typeof(RangedUnits))
                    {
                        RangedUnits m = (RangedUnits)u;

                        if (m.health < 25)
                        {
                            switch (r.Next(0, 4))
                            {
                                case 0: ((RangedUnits)u).NewMovePos(Direction.Nort); break;
                                case 1: ((RangedUnits)u).NewMovePos(Direction.East); break;
                                case 2: ((RangedUnits)u).NewMovePos(Direction.South); break;
                                case 3: ((RangedUnits)u).NewMovePos(Direction.West); break;

                            }
                        }
                        else
                        {
                            bool inCombat = false;
                            foreach (Unit e in map.Units)
                            {

                                if (u.AttackRange(e))
                                {
                                    u.Combat(e);
                                    inCombat = true;
                                }
                            }
                            if (!inCombat)
                            {
                                Unit c = u.UnitDistance(map.Units);
                                m.NewMovePos(m.Directionto(c));
                            }

                        }

                    }
                }
                   
               
            }
            foreach (Building b in map.Buildings)
            {
                if (b.GetType() == typeof(ResourceBuilding))
                {

                    ((ResourceBuilding)b).isDestoryed();
                    ((ResourceBuilding)b).GenResources();

                }
            }
        }
        public void Picture_Click(object sender, EventArgs args)
        {
            //DISPLAYS THE COORDS OF UNITS
            int x = (((PictureBox)sender).Location.X - groupBox1.Location.X) / Size;
            int Y = (((PictureBox)sender).Location.Y - groupBox1.Location.Y) / Size;
            textBox2.Text = "object Clicked at: " + ((PictureBox)sender).Location ;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }
        public void Picture_Click1(object sender, EventArgs args)
        {
            //DISPLAYS THE COORDS OF Resource building
            int x = (((PictureBox)sender).Location.X - groupBox1.Location.X) / Size;
            int Y = (((PictureBox)sender).Location.Y - groupBox1.Location.Y) / Size;
            foreach (Building b in map.Buildings)
            {
                if (b.GetType() == typeof(ResourceBuilding))
                {
                    textBox2.Text = "object Clicked at: " + ((PictureBox)sender).Location + " Ore: " + ((ResourceBuilding)b).Remaining;
                }
                    
            }
                

        }

        private void button3_Click(object sender, EventArgs e)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fsout = new FileStream("Map.dat", FileMode.Create, FileAccess.Write, FileShare.None);
            try
            {
                using (fsout)
                {
                    bf.Serialize(fsout, map);
                    MessageBox.Show("map Info Saved");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred" + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fsin = new FileStream("Map.dat", FileMode.Open, FileAccess.Read, FileShare.None);
            try
            {
                using (fsin)
                {
                    map = (Map)bf.Deserialize(fsin);
                   
                    MessageBox.Show("map Info Loaded");
                }
            }
            catch
            {
                MessageBox.Show("Error occurred");
            }
            DisplayMap();
        }
    }
}
