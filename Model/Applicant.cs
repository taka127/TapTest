using System;
using System.Diagnostics.CodeAnalysis;
using System.IO.Pipes;
using System.Xml.Schema;
using tapTechnicalTest.Util;

namespace tapTechnicalTest.Models  
{
    public class ApplicantInfo
    { 
        private  string _classification = string.Empty;
        public string Classification { 
            get { return _classification;} 
            set { _classification = value; }
            }
        public int EnglishScore { get; set; }
        public int MathematicsScore { get; set; }
        public int ScienceScore { get; set; }
        public int JapaneseScore { get; set; }
        public int GeoHistoryScore { get; set; }  
        public int TotalScore
        {
            get
            {
                return EnglishScore + MathematicsScore + ScienceScore + JapaneseScore + GeoHistoryScore;
            }
        }
        public Boolean AdmissionResult { 
            get{ return this.Criteria2Result; }
        }
        public int SciScore{
            get{ return AllSciScore;}
        }


        // -------- Private & Protected --------
        private int AllSciScore { 
            get { return MathematicsScore + ScienceScore; }
        } 
        private int AllHumScore { 
            get { return JapaneseScore + GeoHistoryScore; }
        }
        private Boolean Criteria1Result { 
            get { 
                if(TotalScore >= 350){
                    return true;
                } else{
                    return false;
                }
            } 
        }
        private Boolean Criteria2Result { 
            get{
                if(Criteria1Result == false){
                    return false;
                }
                else if(string.IsNullOrEmpty(this.Classification)){
                    return false;
                } else {
                    if(UtilHandler.ScienceDivision.Equals(this.Classification.ToLower()) && AllSciScore >= 160){
                    return true;
                    } else if (UtilHandler.HumanDivision.Equals(this.Classification.ToLower()) && AllHumScore >= 160){
                        return true;
                    } else{
                        return false;
                    }
                }
            }
        }
    }
}