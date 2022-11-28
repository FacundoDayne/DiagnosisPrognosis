-- Procedure to add a new Patient
create proc AddPatient
@patient_lastname varchar(30), 
@patient_firstname varchar(30),
@patient_middlename varchar(30), 
@patient_age int, 
@patient_sex tinyint,
@patient_course smallint, 
@patient_contactnumber varchar(13), 
@patient_birthdate date,
@patient_allergies bit, 
@patient_consultation bit, 
@patient_checkup bit, 
@patient_medicalneeds bit
as
	insert into PatientTable values
	(
	@patient_lastname, 
	@patient_firstname,
	@patient_middlename, 
	@patient_age, 
	@patient_sex,
	@patient_course, 
	@patient_contactnumber, 
	@patient_birthdate,
	@patient_allergies, 
	@patient_consultation, 
	@patient_checkup, 
	@patient_medicalneeds
	);

-- Procedure to delete a Patient // Is broken atm
create proc DeletePatient
@patient_name varchar(100)
as
	delete from PatientTable where patient_name = @patient_name;

-- Procedure to get illness - symptom relations via symptom_name
create proc GetIllnessSymptomViaSymptomName
@symptom_name varchar(50)
as
	select 
	b.illness_name as 'Illness Name',
	c.symptom_name as 'Symptom Name'
	from IllnessSymptomsTable a 
	INNER JOIN IllnessTable b ON a.illness_id = b.illness_id
	INNER JOIN SymptomsTable c ON a.symptom_id = c.symptom_id 	
	where c.symptom_name = @symptom_name;
	-- example where c.symptom_name = 'Cough';

-- Procedure to get illness - symptom relations via illness_name
create proc GetIllnessSymptomViaIllnessName
@illness_name varchar(50)
as	
	select 
	b.illness_name as 'Illness Name',
	c.symptom_name as 'Symptom Name'
	from IllnessSymptomsTable a 
	INNER JOIN IllnessTable b ON a.illness_id = b.illness_id
	INNER JOIN SymptomsTable c ON a.symptom_id = c.symptom_id 	
	where b.illness_name = @illness_name;
	-- example: where b.illness_name = 'Common Cold';

-- Procedure to get number of symptoms each illness have

create proc GetIllnessNumberOfSymptoms
@illness_name varchar(50)
as
	select 
	a.illness_name as 'Illness Name',
	COUNT(b.symptom_id) as 'Number of Symptoms' 
	from IllnessTable a 
	inner join IllnessSymptomsTable b on a.illness_id = b.illness_id
	where a.illness_name = @illness_name
	-- example: where a.illness_name = 'Common Cold'
	group by illness_name;

-- Procedure to get Patient's Data DOESNT WORK ATM
create proc GetPatientViaName

declare
@fullname as varchar(100),
@allergies as varchar(3),
@consultation as varchar(3),
@checkup as varchar(3),
@medicalneeds as varchar(3)

if (select cast(patient_allergies as int)from PatientTable) = 1 set @allergies = 'Yes' else set @allergies = 'No'
if (select cast(patient_consultation as int)from PatientTable) = 1 set @consultation = 'Yes' else set	@consultation = 'No'
if (select cast(patient_checkup as int)from PatientTable) = 1 set @checkup = 'Yes' else set @checkup =	'No'
if (select cast(patient_medicalneeds as int)from PatientTable) = 1 set @medicalneeds = 'Yes' else set	@medicalneeds = 'No'	
select 
a.patient_lastname as 'Full Name',
a.patient_age as 'Age',
b.sex_name as 'Sex',
c.course_name as 'Course',
a.patient_contactnumber as 'Contact Number',
a.patient_birthdate as 'Birthday',
@allergies as 'Allergy Concerns',
@consultation as 'Consultation Concerns',
@checkup as 'Check up',
@medicalneeds as 'Medical Needs'
from PatientTable a
inner join SexTable b on a.patient_sex_id = b.sex_id
inner join CourseTable c on a.patient_course_id = c.course_id
--where 'Facundo, Dayne Santos'