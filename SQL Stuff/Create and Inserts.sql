create table SymptomsTable(
symptom_id int identity(0,1) primary key, 
symptom_name varchar(50)
);

create table IllnessTable(
illness_id int identity(0,1) primary key,
illness_name varchar(50),
illness_virality int,
illness_description varchar(5000)
);

create table IllnessSymptomsTable(
illsymp_id int identity(0,1) primary key, 
illness_id int foreign key references IllnessTable(illness_id),
symptom_id int foreign key references SymptomsTable(symptom_id));

-- Patient Info
CREATE TABLE SexTable(
sex_id tinyint primary key, 
sex_name varchar(30)
);

CREATE TABLE CourseTable(
course_id smallint identity(0,1) primary key, 
course_name varchar(64)
);

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
