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
    public partial class Form2 : Form
    {
        public static List<List<List<String>>> listAll = new List<List<List<String>>>();
        public static List<List<List<String>>> filterListAll = new List<List<List<String>>>();

        public static List<List<TextBox>> allTextBoxes = new List<List<TextBox>>();
        public static List<List<ComboBox>> allComboBoxes = new List<List<ComboBox>>();

        //arrayCPU - type counter = 0
        //arrayMotherboard - type counter = 1
        //arrayRAM - type counter = 2
        //arraySSD - type counter = 3
        //arrayHDD - type counter = 4
        //arrayGPU - type counter = 5
        //arrayPSU - type counter = 6
        //arrayCase - type counter = 7

        public static List<List<String>> tempStorage = new List<List<String>>();

        //public static String[][] tempStorage = {{"", "", "", "", "" }, {"", ""}};

        public static bool safety = true;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //CREATE ARRAY
            int numberOfPCs = Directory.GetDirectories(Form1.path).Length;
            String[] pathsPC = Directory.GetDirectories(Form1.path);


            //CLEAR ALL
            listAll.Clear();
            tempStorage.Clear();
            filterListAll.Clear();

            allTextBoxes.Clear();
            allComboBoxes.Clear();

            //CREATE FILTER AND TEMP STORAGE LIST
            for (int i = 0; i < 8; i++) {
                listAll.Add(new List<List<String>>());
                tempStorage.Add(new List<String>());
                filterListAll.Add(new List<List<String>>());

                allTextBoxes.Add(new List<TextBox>());
                allComboBoxes.Add(new List<ComboBox>());
            }

            //CREATE TEMP STORAGE
            for (int i = 0; i < 8; i++)
            {
                tempStorage[1].Add("");
                tempStorage[7].Add("");
            }
            for (int i = 0; i < 7; i++)
            {
                tempStorage[2].Add("");
            }
            for (int i = 0; i < 5; i++)
            {
                tempStorage[0].Add("");
                tempStorage[6].Add("");
            }
            for (int i = 0; i < 4; i++)
            {
                tempStorage[3].Add("");
            }
            for (int i = 0; i < 3; i++)
            {
                tempStorage[4].Add("");
                tempStorage[5].Add("");
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

            int[] divisionArray = {5, 8, 7, 4, 3, 3, 5, 8};

            for (int i = 0; i < listAll.Count; i++) {
                for (int b = 0; b < pathsPC.Length; b++)
                {
                    String[] allText = readFile(pathsPC[b] + @"\" + i.ToString()).TrimEnd('\r', '\n').Split('\n');

                    for (int c = 0; c < divisionArray[i]; c++)
                    {
                        listAll[i][c].Add(allText[c]);
                    }
                }
            }

            String[,] filtersCPU = {};
            refreshCPU(filtersCPU, 0);
        }

        public String tempSort(String text){
            String[] textArray = text.Split('\n');
            String finalText = "";
            
            String temp = "";
            for (int i = 0; i < textArray.Length; i++) {
                String[] tempFinalArray = finalText.Split('\n');
                temp = textArray[i];
                for (int b = 0; b < tempFinalArray.Length; b++) {
                    if (temp.Equals(tempFinalArray[b])) {
                        temp = "";
                        b = tempFinalArray.Length;
                        break;
                    }
                }
                finalText += (temp.Length == 0 ? "" : temp + "\n");
            }

            return finalText;
        }

        public String[] getAll(int x, String type) {
            String text = "";

            for (int i = 0; i < listAll[Int32.Parse(type)][x].Count; i++) {
                text += listAll[Int32.Parse(type)][x][i] + "\n";
            }
            text = tempSort(text);

            return text.TrimEnd('\r', '\n').Split('\n');
        }

        public void addAllBoxes() {
            TextBox[][] arrayGlobal = new TextBox[8][];
            arrayGlobal[0] = new TextBox[] {textBox1CPU, textBox2CPU, textBox3CPU, textBox4CPU, textBox5CPU, textBox6CPU };
            arrayGlobal[1] = new TextBox[] { textBox1MOBO, textBox2MOBO, textBox3MOBO, textBox4MOBO, textBox5MOBO, textBox6MOBO, textBox7MOBO, textBox8MOBO, textBox9MOBO };
            arrayGlobal[2] = new TextBox[] { textBox1RAM, textBox2RAM, textBox3RAM, textBox4RAM, textBox5RAM, textBox6RAM, textBox7RAM, textBox8RAM };
            arrayGlobal[3] = new TextBox[] { textBox1GPU, textBox2GPU, textBox3GPU, textBox4GPU, textBox5GPU};
            arrayGlobal[4] = new TextBox[] { textBox1SSD, textBox2SSD, textBox3SSD, textBox4SSD};
            arrayGlobal[5] = new TextBox[] { textBox1HDD, textBox2HDD, textBox3HDD, textBox4HDD};
            arrayGlobal[6] = new TextBox[] { textBox1PSU, textBox2PSU, textBox3PSU, textBox4PSU, textBox5PSU, textBox6PSU};
            arrayGlobal[7] = new TextBox[] { textBox1CASE, textBox2CASE, textBox3CASE, textBox4CASE, textBox5CASE, textBox6CASE, textBox7CASE, textBox8CASE, textBox9CASE };

            ComboBox[][] arrayGlobalCombo = new ComboBox[8][];
            arrayGlobalCombo[0] = new ComboBox[] { comboBox1CPU, comboBox2CPU, comboBox3CPU, comboBox4CPU, comboBox5CPU };
            arrayGlobalCombo[1] = new ComboBox[] { comboBox1MOBO, comboBox2MOBO, comboBox3MOBO, comboBox4MOBO, comboBox5MOBO, comboBox6MOBO, comboBox7MOBO, comboBox8MOBO };
            arrayGlobalCombo[2] = new ComboBox[] { comboBox1RAM, comboBox2RAM, comboBox3RAM, comboBox4RAM, comboBox5RAM, comboBox6RAM, comboBox7RAM};
            arrayGlobalCombo[3] = new ComboBox[] { comboBox1GPU, comboBox2GPU, comboBox3GPU, comboBox4GPU};
            arrayGlobalCombo[4] = new ComboBox[] { comboBox1SSD, comboBox2SSD, comboBox3SSD};
            arrayGlobalCombo[5] = new ComboBox[] { comboBox1HDD, comboBox2HDD, comboBox3HDD};
            arrayGlobalCombo[6] = new ComboBox[] { comboBox1PSU, comboBox2PSU, comboBox3PSU, comboBox4PSU, comboBox5PSU};
            arrayGlobalCombo[7] = new ComboBox[] { comboBox1CASE, comboBox2CASE, comboBox3CASE, comboBox4CASE, comboBox5CASE, comboBox6CASE, comboBox7CASE, comboBox8CASE };

            for (int i = 0; i < arrayGlobal.Length; i++) {
                allTextBoxes[i].Clear();
                for (int b = 0; b < arrayGlobal[i].Length; b++) {
                    allTextBoxes[i].Add(arrayGlobal[i][b]);
                }
            }

            for (int i = 0; i < arrayGlobalCombo.Length; i++)
            {
                allComboBoxes[i].Clear();
                for (int b = 0; b < arrayGlobalCombo[i].Length; b++)
                {
                    allComboBoxes[i].Add(arrayGlobalCombo[i][b]);
                }
            }
        }

        public void refreshCPU(String[,] array, int type){
            //SET ALL CONTROLS
            addAllBoxes();
            
            //SET LIST
            List<List<List<String>>> ALL_NAMES = new List<List<List<String>>>();
            List<List<int>> ALL_NUMBERS = new List<List<int>>();

            //CLEAR LIST
            ALL_NAMES.Clear();
            ALL_NUMBERS.Clear();

            int[] divisionArray = { 5, 8, 7, 4, 3, 3, 5, 8 };

            for (int i = 0; i < 8; i++) {
                ALL_NAMES.Add(new List<List<String>>());
                ALL_NUMBERS.Add(new List<int>());
            }

            for (int i = 0; i < 8; i++)
            {
                ALL_NAMES[1].Add(new List<String>());
                ALL_NAMES[7].Add(new List<String>());

                ALL_NUMBERS[1].Add(i);
                ALL_NUMBERS[7].Add(i);
            }
            for (int i = 0; i < 7; i++)
            {
                ALL_NAMES[2].Add(new List<String>());

                ALL_NUMBERS[2].Add(i);
            }
            for (int i = 0; i < 5; i++)
            {
                ALL_NAMES[0].Add(new List<String>());
                ALL_NAMES[6].Add(new List<String>());

                ALL_NUMBERS[0].Add(i);
                ALL_NUMBERS[6].Add(i);
            }
            for (int i = 0; i < 4; i++)
            {
                ALL_NAMES[3].Add(new List<String>());

                ALL_NUMBERS[3].Add(i);
            }
            for (int i = 0; i < 3; i++)
            {
                ALL_NAMES[4].Add(new List<String>());
                ALL_NAMES[5].Add(new List<String>());

                ALL_NUMBERS[4].Add(i);
                ALL_NUMBERS[5].Add(i);
            }

            for (int i = 0; i < ALL_NAMES[type].Count; i++) {
                String[] tempArray = getAll(i, type.ToString());
                for (int b = 0; b < tempArray.Length; b++) {
                    ALL_NAMES[type][i].Add(tempArray[b]); //EX. BRAND NUMBER
                }
            }


            for (int i = 0; i < array.GetLength(0); i++) {
                //MORE INFORMATION
                String arrayFilterName = array[i, 0];
                int arrayCounter = Int32.Parse(array[i, 1]);

                for (int b = 0; b < listAll[type].Count; b++) {
                    if (b != arrayCounter) {
                        String text = "";

                        for (int c = 0; c < listAll[type][b].Count; c++) {
                            int pos = ALL_NAMES[type][b].FindIndex(x => x == listAll[type][b][c]);

                            if (pos > -1)
                            {
                                int pos1 = Array.IndexOf(text.TrimEnd('\r', '\n').Split('\n'), listAll[type][b][c]);
                                if (pos1 <= -1)
                                {
                                    if (listAll[type][arrayCounter][c].Equals(arrayFilterName))
                                    {
                                        text += listAll[type][b][c] + "\n";
                                    }
                                }
                            }
                        }

                        String[] textArray = text.TrimEnd('\r', '\n').Split('\n');
                        ALL_NAMES[type][b].Clear();
                        for (int c = 0; c < textArray.Length; c++){
                            ALL_NAMES[type][b].Add(textArray[c]);
                        }
                    }
                }
            }


            //FIND VALUE
            int posText = 0;

            //DISABLE SAFETY
            safety = false;

            for (int i = 0; i < ALL_NAMES[type].Count; i++) {
                //SORT
                ALL_NAMES[type][i].Sort();

                allComboBoxes[type][i].Items.Clear();
                for (int b = 0; b < ALL_NAMES[type][i].Count; b++)
                {
                    allComboBoxes[type][i].Items.Add(ALL_NAMES[type][i][b]);
                }
                allComboBoxes[type][i].Items.Add("");
                posText = ALL_NAMES[type][i].FindIndex(x => x == tempStorage[type][i]);
                if (posText > -1)
                {
                    allComboBoxes[type][i].SelectedIndex = allComboBoxes[type][i].FindStringExact(tempStorage[type][i]);
                }
            }

            //ENABLE SAFETY
            safety = true;
        }        

        private void button2_Click(object sender, EventArgs e)
        {
            String directoryPath = createBase();

            //CREATE CPU FILE
            String cpuText = textBox1CPU.Text + "\n" + textBox2CPU.Text + "\n" + textBox3CPU.Text + "\n" + textBox4CPU.Text + "\n" + textBox5CPU.Text + "\n" + textBox6CPU.Text;
            writeFile(directoryPath + @"\0", cpuText);

            //CREATE MOTHERBOARD FILE
            String moboText = textBox1MOBO.Text + "\n" + textBox2MOBO.Text + "\n" + textBox3MOBO.Text + "\n" + textBox4MOBO.Text + "\n" + textBox5MOBO.Text + "\n" + textBox6MOBO.Text + "\n" + textBox7MOBO.Text + "\n" + textBox8MOBO.Text + "\n" + textBox9MOBO.Text;
            writeFile(directoryPath + @"\1", moboText);

            //CREATE RAM FILE
            String ramText = textBox1RAM.Text + "\n" + textBox2RAM.Text + "\n" + textBox3RAM.Text + "\n" + textBox4RAM.Text + "\n" + textBox5RAM.Text + "\n" + textBox6RAM.Text + "\n" + textBox7RAM.Text + "\n" + textBox8RAM.Text;
            writeFile(directoryPath + @"\2", ramText);

            //CREATE GPU FILE
            String gpuText = textBox1GPU.Text + "\n" + textBox2GPU.Text + "\n" + textBox3GPU.Text + "\n" + textBox4GPU.Text + "\n" + textBox5GPU.Text;
            writeFile(directoryPath + @"\3", gpuText);

            //CREATE SSD FILE
            String ssdText = textBox1SSD.Text + "\n" + textBox2SSD.Text + "\n" + textBox3SSD.Text + "\n" + textBox4SSD.Text;
            writeFile(directoryPath + @"\4", ssdText);

            //CREATE HDD FILE
            String hddText = textBox1HDD.Text + "\n" + textBox2HDD.Text + "\n" + textBox3HDD.Text + "\n" + textBox4HDD.Text;
            writeFile(directoryPath + @"\5", hddText);

            //CREATE PSU FILE
            String psuText = textBox1PSU.Text + "\n" + textBox2PSU.Text + "\n" + textBox3PSU.Text + "\n" + textBox4PSU.Text + "\n" + textBox5PSU.Text + "\n" + textBox6PSU.Text;
            writeFile(directoryPath + @"\6", psuText);

            //CREATE CASE FILE
            String caseText = textBox1CASE.Text + "\n" + textBox2CASE.Text + "\n" + textBox3CASE.Text + "\n" + textBox4CASE.Text + "\n" + textBox5CASE.Text + "\n" + textBox6CASE.Text + "\n" + textBox7CASE.Text + "\n" + textBox8CASE.Text + "\n" + textBox9CASE.Text;
            writeFile(directoryPath + @"\7", caseText);

            Close();
        }

        public String createBase() {
            String[] directory = getDirectories(Form1.path);

            for (int i = 0; i < directory.Length; i++)
            {
                directory[i] = Path.GetFileName(directory[i]).Replace("Nr. ", "");
            }

            int[] array = new int[directory.Length];
            for (int i = 0; i < directory.Length; i++)
            {
                array[i] = Int32.Parse(directory[i]);
            }

            String name = "Nr. " + ((array.Length > 0 ? array.Max() : 0) + 1).ToString();

            Directory.CreateDirectory(Form1.path + @"\" + name);

            return Form1.path + @"\" + name;
        }

        public void writeFile(String path, String text) {
            using (StreamWriter writetext = new StreamWriter(path))
            {
                writetext.WriteLine(text);
            }
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

        public String[] getDirectories(String path) {
            String[] array = Directory.GetDirectories(path);

            return array;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private String[] checkIfExists(String counter, int type) {
            String answer = "false";
            String count = "";

            for (int i = 0; i < filterListAll[type].Count; i++) {
                if(filterListAll[type][i][1].Equals(counter)){
                    answer = "true";
                    count = i.ToString();
                    i = filterListAll[type].Count;
                    break;
                }

                String test = filterListAll[type][0][1];
            }


            String[] countArray = {answer, count};
            return countArray;
        }

        private String[,] addList(String name, String counter, int type) {
            //CHECK IF ALREADY EXISTS
            String[] arrayIf = checkIfExists(counter, type);
            if (arrayIf[0].Equals("true"))
            {
                filterListAll[type][Int32.Parse(arrayIf[1])][0] = name;
                filterListAll[type][Int32.Parse(arrayIf[1])][1] = counter;
            }
            else {
                filterListAll[type].Add(new List<String> { name, counter });
            }

            //CONVERT TO ARRAY
            String[,] array = new String[filterListAll[type].Count, 2];
            for (int i = 0; i < filterListAll[type].Count; i++) {
                array[i, 0] = filterListAll[type][i][0];
                array[i, 1] = filterListAll[type][i][1];
            }

            return array;
        }

        private String[,] removeList(String counter, int type) {
            int loopCounter = filterListAll[type].Count;
            for (int i = 0; i < loopCounter; i++) {
                if (filterListAll[type][i][1].Equals(counter)) {
                    filterListAll[type].RemoveAt(i);
                    i = loopCounter;
                    break;
                }
            }

            String[,] array = new String[filterListAll[type].Count, 2];
            for (int i = 0; i < filterListAll[type].Count; i++)
            {
                array[i, 0] = filterListAll[type][i][0];
                array[i, 1] = filterListAll[type][i][1];
            }

            return array;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIndexChanged(comboBox1CPU, textBox1CPU, "0", 0);
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            selectedIndexChanged(comboBox2CPU, textBox2CPU, "1", 0);
        }

        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            selectedIndexChanged(comboBox3CPU, textBox3CPU, "2", 0);
        }

        private void comboBox4_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            selectedIndexChanged(comboBox4CPU, textBox4CPU, "3", 0);
        }

        private void comboBox5_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            selectedIndexChanged(comboBox5CPU, textBox5CPU, "4", 0);
        }

        private void selectedIndexChanged(ComboBox comboBox, TextBox textBox, String counter, int type)
        {
            if (safety)
            {
                String textCombo = comboBox.GetItemText(comboBox.SelectedItem);

                textBox.Text = (string.IsNullOrEmpty(textCombo.Trim()) ? textBox.Text : textCombo);
                tempStorage[type][Int32.Parse(counter)] = textCombo;

                String[,] filtersCPU;
                if (string.IsNullOrEmpty(textCombo.Trim()))
                {
                    filtersCPU = removeList(counter, type);
                }
                else
                {
                    filtersCPU = addList(textCombo, counter, type);
                }

                refreshCPU(filtersCPU, type);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int currrentTab = tabControl1.SelectedIndex;
            for (int i = 0; i < allComboBoxes[currrentTab].Count; i++) {
                allComboBoxes[currrentTab][i].SelectedIndex = allComboBoxes[currrentTab][i].FindStringExact("");
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String[,] filtersCPU = { };
            refreshCPU(filtersCPU, tabControl1.SelectedIndex);
        }
    }
}
