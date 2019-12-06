using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentMaintenance.DataAccess;
using StudentMaintenance.Business;
using System.Windows.Forms;

namespace StudentMaintenance.GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You want to exit.", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            Application.Exit();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            Student stu = new Student();
            stu.StudentNumber1 = Convert.ToInt32(textBoxSN.Text.Trim());
            stu.FirstName1 = textBoxFN.Text.Trim();
            stu.LastName1 = textBoxLN.Text.Trim();
           
            stu.Email1 = textBoxEM.Text.Trim();
            stu.SaveStudent(stu);
            MessageBox.Show("Student record has been saved successfully.", "Student Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBoxSN.Clear();
            textBoxLN.Clear();
            textBoxFN.Clear();
            textBoxEM.Clear();
        }

        private void ButtonListAll_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            Student stu = new Student();
            List<Student> listStu = stu.GetStudentList();
            if (listStu != null)
            {
                foreach (Student StuItem in listStu)
                {
                    ListViewItem item = new ListViewItem(StuItem.StudentNumber1.ToString());
                    item.SubItems.Add(StuItem.LastName1);
                    item.SubItems.Add(StuItem.FirstName1);
                   
                    item.SubItems.Add(StuItem.Email1);
                    listView1.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("No Student Data in the database.", "No Student Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexSelected = comboBoxOption.SelectedIndex;
            switch (indexSelected)
            {
                case 1:
                    labelMessage.Text = "Please enter Student Number";
                    textBoxInput.Clear();
                    textBoxInput.Focus();
                    break;
                case 2:
                    labelMessage.Text = "Please enter Last Name";
                    textBoxInput.Clear();
                    textBoxInput.Focus();
                    break;
                default:
                    labelMessage.Text = "Please select the search option";
                    break;

            }
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            int selectedIndex = comboBoxOption.SelectedIndex;

            switch (selectedIndex)
            {
                case 1:
                    
                    Student Stu = new Student();
                    Stu = Stu.SearchStudent(Convert.ToInt32(textBoxInput.Text.Trim()));
                    if (Stu != null)
                    {
                        textBoxSN.Text = Stu.StudentNumber1.ToString();
                        textBoxLN.Text = Stu.LastName1;
                        textBoxFN.Text = Stu.FirstName1;
                        textBoxEM.Text = Stu.Email1;
                    }
                    else
                    {
                        textBoxInput.Clear();
                        textBoxInput.Focus();
                        string error = "Record not found !" + "\n" + "Please enter Student Number again.";
                        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;
                
                case 2:
                    
                    Student tempStu = new Student();
                    List<Student> listStu = tempStu.SearchStudent(textBoxInput.Text.Trim());
                    listView1.Items.Clear();
                    if (listStu != null)
                    {
                        foreach (Student anStu in listStu)
                        {
                            ListViewItem item = new ListViewItem(anStu.StudentNumber1.ToString());
                            item.SubItems.Add(anStu.LastName1);
                            item.SubItems.Add(anStu.FirstName1);
                            item.SubItems.Add(anStu.Email1);
                            listView1.Items.Add(item);
                        }

                    }
                    else
                    {

                    }
                    break;
                default:
                    break;
            }
        }
    }
    
}
