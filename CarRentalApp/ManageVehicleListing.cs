using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class frmManageVehicleListing : Form
    {
        private readonly CarRentalEntities _db;
        public frmManageVehicleListing()
        {
            InitializeComponent();
            _db = new CarRentalEntities();
        }

        public void PopulateGrid() 
        {
            var cars = _db.TypesOfCars
                .Select(q => new
                {
                    Make = q.Make,
                    Model = q.Model,
                    VIN = q.VIN,
                    Year = q.Year,
                    LicensePlateNumber = q.LicensePlateNumber,
                    id = q.id
                })
                .ToList();
            gvVehicleList.DataSource = cars;
            //old titles
            //gvVehicleList.Columns[0].HeaderText = "ID";
            //gvVehicleList.Columns[1].HeaderText = "NAME";
            gvVehicleList.Columns[4].HeaderText = "Plate #";
            gvVehicleList.Columns[5].Visible = false;
        }

        private void ManageVehicleListing_Load(object sender, EventArgs e)
        {
            //Select * From TypeOfCars
            //var cars = _db.TypesOfCars.ToList();

            //Select Id as CarId, name as CarName from TypesOfCars

            //Old code from before updating the database to have more columns
            //var cars = _db.TypesOfCars
            //    .Select(q => new {CarId = q.id, CarName = q.name})
            //   .ToList();

            PopulateGrid();            
        }

        private void btnAddCar_Click(object sender, EventArgs e)
        {
            AddEditVehicle addEditVehicle = new AddEditVehicle(this);
            addEditVehicle.MdiParent = this.MdiParent;
            addEditVehicle.Show();
        }

        private void btnEditCar_Click(object sender, EventArgs e)
        {
            try
            {
                //get id of selected row
                var id = (int)gvVehicleList.SelectedRows[0].Cells["id"].Value;

                //query database for record
                var car = _db.TypesOfCars.FirstOrDefault(q => q.id == id);

                //launch AddEditVehicle window with data
                var addEditVehicle = new AddEditVehicle(car, this);
                addEditVehicle.MdiParent = this.MdiParent;
                addEditVehicle.Show();
            }
            catch (System.ArgumentOutOfRangeException) 
            {
                MessageBox.Show("Please select a whole row and not just a cell.");
            }
        }

        private void btnDeleteCar_Click(object sender, EventArgs e)
        {
            try
            {
                //get id of selected row
                var id = (int)gvVehicleList.SelectedRows[0].Cells["id"].Value;

                //query database for record
                var car = _db.TypesOfCars.FirstOrDefault(q => q.id == id);

                DialogResult dr = MessageBox.Show("Are you sure you want to delete this record?",
                    "Delete", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes) 
                {
                    //delete vehicle from table
                    _db.TypesOfCars.Remove(car);
                    _db.SaveChanges();
                    MessageBox.Show("Vehicle deleted successfully.");
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
    }
}
