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

namespace Csharp_Student_System
{
    public partial class AddStudentForm : Form
    {
        public AddStudentForm()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void buttonUploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                pictureBoxStudentImage.Image = Image.FromFile(opf.FileName);
            }
        }

       

        private void buttonAddStudent_Click(object sender, EventArgs e)
        {
            STUDENT student = new STUDENT();
            string fname = textBoxFname.Text;
            string lname = textBoxLname.Text;
            DateTime bdate = dateTimePicker1.Value;
            string phone = textBoxPhone.Text;
            string address = textBoxAddress.Text;
            string gender = "Male";

            if (radioButtonFemale.Checked)
            {
                gender = "Female";
            }

            MemoryStream pic = new MemoryStream();
            int born_year = dateTimePicker1.Value.Year;
            int this_year = DateTime.Now.Year;
            
            if (((this_year - born_year) < 10) || ((this_year - born_year) > 100))
            {
                MessageBox.Show("The Student Age Must Be Between 10 and 100 year", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (verif())
            {
                pictureBoxStudentImage.Image.Save(pic, pictureBoxStudentImage.Image.RawFormat);
                if (student.insertStudent(fname, lname, bdate, gender, phone, address, pic))
                {
                    MessageBox.Show("New Student Added", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Empty Fields", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        bool verif()
        {
            if ((textBoxFname.Text.Trim() == "")
                        || (textBoxLname.Text.Trim() == "")
                        || (textBoxAddress.Text.Trim() == "")
                        || (textBoxPhone.Text.Trim() == "")
                        || (pictureBoxStudentImage.Image == null))
            {
                return false;
            }
            else
            {
                return true;
            }

        } 
        
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
