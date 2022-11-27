

create table SymptomsTable(symptom_id int identity(0,1) primary key, 
symptom_name varchar(50));

create table IllnessTable(
illness_id int identity(0,1) primary key, 
illness_name varchar(50));

create table IllnessSymptomsTable(illsymp_id int identity(0,1) primary key, 
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


-- Query to get all illness - symptoms relations
select c.illness_name, b.symptom_name 
from IllnessSymptomsTable a 
INNER JOIN SymptomsTable b ON a.symptom_id = b.symptom_id 
INNER JOIN IllnessTable c ON a.illness_id = c.illness_id;

-- Query to get an illlness' symptoms
select a.illness_name, c.symptom_name 
from IllnessTable a 
inner join IllnessSymptomsTable b on b.illness_id = a.illness_id 
inner join SymptomsTable c on b.symptom_id = c.symptom_id 
WHERE a.illness_id = 0;

-- Query to get all illnesses with specific symptoms
select a.symptom_name, c.illness_name 
from SymptomsTable a 
inner join IllnessSymptomsTable b on b.symptom_id = a.symptom_id 
inner join IllnessTable c on b.illness_id = c.illness_id 
WHERE a.symptom_id = 0;

-- Query to get number of symptoms each illness have
select a.illness_name, COUNT(b.symptom_id) as 'num of symptoms' 
from IllnessTable a 
inner join IllnessSymptomsTable b on a.illness_id = b.illness_id 
group by illness_name;