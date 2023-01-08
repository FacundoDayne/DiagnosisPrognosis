using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiagnosisPrognosisClient
{
    public partial class InventoryUC : UserControl
    {
		private byte DrugQuantity;
		private byte MedQuantity;
        public InventoryUC()
        {
            InitializeComponent();
			DrugQuantity = 0;
			MedQuantity = 0;
        }

		private void btnAddDrugQuantity_Click(object sender, EventArgs e)
		{
			DrugQuantity++;
			txtDrugQuantity.Text = DrugQuantity.ToString();
		}

		private void btnSubDugQuantity_Click(object sender, EventArgs e)
		{
			DrugQuantity--;
			txtDrugQuantity.Text = DrugQuantity.ToString();
		}

		private void btnTakeDrug_Click(object sender, EventArgs e)
		{
			DrugQuantity = 0;
			txtDrugQuantity.Text = "0";
		}

		private void txtDrugQuantity_TextChanged(object sender, EventArgs e)
		{
			try
			{
				DrugQuantity = byte.Parse(txtDrugQuantity.Text);
			} catch (FormatException ex)
			{
				MessageBox.Show(ex.Message);
				txtDrugQuantity.Text = DrugQuantity.ToString();
			}
		}

		private void btnAddMedQuantity_Click(object sender, EventArgs e)
		{
			MedQuantity++;
			txtMedQuantity.Text = MedQuantity.ToString();
		}

		private void btnSubMedQuantity_Click(object sender, EventArgs e)
		{
			MedQuantity--;
			txtMedQuantity.Text = MedQuantity.ToString();
		}

		private void btnTakeMedkit_Click(object sender, EventArgs e)
		{
			MedQuantity = 0;
			txtMedQuantity.Text = "0"; ;
		}

		private void txtMedQuantity_TextChanged(object sender, EventArgs e)
		{
			try
			{
				MedQuantity = byte.Parse(txtMedQuantity.Text);
			}
			catch (FormatException ex)
			{
				MessageBox.Show(ex.Message);
				txtMedQuantity.Text = MedQuantity.ToString();
			}
		}
	}
}
