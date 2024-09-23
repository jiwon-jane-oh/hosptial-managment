using Microsoft.AspNetCore.SignalR.Client;
using MongoDB.Driver.Core.Connections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagementySite
{
    // Class implement medical inventory within the hospital system.
    // This allows staffs to view inventory items, add new supply items, remove an inventory items,
    // update (consume or refill hospital supplies)
    // and send alert to appropriate staffs if a supply item is low.
    public partial class MedicalInventoryForm : Form
    {
        private HospitalManagementDBEntities1 context;
        private HubConnection connectionInventory;
        const int LOW_SUPPLY_TRIGGER = 100; // a trigger constant for low supply  
        private User user;

        public MedicalInventoryForm(User user)
        {
            InitializeComponent();
            InitializeSignalR();
            context = new HospitalManagementDBEntities1();
            this.user = user;
        }

        // Function to add new supply items
        private void buttonAddNewSupply_Click(object sender, EventArgs e)
        {
            // user inputs for new supply item
            string itemName = textBoxItemName.Text;
            string quantity = textBoxQuantity.Text;
            string supplierName = textBoxSupplierName.Text;
            string supplierPhone = textBoxSupplierPhone.Text;

            if (checkValidInventory(itemName, quantity, supplierName, supplierPhone)) // check validity of the inputs
            {
                MedicalInventory medicalInventory = new MedicalInventory();
                // fill an instant of the medical inventory
                medicalInventory.ItemName = itemName;
                medicalInventory.Quantity = Int32.Parse(quantity);
                medicalInventory.SupplierName = supplierName;
                medicalInventory.SupplierPhone = supplierPhone;
                // add the new instant to the MedicalInventories table
                context.MedicalInventories.Add(medicalInventory);
                context.SaveChanges(); // save the change 
            }
            loadToDataGridView(); // update the datagridview
        }

        // Function to update existing supply items
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            var context = new HospitalManagementDBEntities1();
            // user update existing supply item
            string itemName = textBoxItemName.Text;
            string quantity = textBoxQuantity.Text;
            string supplierName = textBoxSupplierName.Text;
            string supplierPhone = textBoxSupplierPhone.Text;

            // search for the item name in the MedicalInventories database 
            var invToUpdate = context.MedicalInventories.FirstOrDefault(p => p.ItemName == itemName);
            if (invToUpdate != null) // inventory is existing in the database
            {
                // update the instant of the medical inventory with user input
                invToUpdate.ItemName = itemName;
                invToUpdate.Quantity = Int32.Parse(quantity);
                invToUpdate.SupplierName = supplierName;
                invToUpdate.SupplierPhone = supplierPhone;
                // save the change 
                context.SaveChanges();                   
                loadToDataGridView(); // update the datagridview
                MessageBox.Show("Item updated successfully.");
                
                if (invToUpdate.Quantity < LOW_SUPPLY_TRIGGER) // the item quantity is below the threadhold 
                {
                    sendInventoryAlert(itemName); // send an alert to staff using signalR
                }
            }
            else
            {
                MessageBox.Show("Item not found.");
            }
            
        }

        // Function to handle delete button click that allows staff to remove an inventory item from the
        // database. User has to select an item to be removed by clicking on the item using mouse.
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null) // check if an item has been selected
            {
                // get a selected item id 
                int selectedId = Int32.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                // query database for the selected item
                var deleteMedInv =
                        from medInv in context.MedicalInventories
                        where medInv.MedicalInventoryId == selectedId
                        select medInv;

                foreach (var inv in deleteMedInv) // loop to remove the item from the database
                {
                    context.MedicalInventories.Remove(inv);
                }

                try
                {
                    context.SaveChanges(); // update the database
                    loadToDataGridView();  // update datagridview
                    MessageBox.Show("Delete sucessful");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            else
            {
                MessageBox.Show("Please select an item to be deleted from datagridview");
            }
            
        }

        // Function to handle load button click to load all iventory items to the datagridview
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            loadToDataGridView();
        }

        // Intialized signalR to communicate using inventory port
        private async void InitializeSignalR()
        {
            connectionInventory = new HubConnectionBuilder()
                .WithUrl("http://localhost:5041/inventory")
                .Build();

            try
            {
                await connectionInventory.StartAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to SignalR hub: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // helper function to send inventory alert
        private async void sendInventoryAlert(string itemName)
        {
            try
            {
                string message = "Software System detects low stock for " + itemName;
                await connectionInventory.InvokeAsync("SendInventoryMessage", message);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxItemName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBoxQuantity.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBoxSupplierName.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBoxSupplierPhone.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        // Helper function to upload the MedicalInventories database to datagridview
        private void loadToDataGridView()
        {
            var query = from inv in context.MedicalInventories
                        select new
                        {
                            MedicalInventoryId = inv.MedicalInventoryId,
                            ItemName = inv.ItemName,
                            Quantity = inv.Quantity,
                            SupplierName = inv.SupplierName,
                            SupplierPhone = inv.SupplierPhone
                            // Add more fields as needed
                        };

            // Bind the result to DataGridView
            dataGridView1.DataSource = query.ToList();
        }

        // Helper function to return true if user inputs are valid
        private bool checkValidInventory(string itemName, string quantity, string supplierName, string supplierPhone)
        {
            bool result = true;

            if (itemName == "")
            {
                MessageBox.Show("Please enter item name.");
                return false;
            }
            else if (quantity == "")
            {
                MessageBox.Show("Please enter item quantity.");
                return false;
            }
            else if (supplierName == "")
            {
                MessageBox.Show("Please enter supplier name.");
                return false;
            }
            else if (supplierPhone == "")
            {
                MessageBox.Show("Please enter supplier phone.");
                return false;
            }
            return result;
        }
    }
}
