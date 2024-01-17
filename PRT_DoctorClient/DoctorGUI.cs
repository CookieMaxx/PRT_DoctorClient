using DoctorClient.Logic;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Model;


namespace PRT_DoctorClient
{
    public partial class DoctorGUI : Form
    {

        private List<Hl7.Fhir.Model.Patient> patientList = new List<Hl7.Fhir.Model.Patient>();
        private Hl7.Fhir.Model.Patient selectedPatient;


        public DoctorGUI()
        {
            InitializeComponent();
            PopulateMedicationBox();
            PopulateSurveyBox();

            this.checkPatients.ItemCheck += new ItemCheckEventHandler(checkPatients_ItemCheck);
            this.checkMedication.ItemCheck += new ItemCheckEventHandler(medicationCheckList_ItemCheck);

        }


        private void PopulateMedicationBox()
        {
            // Clear any existing items in the CheckedListBox
            checkMedication.Items.Clear();

            // Iterate through the enum values and add them to the CheckedListBox
            foreach (DoctorClient.Logic.Medication medication in Enum.GetValues(typeof(DoctorClient.Logic.Medication)))
            {
                checkMedication.Items.Add(medication.ToString());
            }
        }

        private void PopulateSurveyBox()
        {
            // Clear any existing items in the CheckedListBox
            checkSurveyQuestions.Items.Clear();

            // Iterate through the enum values and add them to the CheckedListBox
            foreach (Survey survey in SurveyManager.Surveys)
            {
                checkSurveyQuestions.Items.Add(survey.Name);
            }
        }

        private void LoadXmlDataToListView(string filePath)
        {
            XmlReader reader = new XmlReader();
            var data = reader.ParseCdaFile(filePath);

            foreach (var item in data)
            {
                ListViewItem listViewItem = new ListViewItem(item.Key);
                listViewItem.SubItems.Add(item.Value);
                listPatient.Items.Add(listViewItem);
            }
        }



        private void listPatient_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkSurveyQuestions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkMedication_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listServerCom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkPatients_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkPatients_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {

                selectedPatient = patientList[e.Index];

                // Uncheck all other items
                this.BeginInvoke((Action)(() =>
                {
                    for (int i = 0; i < checkPatients.Items.Count; i++)
                    {
                        if (i != e.Index)
                        {
                            checkPatients.SetItemChecked(i, false);
                        }
                    }
                }));

                // Display patient information after the check state has been updated
                this.BeginInvoke((Action)(() =>
                {
                    if (e.Index >= 0 && e.Index < patientList.Count)
                    {
                        Patient selectedPatient = patientList[e.Index];
                        DisplayPatientInfo(selectedPatient);
                    }
                }));
            }
        }

        private List<string> checkedMedications = new List<string>();

        private void medicationCheckList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string medication = checkMedication.Items[e.Index].ToString();

            if (e.NewValue == CheckState.Checked && !checkedMedications.Contains(medication))
            {
                checkedMedications.Add(medication);
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                checkedMedications.Remove(medication);
            }
        }


        private void DisplayPatientInfo(Hl7.Fhir.Model.Patient patient)
        {
            listPatient.Items.Clear();

            // Adding each detail as a separate item
            listPatient.Items.Add("Name: " + (patient.Name.FirstOrDefault()?.ToString() ?? "Unknown"));
            listPatient.Items.Add("Gender: " + (patient.Gender.HasValue ? patient.Gender.Value.ToString() : "Unknown"));
            listPatient.Items.Add("BirthDate: " + (patient.BirthDate ?? "Unknown"));

            var phone = patient.Telecom?.FirstOrDefault(t => t.System == Hl7.Fhir.Model.ContactPoint.ContactPointSystem.Phone)?.Value ?? "Unknown";
            listPatient.Items.Add("Phone: " + phone);

            listPatient.Items.Add("Address: " + (patient.Address?.FirstOrDefault()?.ToString() ?? "Unknown"));

            var email = patient.Telecom?.FirstOrDefault(t => t.System == Hl7.Fhir.Model.ContactPoint.ContactPointSystem.Email)?.Value ?? "Unknown";
            listPatient.Items.Add("Email: " + email);

            listPatient.View = View.Tile;

        }


        private async void btnSend_Click(object sender, EventArgs e)
        {

            var selectedSurvey = GetSelectedSurvey(); // Get the selected survey
            var selectedMedications = GetSelectedMedications(); // Get the selected medications

            var fhirClient = new Hl7.Fhir.Rest.FhirClient("http://54.93.124.150:8080/fhir");

            foreach (string medication in selectedMedications)
            {
                var medicationStatement = new MedicationStatement
                {
                    Subject = new ResourceReference($"Patient/{selectedPatient.Id}"),
                    Medication = new CodeableConcept("http://example.org/fhir/medication-codes", medication),
                    Status = MedicationStatement.MedicationStatusCodes.Active
                };

                await fhirClient.CreateAsync(medicationStatement);
            }

            // For Survey
            if (selectedSurvey != null)
            {
                var taskResource = new Hl7.Fhir.Model.Task
                {
                    Description = selectedSurvey.Name,
                    Status = Hl7.Fhir.Model.Task.TaskStatus.Requested,
                    Intent = Hl7.Fhir.Model.Task.TaskIntent.Order,
                    For = new ResourceReference($"Patient/{selectedPatient.Id}")
                };

                await fhirClient.CreateAsync(taskResource);
            }
        }

        private List<string> GetSelectedMedications()
        {
            List<string> selectedMedications = new List<string>();
            foreach (object itemChecked in checkMedication.CheckedItems)
            {
                selectedMedications.Add(itemChecked.ToString());
            }
            return selectedMedications;
        }

        private Survey GetSelectedSurvey()
        {
            if (checkSurveyQuestions.CheckedItems.Count > 0)
            {
                string selectedSurveyName = checkSurveyQuestions.CheckedItems[0].ToString();
                // Assuming you have a list/array of Survey objects: surveys
                return SurveyManager.Surveys.FirstOrDefault(s => s.Name == selectedSurveyName);
            }
            return null;
        }



        private void btnConnect_Click(object sender, EventArgs e)
        {
            var client = new FhirClient("http://54.93.124.150:8080/fhir");
            try
            {
                // Retrieve patients from the server
                var patients = client.Search<Patient>();

                // Clear the existing items
                patientList.Clear();
                checkPatients.Items.Clear();

                foreach (var entry in patients.Entry)
                {
                    var patient = (Hl7.Fhir.Model.Patient)entry.Resource;
                    patientList.Add(patient); // Store the full patient object

                    // Add patient's name to the CheckedListBox
                    string patientName = patient.Name.FirstOrDefault()?.ToString() ?? "Unnamed";
                    checkPatients.Items.Add(patientName);
                }
                listServerCom.View = View.List;

                // Update the server communication info

                listServerCom.Items.Add("Successfully connected and retrieved patients.");

            }
            catch (Exception ex)
            {
                // Handle any exceptions (e.g., connection issues)
                listServerCom.Items.Add("Failed to connect or retrieve patients. Error: " + ex.Message);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkMedication.Items.Count; i++)
            {
                if (checkMedication.GetItemChecked(i))
                {
                    checkMedication.SetItemChecked(i, false);
                }
            }

            for (int i = 0; i < checkSurveyQuestions.Items.Count; i++)
            {
                if (checkSurveyQuestions.GetItemChecked(i))
                {
                    checkSurveyQuestions.SetItemChecked(i, false);
                }
            }

            for (int i = 0; i < checkPatients.Items.Count; i++)
            {
                if (checkPatients.GetItemChecked(i))
                {
                    checkPatients.SetItemChecked(i, false);
                }
            }

            listPatient.Clear();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            var client = new FhirClient("http://54.93.124.150:8080/fhir");
            try
            {
                // Retrieve patients from the server
                var patients = client.Search<Patient>();

                // Clear the existing items
                patientList.Clear();
                checkPatients.Items.Clear();

                foreach (var entry in patients.Entry)
                {
                    var patient = (Hl7.Fhir.Model.Patient)entry.Resource;
                    patientList.Add(patient); // Store the full patient object

                    // Add patient's name to the CheckedListBox
                    string patientName = patient.Name.FirstOrDefault()?.ToString() ?? "Unnamed";
                    checkPatients.Items.Add(patientName);
                }
                listServerCom.View = View.List;

                // Update the server communication info

                listServerCom.Items.Add("Successfully refreshed patients.");

            }
            catch (Exception ex)
            {
                // Handle any exceptions (e.g., connection issues)
                listServerCom.Items.Add("Failed to  retrieve patients. Error: " + ex.Message);
            }
        }
    }
}
