select 
i.illness_id as 'Illness ID',
i.illness_name as 'Illness Name',
s.symptom_name as 'Symptom Name'
from IllnessTable i
inner join SymptomsTable s
on i.symptom_id = s.symptom_id
where s.symptom_name = 'Headache';

select * from IllnessTable;
select * from SymptomsTable