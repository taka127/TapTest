// See https://aka.ms/new-console-template for more information
using System;
using tapTechnicalTest.Models;
using tapTechnicalTest.controller;

namespace tapTechnicalTest
{

    class Program
    {
        static void Main()
        {
            // declearing section
            tapUniversity tResult = new tapUniversity();

            // function calling section
            tResult.GetAndSetApplicantScore();
        }

    }
}