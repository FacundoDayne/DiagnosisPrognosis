if OBJECT_ID(N'dbo.SymptomsTable', N'U') is null
	create table SymptomsTable(
	symptom_id int identity(0,1) primary key, 
	symptom_name varchar(50)
	);

if OBJECT_ID(N'dbo.IllnessTable', N'U') is null
	create table IllnessTable(
	illness_id int identity(0,1) primary key,
	illness_name varchar(50),
	illness_virality int,
	illness_description varchar(5000)
	);

if OBJECT_ID(N'dbo.IllnessSymptomsTable', N'U') is null
	create table IllnessSymptomsTable(
	illsymp_id int identity(0,1) primary key, 
	illness_id int foreign key references IllnessTable(illness_id),
	symptom_id int foreign key references SymptomsTable(symptom_id));

-- Patient Info
if OBJECT_ID(N'dbo.SexTable', N'U') is null
	CREATE TABLE SexTable(
	sex_id tinyint primary key, 
	sex_name varchar(30)
	);

if OBJECT_ID(N'dbo.CourseTable', N'U') is null
	CREATE TABLE CourseTable(
	course_id smallint identity(0,1) primary key, 
	course_name varchar(64)
	);

if OBJECT_ID(N'dbo.PatientTable', N'U') is null
	CREATE TABLE PatientTable(
	patient_id int identity(0,1) primary key, 
	patient_lastname varchar(30), 
	patient_firstname varchar(30),
	patient_middlename varchar(30), 
	patient_age int, 
	patient_sex_id tinyint foreign key references SexTable(sex_id),
	patient_course_id smallint foreign key references CourseTable(course_id), 
	patient_contactnumber varchar(13), 
	patient_birthdate date,
	patient_allergies bit, 
	patient_consultation bit, 
	patient_checkup bit, 
	patient_medicalneeds bit
	);
-- as per ISO/IEC 5218 standard, sex is designated as tintyint. 0 = not known, 1 = male, 2 = female, 9 = not applicable

insert into SymptomsTable values 
('Cough'), 
('Fever'), 
('Runny Nose'), 
('Stuffed Nose'),
('Sore Throat'), 
('Tiredness'), 
('Loss of taste or smell'), 
('Aches'), 
('Diarrhea'), 
('Rashes'), 
('Irritated Eyes'), 
('Shortness of Breath'), 
('Confusion'), 
('Chest Pain'), 
('Vomiting'), 
('Headache'), 
('Sneezing'), 
('Post-nasal drip'), 
('Watery eyes');

insert into IllnessTable values 
('Common Cold', 5, 'The common cold is a viral infection of your nose and throat (upper respiratory tract).'),
('Influenza', 4, 'Flu (influenza) is an infection of the nose, throat and lungs, which are part of the respiratory system. Influenza is commonly called the flu, but it''s not the same as stomach "flu" viruses that cause diarrhea and vomiting'), 
('Coronavirus', 3, 'Coronaviruses are a family of viruses that can cause illnesses such as the common cold, severe acute respiratory syndrome (SARS) and Middle East respiratory syndrome (MERS). In 2019, a new coronavirus was identified as the cause of a disease outbreak that originated in China'
);

insert into IllnessSymptomsTable values 
(0, 0), 
(0, 1), 
(0, 2), 
(0, 3), 
(0, 4), 
(0, 16), 
(0, 17), 
(0, 18), 
(1, 0), 
(1, 1), 
(1, 2), 
(1, 3), 
(1, 4), 
(1, 5), 
(1, 8), 
(1, 14), 
(1, 15), 
(2, 0), 
(2, 1), 
(2, 4), 
(2, 5), 
(2, 6), 
(2, 7), 
(2, 8), 
(2, 9), 
(2, 10), 
(2, 11), 
(2, 12), 
(2, 13), 
(2, 15);

INSERT INTO SexTable values 
(0, 'Not Known'), 
(1, 'Male'),
(2, 'Female'), 
(9, 'Not Applicable');

INSERT INTO CourseTable values 
('BS in Information Technology')

insert into PatientTable values
--('Facundo', 'Dayne', 'Santos', 22, 1, 0, 09457719540, '2000-11-19', 1, 1, 1,0);
('Facundo', 'Kyle', 'Santos', 20, 2, 0, 09, '2000-10-10', 0,0,0,1);

CREATE TABLE DoctorTable
(
	doctor_id int identity(0,1) primary key, 
	doctor_lastname varchar(30), 
	doctor_firstname varchar(30),
	doctor_middlename varchar(30)
);

CREATE TABLE AdminTable
(
	admin_id int identity(0,1) primary key, 
	admin_lastname varchar(30), 
	admin_firstname varchar(30),
	admin_middlename varchar(30)
);

CREATE TABLE UserType 
	(
	type_id int primary key identity(0,1), 
	descr varchar(64) not null
);

CREATE TABLE UserTable 
	(
	id int primary key identity(0,1), 
	username varchar (64) not null UNIQUE, 
	password varchar(512) not null, 
	usertype int not null foreign key references UserType(type_id), 
	patientID int null foreign key references PatientTable(patient_id), 
	doctorID int null foreign key references DoctorTable(doctor_id), 
	adminID int null foreign key references AdminTable(admin_id)
);

insert into UserType values ('Patient'), ('Doctor'), ('Admin');




insert into DoctorTable values ('Doctor', 'John', 'Medical');
insert into AdminTable values ('Admin', 'John', 'Superuser');

insert into UserTable values 
('facundodayne', 'password123', 0, 0, null, null), 
('facundokyle', 'password123', 0, 1, null, null), 
('riverajuan', 'password123', 0, 2, null, null), 
('vonmackensen', 'password123', 0, 3, null, null),
('johndoctor', 'password123', 1, null, 0, null),
('johnadmin', 'password123', 2, null, null, 0)

CREATE TABLE PatientSymptomsTable(
	PatientSymptomPairKey varchar(21) primary key not null,
	PatientID int foreign key references PatientTable(patient_id) not null, 
	SymptomID int foreign key references SymptomsTable(symptom_id) not null, 
);

CREATE TABLE PatientDiagnosisTable(
	PatientSymptomPairKey varchar(21) primary key not null,
	PatientID int foreign key references PatientTable(patient_id) not null,
	IllnessID int foreign key references IllnessTable(illness_id) not null,
	numOfMatchSymptoms int not null,
	numOfSymptoms int not null,
	isConfirmed bit not null
)

CREATE TABLE PatientSymptomsTable(
	PatientSymptomPairKey varchar(21) primary key not null,
	PatientID int foreign key references PatientTable(patient_id) not null, 
	SymptomID int foreign key references SymptomsTable(symptom_id) not null, 
);
drop table PatientDiagnosisTable;
CREATE TABLE PatientDiagnosisTable(
	PatientSymptomPairKey varchar(21) primary key not null,
	PatientID int foreign key references PatientTable(patient_id) not null,
	IllnessID int foreign key references IllnessTable(illness_id) not null
)