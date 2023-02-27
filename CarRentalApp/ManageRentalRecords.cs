using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class ManageRentalRecords : Form
    {
        private readonly CarRentalEntities _db;
        public ManageRentalRecords()
        {
            InitializeComponent();
            _db = new CarRentalEntities();
        }

        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            var addRentalRecord = new AddEditRentalRecord(this);
            addRentalRecord.MdiParent = this.MdiParent;
            addRentalRecord.Show();
        }

        private void btnEditRecord_Click(object sender, EventArgs e)
        {
            try
            {
                //get id of selected row
                var id = (int)gvRecordList.SelectedRows[0].Cells["Id"].Value;

                //query database for record
                var record = _db.CarRentalRecords.FirstOrDefault(q => q.id == id);

                //launch AddEditVehicle window with data
                var addEditRecord = new AddEditRentalRecord(record, this);
                addEditRecord.MdiParent = this.MdiParent;
                addEditRecord.Show();
            }
            catch (System.ArgumentOutOfRangeException)
            {
                MessageBox.Show("Please select a whole row and not just a cell.");
            }
        }

        private void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            try
            {
                //get id of selected row
                var id = (int)gvRecordList.SelectedRows[0].Cells["Id"].Value;

                //query database for record
                var record = _db.CarRentalRecords.FirstOrDefault(q => q.id == id);

                DialogResult dr = MessageBox.Show("Are you sure you want to delete this record?",
                    "Delete", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    //delete record from table
                    _db.CarRentalRecords.Remove(record);
                    _db.SaveChanges();
                    MessageBox.Show("Record deleted successfully.");
                }

                PopulateGrid();                
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                MessageBox.Show("A rental record exists with this vehicle and you can not delete it.");
            }
            catch (System.ArgumentOutOfRangeException)
            {
                MessageBox.Show("Please select a whole row and not just a cell.");
            }
        }

        private void ManageRentalRecords_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error:  {ex.Message}");
                throw;
            }
        }

        public void PopulateGrid()
        {
            var records = _db.CarRentalRecords
                .Select(q => new 
                {
                    Customer = q.CustomerName,
                    DateOut = q.DateRented,
                    DateIn = q.DateReturned,
                    Id = q.id,
                    Cost = q.Cost,
                    Car = q.TypesOfCar.Make + " " + q.TypesOfCar.Model
                }).ToList();
            gvRecordList.DataSource = records;
            //old titles
            //gvVehicleList.Columns[0].HeaderText = "ID";
            //gvVehicleList.Columns[1].HeaderText = "NAME";
            gvRecordList.Columns["DateOut"].HeaderText = "Date Out";
            gvRecordList.Columns["DateIn"].HeaderText = "Date In";
            gvRecordList.Columns["Id"].Visible = false;
        }
    }
}
