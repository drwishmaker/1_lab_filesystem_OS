using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba_OS_Filesystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string text;
        int count = 0;
        string[] arrayLine = null;
        string firstLine;
        string outputText = string.Empty;
        string[] arrayCluster = null;
        string[] alphabet = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };

        private void buttonFile_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                input();
                output();
            }

            else
            {
                MessageBox.Show("Unable to read file");
            }
        }

        private void input()
        {
            string fileName = ofd.FileName;

            try
            {
                string filename = ofd.FileName;
                text = File.ReadAllText(filename);
                textBoxDefault.Text = "Introduced filesystem:" + Environment.NewLine + text + Environment.NewLine + "Files:" + Environment.NewLine;

                firstLine = File.ReadLines(fileName).First();
                string[] elemsOfFirstLine = firstLine.Split(' ');

                string secondLine = File.ReadLines(fileName).Skip(1).First();
                arrayCluster = new string[(secondLine.Length + 1) / 2];
                arrayCluster = secondLine.Split(' ');
                string[] arrayClusterCopy = secondLine.Split(' ');

                count = elemsOfFirstLine.Length / 2 + 1;
                arrayLine = new string[count];
                int amt = 0;

                for (int j = 0; j != arrayLine.Length; j++)
                {
                    if (amt < elemsOfFirstLine.Length)
                    {
                        arrayLine[j] = elemsOfFirstLine[amt] + " " + elemsOfFirstLine[amt + 1];
                        int startValue = Convert.ToInt32(elemsOfFirstLine[amt + 1]);
                        string nextValue = arrayCluster[startValue];

                        while (nextValue != "eof" && nextValue != "bad" && nextValue != "emp")
                        {
                            arrayLine[j] += " " + nextValue;
                            startValue = Convert.ToInt32(arrayCluster[startValue]);
                            nextValue = arrayCluster[startValue];
                        }

                        if (nextValue == "eof")
                        {
                            arrayLine[j] += " eof";
                        }

                        if (nextValue == "bad")
                        {
                            arrayLine[j] += " bad";
                        }

                        amt += 2;
                        textBoxDefault.Text += arrayLine[j] + Environment.NewLine;
                    }
                }

                for (int j = 0; j != elemsOfFirstLine.Length; j += 2)
                {
                    int firstValue = Convert.ToInt32(elemsOfFirstLine[j + 1]);
                    string nextValue = arrayClusterCopy[firstValue];

                    while (nextValue != "eof" && nextValue != "bad" && nextValue != "emp")
                    {
                        int indexOfCopyArray = firstValue;
                        firstValue = Convert.ToInt32(nextValue);
                        nextValue = arrayClusterCopy[firstValue];
                        arrayClusterCopy[indexOfCopyArray] = "emp";
                    }

                    if (nextValue == "eof")
                    {
                        arrayClusterCopy[firstValue] = "emp";
                    }

                    if (nextValue == "bad")
                    {
                        arrayClusterCopy[firstValue] = "emp";
                    }
                }

                string otherLine = string.Empty;

                for (int j = 0; j != arrayClusterCopy.Length; j++)
                {
                    if (arrayClusterCopy[j] != "emp")
                    {
                        if (otherLine == string.Empty)
                        {
                            otherLine = Convert.ToString(j);
                            int firstValue = j;
                            string nextValue = arrayClusterCopy[firstValue];

                            while (nextValue != "eof" && nextValue != "bad" && nextValue != "0")
                            {
                                int tempValue = firstValue;
                                otherLine += " " + nextValue;
                                firstValue = Convert.ToInt32(arrayClusterCopy[firstValue]);
                                nextValue = arrayClusterCopy[firstValue];
                                arrayClusterCopy[tempValue] = "emp";
                            }

                            if (nextValue == "eof")
                            {
                                otherLine += " eof";
                                arrayClusterCopy[firstValue] = "emp";
                            }

                            if (nextValue == "bad")
                            {
                                otherLine += " bad";
                                arrayClusterCopy[firstValue] = "emp";
                            }
                        }

                        else
                        {
                            int indexOfSubstring = otherLine.IndexOf(arrayClusterCopy[j]);
                            otherLine = otherLine.Insert(indexOfSubstring, arrayClusterCopy[j] + " ");
                        }
                    }
                }

                arrayLine[arrayLine.Length - 1] = otherLine;
                textBoxDefault.Text += arrayLine[arrayLine.Length - 1] + Environment.NewLine;
            }

            catch
            {
                MessageBox.Show("Bad data from file");
            }
        }   
        private void output() 
        {
            int[] emptyClusters = new int[32];

            for (int j = 0; j != emptyClusters.Length; j++)
            {
                emptyClusters[j] = 0;
            }

            bool firstSign = false;
            bool overlay = false;

            for (int z = 0; z != arrayLine.Length; z++)
            {
                if (arrayLine[z] != null && arrayLine[z] != "")
                {
                    string line = arrayLine[z];
                    string[] elemOfFiles = line.Split(' ');
                    textBoxProceeded.Text += line;
                    bool Yes = false;

                    for (int j = 0; j != elemOfFiles.Length; j++)
                    {
                        if (Yes == false)
                        {
                            if (elemOfFiles[0] == alphabet[z])
                            {
                                outputText += elemOfFiles[0];
                            }

                            else
                            {
                                outputText += alphabet[z];
                                firstLine += " " + alphabet[z] + " " + elemOfFiles[0];
                                textBoxProceeded.Text += Environment.NewLine + "File was lost in your filesystem. It was added under name '" + alphabet[z] + "'" + Environment.NewLine;
                                firstSign = true;
                            }

                            Yes = true;
                        }

                        if (elemOfFiles[j] != alphabet[z] && elemOfFiles[j] != "eof" && elemOfFiles[j] != "bad")
                        {
                            int k = Convert.ToInt32(elemOfFiles[j]);

                            if (emptyClusters[k] == 0)
                            {
                                emptyClusters[k] = k;
                                outputText += " " + elemOfFiles[j];
                            }

                            else
                            {
                                overlay = true;
                                textBoxProceeded.Text += Environment.NewLine + "Crossing of adresses " + elemOfFiles[j] + ". Duplicate elements will be rewritten to empty cells" + Environment.NewLine;
                                bool record = false;

                                for (int a = 0; a != emptyClusters.Length; a++)
                                {
                                    if (record == false)
                                    {
                                        if (emptyClusters[a] == 0)
                                        {
                                            record = true;
                                            emptyClusters[a] = k;
                                            outputText += " " + a;
                                            arrayCluster[Convert.ToInt32(elemOfFiles[j - 1])] = Convert.ToString(a);
                                            arrayCluster[a] = "eof";
                                            elemOfFiles[j] = Convert.ToString(a);
                                        }
                                    }
                                }

                                record = false;
                            }
                        }

                        else
                        {
                            if (elemOfFiles[j] == "eof")
                            {
                                if (firstSign == false && overlay == false)
                                {
                                    textBoxProceeded.Text += Environment.NewLine + "No errors found" + Environment.NewLine;
                                }
                                outputText += " " + "eof" + Environment.NewLine;
                            }

                            if (elemOfFiles[j] == "bad")
                            {
                                textBoxProceeded.Text += Environment.NewLine + "Found a bad block. This error will be corrected by deleting this file" + Environment.NewLine;
                                outputText += " " + "eof" + Environment.NewLine;
                                arrayCluster[Convert.ToInt32(elemOfFiles[j - 1])] = "eof";
                            }
                        }
                        if (j == elemOfFiles.Length - 1)
                        {
                            if (elemOfFiles[j] != "eof" && elemOfFiles[j] != "bad")
                            {
                                textBoxProceeded.Text += Environment.NewLine + "The end of the file was missed. This error will be corrected by writing 'Eof' to the last cell." + Environment.NewLine;
                                outputText += " " + "eof" + Environment.NewLine;
                                arrayCluster[Convert.ToInt32(elemOfFiles[j])] = "eof";
                            }
                        }
                    }
                }
            }

            textBoxProceeded.Text += Environment.NewLine + "Fixed filesystem:" + Environment.NewLine + outputText + Environment.NewLine;
        }
    }
}