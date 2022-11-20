

create table SymptomsTable(symptom_id int identity(1,1) primary key, 
symptom_name varchar(50));

create table IllnessTable(
illness_id int identity(1,1) primary key, 
illness_name varchar(50));

create table IllnessSymptomsTable(illsymp_id int identity(1,1) primary key, 
illness_id int foreign key references IllnessTable(illness_id),
symptom_id int foreign key references SymptomsTable(symptom_id));

insert into SymptomsTable values ('Cough'), ('Fever'), ('Runny Nose'), ('Stuffy Nose'),
('Sore Throat'), ('Tiredness'), ('Loss of taste or smell'), ('Aches'), ('Diarrhoea'), 
('Rashes'), ('Irritated Eyes'), ('Shortness of Breath'), ('Confusion'), ('Chest Pain'), 
('Vomitting'), ('Headache'), ('Sneezing'), ('Post-nasal drip'), ('Watery eyes');

insert into IllnessTable values ('Cold'), ('Flu'), ('COVID-19');

insert into IllnessSymptomsTable values (0, 0), (0, 1), (0, 2), (0, 3), (0, 4), (0, 16), 
(0, 17), (0, 18), (1, 0), (1, 1), (1, 2), (1, 3), (1, 4), (1, 5), (1, 8), (1, 14), (1, 15), 
(2, 0), (2, 1), (2, 4), (2, 5), (2, 6), (2, 7), (2, 8), (2, 9), (2, 10), (2, 11), 
(2, 12), (2, 13), (2, 15);

select * from SymptomsTable;
select * from IllnessTable;
select * from IllnessSymptomsTable;

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