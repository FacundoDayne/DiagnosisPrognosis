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

-- Procedure to get Patient's Data via Name
create proc GetPatientViaName
@patient_name varchar(50)
as
	select
	a.patient_studentnumber as 'Student Number',
	a.patient_lastname + ', ' + a.patient_firstname + ' ' + a.patient_middlename as 'Full Name',
	a.patient_age as 'Age',
	b.sex_name as 'Sex',
	c.course_name as 'Course',
	a.patient_contactnumber as 'Contact Number',
	a.patient_birthdate as 'Birthday',
	case 
		when cast(a.patient_allergies as int) = 1 then 'Yes'
		else 'No'
	end as 'Allergy Concerns',
	case 
		when cast(a.patient_consultation as int) = 1 then 'Yes'
		else 'No'
	end as 'Consultation Concerns',
	case 
		when cast(a.patient_checkup as int) = 1 then 'Yes'
		else 'No'
	end as 'Check up',
	case 
		when cast(a.patient_medicalneeds as int) = 1 then 'Yes'
		else 'No'
	end as 'Medical Needs'
	from PatientTable a
	inner join SexTable b on a.patient_sex_id = b.sex_id
	inner join CourseTable c on a.patient_course_id = c.course_id
	where (a.patient_lastname + ', ' + a.patient_firstname + ' ' + a.patient_middlename) = @patient_name;

-- Procedure to get Patient's Data via Student Number
create proc GetPatientViaStudentNumber
@patient_studentnumber int
as
	select
	a.patient_studentnumber as 'Student Number',
	a.patient_lastname + ', ' + a.patient_firstname + ' ' + a.patient_middlename as 'Full Name',
	a.patient_age as 'Age',
	b.sex_name as 'Sex',
	c.course_name as 'Course',
	a.patient_contactnumber as 'Contact Number',
	a.patient_birthdate as 'Birthday',
	case 
		when cast(a.patient_allergies as int) = 1 then 'Yes'
		else 'No'
	end as 'Allergy Concerns',
	case 
		when cast(a.patient_consultation as int) = 1 then 'Yes'
		else 'No'
	end as 'Consultation Concerns',
	case 
		when cast(a.patient_checkup as int) = 1 then 'Yes'
		else 'No'
	end as 'Check up',
	case 
		when cast(a.patient_medicalneeds as int) = 1 then 'Yes'
		else 'No'
	end as 'Medical Needs'
	from PatientTable a
	inner join SexTable b on a.patient_sex_id = b.sex_id
	inner join CourseTable c on a.patient_course_id = c.course_id
	where a.patient_studentnumber = @patient_studentnumber;

-- Procedure to delete a patient via Name
create proc DeletePatientViaName
@patient_name varchar(50)
as
	delete from PatientTable 
	where (patient_lastname + ', ' + patient_firstname + ' ' + patient_middlename) = @patient_name;

-- Procedure to delete a patient via Student Number
create proc DeletePatientViaStudentNumber
@patient_studentnumber int
as
	delete from PatientTable 
	where patient_studentnumber = @patient_studentnumber;