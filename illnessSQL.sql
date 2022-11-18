create database IllnessDb;

create table SymptomsTable(symptom_id int identity(1,1) primary key, 
symptom_name varchar(50));

create table IllnessTable(
illness_id int identity(1,1) primary key, 
illness_name varchar(50), 
symptom_id int foreign key references SymptomsTable(symptom_id));


insert into SymptomsTable values ('Headache'), ('Runny Nose'), ('Weakness in the body'), ('Cough');
insert into IllnessTable values ('Cold', 1), ('Cold', 2), ('Cold', 4);

insert into SymptomsTable values ('Difficulty Breathing'), ('Stomach Pains');
insert into IllnessTable values ('Coronavirus', 1), ('Coronavirus', 3), ('Coronavirus', 4), 
('Coronavirus', 5), ('Diarrhea', 6) ;

select * from SymptomsTable;
select * from IllnessTable;

select symptom_name from SymptomsTable where symptom_id = 1 ;

select 
i.illness_name as 'Illness Name', 
s.symptom_name as 'Symptom Name'

from IllnessTable i
inner join SymptomsTable s 
on i.symptom_id = s.symptom_id
--where i.illness_name = 'Cold';
where s.symptom_name = 'Cough';

sp_helptext findSymptomViaID

declare @symptom_id as  int  
set @symptom_id = 1
 select symptom_name  
 from SymptomsTable where symptom_id = @symptom_id