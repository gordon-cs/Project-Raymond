﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CCT_App.Models;
using CCT_App.Repositories;

namespace CCT_App.Services
{
    public class StudentService : IStudentService
    {
        private IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Student Add(Student student)
        {
            throw new NotImplementedException();
        }

        public Student Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Student Get(string id)
        {
            var result = _unitOfWork.StudentRepository.GetById(id);
            return result;
        }

        public IEnumerable<ACT_CLUB_DEF> GetActivitiesForStudent(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAll()
        {
            var result = _unitOfWork.StudentRepository.GetAll();
            return result;
        }

        public Student Update(string id, Student student)
        {
            throw new NotImplementedException();
        }
    }
}