﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gordon360.Models;
using Gordon360.Models.ViewModels;
using Gordon360.Repositories;
using Gordon360.Exceptions.CustomExceptions;
using Gordon360.Static.Names;

namespace Gordon360.Services
{
    public class ProfileService : IProfileService
    {
        private IUnitOfWork _unitOfWork;

        public ProfileService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public StudentProfileViewModel GetStudentProfileByUsername(string username)
        {
            var query = _unitOfWork.StudentTempRepository.FirstOrDefault(x => x.EmailUserName == username);
            if (query == null)
            {
                return null;
            }
            StudentProfileViewModel result = query; // Implicit conversion happening here, see ViewModels.
            return result;
        }

        public FacultyStaffProfileViewModel GetFacultyStaffProfileByUsername(string username)
        {
            var query = _unitOfWork.FacultyStaffRepository.FirstOrDefault(x => x.EmailUserName == username);
            if (query == null)
            {
                return null;
            }
            FacultyStaffProfileViewModel result = query; // Implicit conversion happening here, see ViewModels.
            return result;
        }

        public AlumniProfileViewModel GetAlumniProfileByUsername(string username)
        {
            var query = _unitOfWork.AlumniRepository.FirstOrDefault(x => x.EmailUserName == username);
            if (query == null)
            {
                return null;
            }
            AlumniProfileViewModel result = query; // Implicit conversion happening here, see ViewModels.
            return result;
        }

        /// <summary>
        /// Fetches a single profile whose username matches the username provided as an argument
        /// </summary>
        /// <param name="username">The username</param>
        /// <returns>ProfileViewModel if found, null if not found</returns>
        public ProfileCustomViewModel GetCustomUserInfo(string username)
        {
            var query = _unitOfWork.ProfileCustomRepository.GetByUsername(username);
            if (query == null)
            {
                throw new ResourceNotFoundException() { ExceptionMessage = "The Profile was not found." };
            }
            ProfileCustomViewModel result = query;
            return result;
        }


        /// <summary>
        /// Sets the path for the profile image.
        /// </summary>
        /// <param name="username">The username</param>
        /// <param name="path"></param>
        public void UpdateProfileImage(string username, string path)
        {
            var original = _unitOfWork.ProfileCustomRepository.GetByUsername(username);

            if (original == null)
            {
                throw new ResourceNotFoundException() { ExceptionMessage = "The profile was not found." };
            }

            original.Img_Path = path;

            _unitOfWork.Save();
        }

        /// <summary>
        /// Sets the path for the profile links.
        /// </summary>
        /// <param name="username">The username</param>
        /// <param name="type"></param>
        /// <param name="path"></param>
        public void UpdateProfileLink(string username, string type, PROFILE_IMAGE path)
        {
            var original = _unitOfWork.ProfileCustomRepository.GetByUsername(username);

            if (original == null)
            {
                throw new ResourceNotFoundException() { ExceptionMessage = "The profile was not found." };
            }

            switch (type)
            {
                case "facebook":
                    original.facebook = path.facebook;
                    break;

                case "twitter":
                    original.twitter = path.twitter;
                    break;

                case "instagram":
                    original.instagram = path.instagram;
                    break;

                case "linkedin":
                    original.linkedin = path.linkedin;
                    break;
            }

            _unitOfWork.Save();
        }

        /// <summary>
        /// Reset the path for the profile image
        /// </summary>
        /// <param name="username">The username</param>
        public void ResetProfileImage(string username)
        {
            var original = _unitOfWork.ProfileCustomRepository.GetByUsername(username);

            if (original == null)
            {
                throw new ResourceNotFoundException() { ExceptionMessage = "The profile was not found." };
            }

            original.Img_Path = Defaults.DEFAULT_PROFILE_IMAGE_PATH;

            _unitOfWork.Save();
        }

        /// <summary>
        /// privacy setting of mobile phone.
        /// </summary>
        /// <param name="username">The username</param>
        /// <param name="p"></param>
        public void UpdateMobilePrivacy(string username, bool p)
        {
            var original = _unitOfWork.StudentTempRepository.FirstOrDefault(x => x.EmailUserName == username);

            if (original == null)
            {
                throw new ResourceNotFoundException() { ExceptionMessage = "The profile was not found." };
            }
            original.IsMobilePhonePrivate = p;
            _unitOfWork.Save();
        }
        /// <summary>
        /// privacy setting user profile photo.
        /// </summary>
        /// <param name="username">The username</param>
        /// <param name="p"></param>
        public void UpdateImagePrivacy(string username, bool p)
        {
            var original = _unitOfWork.ProfileCustomRepository.FirstOrDefault(x => x.username == username);

            if (original == null)
            {
                throw new ResourceNotFoundException() { ExceptionMessage = "The profile was not found." };
            }
            original.show_img = p;
            _unitOfWork.Save();
        }

    }
}