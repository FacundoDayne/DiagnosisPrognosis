
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

create table PatientsTable(
patient_id int identity(0,1) primary key,
patient_name varchar(100), 
patient_age int,
patient_gender varchar(3),
patient_medical_concern varchar(20),
patient_birthday datetime, -- default date format is yyyy:mm:dd hh:mm:ss 
patient_allergies varchar(2)
);

create table IllnessSymptomsTable(
illsymp_id int identity(0,1) primary key, 
illness_id int foreign key references IllnessTable(illness_id),
symptom_id int foreign key references SymptomsTable(symptom_id));

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

drop table IllnessSymptomsTable;
drop table IllnessTable;
drop table SymptomsTable;
drop table PatientsTable;

select * from SymptomsTable;
select * from IllnessTable;
select * from IllnessSymptomsTable;
select * from PatientsTable;

-- 

-- Procedure to add a new Patient
create proc AddPatient
@patient_name varchar(100), 
@patient_age int,
@patient_gender varchar(3)
as
	insert into PatientsTable values
	(patient_name, patient_age, patient_gender);

-- Procedure to delete a Patient
create proc DeletePatient
@patient_name varchar(100)
as
	delete from PatientsTable where patient_name = @patient_name;

-- Procedure to get illness - symptom relations via symptom_name
create proc GetIllnessSymptomViaSymptomName
@symptom_name varchar(50)
as
	select c.illness_name, b.symptom_name 
	from IllnessSymptomsTable a 
	INNER JOIN SymptomsTable b ON a.symptom_id = b.symptom_id 
	INNER JOIN IllnessTable c ON a.illness_id = c.illness_id
	where b.symptom_name = @symptom_name;
	-- example: where b.symptom_name = 'Cough';

-- Procedure to get illness - symptom relations via illness_name
create proc GetIllnessSymptomViaIllnessName
@illness_name varchar(50)
as
	select 
	a.illness_name as 'Illness Name',
	c.symptom_name as 'Symptom Name'
	from IllnessTable a 
	inner join IllnessSymptomsTable b on b.illness_id = a.illness_id 
	inner join SymptomsTable c on b.symptom_id = c.symptom_id 
	where a.illness_name = @illness_name;
	-- example: where a.illness_name = 'Cold';

-- Query to get all illnesses with specific symptoms

@
as
	select 
	c.illness_name as 'Illness Name',
	a.symptom_name as 'Symptom Name'
	from SymptomsTable a 
	inner join IllnessSymptomsTable b on b.symptom_id = a.symptom_id 
	inner join IllnessTable c on b.illness_id = c.illness_id 
	--WHERE a.symptom_id = 0;
	where a.symptom_name = 'Cough';

-- Query to get number of symptoms each illness have
select a.illness_name, COUNT(b.symptom_id) as 'num of symptoms' 
from IllnessTable a 
inner join IllnessSymptomsTable b on a.illness_id = b.illness_id 
group by illness_name;