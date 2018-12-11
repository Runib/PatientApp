using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using PatientApp.localhost1;
using PatientApp.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace PatientApp.ViewModel
{
    public class AddPatientViewModel : ViewModelBase, IDataErrorInfo
    {
        private Regex emailRegex = new Regex(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$");

        private IMyNavigationService navigationService;

        private WebService servObj;

        public RelayCommand AddPatientCmd { get; set; }
        public RelayCommand BackCmd { get; set; }

        public bool IsValidAdd
        {
            get
            {
                return !string.IsNullOrWhiteSpace(PatientFirstName) && !string.IsNullOrWhiteSpace(PatientSecondName) && !string.IsNullOrWhiteSpace(SelectedPatientSex)
                    && !string.IsNullOrWhiteSpace(PatientMRN) && !string.IsNullOrWhiteSpace(PatientEmail) && IsValidEmailAddress && PatientFirstName.Length>3
                    && PatientSecondName.Length>3 && PatientMRN.Length>1 && PatientEmail.Length>7;
            }
        }

        private DateTime actualDate = DateTime.Now;
        public DateTime ActualDate
        {
            get { return actualDate; }
            set { actualDate = value; RaisePropertyChanged(() => ActualDate); }
        }


        private string patientFirstName;
        public string PatientFirstName
        {
            get { return patientFirstName; }
            set { patientFirstName = value; RaisePropertyChanged(() => PatientFirstName); }
        }

        private string patientSecondName;
        public string PatientSecondName
        {
            get { return patientSecondName; }
            set { patientSecondName = value; RaisePropertyChanged(() => PatientSecondName); }
        }

        private string patientMRN;
        public string PatientMRN
        {
            get { return patientMRN; }
            set { patientMRN = value; RaisePropertyChanged(() => PatientMRN); }
        }

        private DateTime patientDOB= new DateTime(2018,1,1);
        public DateTime PatientDOB
        {
            get { return patientDOB; }
            set { patientDOB = value; RaisePropertyChanged(() => PatientDOB); }
        }


        private List<string> patientSex = new List<string> { "Male","Female" };
        public List<string> PatientSex
        {
            get { return patientSex; }
            set { patientSex = value; RaisePropertyChanged(() => PatientSex); }
        }

        private string selectedPatientSex;
        public string SelectedPatientSex
        {
            get { return selectedPatientSex; }
            set { selectedPatientSex = value; RaisePropertyChanged(() => SelectedPatientSex); }
        }


        private string patientEmail;
        public string PatientEmail
        {
            get { return patientEmail; }
            set { patientEmail = value; RaisePropertyChanged(() => PatientEmail); }
        }

        private bool IsValidEmailAddress
        {
            get
            {
                return emailRegex.IsMatch(PatientEmail);
            }
        }

        private string error = String.Empty;
        public string Error
        {
            get
            {
                return error;
            }
        }

        public string this[string columnName]
        {
            get
            {
                error = string.Empty;
                if (columnName == "PatientFirstName" && string.IsNullOrWhiteSpace(PatientFirstName))
                {
                    error = "FirstName name is required!";
                }
                else if (columnName == "PatientSecondName" && string.IsNullOrWhiteSpace(PatientSecondName))
                {
                    error = "SecondName is required!";
                }
                else if (columnName == "PatientMRN" && string.IsNullOrWhiteSpace(PatientMRN))
                {
                    error = "MRN is required";
                }
                else if (columnName == "PatientEmail" && string.IsNullOrWhiteSpace(PatientEmail))
                {
                    error = "Email is required!";
                }
                else if (columnName == "SelectedPatientSex" && string.IsNullOrWhiteSpace(SelectedPatientSex))
                {
                    error = "Sex is required!";
                }
                else if (columnName == "PatientEmail" && !IsValidEmailAddress)
                {
                    error = "Please enter valid email address!";
                }
                else if (columnName== "PatientDOB")
                {
                    error = "l";
                }
                else if (columnName== "PatientFirstName" && PatientFirstName.Length<4)
                {
                    error = "To short FirstName";
                }
                else if (columnName == "PatientSecondName" && PatientSecondName.Length<4)
                {
                    error = "To short SecondName";
                }
                else if (columnName == "PatientMRN" && PatientMRN.Length<2)
                {
                    error = "To short MRN";
                }
                else if (columnName == "PatientEmail" && PatientEmail.Length<8)
                {
                    error = "To short Email";
                }

                RaisePropertyChanged("IsValidAdd");
                return error;
            }
        }

        public AddPatientViewModel(IMyNavigationService navService)
        {
            servObj = new WebService();
            //servObj = new WebService_Binding();
            navigationService = navService;
            InitCommand();
        }

        private void InitCommand()
        {
            AddPatientCmd = new RelayCommand(() =>
            {
                if (error!="" || PatientFirstName==null || PatientSecondName==null || PatientDOB==null || PatientEmail==null || PatientMRN==null || PatientSex==null)
                {
                    MessageBox.Show("Invalid data!",
                                "Confirmation", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if(servObj.CreatePatientData(new Patient
                {
                    FirstName = PatientFirstName,
                    SecondName = PatientSecondName,
                    MRN = PatientMRN,
                    DOB = PatientDOB,
                    Email = PatientEmail,
                    Sex = SelectedPatientSex
                }))
                {
                    {
                        MessageBox.Show("Succesfull",
                                    "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);
                        PatientFirstName = null;
                        PatientSecondName = null;
                        PatientMRN = null;
                        PatientEmail = null;
                        PatientSex = null;
                        navigationService.NavigateTo(ViewModelLocator.PatientKey);
                    }
                }
                else
                {
                    MessageBox.Show("Check MRN",
                                                "Confirmation", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
                
            });

            BackCmd = new RelayCommand(() =>
            {
                if (PatientFirstName!=null || PatientEmail!=null || PatientSecondName!=null || PatientSex!=null || PatientMRN!=null)
                {
                    MessageBoxResult msgResult = MessageBox.Show("Are you sure to back?",
                                    "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if(msgResult == MessageBoxResult.Yes)
                    {
                        PatientFirstName = PatientSecondName = PatientMRN = PatientEmail = SelectedPatientSex = null;
                        navigationService.NavigateTo(ViewModelLocator.PatientKey);
                    } 
                }
                else
                    navigationService.NavigateTo(ViewModelLocator.PatientKey);

            });
        }
    }
}
