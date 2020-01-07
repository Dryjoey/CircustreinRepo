using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System
    .Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Circustrein
{
    public partial class Form1 : Form
    {

        List<Animal> Animals = new List<Animal>();
        Train mainTrain = new Train();
     
        public Form1()
        {
            InitializeComponent();
            comboBox2.DataSource = Enum.GetValues(typeof(AnimalSize));
            comboBox1.DataSource = Enum.GetValues(typeof(Diet));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox1.Text;  
                Enum.TryParse(comboBox2.SelectedValue.ToString(), out AnimalSize size);  
                Enum.TryParse(comboBox1.SelectedValue.ToString(), out Diet eatingKind);  

                Animal newAnimal = new Animal(name, eatingKind, size);
                Animals.Add(newAnimal);  

                ListViewItem lvi = new ListViewItem();
                lvi.Text = name;
                lvi.SubItems.Add(newAnimal.AnimalSize.ToString());
                lvi.SubItems.Add(newAnimal.Diet.ToString());
                lvi.Tag = newAnimal;

                listView1.Items.Add(lvi);

                
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            listBox1.Items.Clear();
        }
        private void button1_Click(object sender, EventArgs e)
        {
             
            foreach (var animal in Animals)
            {
                mainTrain.AddAnimal(animal);
            }

            foreach (Wagon wagon in mainTrain.Wagons)  
            {

                listBox1.Items.Add($"{wagon.Animals.Count()} dieren in wagon Id: {wagon.Id}");
                foreach (Animal animal in wagon.Animals)
                {
                    listBox2.Items.Add($"{animal.Name} | {animal.AnimalSize} | {animal.Diet} - wagon Id: {wagon.Id}");
                }
            }
            
            listView1.Clear();
        }

       

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

