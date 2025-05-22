using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace PC_Catalog
{
    public partial class Form1 : Form
    {
        public static String path = @"C:\Users\Michael\AppData\Roaming\PC Catalog\PCs";

        public static List<List<List<String>>> listAll = new List<List<List<String>>>();
        public static List<List<List<String>>> filterListAll = new List<List<List<String>>>();

        public static List<List<List<String>>> ALL_NAMES = new List<List<List<String>>>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //CREATE DIRECTORY
            createDirectory(path);

            //LOAD FILTER
            loadFilter();
        }

        public String tempSort(String text)
        {
            String[] textArray = text.Split('\n');
            String finalText = "";

            String temp = "";
            for (int i = 0; i < textArray.Length; i++)
            {
                String[] tempFinalArray = finalText.Split('\n');
                temp = textArray[i];
                for (int b = 0; b < tempFinalArray.Length; b++)
                {
                    if (temp.Equals(tempFinalArray[b]))
                    {
                        temp = "";
                        b = tempFinalArray.Length;
                        break;
                    }
                }
                finalText += (temp.Length == 0 ? "" : temp + "\n");
            }

            return finalText;
        }

        public String[] getAll(int x, String type)
        {
            String text = "";

            for (int i = 0; i < listAll[Int32.Parse(type)][x].Count; i++)
            {
                text += listAll[Int32.Parse(type)][x][i] + "\n";
            }
            text = tempSort(text);

            return text.TrimEnd('\r', '\n').Split('\n');
        }

        public void loadFilter() {
            //CREATE ARRAY
            int numberOfPCs = Directory.GetDirectories(path).Length;
            String[] pathsPC = Directory.GetDirectories(path);

            for (int i = 0; i < 8; i++)
            {
                listAll.Add(new List<List<String>>());
            }

            //CREATE FILTER ALL STORAGE
            for (int i = 0; i < 8; i++)
            {
                listAll[1].Add(new List<String>());
                listAll[7].Add(new List<String>());
            }
            for (int i = 0; i < 7; i++)
            {
                listAll[2].Add(new List<String>());
            }
            for (int i = 0; i < 5; i++)
            {
                listAll[0].Add(new List<String>());
                listAll[6].Add(new List<String>());
            }
            for (int i = 0; i < 4; i++)
            {
                listAll[3].Add(new List<String>());
            }
            for (int i = 0; i < 3; i++)
            {
                listAll[4].Add(new List<String>());
                listAll[5].Add(new List<String>());
            }

            int[] divisionArray = { 5, 8, 7, 4, 3, 3, 5, 8 };

            for (int i = 0; i < listAll.Count; i++)
            {
                for (int b = 0; b < pathsPC.Length; b++)
                {
                    String[] allText = readFile(pathsPC[b] + @"\" + i.ToString()).TrimEnd('\r', '\n').Split('\n');

                    for (int c = 0; c < divisionArray[i]; c++)
                    {
                        listAll[i][c].Add(allText[c]);
                    }
                }
            }

            //SET NAMES
            setNames();
        }

        public void setNames() {
            for (int i = 0; i < 8; i++)
            {
                ALL_NAMES.Add(new List<List<String>>());
            }

            for (int i = 0; i < 8; i++)
            {
                ALL_NAMES[1].Add(new List<String>());
                ALL_NAMES[7].Add(new List<String>());
            }
            for (int i = 0; i < 7; i++)
            {
                ALL_NAMES[2].Add(new List<String>());
            }
            for (int i = 0; i < 5; i++)
            {
                ALL_NAMES[0].Add(new List<String>());
                ALL_NAMES[6].Add(new List<String>());
            }
            for (int i = 0; i < 4; i++)
            {
                ALL_NAMES[3].Add(new List<String>());
            }
            for (int i = 0; i < 3; i++)
            {
                ALL_NAMES[4].Add(new List<String>());
                ALL_NAMES[5].Add(new List<String>());
            }

            for (int i = 0; i < ALL_NAMES.Count; i++)
            {
                for (int b = 0; b < ALL_NAMES[i].Count; b++)
                {
                    String[] tempArray = getAll(b, i.ToString());
                    for (int c = 0; c < tempArray.Length; c++)
                    {
                        ALL_NAMES[i][b].Add(tempArray[c]);
                    }
                    ALL_NAMES[i][b].Sort();
                }
            }

            //DISPLAY FILTER
            displayFilter();
        }

        public void displayFilter() {
            //Debug.WriteLine(filterGlobal.Nodes.Count);
            for (int i = 0; i < filterGlobal.Nodes.Count; i++) {
                String[] array = convert(i);
                int baseInt = Int32.Parse(array[0]);
                int secondInt = Int32.Parse(array[1]);

                for (int b = 0; b < ALL_NAMES[baseInt][secondInt].Count; b++) {
                    filterGlobal.Nodes[i].Nodes.Add(ALL_NAMES[baseInt][secondInt][b]);
                }
            }
        }

        public String[] convert(int nodeNumber) {
            String[] array = new String[2];

            String[,] instructions = { {"0", "2"}, {"0", "4"}, { "1", "7" }, { "2", "4" }, { "2", "2" }, { "2", "3" }, { "4", "2" }, { "5", "2" }
            , {"3", "1"} , {"6", "2"} , {"1", "4"} , {"1", "5"} , {"1", "2"} , {"1", "3"} , {"0", "0"} };

            for (int i = 0; i < instructions.GetLength(0); i++) {
                if (nodeNumber == i) {
                    array[0] = instructions[i, 0];
                    array[1] = instructions[i, 1];
                }
            }

            return array;
        }

        public String readFile(String path)
        {
            String text = "";
            using (StreamReader sr = File.OpenText(path))
            {
                string s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    text += s + "\n";
                }
            }

            return text;
        }

        public static void createDirectory(String path) {
            Directory.CreateDirectory(path);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }
    }
}
