using HovLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HovLibrary.Views
{
    public partial class FormMasterMember : Form
    {
        HovLibraryDb context = new HovLibraryDb();

        private List<Member> members;
        int id;

        public FormMasterMember()
        {
            InitializeComponent();
            queryMember();
        }

        private void queryMember()
        {
            members = context.Members.ToList();
            dgvMember.DataSource = members;
            foreach (DataGridViewRow row in dgvMember.Rows )
            {
                row.Cells[8].Value = "edit";
            }
        }

        private void FormMasterMember_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hovLibraryDataSet.Member' table. You can move, or remove it, as needed.
            //this.memberTableAdapter.Fill(this.hovLibraryDataSet.Member);

        }

        private void dgvMember_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvMember_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvMember.Columns[e.ColumnIndex].Name == "edit")
                {
                    btnSave.Enabled = true;
                    id = Convert.ToInt32(dgvMember.SelectedCells[0].OwningRow.Cells[0].Value.ToString());
                    var member = context.Members.Find(id);
                    tbName.Text = member.name.ToString();
                    tbPhone.Text = member.phone_number.ToString();
                    tbEmail.Text = member.email.ToString();
                    tbAddress.Text = member.address.ToString();
                    tbCityOfBirth.Text = member.city_of_birth.ToString();
                    dtpDateOfBirth.Text = member.date_of_birth.ToString();
                    if (member.gender.ToString() == "Male")
                    {
                        radioGenderMale.Checked = true;
                    }
                    else if (member.gender.ToString() == "Female")
                    {
                        radioFemale.Checked = true;
                    }
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbName.Text != "" && tbPhone.Text != "" && tbEmail.Text != "" && tbAddress.Text != "" && tbCityOfBirth.Text != "" && dtpDateOfBirth.Text != "" && (radioGenderMale.Checked == true || radioFemale.Checked == true))
                {
                    var member = context.Members.Find(id);
                    if (member != null)
                    {
                        member.name = tbName.Text;
                        member.phone_number = tbPhone.Text;
                        member.email = tbEmail.Text;
                        member.address = tbAddress.Text;
                        member.city_of_birth = tbCityOfBirth.Text;
                        member.date_of_birth = dtpDateOfBirth.Value;
                        if (radioGenderMale.Checked == true)
                        {
                            member.gender = radioGenderMale.Text;
                        }
                        else if (radioFemale.Checked = true)
                        {
                            member.gender = radioFemale.Text;
                        }
                        context.SaveChanges();
                        MessageBox.Show("Member saved!");
                    }
                } else
                {
                    MessageBox.Show("Please fill form!");
                }
                queryMember();
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
