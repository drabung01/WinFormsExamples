using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class AddEditVehicle : Form
    {
        private bool isEditMode;
        private frmManageVehicleListing _manageVehicleListing;
        private readonly CarRentalEntities _db;

        public AddEditVehicle(frmManageVehicleListing manageVehicleListing = null)
        {
            InitializeComponent();
            this.Text = "Add New Vehicle";
            lblTitle.Text = "Add New Vehicle";
            isEditMode = false;
            _db = new CarRentalEntities();
            _manageVehicleListing = manageVehicleListing;
        }

        public AddEditVehicle(TypesOfCar carToEdit, frmManageVehicleListing manageVehicleListing = null)
        {
            InitializeComponent();
            this.Text = "Edit Vehicle";
            lblTitle.Text = "Edit Vehicle";
            _manageVehicleListing = manageVehicleListing;
            if (carToEdit == null)
            {
                MessageBox.Show("Please ensure that you selected a valid record to edit");
                Close();
            }
            else 
            {
                isEditMode = true;
                _db = new CarRentalEntities();
                PopulateFields(carToEdit);
            }
        }

        private void PopulateFields(TypesOfCar car)
        {
            lblID.Text = car.id.ToString();
            tbModel.Text = car.Model;
            tbMake.Text = car.Make;
            tbVIN.Text= car.VIN;
            tbYear.Text = car.Year.ToString();
            tbPlateNum.Text = car.LicensePlateNumber;

        }

        private void btnSaveEdits_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbModel.Text == "" || tbMake.Text == "")
                {
                    MessageBox.Show("Please make sure to enter both a make and model");
                }
                else
                {
                    if (isEditMode)
                    {
                        //edit code here
                        var id = int.Parse(lblID.Text);
                        var car = _db.TypesOfCars.FirstOrDefault(q => q.id == id);
                        car.Model = tbModel.Text;
                        car.Make = tbMake.Text;
                        car.VIN = tbVIN.Text;
                        car.Year = int.Parse(tbYear.Text);
                        car.LicensePlateNumber = tbPlateNum.Text;
                    }
                    else
                    {
                        //add code here
                        var newCar = new TypesOfCar
                        {
                            Make = tbMake.Text,
                            Model = tbModel.Text,
                            VIN = tbVIN.Text,
                            Year = int.Parse(tbYear.Text),
                            LicensePlateNumber = tbPlateNum.Text
                        };

                        _db.TypesOfCars.Add(newCar);
                    }
                    _db.SaveChanges();
                    _manageVehicleListing.PopulateGrid();
                    MessageBox.Show("Car successfully saved.");
                    Close();
                }
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Error: Formatting is incorrect.\nPlease input the year as an integer");
            }
                                   
        }

        private void btnCancelEdits_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
