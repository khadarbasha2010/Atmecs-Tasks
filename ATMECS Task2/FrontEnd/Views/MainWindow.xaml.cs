using FrontEnd.Business;
using FrontEnd.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FrontEnd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private APIConsumption APIConsumptionobj;
        
        public MainWindow()
        {
            InitializeComponent();
            APIConsumptionobj = new APIConsumption();            
            FillData();
        }
        private Contacts ContactObj;
        private async void AddContact(object sender, RoutedEventArgs e)
        {
            string validationMsg = Validation();
            if (validationMsg == string.Empty)
            {
                try
                {
                    ContactObj = new Contacts()
                    {
                        FirstName = FirstNameTextBox.Text,
                        LastName = LastNameTextBox.Text,
                        DateOfBirth = (DateTime)DOBPicker.SelectedDate,
                        ListOfEmails = EmailTextBox.Text,
                        Phonenumbers = PhonetextBox.Text
                    };
                    var response = await APIConsumptionobj.postAPICall("AddContacts", ContactObj);
                    if (response == null)
                    {
                        MessageBox.Show("Error while api Call");
                    }
                    else
                    {
                        if (response.StatusCode == 201)
                        {
                            MessageBox.Show("Contact Created Successfully, status code:" + response.StatusCode);
                            ClearFields();
                            FillData();
                        }
                        else
                            MessageBox.Show("Failed to add the contact, status code:" + response.StatusCode);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error:" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show(validationMsg);
            }


        }
        private void ClearContact(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }
        private async void SearchContact(object sender, RoutedEventArgs e)
        {
            string searchStr = SearchTextBox.Text;
            if (!string.IsNullOrEmpty(searchStr)) { 
                try
                {
                    var response = await APIConsumptionobj.GetApiCall("SearchedContacts/" + searchStr);
                    if (response == null)
                    {
                        MessageBox.Show("Error while api Call");
                    }
                    else
                    {
                        if (response.StatusCode == 200)
                        {
                            if (response.Data == null)
                            {
                                ContactsListGrid.ItemsSource = null;
                                MessageBox.Show("No Contacts Found");
                            }
                            else
                                ContactsListGrid.ItemsSource = response.Data;
                            ClearFields();

                        }
                        else
                            MessageBox.Show("Failed to search the contacts, status code:" + response.StatusCode);
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Failed");
                } 
            }
           
           
        }
        
        private async void UpdateContact(object sender, RoutedEventArgs e)
        {
            string validationMsg= Validation();
            if (validationMsg == string.Empty)
            {
                try
                {
                    ContactObj = new Contacts()
                    {
                        Id = Convert.ToInt32(ContactObj.Id),
                        FirstName = FirstNameTextBox.Text,
                        LastName = LastNameTextBox.Text,
                        DateOfBirth = (DateTime)DOBPicker.SelectedDate,
                        ListOfEmails = EmailTextBox.Text,
                        Phonenumbers = PhonetextBox.Text
                    };
                    var res = await APIConsumptionobj.postAPICall("UpdateContacts", ContactObj);
                    if (res == null)
                    {
                        MessageBox.Show("Error while api Call");
                    }
                    else
                    {
                        if (res.StatusCode == 200)
                        {
                            MessageBox.Show("Contact Updated Successfully, status code:" + res.StatusCode);
                            UpdateContactBtn.Visibility = Visibility.Visible;
                            AddContactBtn.Visibility = Visibility.Visible;
                            ClearFields();
                            FillData();
                        }
                        else
                            MessageBox.Show("Failed to add the contact, status code:" + res.StatusCode);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error:" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show(validationMsg);
            }


        }
        public async void FillData()
        {
            
            var response = await APIConsumptionobj.GetApiCall("ListContacts");
            ContactsListGrid.ItemsSource = response.Data;
        }
        public void databindingmethod()
        {
          
        }

        private void ContactsListGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ContactsListGrid.SelectedItems.Count!=0)
            {
                try
                {
                    ContactObj = (Contacts)ContactsListGrid.SelectedItems[0];
                    FirstNameTextBox.Text = ContactObj.FirstName;
                    LastNameTextBox.Text = ContactObj.LastName;
                    DOBPicker.SelectedDate = ContactObj.DateOfBirth;
                    EmailTextBox.Text = ContactObj.ListOfEmails;
                    PhonetextBox.Text = ContactObj.Phonenumbers;
                    UpdateContactBtn.Visibility = Visibility.Visible;
                    AddContactBtn.Visibility = Visibility.Hidden;
                    CleartBtn.Visibility = Visibility.Visible;
                    dltBtn.Visibility = Visibility.Visible;
                }
                catch (Exception)
                {

                }
               
            }
           

        }
        private async void DeleteContact(object sender, RoutedEventArgs e)
        {
            var SelectedContacts = ContactsListGrid.SelectedItems;
            foreach (var item in SelectedContacts)
            {
                var currentItem = (Contacts)item;
                try
                {

                    var response = await APIConsumptionobj.DeleteApiCall("DeleteContacts/" + currentItem.Id);
                    if (response == null) {
                        MessageBox.Show("Error while api Call");
                    }
                    else
                    {
                        if (response.StatusCode == 200)
                        {
                            MessageBox.Show("Deleted Successfully");
                            ClearFields();
                            FillData();

                        }
                        else
                            MessageBox.Show("Failed to search the contacts, status code:" + response.StatusCode);
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Failed");
                }
            }
            

        }
        public void ClearFields()
        {
            FirstNameTextBox.Text = "";
            LastNameTextBox.Text = "";
            DOBPicker.SelectedDate = DateTime.Now; ;
            EmailTextBox.Text = "";
            PhonetextBox.Text = "";
            UpdateContactBtn.Visibility = Visibility.Hidden;
            AddContactBtn.Visibility = Visibility.Visible;
            CleartBtn.Visibility = Visibility.Hidden;
            dltBtn.Visibility = Visibility.Hidden;
        }

        private void SearchTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            string searchStr = SearchTextBox.Text;
            if (string.IsNullOrEmpty(searchStr))
            {
                FillData();
            }
        }
        public string Validation()
        {
            return ViewModelClass.DataValidation(FirstNameTextBox.Text, LastNameTextBox.Text);
            
        }
    }
}
