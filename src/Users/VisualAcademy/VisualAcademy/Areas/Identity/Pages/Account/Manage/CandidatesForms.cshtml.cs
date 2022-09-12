// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VisualAcademy.Areas.Identity.Models;

namespace VisualAcademy.Areas.Identity.Pages.Account.Manage
{
    public class CandidatesFormsModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public CandidatesFormsModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }


            //[Required]
            [StringLength(50)]
            public string? FirstName { get; set; }

            //[Required]
            [StringLength(50)]
            public string? LastName { get; set; }

            public string? Timezone { get; set; }

            // TODO: 
            // Full Middle Name
            [StringLength(35)]
            public string? MiddleName { get; set; }

            // Suffix
            public string? NameSuffix { get; set; }

            // Alias(es): (oral or written)
            public string? AliasNames { get; set; }

            public string? SSN { get; set; }

            // Street
            [StringLength(70)]
            public string? Address { get; set; }

            [StringLength(70)]
            public string? City { get; set; }

            [StringLength(2)]
            public string? State { get; set; }

            // Zip 
            [DataType(DataType.PostalCode)]
            [StringLength(35)]
            public string? PostalCode { get; set; }

            // county
            public string? County { get; set; }

            // Telephone Number (Primary)
            [DataType(DataType.PhoneNumber)]
            [StringLength(35)]
            public string? PrimaryPhone { get; set; }

            // Telephone Number (Secondary)
            [DataType(DataType.PhoneNumber)]
            [StringLength(35)]
            public string? SecondaryPhone { get; set; }

            // Telephone Number (Work)
            //work_phone
            public string? WorkPhone { get; set; }


            // Email Address
            [DataType(DataType.EmailAddress)]
            [StringLength(254)]
            public string? PersonalEmail { get; set; }

            // home_phone
            public string? HomePhone { get; set; }

            // mobile_phone
            public string? MobilePhone { get; set; }

            // Date of Birth
            public string? DOB { get; set; }

            // Age: age
            public int? Age { get; set; }

            [StringLength(35)]
            public string? Gender { get; set; } // Male, Female 

            #region Birth Place
            [StringLength(70)]
            public string? BirthCity { get; set; }

            [StringLength(2)]
            public string? BirthState { get; set; }

            // birth_county
            public string? BirthCounty { get; set; }

            [StringLength(70)]
            public string? BirthCountry { get; set; }
            #endregion

            #region Driver's License
            // Driver's License Number: driver_license_number
            [StringLength(35)]
            public string? DriverLicenseNumber { get; set; }

            // State Issued: driver_license_state
            [StringLength(2)]
            public string? DriverLicenseState { get; set; }

            // Expiration Date: driver_license_expiration
            public DateTime? DriverLicenseExpiration { get; set; }
            #endregion

            public string? Photo { get; set; }

            [StringLength(35)]
            public string? LicenseNumber { get; set; }

            public string? OfficeAddress { get; set; }

            // office_city
            public string? OfficeCity { get; set; }

            // office_state
            public string? OfficeState { get; set; }

            // work_fax
            public string? WorkFax { get; set; }

            public string? BirthPlace { get; set; }

            // us_citizen
            public string? UsCitizen { get; set; }

            // marital_status
            public string? MaritalStatus { get; set; }

            // eye_color
            public string? EyeColor { get; set; }

            // hair_color
            public string? HairColor { get; set; }

            public string? Height { get; set; }
            public string? HeightFeet { get; set; }
            public string? HeightInches { get; set; }

            // business_structure
            public string? BusinessStructure { get; set; }

            // business_structure_other
            public string? BusinessStructureOther { get; set; }

            // weight
            public string? Weight { get; set; }

            // physical_marks
            public string? PhysicalMarks { get; set; }

        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                Age = user.Age,
                AliasNames = user.AliasNames,
                BirthCity = user.BirthCity,
                BirthCountry = user.BirthCountry,
                BirthCounty = user.BirthCounty,
                BirthPlace = user.BirthPlace,
                BirthState = user.BirthState,
                BusinessStructure = user.BusinessStructure,
                BusinessStructureOther = user.BusinessStructureOther,
                City = user.City,
                County = user.County,
                DOB = user.DOB,
                DriverLicenseExpiration = user.DriverLicenseExpiration,
                DriverLicenseNumber = user.DriverLicenseNumber,
                DriverLicenseState = user.DriverLicenseState,
                EyeColor = user.EyeColor,
                Gender = user.Gender,
                HairColor = user.HairColor,
                Height = user.Height,
                HeightFeet = user.HeightFeet,
                HeightInches = user.HeightInches,
                HomePhone = user.HomePhone,
                LicenseNumber = user.LicenseNumber,
                MaritalStatus = user.MaritalStatus,
                MiddleName = user.MiddleName,
                MobilePhone = user.MobilePhone,
                NameSuffix = user.NameSuffix,
                OfficeAddress = user.OfficeAddress,
                OfficeCity = user.OfficeCity,
                OfficeState = user.OfficeState,
                PersonalEmail = user.PersonalEmail,
                Photo = user.Photo,
                PhysicalMarks = user.PhysicalMarks,
                PostalCode = user.PostalCode,
                PrimaryPhone = user.PrimaryPhone,
                SecondaryPhone = user.SecondaryPhone,
                SSN = user.SSN,
                State = user.State,
                Timezone = user.Timezone,
                UsCitizen = user.UsCitizen,
                Weight = user.Weight,
                WorkFax = user.WorkFax,
                WorkPhone = user.WorkPhone                
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            // 데이터 업데이트
            if (Input.FirstName is not null)
            {
                user.FirstName = Input.FirstName;
                user.LastName = Input.LastName;
                user.Address = Input.Address;
                user.Age = Input.Age;
                user.AliasNames = Input.AliasNames;
                user.BirthCity = Input.BirthCity;
                user.BirthCountry = Input.BirthCountry;
                user.BirthCounty = Input.BirthCounty;
                user.BirthPlace = Input.BirthPlace;
                user.BirthState = Input.BirthState;
                user.BusinessStructure = Input.BusinessStructure;
                user.BusinessStructureOther = Input.BusinessStructureOther;
                user.City = Input.City;
                user.County = Input.County;
                user.DOB = Input.DOB;
                user.DriverLicenseExpiration = Input.DriverLicenseExpiration;
                user.DriverLicenseNumber = Input.DriverLicenseNumber;
                user.DriverLicenseState = Input.DriverLicenseState;
                user.EyeColor = Input.EyeColor;
                user.Gender = Input.Gender;
                user.HairColor = Input.HairColor;
                user.Height = Input.Height;
                user.HeightFeet = Input.HeightFeet;
                user.HeightInches = Input.HeightInches;
                user.HomePhone = Input.HomePhone;
                user.LicenseNumber = Input.LicenseNumber;
                user.MaritalStatus = Input.MaritalStatus;
                user.MiddleName = Input.MiddleName;
                user.MobilePhone = Input.MobilePhone;
                user.NameSuffix = Input.NameSuffix;
                user.OfficeAddress = Input.OfficeAddress;
                user.OfficeCity = Input.OfficeCity;
                user.OfficeState = Input.OfficeState;
                user.PersonalEmail = Input.PersonalEmail;
                user.PhoneNumber = Input.PhoneNumber;
                user.Photo = Input.Photo;
                user.PhysicalMarks = Input.PhysicalMarks;
                user.PostalCode = Input.PostalCode;
                user.PrimaryPhone = Input.PrimaryPhone;
                user.SecondaryPhone = Input.SecondaryPhone;
                user.SSN = Input.SSN;
                user.State = Input.State;
                user.Timezone = Input.Timezone;
                user.UsCitizen = Input.UsCitizen;
                user.Weight = Input.Weight;
                user.WorkFax = Input.WorkFax;
                user.WorkPhone = Input.WorkPhone;
            }

            await _userManager.UpdateAsync(user); // Update

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
