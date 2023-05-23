using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void display_Click(object sender, EventArgs e)
		{
			listBox1.Items.Clear();

			Queue<string> passedStudents = new Queue<string>();
			Queue<string> failedStudents = new Queue<string>();

			string fileName = "students.txt";

			using (StreamReader reader = new StreamReader(fileName))
			{
				while (!reader.EndOfStream)
				{
					string line = reader.ReadLine();

					string[] data = line.Split(';');

					string name = data[0] + " " + data[1] + " " + data[2];
					string group = data[3];
					int[] grades = Array.ConvertAll(data[4].Split(','), int.Parse);

					double average = (grades[0] + grades[1] + grades[2]) / 3.0;

					string studentData = "ФИО: " + name + ", Группа: " + group + ", Оценки: " + data[4];

					if (average >= 4.0) passedStudents.Enqueue(studentData);
					else failedStudents.Enqueue(studentData);
				}
			}

			listBox1.Items.AddRange(passedStudents.Concat(failedStudents).ToArray());
		}

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
