﻿using ClinicBookingSystem_DataAccessObject;
using ClinicBookingSystem_DataAcessObject.DBContext;
using ClinicBookingSystem_Repository.BaseRepositories;
using ClinicBookingSystem_Repository.IRepositories;

namespace ClinicBookingSystem_Repository.Repositories;

public class UnitOfWork : BaseUnitOfWork, IUnitOfWork
{
    private readonly ClinicBookingSystemContext _dbContext;
    private readonly IUserRepository _userRepository;
    private readonly ISlotRepository _slotRepository;
    private readonly IApplicationRepository _applicationRepository;
    private readonly IDentistRepository _dentistRepository;
    private readonly IStaffRepository _staffRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly ITokenRepository _tokenRepository;
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IBillingRepository _billingRepository;
    private readonly IClaimRepository _claimRepository;
    private readonly IClinicRepository _clinicRepository;
    private readonly IMedicalRecordRepository _medicalRecordRepository;
    private readonly IMedicineRepository _medicineRepository;
    private readonly IUserProfileRepository _userProfileRepository;
    private readonly IResultRepository _resultRepository;
    private readonly IServiceRepository _serviceRepository;
    private readonly ISpecificationRepository _specificationRepository;
    private readonly ITransactionRepository _transactionRepository;
    private readonly ISalaryRepository _salaryRepository;
    private readonly IClinicOwnerRepository _clinicOwnerRepository;
    private readonly IAppointmentBusinessServiceRepository _appointmentBusinessServiceRepository;
    private readonly IMeetingRepository _meetingRepository;
    private readonly INoteRepository _noteRepository;
    public UnitOfWork(ClinicBookingSystemContext dbContext,
        IApplicationRepository applicationRepository,
        IAppointmentRepository appointmentRepository,
        IBillingRepository billingRepository,
        IClaimRepository claimRepository,
        IClinicRepository clinicRepository,
        ICustomerRepository customerRepository,
        IDentistRepository dentistRepository,
        IMedicalRecordRepository medicalRecordRepository,
        IMedicineRepository medicineRepository,
        IUserProfileRepository userProfileRepository,
        IResultRepository resultRepository,
        IRoleRepository roleRepository,
        ISalaryRepository salaryRepository,
        IServiceRepository serviceRepository,
        ISlotRepository slotRepository,
        ISpecificationRepository specificationRepository,
        IStaffRepository staffRepository,
        ITokenRepository tokenRepository,
        ITransactionRepository transactionRepository,
        IUserRepository userRepository,
        IClinicOwnerRepository clinicOwnerRepository,
        IAppointmentBusinessServiceRepository appointmentBusinessServiceRepository,
        IMeetingRepository meetingRepository,
        INoteRepository noteRepository
        ) : base(dbContext) 
    {
        _dbContext = dbContext;
        _userRepository = userRepository;
        _dentistRepository = dentistRepository;
        _roleRepository = roleRepository;
        _staffRepository = staffRepository;
        _applicationRepository = applicationRepository;
        _customerRepository = customerRepository;
        _tokenRepository = tokenRepository;
        _slotRepository = slotRepository;
        _appointmentRepository = appointmentRepository;
        _billingRepository = billingRepository;
        _claimRepository = claimRepository;
        _clinicRepository = clinicRepository;
        _medicalRecordRepository = medicalRecordRepository;
        _medicineRepository = medicineRepository;
        _userProfileRepository = userProfileRepository;
        _resultRepository = resultRepository;
        _serviceRepository = serviceRepository;
        _specificationRepository = specificationRepository;
        _transactionRepository = transactionRepository;
        _salaryRepository = salaryRepository;
        _clinicOwnerRepository = clinicOwnerRepository;
        _appointmentBusinessServiceRepository = appointmentBusinessServiceRepository;
        _meetingRepository = meetingRepository;
        _noteRepository = noteRepository;
    }
    public IApplicationRepository ApplicationRepository => _applicationRepository;
    public IAppointmentRepository AppointmentRepository => _appointmentRepository;
    public IBillingRepository BillingRepository => _billingRepository;
    public IClaimRepository ClaimRepository => _claimRepository;
    public IClinicRepository ClinicRepository => _clinicRepository;
    public ICustomerRepository CustomerRepository => _customerRepository;
    public IDentistRepository DentistRepository => _dentistRepository;
    public IMedicalRecordRepository MedicalRecordRepository => _medicalRecordRepository;
    public IMedicineRepository MedicineRepository => _medicineRepository;
    public IUserProfileRepository UserProfileRepository => _userProfileRepository;
    public IResultRepository ResultRepository => _resultRepository;
    public IRoleRepository RoleRepository => _roleRepository;
    public ISalaryRepository SalaryRepository => _salaryRepository;
    public IServiceRepository ServiceRepository => _serviceRepository;
    public ISlotRepository SlotRepository => _slotRepository;
    public ISpecificationRepository SpecificationRepository => _specificationRepository;
    public IStaffRepository StaffRepository => _staffRepository;
    public ITokenRepository TokenRepository => _tokenRepository;
    public ITransactionRepository TransactionRepository => _transactionRepository;
    public IUserRepository UserRepository => _userRepository;
    public IClinicOwnerRepository ClinicOwnerRepository => _clinicOwnerRepository;
    public IAppointmentBusinessServiceRepository AppointmentBusinessServiceRepository => _appointmentBusinessServiceRepository;
    public IMeetingRepository MeetingRepository => _meetingRepository;
    public INoteRepository NoteRepository => _noteRepository;
}