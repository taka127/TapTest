using System;
using tapTechnicalTest.Models;
using tapTechnicalTest.Util;

namespace tapTechnicalTest.controller
{
    public class tapUniversity
    {
        UtilHandler utilHandler = new UtilHandler();
        

        public void GetAndSetApplicantScore(){
            
            List<string> tempInput = new List<string>();
            String[] input; // Array of applicant information that user input in each line
            // Check if User input everything at once?
            Console.Write("Enter the data: "); 
            tempInput = utilHandler.GetAllMultiplelineValue();
            int numApplicants = int.Parse(tempInput.First());
            int nPassApplicants = 0;
            List<ApplicantInfo> allApplicant = new List<ApplicantInfo>();
            for(int i = 1;  i <= numApplicants; i++){
                ApplicantInfo applicant = new ApplicantInfo();
                input = tempInput[i].Split(' ');
                applicant = setValueEachApplicant(input);
                allApplicant.Add(applicant);
            }

            nPassApplicants = allApplicant.Count(item => item.AdmissionResult);
            Console.WriteLine(nPassApplicants);
        }

        // -------- Private Fuction --------

        private ApplicantInfo setValueEachApplicant(String[] dataArray ){
            ApplicantInfo applicant = new ApplicantInfo();
            applicant.Classification = dataArray[0];
            applicant.EnglishScore = int.Parse(dataArray[1]);
            applicant.MathematicsScore = int.Parse(dataArray[2]);
            applicant.ScienceScore = int.Parse(dataArray[3]);
            applicant.JapaneseScore = int.Parse(dataArray[4]);
            applicant.GeoHistoryScore = int.Parse(dataArray[5]);
            return applicant;
        }
        
    }
}