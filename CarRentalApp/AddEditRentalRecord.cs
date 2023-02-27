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
    public partial class AddEditRentalRecord : Form
    {
        private bool isEditMode;
        private readonly CarRentalEntities _db;
        private ManageRentalRecords _manageRentalRecords;
        public AddEditRentalRecord(ManageRentalRecords manageRentalRecords = null)
        {
            InitializeComponent();
            this.Text = "Add New Rental Record";
            lblTitle.Text = "Add New Rental Record";
            isEditMode = false;
            _db = new CarRentalEntities();
            _manageRentalRecords = manageRentalRecords;
        }
        public AddEditRentalRecord(CarRentalRecord recordToEdit, ManageRentalRecords manageRentalRecords = null)
        {
            InitializeComponent();
            this.Text = "Edit Rental Record";
            lblTitle.Text = "Edit Rental Record";
            _manageRentalRecords = manageRentalRecords;
            if (recordToEdit == null)
            {
                MessageBox.Show("Please ensure that you selected a valid record to edit");
                Close();
            }
            else
            {
                isEditMode = true;
                _db = new CarRentalEntities();
                PopulateFields(recordToEdit);
            }
        }

        private void PopulateFields(CarRentalRecord recordToEdit)
        {
            tbCustomerName.Text = recordToEdit.CustomerName;
            DateRentedPicker.Value = (DateTime)recordToEdit.DateRented;
            DateReturnedPicker.Value = (DateTime)recordToEdit.DateReturned;
            tbCost.Text = recordToEdit.Cost.ToString();
            lblRecordId.Text = recordToEdit.id.ToString();
            //This line doesn't work and sometimes causes an exception
            cboCarType.SelectedValue = recordToEdit.TypesOfCar.Make + " " + recordToEdit.TypesOfCar.Model;
            //MessageBox.Show(recordToEdit.TypesOfCar.Make + " " + recordToEdit.TypesOfCar.Model);
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                string customerName = tbCustomerName.Text;
                DateTime dateOut = DateRentedPicker.Value;
                DateTime dateIn = DateReturnedPicker.Value;
                var carType = cboCarType.Text;
                double cost = Convert.ToDouble(tbCost.Text);
                var isValid = true;
                var errorMessage = "";

                if (string.IsNullOrWhiteSpace(customerName) || string.IsNullOrWhiteSpace(carType))
                {
                    isValid = false; 
                    errorMessage += "Error: Please enter missing data.\n\r";
                }

                if (dateOut > dateIn)
                {
                    isValid = false; 
                    errorMessage += "Error: Illegal date selection\n\r";
                }

                if (isValid == true) //could also just say if(isValid)
                {
                    if (isEditMode) 
                    {
                        var id = int.Parse(lblRecordId.Text);
                        var record = _db.CarRentalRecords.FirstOrDefault(q => q.id == id);
                        record.CustomerName = customerName;
                        record.DateRented = dateOut;
                        record.DateReturned = dateIn;
                        record.Cost = (decimal)cost;
                        record.TypeOfCarid = (int)cboCarType.SelectedValue;

                        _db.SaveChanges();
                        _manageRentalRecords.PopulateGrid();

                        MessageBox.Show("Data Successfully Saved" + "\n\r" +
                            "Customer Name: " + customerName + "\n\r" +
                            "Date Rented: " + dateOut + "\n\r" +
                            "Date Returned: " + dateIn + "\n\r" +
                            "Car Type: " + carType + "\n\r" +
                            "Cost: " + cost);
                    }
                    else 
                    {
                        var rentalRecord = new CarRentalRecord();
                        rentalRecord.CustomerName = customerName;
                        rentalRecord.DateRented = dateOut;
                        rentalRecord.DateReturned = dateIn;
                        rentalRecord.Cost = (decimal)cost;
                        rentalRecord.TypeOfCarid = (int)cboCarType.SelectedValue;

                        _db.CarRentalRecords.Add(rentalRecord);
                        _db.SaveChanges();
                        _manageRentalRecords.PopulateGrid();

                        MessageBox.Show("Customer Name: " + customerName + "\n\r" +
                            "Date Rented: " + dateOut + "\n\r" +
                            "Date Returned: " + dateIn + "\n\r" +
                            "Car Type: " + carType + "\n\r" +
                            "Cost: " + cost + "\n\r" +
                            "Thank you for your business.");
                    }
                    Close();
                }
                else 
                {
                    MessageBox.Show(errorMessage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw; will end the program
            }
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //same as Select * from TypesOfCars <- but that is SQL
            //old code from before adding more columns to database
            //var cars = carRentalEntities.TypesOfCars.ToList();

            var cars = _db.TypesOfCars
                .Select(q => new {id = q.id, Name = q.Make + " " + q.Model })
                .ToList();
            cboCarType.DisplayMember = "Name";
            cboCarType.ValueMember = "id";
            cboCarType.DataSource = cars;
        }
    }
}
