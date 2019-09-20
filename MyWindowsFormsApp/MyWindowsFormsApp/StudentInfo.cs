using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyWindowsFormsApp
{
    public partial class StudentInfo : Form

    {
        List<string> ids = new List<string>();
        List<string> names = new List<string>();
        List<string> mobiles = new List<string>();
        List<int> ages = new List<int>();
        List<string> addresses = new List<string>();
        List<double> gpaPoints = new List<double>();



        public StudentInfo()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string id = idTextBox.Text;
            string name = nameTextBox.Text;
            string mobile = mobileTextBox.Text;
            string age = ageTextBox.Text;
            string address = addressTextBox.Text;
            string gpapoint = gpaTextBox.Text;

            for (int i = 0; i < mobiles.Count(); i++)
            {
                if (mobile == mobiles[i])
                {
                    MessageBox.Show("Contact Number already exist plz enter another number ");
                    return;
                }

            }

            for (int i = 0; i < ids.Count(); i++)
            {
                if (id == ids[i])
                {
                    MessageBox.Show("Id Number already exist plz enter another number ");
                    return;
                }

            }



            if (id == "" || name == "" || mobile == "" || age == "" || address == "" || gpapoint == "")
            {
                MessageBox.Show("Plz Fill up All field");
            }
            if (id.Length != 4)
            {
                MessageBox.Show("4 digit recuired");
                return;
            }
            if (name.Length > 30)
            {
                MessageBox.Show("Max 30 digit");
                return;
            }
            if (mobile.Length != 11)
            {
                MessageBox.Show("Max 11 digit");
                return;
            }
            try
            {
                if (String.IsNullOrEmpty(gpaTextBox.Text))
                {
                    MessageBox.Show("Please enter gpa!");
                    return;
                }

                if (String.IsNullOrEmpty(ageTextBox.Text))
                {
                    MessageBox.Show("Please enter Age!");
                    return;
                }


                else
                {
                    double gpapiont = Convert.ToDouble(gpaTextBox.Text);
                    if (gpapiont < 0 || gpapiont > 4)

                    {
                        MessageBox.Show("Enter GPA:");
                        return;
                    }
                    else
                    {
                        ids.Add(id);
                        names.Add(name);
                        mobiles.Add(mobile);
                        ages.Add(Convert.ToInt32(age));
                        addresses.Add(address);
                        gpaPoints.Add(Convert.ToDouble(gpapoint));

                        int index = ids.Count() - 1;
                        ResultShowAllInfo(index, index);

                       
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }





        }
        private void ResultShowAllInfo(int startindex, int endindex)
        {
            resultRichTextBox.Text = "";
            for (int i = startindex; i <= endindex; i++)
            {
                resultRichTextBox.Text += "ID: " + ids[i] + ",   " + "Name: " + names[i] + ",   " + "Mobile: " + mobiles[i] + ",   " + " Age: " + ages[i] + ",   " + "Address: " + addresses[i] + ",   " + "GPA point: " + gpaPoints[i] + "\n";
            }

        }

        private void showAllButton_Click(object sender, EventArgs e)
        {
            ResultShowAllInfo(0, ids.Count - 1);

           

            double gpamax = gpaPoints.Max();
            int index = gpaPoints.IndexOf(gpamax);
            string name = names[index];
            maxMarksTextBox.Text = gpamax.ToString();
            nameForMaxmarkTextBox.Text = name.ToString();

            double gpamin = gpaPoints.Min();
            index = gpaPoints.IndexOf(gpamin);
            name = names[index];
            minMarksTextBox.Text = gpamin.ToString();
            nameForMarksTextBox.Text = name.ToString();

            double total = gpaPoints.Sum();
            double avg = total / gpaPoints.Count();
            avgMarksTextBox.Text = avg.ToString();
            totalMarksForTextBox.Text = total.ToString();




        }

        private void showButtonForResult_Click(object sender, EventArgs e)
        {

            //search start here

            int index;

            if (searchTextBoxForSearch.Text == "")
            {
                MessageBox.Show("Enter search value");
                return;
            }
            int flag = -1;
            index = -1;
            if (idRadioButton.Checked == true)
            {
                try
                {
                    string id = (searchTextBoxForSearch.Text);
                    index = (ids.IndexOf(id));
                    flag = 1;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex + " \nEneter numeric value");
                    return;
                }


            }
            else if (nameRadioButton.Checked == true)
            {
                index = names.IndexOf(searchTextBoxForSearch.Text);
                flag = 1;
            }
            else if (mobileRadioButton.Checked == true)
            {
                index = mobiles.IndexOf(searchTextBoxForSearch.Text);
                flag = 1;
            }

            if (index >= 0 && flag == 1)
            {
                //ids[index],names[index] ei vabe sob list richtext box a add kore dan
                resultRichTextBox.Text = "ID: " + ids[index] +"\n"+ "Name: " + names[index] + "\n" + "Mobile: " + mobiles[index] + "\n" + "Age:  " + ages[index] + "\n" + "Address: " + addresses[index] + "\n" + "GPA Point: " + gpaPoints[index];

                MessageBox.Show("result found");

            }
            else
            {
                MessageBox.Show("no result found");
            }




        }
    }
    }


