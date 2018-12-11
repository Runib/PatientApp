using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using PatientApp.localhost1;
using PatientApp.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PatientApp.ViewModel
{
    public class PatientViewModel : ViewModelBase
    {
        private IMyNavigationService navigationService;
       
        private List<Patient> Patients;

        private WebService servObj;

        public RelayCommand DisplayOrderCmd { get; set; }
        public RelayCommand DeleteCmd { get; set; }
        public RelayCommand AddCmd { get; set; }
        public RelayCommand OnLoad { get; set; }
        public RelayCommand BackCmd { get; set; }
        public RelayCommand UpdateCmd { get; set; }

        private Patient selectedPatient;
        public Patient SelectedPatient
        {
            get { return selectedPatient; }
            set { selectedPatient = value; RaisePropertyChanged(() => SelectedPatient); CheckIsSelected(); }
        }

        private void CheckIsSelected()
        {
            if (SelectedPatient == null)
            {
                IsSelected = false;
            }
            else
            {
                IsSelected = true;
            }
                
        }

        private bool isSelected = false;
        public bool IsSelected
        {
            get { return isSelected; }
            set { isSelected = value; RaisePropertyChanged(() => IsSelected); }
        }

        private string searchMRN="";
        public string SearchMRN
        {
            get { return searchMRN; }
            set { searchMRN = value; RaisePropertyChanged(() => SearchMRN); SearchPatient(); }
        }

        private void SearchPatient()
        {
            if (SearchMRN != "")
                AllPatient = Patients.Where(p => p.MRN.Contains(SearchMRN)).ToList();
            else
                AllPatient = Patients;
        }

        private List<Patient> allPatient;
        public List<Patient> AllPatient
        {
            get { return allPatient; }
            set { allPatient = value; RaisePropertyChanged(() => AllPatient); }
        }

        public PatientViewModel(IMyNavigationService navService)
        {
            LoadPatient();
            navigationService = navService;
            InitCommand();
        }
        private void LoadPatient()
        {
            servObj = new WebService();
            Patients = servObj.LoadAllPatientData().ToList();
            AllPatient = Patients;
        }

        private void InitCommand()
        {
            DeleteCmd = new RelayCommand(() =>
            {
               try
               {
                   if (servObj.DeletePatientData(SelectedPatient.MRN))
                   {
                       MessageBox.Show("Succesfull",
                                "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);
                        SelectedPatient = null;
                        LoadPatient();
                   }
                   else
                   {
                       MessageBox.Show("The problem occured with removal",
                                "Confirmation", MessageBoxButton.OK, MessageBoxImage.Warning);
                   }
                   SelectedPatient = null;
               }
               catch (Exception e)
               {
                   MessageBox.Show(e.Message,
                                "Confirmation", MessageBoxButton.OK, MessageBoxImage.Warning);
               }
               
           });

            AddCmd = new RelayCommand(() =>
            {
                navigationService.NavigateTo(ViewModelLocator.AddPatientKey);   
            });

            OnLoad = new RelayCommand(() =>
            {
                LoadPatient();
            });

           BackCmd = new RelayCommand(() =>
           {
               navigationService.NavigateTo(ViewModelLocator.ChoiceKey);
           });

            UpdateCmd = new RelayCommand(() =>
            {
                if (SelectedPatient == null)
                    ViewModelLocator.SearchPatient = null;
                else
                    ViewModelLocator.SearchPatient = SelectedPatient;

                navigationService.NavigateTo(ViewModelLocator.ChangePatientKey);
            });

            DisplayOrderCmd = new RelayCommand(() =>
            {
                if (SelectedPatient==null)
                    ViewModelLocator.SearchPatient = null;
                else
                    ViewModelLocator.SearchPatient = SelectedPatient;

                navigationService.NavigateTo(ViewModelLocator.OrderKey);
            });
        }
    }
}
