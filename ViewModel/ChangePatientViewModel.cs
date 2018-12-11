using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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
using System.Windows.Controls;

namespace PatientApp.ViewModel
{
    public class ChangePatientViewModel : ViewModelBase,  IDataErrorInfo
    {
        private Regex emailRegex = new Regex(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$");


        private WebService servObj;

        private IMyNavigationService navigationService;

        public RelayCommand BackCmd { get; set; }
        public RelayCommand OnLoad { get; set; }
        public RelayCommand ChangePatientDataCmd { get; set; }

        private Patient searchPatient;
        public Patient SearchPatient
        {
            get { return searchPatient; }
            set { searchPatient = value;  RaisePropertyChanged(() => SearchPatient); }
        }

        private DateTime actualDate=DateTime.Now;
        public DateTime ActualDate
        {
            get { return actualDate; }
            set { actualDate = value; RaisePropertyChanged(() => ActualDate); }
        }


        private string patientFirstName;
        public string PatientFirstName
        {
            get { return patientFirstName; }
            set { patientFirstName = value; RaisePropertyChanged(() => PatientFirstName);  }
        }

        private string patientSecondName;
        public string PatientSecondName
        {
            get { return patientSecondName; }
            set { patientSecondName = value; RaisePropertyChanged(() => PatientSecondName);  }
        }

        private DateTime patientDOB;
        public DateTime PatientDOB
        {
            get { return patientDOB; }
            set { patientDOB = value; RaisePropertyChanged(() => PatientDOB);  }
        }

        private List<string> patientSex= new List<string> {"Male", "Female" };
        public List<string> PatientSex
        {
            get { return patientSex; }
            set { patientSex = value; RaisePropertyChanged(() => PatientSex);  }
        }

        private string selectedPatientSex;
        public string SelectedPatientSex
        {
            get { return selectedPatientSex; }
            set { selectedPatientSex = value; RaisePropertyChanged(() => SelectedPatientSex); }
        }


        private string patientMRN;
        public string PatientMRN
        {
            get { return patientMRN; }
            set { patientMRN = value; RaisePropertyChanged(() => PatientMRN); }
        }

        private string patientEmail;
        public string PatientEmail
        {
            get { return patientEmail; }
            set { patientEmail = value; RaisePropertyChanged(() => PatientEmail);  }
        }

        private Boolean isChanged = false;
        public Boolean IsChanged
        {
            get { return isChanged; }
            set { isChanged = value; RaisePropertyChanged(() => IsChanged); }
        }

        private bool IsValidEmailAddress
        {
            get
            {
                return emailRegex.IsMatch(PatientEmail);
            }
        }

        public bool IsValidChange
        {
            get
            {
                return !string.IsNullOrWhiteSpace(PatientFirstName) && !string.IsNullOrWhiteSpace(PatientSecondName) && !string.IsNullOrWhiteSpace(SelectedPatientSex)
                    && !string.IsNullOrWhiteSpace(PatientMRN) && !string.IsNullOrWhiteSpace(PatientEmail) && IsValidEmailAddress && PatientFirstName.Length > 3
                    && PatientSecondName.Length > 3 && PatientMRN.Length > 1 && PatientEmail.Length > 7;
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
                    error = "FirstName is required!";
                }
                else if (columnName == "PatientSecondName" && string.IsNullOrWhiteSpace(PatientSecondName))
                {
                    error = "SecondName is required!";
                }
                else if (columnName == "SearchPatient.MRN" && string.IsNullOrWhiteSpace(SearchPatient.MRN))
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
                else if (columnName == "PatientDOB")
                {
                    error = "l";
                }
                else if (columnName == "PatientFirstName" && PatientFirstName.Length < 4)
                {
                    error = "To short FirstName";
                }
                else if (columnName == "PatientSecondName" && PatientSecondName.Length < 4)
                {
                    error = "To short SecondName";
                }
                else if (columnName == "PatientMRN" && PatientMRN.Length < 2)
                {
                    error = "To short MRN";
                }
                else if (columnName == "PatientEmail" && PatientEmail.Length < 8)
                {
                    error = "To short Email";
                }

                RaisePropertyChanged("IsValidChange");
                return error;
            }
        }

        public ChangePatientViewModel(IMyNavigationService navService)
        {
            servObj = new WebService();
            navigationService = navService;
            SetSearchPatient();
            SetPatientData();
            InitCommand();
        }

        private void SetPatientData()
        {
            PatientFirstName = SearchPatient.FirstName;
            PatientSecondName = SearchPatient.SecondName;
            PatientDOB = SearchPatient.DOB;
            PatientEmail = SearchPatient.Email;
            SelectedPatientSex = SearchPatient.Sex;
            PatientMRN = SearchPatient.MRN;
        }

        private bool SetSearchPatientData()
        {
            SearchPatient = new Patient { DOB = PatientDOB, Email = PatientEmail, FirstName = PatientFirstName, MRN = PatientMRN, SecondName = PatientSecondName, Sex = SelectedPatientSex };
            return servObj.EqualsPatient(SearchPatient);
        }

        private void InitCommand()
        {
            BackCmd = new RelayCommand(() =>
            {
                servObj = new WebService();

                if (!SetSearchPatientData())
                {
                    MessageBoxResult msgResult = MessageBox.Show("Are you sure to back?",
                                    "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (msgResult == MessageBoxResult.Yes)
                    {
                        SearchPatient = null;
                        navigationService.GoBack();
                    }
                }
                else
                {
                    SearchPatient = null;
                    navigationService.GoBack();
                }
            });

            OnLoad = new RelayCommand(() =>
            {
                servObj = new WebService();
                SetSearchPatient();
                SetPatientData();
            });

            ChangePatientDataCmd = new RelayCommand(() =>
            {
                if(!SetSearchPatientData())
                {
                    if (error != "" || PatientFirstName == null || PatientSecondName == null || PatientDOB == null || PatientEmail == null || PatientMRN == null || PatientSex == null)
                    {
                        MessageBox.Show("Invalid data!",
                                    "Confirmation", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        SearchPatient = new Patient { DOB = PatientDOB, Email = PatientEmail, FirstName = PatientFirstName, MRN = PatientMRN, SecondName = PatientSecondName, Sex = SelectedPatientSex };
                        servObj = new WebService();
                        servObj.UpdatePatientData(SearchPatient.MRN, SearchPatient.FirstName, SearchPatient.SecondName, SearchPatient.DOB.Date, true, SearchPatient.Sex, SearchPatient.Email);
                        MessageBox.Show("Succesfull",
                                        "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);
                        navigationService.GoBack();
                    }
                }
                else
                {
                    MessageBox.Show("Nie wprowadzono zmian",
                                        "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                
            });
        }

        private void SetSearchPatient()
        {
            if (ViewModelLocator.SearchPatient!=null)
            {
                SearchPatient = ViewModelLocator.SearchPatient;
            }
        }
    }
}
