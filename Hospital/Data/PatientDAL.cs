using Hospital.Models;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital.Data
{
    public interface IPDAL
    {
        List<Patient> GetPatients();
        List<Patient> GetMyPatients(string userid);
        Patient GetPatient(int id);
        List <Appointments> GetAppointments(int id);

        void CreatePatient(Patient patient);
        void UpdatePatient(Patient patient);
        void DeletePatient(int id);
    }


    public class PatientDAL : IPDAL{

        private readonly ApplicationDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PatientDAL(ApplicationDbContext context,IHttpContextAccessor httpContextAccessor)
        {
            _db = context;
            _httpContextAccessor = httpContextAccessor;
        }



        public List<Patient> GetPatients()
        {
            return _db.patients.ToList();

        }
        public List<Patient> GetMyPatients(string userid)
        {
            var patients = _db.patients.ToList();


            return _db.patients.ToList();
        }
        public Patient GetPatient(int id)
        {
            return _db.patients.FirstOrDefault(i => i.ID == id);
        }
        public List<Appointments> GetAppointments(int id)
        {
            return _db.appointments.Where(i => i.Patient.ID == id).ToList();
        }

        public void CreatePatient(Patient patient)
        {
            var newPatient = new Patient();

            newPatient = patient;

            _db.patients.Add(newPatient);
            _db.SaveChanges();
        }
        public void UpdatePatient(Patient patient)
        {

        }
        public void DeletePatient(int id)
        {

        }

    }
}
