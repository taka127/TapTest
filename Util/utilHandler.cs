using System;
using System.Linq;

namespace tapTechnicalTest.Util
{
    public class UtilHandler
    {
        // ----- Const -----
        public const string ERROR_MESSAGE_WRONG_INFO = "Wrong information. Please try again";
        public const string APPLICANT_INFO_NUM_NOT_MATCH = "Number of information does not match. Please try again";
        public const string APPLICANT_INFO_NUM_NOT_MATCH_OR_MISSING = "Number of information does not match or some info is missing. Please try again";
        public const string WRONG_INPUT_FORMAT = "Wrong INFO format. Please try again";
        public const string APPLICANT_NO_DOES_NOT_MATCH = "Number of Applicant and input data does not match. Please try again from the beginning";
        public const string APPLICANT_CANNOT_BE_NEGATIVE_OR_ZERO = "Number of Applicant cannot be Charactor, negative integer, zero. Please try again from the beginning";
        public const string ERROR_INFO_ON_APPLICANT_NUMBER = "It has some error information on Applicant No.";
        public const string APPLICANT_NUMBER_IS_EXCEED_TOTAL_NUM = "Number of Applicant info is exceed total Applicant number please restart program and try again.";

        public const string ScienceDivision = "s";
        public const string HumanDivision = "l";

        public const int INFO_NUMBER_FOR_EACH_APPLICANT = 6;
        private bool isTotalApplicantisExist = false;
        private int totalApplicantis = 0;


        public bool isDigitOrExceedMaxApplicantNumber(string? msgstring){
            if(string.IsNullOrEmpty(msgstring) || string.IsNullOrWhiteSpace(msgstring)){
                return false;
            } else if(!msgstring.All(char.IsDigit)){
                return false;
            } else if (int.Parse(msgstring) < 1 || int.Parse(msgstring) > 10000){
                return false;
            }
            return true;
        }

        public bool isAllScoreAreDigitOrExceedMaxScore(string[] msgstrings){
            for(int i=1; i<msgstrings.Length;i++){
                if(string.IsNullOrEmpty(msgstrings[i]) || string.IsNullOrWhiteSpace(msgstrings[i])){
                    return false;
                }else if(!msgstrings[i].All(char.IsDigit)){
                    return false;
                } else if (int.Parse(msgstrings[i]) < 1 || int.Parse(msgstrings[i]) > 100) {
                    return false;
                }
            }
            return true;
        }

        public List<string> GetAllMultiplelineValue (){
            List<string> lines = new List<string>();
            string? line;
            int lineCount = 0;
            
            while (true)
            {
                line = Console.ReadLine();
                //Console.WriteLine($"Line: {lineCount} totalApplicantis: {totalApplicantis}");
                if(totalApplicantis != 0 && totalApplicantis == lineCount){
                    // Last Line
                    if (InputValidation(line)) {
                        lineCount++;
                        lines.Add(line);
                        break;
                    }
                } else if (totalApplicantis != 0 && (totalApplicantis + 1) < lineCount){
                    // Number of Applicant info is exceed total Applicant number
                    Console.WriteLine(UtilHandler.APPLICANT_NUMBER_IS_EXCEED_TOTAL_NUM);
                    break;
                } else if (string.IsNullOrEmpty(line) || string.IsNullOrWhiteSpace(line)){
                    // Check is input is NULL Empty ot Whitespace
                    Console.WriteLine(UtilHandler.ERROR_MESSAGE_WRONG_INFO);
                } else if (InputValidation(line)) {
                    lineCount++;
                    lines.Add(line);
                }
            }
            return lines;
        }

        public bool InputValidation(string input){
            string[] inputArr = input.Split(' ');
            int inputLenght = inputArr.Length;
            bool validateResult = true;
            switch(inputLenght) 
            {
                case 1:
                    // Check if user already put total applicant number?
                    if(isTotalApplicantisExist){
                        Console.WriteLine(UtilHandler.APPLICANT_INFO_NUM_NOT_MATCH_OR_MISSING);
                        validateResult = false;
                        return validateResult;
                    } else{
                        // 1st Line (total Applicant)
                        validateResult = ValidateApplicantNumber(inputArr[0]);
                        break;
                    }
                case 6:
                    // 2nd~ Line (Applicant Detail)
                    validateResult = ValidateApplicantDetail(inputArr);
                    break;
                default:
                    // Wrong input format
                    Console.WriteLine(UtilHandler.APPLICANT_INFO_NUM_NOT_MATCH_OR_MISSING);
                    validateResult = false;
                    break;
            }
            return validateResult;
        }

        public bool ValidateApplicantNumber(string msg){
            if(isDigitOrExceedMaxApplicantNumber(msg)){
                isTotalApplicantisExist = true;
                totalApplicantis = int.Parse(msg);
                return true;
            }else{
                Console.WriteLine(UtilHandler.APPLICANT_CANNOT_BE_NEGATIVE_OR_ZERO);
                return false;
            }
        }

        public bool ValidateApplicantDetail(string[] msgArray){
            if(!ScienceDivision.Equals(msgArray[0].ToLower()) && !HumanDivision.Equals(msgArray[0].ToLower())){
                // Check the Classification data is 'l' or 's' or not
                Console.WriteLine(UtilHandler.WRONG_INPUT_FORMAT);
                return false;
            } else if (!isAllScoreAreDigitOrExceedMaxScore(msgArray)){
                // Check is the score are integer between 0 - 100 or not
                Console.WriteLine(UtilHandler.WRONG_INPUT_FORMAT);
                return false;
            }

            return true;
        }

        public bool DoesApplicantInfoHasNullOrEmpty (string[] msgstrings){
            int stringlenght;
            stringlenght = msgstrings.Length;
            for(int i=0; i < stringlenght; i++){
                if(string.IsNullOrEmpty(msgstrings[i])){
                    return true;
                }
            }
            return false;
        }
    }
}